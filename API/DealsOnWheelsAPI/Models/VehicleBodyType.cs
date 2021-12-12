using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class VehicleBodyType
    {
        [Required]
        public int BodyTypeId { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1)]
        public String BodyType { get; set; }
    }
}
