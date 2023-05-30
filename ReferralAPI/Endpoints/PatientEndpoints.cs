using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using ReferralAPI.Data;
using ReferralAPI.Model;

namespace ReferralAPI.Endpoints;

public static class PatientEndpoints
{
    public static void MapPatientEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Patient").WithTags(nameof(Patient));
        

        group.MapGet("/", async (ReferralAPIContext db) =>
        {
            return await db.Patient.ToListAsync();
        })
        .WithName("GetAllPatients")
        .WithOpenApi();

        
        group.MapGet("/{patientid}", async Task<Results<Ok<Patient>, NotFound>> (int patientid, ReferralAPIContext db) =>
        {
            return await db.Patient.AsNoTracking()
                .FirstOrDefaultAsync(model => model.PatientId == patientid)
                is Patient model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetPatientById")
        .WithOpenApi();

        group.MapPut("/{patientid}", async Task<Results<Ok, NotFound>> (int patientid, Patient patient, ReferralAPIContext db) =>
        {
            var affected = await db.Patient
                .Where(model => model.PatientId == patientid)
                .ExecuteUpdateAsync(setters => setters
                  .SetProperty(m => m.PatientId, patient.PatientId)
                  .SetProperty(m => m.FirstName, patient.FirstName)
                  .SetProperty(m => m.LastName, patient.LastName)
                  .SetProperty(m => m.DateOfBirth, patient.DateOfBirth)
                  .SetProperty(m => m.Address, patient.Address)
                  .SetProperty(m => m.Gender, patient.Gender)
                  .SetProperty(m => m.Phone, patient.Phone)
                  .SetProperty(m => m.Email, patient.Email)
                  .SetProperty(m => m.RegistrationDate, patient.RegistrationDate)
                );

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdatePatient")
        .WithOpenApi();

        group.MapPost("/", async (Patient patient, ReferralAPIContext db) =>
        {
            db.Patient.Add(patient);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Patient/{patient.PatientId}",patient);
        })
        .WithName("CreatePatient")
        .WithOpenApi();

        group.MapDelete("/{patientid}", async Task<Results<Ok, NotFound>> (int patientid, ReferralAPIContext db) =>
        {
            var affected = await db.Patient
                .Where(model => model.PatientId == patientid)
                .ExecuteDeleteAsync();

            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeletePatient")
        .WithOpenApi();
    }
}
