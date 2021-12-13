using DealsOnWheelsAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class User
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5)]
        public String EmailAddress { get; set; }
        
        [Required]
        [StringLength(255, MinimumLength = 8)]
        public String Password { get; set; }
    }
}
