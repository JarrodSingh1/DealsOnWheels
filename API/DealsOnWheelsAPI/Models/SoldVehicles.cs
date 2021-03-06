using DealsOnWheelsAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class SoldVehicles
    {
        [Required]
        [Key]
        public int VehicleId { get; set; }

        [Required]
        public DateTime DateSold { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}
