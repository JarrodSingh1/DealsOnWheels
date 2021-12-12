using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class UserPaymentDetails
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 5)]
        public String AccountNumber { get; set; }
    }
}
