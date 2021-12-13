using DealsOnWheelsAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class VehicleBodyType
    {
        [Required]
        [Key]
        public int BodyTypeId { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1)]
        public String BodyType { get; set; }
    }
}
