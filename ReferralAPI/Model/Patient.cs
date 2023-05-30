using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ReferralAPI.Model
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(10)]
        public string Gender { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public DateTime RegistrationDate { get; set; }

        // Navigation property for the referrals
        [JsonIgnore]
        public List<Referral> Referrals { get; set; }
    }

}
