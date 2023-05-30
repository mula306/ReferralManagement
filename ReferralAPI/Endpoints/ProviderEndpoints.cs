using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using ReferralAPI.Data;
using ReferralAPI.Model;

namespace ReferralAPI.Endpoints;

public static class ProviderEndpoints
{
    public static void MapProviderEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Provider").WithTags(nameof(Provider));

        group.MapGet("/", async (ReferralAPIContext db) =>
        {
            return await db.Provider.ToListAsync();
        })
        .WithName("GetAllProviders")
        .WithOpenApi();

        group.MapGet("/{providerid}", async Task<Results<Ok<Provider>, NotFound>> (int providerid, ReferralAPIContext db) =>
        {
            return await db.Provider.AsNoTracking()
                .FirstOrDefaultAsync(model => model.ProviderId == providerid)
                is Provider model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetProviderById")
        .WithOpenApi();

        group.MapPut("/{providerid}", async Task<Results<Ok, NotFound>> (int providerid, Provider provider, ReferralAPIContext db) =>
        {
            var affected = await db.Provider
                .Where(model => model.ProviderId == providerid)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.ProviderId, provider.ProviderId)
                  .SetProperty(m => m.FirstName, provider.FirstName)
                  .SetProperty(m => m.LastName, provider.LastName)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateProvider")
        .WithOpenApi();

        group.MapPost("/", async (Provider provider, ReferralAPIContext db) =>
        {
            db.Provider.Add(provider);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Provider/{provider.ProviderId}",provider);
        })
        .WithName("CreateProvider")
        .WithOpenApi();

        group.MapDelete("/{providerid}", async Task<Results<Ok, NotFound>> (int providerid, ReferralAPIContext db) =>
        {
            var affected = await db.Provider
                .Where(model => model.ProviderId == providerid)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteProvider")
        .WithOpenApi();
    }
}
