using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class SoldVehicles
    {
        [Required]
        public int VehicleId { get; set; }

        [Required]
        public DateOnly DateSold { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
