using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReferralManagement.Services;
using ReferralManagement.Model;

namespace ReferralManagement.Pages
{
    public class EditPatientModel : PageModel
    {
        private IPatientService _patientService;
        public Patient Patient { get; set; }

        public EditPatientModel(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Fetch the patient data based on the ID here
            Patient = await _patientService.GetPatientById(id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Patient patient)
        {
            // Call the PatientService to save the changes here
            await _patientService.UpdatePatient(patient);
            return RedirectToPage("/Patients/Patients");
        }
    }
}

