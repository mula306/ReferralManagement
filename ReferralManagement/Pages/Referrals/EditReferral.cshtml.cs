using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReferralManagement.Model;
using ReferralManagement.Services;

namespace ReferralManagement.Pages
{
    public class EditReferralModel : PageModel
    {
        private IReferralService _referralService;
        // Add other properties as needed for the page
        public Referral Referral { get; set; }

        public EditReferralModel(IReferralService referralService)
        {
            _referralService = referralService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Fetch the patient data based on the ID here
            Referral = await _referralService.GetReferralById(id);

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(Referral referral)
        {
            // Call the PatientService to save the changes here
            await _referralService.UpdateReferral(referral);
            return RedirectToPage("/Referrals/Referrals");
        }
    }
}
