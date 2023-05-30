using System.ComponentModel.DataAnnotations;

namespace ReferralAPI.Model
{
    public class Specialty
    {
        [Key]
        public int SpecialtyId { get; set; }

        [Required]
        [StringLength(50)]
        public string SpecialtyName { get; set; }
    }
}
