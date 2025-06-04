using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReferralManagement.Model;
using ReferralManagement.Services;

namespace ReferralManagement.Pages.Ref
{
    public class ReferralsModel : PageModel
    {
        private readonly IReferralService _ReferralService;
        // Add other properties as needed for the page

        public ReferralsModel(IReferralService ReferralService)
        {
            _ReferralService = ReferralService;
        }

        public List<Referral> Referrals{ get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            // Fetch patient data using APIService
            Referrals = await _ReferralService.GetReferrals();

            if (Referrals == null)
            {
                return RedirectToPage("/Error");
            }

            return Page();
        }
    }
}
