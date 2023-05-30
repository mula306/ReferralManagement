using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using Microsoft.EntityFrameworkCore;

namespace ReferralAPI.Model
{
    public class Referral
    {
        [Key]
        public int ReferralId { get; set; }

        [ForeignKey("PatientId")]
        public int PatientId { get; set; } // Foreign Key
        
        [ForeignKey("ProviderId")]
        public int ProviderId { get; set; } // The department/doctor to which patient is referred

        public DateTime ReferralDate { get; set; } // When the referral was made

        public string ReferralReason { get; set; } // Why the patient was referred

        [ForeignKey("SpecialtyId")]
        public int SpecailtyId { get; set; } // Specialty assigned too

        public string Status { get; set; } // Status of the referral

    }

    
}
