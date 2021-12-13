using DealsOnWheelsAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class UserPersonalDetails
    {
        [Required]
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 2)]
        public String FirstName { get; set; }
        
        [Required]
        [StringLength(255, MinimumLength = 2)]
        public String LastName { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 2)]
        public String IDNumber { get; set; }
    }
}
