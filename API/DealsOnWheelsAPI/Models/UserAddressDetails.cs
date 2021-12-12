using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class UserAddressDetails
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public String StreetAddress { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public String City { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public String Country { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 3)]
        public String State { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 3)]
        public String ZipCode { get; set; }

    }
}
