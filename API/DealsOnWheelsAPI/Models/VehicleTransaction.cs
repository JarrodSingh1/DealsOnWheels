using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class VehicleTransaction
    {
        [Required]
        public int TransactionId { get; set; }

        [Required]
        public int VehicleId { get; set; }
    }
}
