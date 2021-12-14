using DealsOnWheelsAPI.Data;
using System.ComponentModel.DataAnnotations;

namespace DealsOnWheelsAPI.Models
{
    public class NewTransaction
    {
        [Required]
        public int VehicleId { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}