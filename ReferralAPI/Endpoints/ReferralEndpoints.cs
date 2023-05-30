using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using ReferralAPI.Data;
using ReferralAPI.Model;

namespace ReferralAPI.Endpoints;

public static class ReferralEndpoints
{
    public static void MapReferralEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Referral").WithTags(nameof(Referral));
        var group1 = routes.MapGroup("/api/DynamicReferral").WithTags(nameof(DynamicReferral));

        group.MapGet("/", async (ReferralAPIContext db) =>
        {
            return await db.Referral.ToListAsync();
        })
        .WithName("GetAllReferrals")
        .WithOpenApi();

        group.MapGet("/{referralid}", async Task<Results<Ok<Referral>, NotFound>> (int referralid, ReferralAPIContext db) =>
        {
            return await db.Referral.AsNoTracking()
                .FirstOrDefaultAsync(model => model.ReferralId == referralid)
                is Referral model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetReferralById")
        .WithOpenApi();

        group.MapPut("/{referralid}", async Task<Results<Ok, NotFound>> (int referralid, Referral referral, ReferralAPIContext db) =>
        {
            var affected = await db.Referral
                .Where(model => model.ReferralId == referralid)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.ReferralId, referral.ReferralId)
                  .SetProperty(m => m.PatientId, referral.PatientId)
                  .SetProperty(m => m.ProviderId, referral.ProviderId)
                  .SetProperty(m => m.ReferralDate, referral.ReferralDate)
                  .SetProperty(m => m.ReferralReason, referral.ReferralReason)
                  .SetProperty(m => m.Status, referral.Status)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateReferral")
        .WithOpenApi();

        group.MapPost("/", async (Referral referral, ReferralAPIContext db) =>
        {
            // Retrieve all providers with the given specialty

            if (referral.ProviderId == 0)
            {
                var providers = db.Provider.Where(p => p.SpecialtyId == referral.SpecailtyId);

                // Count the number of referrals for each provider
                var referralCounts = await providers.Select(p => new
                {
                    Provider = p,
                    ReferralCount = db.Referral.Count(r => r.ProviderId == p.ProviderId)
                }).ToListAsync();

                // Find the provider with the fewest referrals
                var providerWithFewestReferrals = referralCounts.OrderBy(rc => rc.ReferralCount).First().Provider;

                // Assign the provider to the referral
                referral.ProviderId = providerWithFewestReferrals.ProviderId;
            }
            // Add the referral to the database
            db.Referral.Add(referral);
            await db.SaveChangesAsync();

            return TypedResults.Created($"/api/Referral/{referral.ReferralId}", referral);
        })
        .WithName("CreateReferral")
        .WithOpenApi();

        group.MapDelete("/{referralid}", async Task<Results<Ok, NotFound>> (int referralid, ReferralAPIContext db) =>
        {
            var affected = await db.Referral
                .Where(model => model.ReferralId == referralid)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteReferral")
        .WithOpenApi();


    }

}
