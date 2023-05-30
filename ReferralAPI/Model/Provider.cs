using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReferralAPI.Model
{
    public class Provider
    {
        [Key]
        public int ProviderId { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [ForeignKey("SpecialtyId")]
        public int SpecialtyId { get; set; }
    }
}
