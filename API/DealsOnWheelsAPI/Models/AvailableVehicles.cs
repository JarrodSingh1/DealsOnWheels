using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class AvailableVehicles
    {
        [Required]
        public int VehicleId { get; set; }

        [Required]
        public DateOnly DateAdded { get; set; }
    }
}
