using ReferralManagement.Model;
using System;

namespace ReferralManagement.Services
{
    public interface IPatientService
    {
        Task<List<Patient>> GetPatients();
        Task<Patient> GetPatientById(int id);
        Task UpdatePatient(Patient patient);
    }
}
