using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using ReferralAPI.Data;
using ReferralAPI.Model;

namespace ReferralAPI.Endpoints;

public static class DynamicReferralEndpoints
{
    public static void MapDynamicReferralEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/DynamicReferral").WithTags(nameof(DynamicReferral));

        group.MapGet("/", async (ReferralAPIContext db) =>
        {
            return await db.DynamicReferral.ToListAsync();
        })
        .WithName("GetAllDynamicReferrals")
        .WithOpenApi();

        group.MapGet("/{dynamicreferralid}", async Task<Results<Ok<DynamicReferral>, NotFound>> (int dynamicreferralid, ReferralAPIContext db) =>
        {
            return await db.DynamicReferral.AsNoTracking()
                .FirstOrDefaultAsync(model => model.DynamicReferralId == dynamicreferralid)
                is DynamicReferral model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetDynamicReferralById")
        .WithOpenApi();

        group.MapPut("/{dynamicreferralid}", async Task<Results<Ok, NotFound>> (int dynamicreferralid, DynamicReferral dynamicReferral, ReferralAPIContext db) =>
        {
            var affected = await db.DynamicReferral
                .Where(model => model.DynamicReferralId == dynamicreferralid)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.DynamicReferralId, dynamicReferral.DynamicReferralId)
                  .SetProperty(m => m.ReferralName, dynamicReferral.ReferralName)
                  .SetProperty(m => m.ReferralJson, dynamicReferral.ReferralJson)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateDynamicReferral")
        .WithOpenApi();

        group.MapPost("/", async (DynamicReferral dynamicReferral, ReferralAPIContext db) =>
        {
            db.DynamicReferral.Add(dynamicReferral);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/DynamicReferral/{dynamicReferral.DynamicReferralId}",dynamicReferral);
        })
        .WithName("CreateDynamicReferral")
        .WithOpenApi();

        group.MapDelete("/{dynamicreferralid}", async Task<Results<Ok, NotFound>> (int dynamicreferralid, ReferralAPIContext db) =>
        {
            var affected = await db.DynamicReferral
                .Where(model => model.DynamicReferralId == dynamicreferralid)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteDynamicReferral")
        .WithOpenApi();
    }
}
