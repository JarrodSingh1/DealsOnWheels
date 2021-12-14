using Microsoft.EntityFrameworkCore;

namespace DealsOnWheelsAPI.Data.EfCore
{
    public class DealsOnWheelsAPIContext : DbContext
    {
        public DealsOnWheelsAPIContext (DbContextOptions<DealsOnWheelsAPIContext> options)
            : base(options)
        {
        }

        public DbSet<DealsOnWheelsAPI.Models.User> tb_UserCredentials { get; set; }

        public DbSet<DealsOnWheelsAPI.Models.VehicleSpecs> tb_VehicleSpecs { get; set; }

        public DbSet<DealsOnWheelsAPI.Models.VehicleTransaction> tb_VehicleTransaction { get; set; }

        public DbSet<DealsOnWheelsAPI.Models.Manufacturer> tb_Manufacturer { get; set; }

        public DbSet<DealsOnWheelsAPI.Models.Model> tb_Model { get; set; }

        public DbSet<DealsOnWheelsAPI.Models.VehicleModel> tb_VehicleModel { get; set; }

        public DbSet<DealsOnWheelsAPI.Models.AvailableVehicles> tb_AvailableVehicles { get; set; }

        public DbSet<DealsOnWheelsAPI.Models.SoldVehicles> tb_SoldVehicles { get; set; }

        public DbSet<DealsOnWheelsAPI.Models.UserAddressDetails> tb_UserAddressDetails { get; set; }

        public DbSet<DealsOnWheelsAPI.Models.UserContactDetails> tb_UserContactDetails { get; set; }

        public DbSet<DealsOnWheelsAPI.Models.UserPaymentDetails> tb_UserPaymentDetails { get; set; }

        public DbSet<DealsOnWheelsAPI.Models.UserPersonalDetails> tb_UserPersonalDetails { get; set; }

        public DbSet<DealsOnWheelsAPI.Models.VehicleBodyType> tb_VehicleBodyType { get; set; }

        public DbSet<DealsOnWheelsAPI.Models.VehicleImage> tb_VehicleImage { get; set; }

        public DbSet<DealsOnWheelsAPI.Models.VehicleManufacturer> tb_VehicleManufacturer { get; set; }
    }
}
