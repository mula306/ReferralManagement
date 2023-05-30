using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ReferralManagement.Model
{
    public class Referral
    {
        public int ReferralId { get; set; }
        public int PatientId { get; set; } // Foreign Key
        public int ProviderId { get; set; } // The department/doctor to which patient is referred
        public DateTime ReferralDate { get; set; } // When the referral was made
        public string ReferralReason { get; set; } // Why the patient was referred
        public int SpecailtyId { get; set; } // Specialty assigned too
        public string Status { get; set; } // Status of the referral
    }
}
