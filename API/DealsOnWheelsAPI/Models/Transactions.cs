using DealsOnWheelsAPI.Data;

namespace DealsOnWheelsAPI.Models
{
    public class Transactions
    {
        public int TransactionId { get; set; }

        public int VehicleId { get; set; }

        public DateTime DateSold { get; set; }

        public DateTime DateAdded { get; set; }

        public double Price { get; set; }

        public int UserId { get; set; }
    }
}
