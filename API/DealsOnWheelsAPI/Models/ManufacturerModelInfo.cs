using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class ManufacturerModelInfo
    {
        [Required]
        public int ManufacturerId { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1)]
        public String ModelName { get; set; }
    }
}
