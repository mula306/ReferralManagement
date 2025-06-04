using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReferralManagement.Model;
using ReferralManagement.Services;

namespace ReferralManagement.Pages.Patients
{
    public class AddPatientModel : PageModel
    {
        private IPatientService _patientService;
        public Patient Patient { get; set; } = new Patient();

        public AddPatientModel(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public IActionResult OnGet()
        {
            // Provide an empty patient so the razor page does not encounter
            // null reference issues when binding form fields.
            Patient = new Patient();
            return Page();
        }


        public async Task<IActionResult> OnPostAsync(Patient patient)
        {
            // Call the PatientService to save the changes here
            await _patientService.AddPatient(patient);
            return RedirectToPage("/Patients/Patients");
        }
    }
}
