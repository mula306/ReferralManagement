using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ReferralManagement.Model;
using ReferralManagement.Services;

namespace ReferralManagement.Pages
{
    public class ReferralFormModel : PageModel
    {

        private readonly IDynamicReferralService _dynamicReferralService;
        // Add other properties for player stats as needed

        public ReferralFormModel(IDynamicReferralService dynamicReferralService)
        {
            _dynamicReferralService = dynamicReferralService;
        }

        public DynamicReferral DynamicReferral { get; set; }

        public async Task<IActionResult> OnGetAsync(int id)
        {

            // Fetch patient data using APIService
            DynamicReferral = await _dynamicReferralService.GetDynamicReferralById(id);

            //if (DynamicReferral == null)
            //{
            //    return RedirectToPage("/Error");
            //}

            // Deserialize the JSON to an object
            //JObject jObject = JObject.Parse(DynamicReferral.ReferralJson);
            //Dictionary<string, object> schema = jObject.ToObject<Dictionary<string, object>>();

            //// Set the schema in ViewData
            //ViewData["Schema"] = schema;

            return Page();
        }

        //public void OnGet()
        //{
        //    // Your JSON schema
        //    string json = @"{
        //        ""title"":""Referral"",
        //        ""fields"":[
        //            {""name"":""firstName"",""label"":""First name"",""type"":""string"",""description"":""The patient's first name.""},
        //            {""name"":""lastName"",""label"":""Last name"",""type"":""string"",""description"":""The patient's last name.""},
        //            {""name"":""gender"",""label"":""Gender"",""type"":""string"",""description"":""The patient's gender."",""options"":[""Male"",""Female"",""Other""]},
        //            {""name"":""referralReason"",""label"":""Referral reason"",""type"":""string"",""description"":""The reason for the referral.""}
        //        ]
        //    }";

        //    // Deserialize the JSON to an object
        //    JObject jObject = JObject.Parse(json);
        //    Dictionary<string, object> schema = jObject.ToObject<Dictionary<string, object>>();

            
        //}
    }
}
