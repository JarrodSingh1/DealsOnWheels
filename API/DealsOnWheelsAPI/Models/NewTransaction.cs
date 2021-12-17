using DealsOnWheelsAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class NewTransaction
    {
        [Required]
        public int VehicleId { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 5)]
        public String EmailAddress { get; set; }
    }
}