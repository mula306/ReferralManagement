using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReferralManagement.Model;
using ReferralManagement.Services;

namespace ReferralManagement.Pages.ReferralForms
{
    public class AddReferralFormModel : PageModel
    {
        private IDynamicReferralService _dynamicReferralService;
        [BindProperty]
        public DynamicReferral DynamicReferral { get; set; }

        public AddReferralFormModel(IDynamicReferralService dynamicReferralService)
        {
            _dynamicReferralService = dynamicReferralService;
        }

        
        public async Task<IActionResult> OnPostAsync(DynamicReferral dynamicReferral)
        {
            // Call the PatientService to save the changes here
            await _dynamicReferralService.AddDynamicReferral(dynamicReferral);
            return RedirectToPage("/ReferralForms/ReferralForms");
        }
    }
}
