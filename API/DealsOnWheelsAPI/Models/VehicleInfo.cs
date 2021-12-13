using DealsOnWheelsAPI.Data;

namespace DealsOnWheelsAPI.Models
{
    public class VehicleInfo
    {
        public int VehicleId { get; set; }

        public int ManufacturerId { get; set; }

        public String ManufacturerName { get; set; }

        public String ModelName { get; set; }

        public int Year { get; set; }

        public double Price { get; set; }

        public string FuelType { get; set; }

        public String Transmission { get; set; }

        public double Displacement { get; set; }

        public double Power { get; set; }

        public double Torque { get; set; }

        public double Weight { get; set; }

        public String BodyType { get; set; }

        public String AdditionalInfo { get; set; }
    }
}
