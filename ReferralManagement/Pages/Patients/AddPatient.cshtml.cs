using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReferralManagement.Model;
using ReferralManagement.Services;

namespace ReferralManagement.Pages.Patients
{
    public class AddPatientModel : PageModel
    {
        private IPatientService _patientService;
        public Patient Patient { get; set; }

        public AddPatientModel(IPatientService patientService)
        {
            _patientService = patientService;
        }


        public async Task<IActionResult> OnPostAsync(Patient patient)
        {
            // Call the PatientService to save the changes here
            await _patientService.AddPatient(patient);
            return RedirectToPage("/Patients/Patients");
        }
    }
}
