using DealsOnWheelsAPI.Data;

namespace DealsOnWheelsAPI.Models
{
    public class TransactionInfo
    {
        public int TransactionId { get; set; }

        public int VehicleId { get; set; }

        public String ManufacturerName { get; set; }

        public String ModelName { get; set; }

        public int Year { get; set; }

        public double Price { get; set; }

        public String FuelType { get; set; }

        public String Transmission { get; set; }

        public double Displacement { get; set; }

        public double Power { get; set; }

        public double Torque { get; set; }

        public double Weight { get; set; }

        public String BodyType { get; set; }

        public String AdditionalInfo { get; set; }

        public DateTime DateSold { get; set; }

        public DateTime DateAdded { get; set; }

        public int UserId { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String AccountNumber { get; set; }
    }
}
