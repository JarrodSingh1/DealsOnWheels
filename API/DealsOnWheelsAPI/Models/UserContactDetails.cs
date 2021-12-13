using DealsOnWheelsAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class UserContactDetails
    {
        [Required]
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(10)]
        public String PhoneNumber { get; set; }
        
    }
}
