using DealsOnWheelsAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class Model
    {
        [Required]
        [Key]
        public int ModelId { get; set; }

        [Required]
        [StringLength(255, MinimumLength = 1)]
        public String ModelName { get; set; }
    }
}
