using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReferralManagement.Model;
using ReferralManagement.Services;

namespace ReferralManagement.Pages.Patients
{
    public class PatientModel : PageModel
    {
        private readonly IPatientService _patientService;
        // Add other properties as needed for the page

        public PatientModel(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public List<Patient> Patients { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            
            // Fetch patient data using APIService
            Patients = await _patientService.GetPatients();

            if (Patients  == null)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }
    }
}
