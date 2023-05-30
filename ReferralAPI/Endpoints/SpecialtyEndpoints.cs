using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using ReferralAPI.Data;
using ReferralAPI.Model;

namespace ReferralAPI.Endpoints;

public static class SpecialtyEndpoints
{
    public static void MapSpecialtyEndpoints(this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Specialty").WithTags(nameof(Specialty));

        group.MapGet("/", async (ReferralAPIContext db) =>
        {
            return await db.Specialty.ToListAsync();
        })
        .WithName("GetAllSpecialtys")
        .WithOpenApi();

        group.MapGet("/{specialtyid}", async Task<Results<Ok<Specialty>, NotFound>> (int specialtyid, ReferralAPIContext db) =>
        {
            return await db.Specialty.AsNoTracking()
                .FirstOrDefaultAsync(model => model.SpecialtyId == specialtyid)
                is Specialty model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetSpecialtyById")
        .WithOpenApi();

        group.MapPut("/{specialtyid}", async Task<Results<Ok, NotFound>> (int specialtyid, Specialty specialty, ReferralAPIContext db) =>
        {
            var affected = await db.Specialty
                .Where(model => model.SpecialtyId == specialtyid)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.SpecialtyId, specialty.SpecialtyId)
                  .SetProperty(m => m.SpecialtyName, specialty.SpecialtyName)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateSpecialty")
        .WithOpenApi();

        group.MapPost("/", async (Specialty specialty, ReferralAPIContext db) =>
        {
            db.Specialty.Add(specialty);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Specialty/{specialty.SpecialtyId}", specialty);
        })
        .WithName("CreateSpecialty")
        .WithOpenApi();

        group.MapDelete("/{specialtyid}", async Task<Results<Ok, NotFound>> (int specialtyid, ReferralAPIContext db) =>
        {
            var affected = await db.Specialty
                .Where(model => model.SpecialtyId == specialtyid)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteSpecialty")
        .WithOpenApi();
    }
}
