using DealsOnWheelsAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class VehicleSpecs
    {
        [Required]
        [Key]
        public int VehicleId { get; set; }

        [Required]
        public int Year { get; set; }
        
        [Required]
        public double Displacement { get; set; }

        [Required]
        public String FuelType { get; set; }

        [Required]
        public double Power { get; set; }

        [Required]
        public double Torque { get; set; }

        [Required]
        public double Weight { get; set; }

        [Required]
        public int BodyTypeId { get; set; }

        [Required]
        [StringLength(1000)]
        public String AdditionalInfo { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        [StringLength(50)]
        public String Transmission { get; set; }
    }
}
