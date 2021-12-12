using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class VehicleManufacturer
    {
        [Required]
        public int VehicleId { get; set; }

        [Required]
        public int ManufacturerId { get; set; }
    }
}
