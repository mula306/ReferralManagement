using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ReferralManagement.Services;
using ReferralManagement.Model;

namespace ReferralManagement.Pages
{
    public class EditReferralFormModel : PageModel
    {
        private IDynamicReferralService _dynamicReferralService;
        [BindProperty]
        public DynamicReferral DynamicReferral { get; set; }

        public EditReferralFormModel(IDynamicReferralService dynamicReferralService)
        {
            _dynamicReferralService = dynamicReferralService;
        }

        public async Task<IActionResult> OnGetAsync(int id)
        {
            // Fetch patient data using APIService
            DynamicReferral = await _dynamicReferralService.GetDynamicReferralById(id);
    
            return Page();
        }

        public async Task<IActionResult> OnPostUpdateAsync(DynamicReferral dynamicReferral)
        {
            // Call the PatientService to save the changes here
            await _dynamicReferralService.UpdateDynamicReferral(dynamicReferral);
            return RedirectToPage("/ReferralForms/ReferralForms");
        }
    }
}

