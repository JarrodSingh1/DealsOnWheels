using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class NewUser
    {
        [Required]
        [StringLength(255, MinimumLength = 5)]
        public String EmailAddress { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 8)]
        public String Password { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 2)]
        public String FirstName { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 2)]
        public String LastName { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 2)]
        public String IDNumber { get; set; }

        [Required]
        [StringLength(10)]
        public String PhoneNumber { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 5)]
        public String AccountNumber { get; set; }

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
