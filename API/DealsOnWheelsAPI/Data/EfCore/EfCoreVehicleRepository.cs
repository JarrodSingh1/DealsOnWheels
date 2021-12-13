using DealsOnWheelsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DealsOnWheelsAPI.Data.EfCore
{
    public class EfCoreVehicleRepository : EfCoreRepository<VehicleSpecs, DealsOnWheelsAPIContext>
    {
        private readonly DealsOnWheelsAPIContext _context;
        public EfCoreVehicleRepository(DealsOnWheelsAPIContext context) : base(context)
        {
            _context = context;
        }

        public async Task<VehicleInfo?> GetVehicleInfo(int vehicleId)
        {
            VehicleInfo returnObject = new VehicleInfo();

            var searchVehicle = await _context.tb_VehicleSpecs
                 .FirstOrDefaultAsync(m => m.VehicleId == vehicleId);
            if (searchVehicle == null)
            {
                return null;
            }

            var vehicleManufacturerInfo = await _context.tb_VehicleManufacturer
                 .FirstOrDefaultAsync(m => m.VehicleId == vehicleId);
            if (vehicleManufacturerInfo == null)
            {
                return null;
            }

            var manufacturerId = vehicleManufacturerInfo.ManufacturerId;
            var bodyTypeId = searchVehicle.BodyTypeId;

            var manufacturerInfo = await _context.tb_Manufacturer
                 .FirstOrDefaultAsync(m => m.ManufacturerId == manufacturerId);
            var manufacturerModelInfo = await _context.tb_ManufacturerModelInfo
                 .FirstOrDefaultAsync(m => m.ManufacturerId == manufacturerId);
            var bodyTypeInfo = await _context.tb_VehicleBodyType
                 .FirstOrDefaultAsync(m => m.BodyTypeId == bodyTypeId);

            if (manufacturerInfo == null || manufacturerModelInfo == null || bodyTypeInfo == null)
            {
                return null;
            }

            returnObject.Power = searchVehicle.Power;
            returnObject.AdditionalInfo = searchVehicle.AdditionalInfo;
            returnObject.Displacement = searchVehicle.Displacement;
            returnObject.BodyType = bodyTypeInfo.BodyType;
            returnObject.Year = searchVehicle.Year;
            returnObject.ManufacturerId = manufacturerId;
            returnObject.Torque = searchVehicle.Torque;
            returnObject.Weight = searchVehicle.Weight;
            returnObject.Price = searchVehicle.Price;
            returnObject.ModelName = manufacturerModelInfo.ModelName;
            returnObject.FuelType = searchVehicle.FuelType;
            returnObject.VehicleId = searchVehicle.VehicleId;
            returnObject.ManufacturerName = manufacturerInfo.ManufacturerName;
            returnObject.Transmission = searchVehicle.Transmission;

            return returnObject;
        }

        public async Task<List<Manufacturer>> GetAllManufacturers()
        {
            return await _context.tb_Manufacturer.ToListAsync();
        }

        public async Task<List<ManufacturerModelInfo>> GetAllModelsForManufacturer(int manufacturerId)
        {
            return await _context.tb_ManufacturerModelInfo.Where(m => m.ManufacturerId == manufacturerId).ToListAsync();
        }

        public async Task<List<ManufacturerModelInfo>> GetAllModels()
        {
            return await _context.tb_ManufacturerModelInfo.ToListAsync();
        }

        public async Task<List<VehicleSpecs>> GetAllVehicles()
        {
            return await _context.tb_VehicleSpecs.ToListAsync();
        }
    }
}
