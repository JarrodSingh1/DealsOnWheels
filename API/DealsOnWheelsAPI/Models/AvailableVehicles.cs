using DealsOnWheelsAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class AvailableVehicles
    {
        [Required]
        [Key]
        public int VehicleId { get; set; }

        [Required]
        public DateTime DateAdded { get; set; }
    }
}
