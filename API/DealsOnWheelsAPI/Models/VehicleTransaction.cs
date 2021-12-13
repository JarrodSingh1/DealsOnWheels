using DealsOnWheelsAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class VehicleTransaction
    {
        [Required]
        [Key]
        public int TransactionId { get; set; }

        [Required]
        public int VehicleId { get; set; }
    }
}
