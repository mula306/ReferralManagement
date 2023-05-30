using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReferralManagement.Model;
using ReferralManagement.Services;

namespace ReferralManagement.Pages
{
    public class ReferralFormsModel : PageModel
    {
        private readonly IDynamicReferralService _dynamicReferralService;
        // Add other properties for player stats as needed

        public ReferralFormsModel(IDynamicReferralService dynamicReferralService)
        {
            _dynamicReferralService = dynamicReferralService;
        }

        public List<DynamicReferral> DynamicReferrals { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {

            // Fetch referral forms data using APIService
            DynamicReferrals = await _dynamicReferralService.GetDynamicReferrals();

            if (DynamicReferrals == null)
            {
                //return RedirectToPage("/Error");
            }

            return Page();
        }
    }
}
