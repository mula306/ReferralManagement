using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReferralManagement.Model;
using ReferralManagement.Services;

namespace ReferralManagement.Pages.Patients
{
    public class DeletePatientModel : PageModel
    {
        private IPatientService _patientService;
        public Patient Patient { get; set; }

        public DeletePatientModel(IPatientService patientService)
        {
            _patientService = patientService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Fetch the patient data based on the ID here
            Patient = await _patientService.GetPatientById(id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            // Call the PatientService to save the changes here
            await _patientService.DeletePatient(id);
            return RedirectToPage("/Patients/Patients");
        }
    }
}
