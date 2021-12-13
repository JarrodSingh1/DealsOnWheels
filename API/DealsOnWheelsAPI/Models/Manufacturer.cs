using DealsOnWheelsAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class Manufacturer
    {
        [Required]
        [Key]
        public int ManufacturerId { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1)]
        public String ManufacturerName { get; set; }
    }
}
