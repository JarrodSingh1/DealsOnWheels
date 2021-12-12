using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class Manufacturer
    {
        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1)]
        public String ManufacturerName { get; set; }
    }
}
