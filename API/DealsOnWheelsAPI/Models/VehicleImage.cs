using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class VehicleImage
    {
        [Required]
        public int VehicleId { get; set; }
        
        [StringLength(1000)]
        public String ImageURL { get; set; }
    }
}
