using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class VehicleSpecs
    {
        [Required]
        public int VehicleId { get; set; }

        [Required]
        public int Year { get; set; }
        
        [Required]
        public float Displacement { get; set; }

        [Required]
        public float FuelType { get; set; }

        [Required]
        public float Power { get; set; }

        [Required]
        public float Torque { get; set; }

        [Required]
        public float Weight { get; set; }

        [Required]
        public int BodyTypeId { get; set; }

        [Required]
        [StringLength(1000)]
        public String AdditionalInfo { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        [StringLength(50)]
        public String Transmission { get; set; }
    }
}
