using System.ComponentModel.DataAnnotations;

namespace ReferralAPI.Model
{
    public class DynamicReferral
    {
        [Key]
        public int DynamicReferralId { get; set; }
        public string ReferralName { get; set; }
        public string ReferralJson { get; set; } // Dynamic Form

    }
}
