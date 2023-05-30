using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReferralManagement.Model;
using ReferralManagement.Services;

namespace ReferralManagement.Pages
{
    public class AddReferralModel : PageModel
    {
        private IReferralService _referralService;
        // Add other properties for player stats as needed
        public Referral Referral { get; set; }

        public AddReferralModel(IReferralService referralService)
        {
            _referralService = referralService;
        }

        public async Task<IActionResult> OnPostAsync(Referral referral)
        {
            // Call the PatientService to save the changes here
            await _referralService.AddReferral(referral);
            return RedirectToPage("/Referrals/Referrals");
        }
    }
}
