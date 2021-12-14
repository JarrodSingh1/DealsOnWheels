using DealsOnWheelsAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class VehicleModel
    {
        [Required]
        [Key]
        public int VehicleId { get; set; }

        [Required]
        public int ModelId { get; set; }
    }
}
