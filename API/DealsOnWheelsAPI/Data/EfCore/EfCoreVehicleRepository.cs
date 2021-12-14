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

        public async Task<List<VehicleInfo>> GetAllVehicleInfo()
        {
            List<VehicleInfo> returnList = new List<VehicleInfo>();
            List <VehicleSpecs> vehicleList = await _context.tb_VehicleSpecs.ToListAsync();

            foreach (VehicleSpecs searchVehicle in vehicleList)
            {
                bool valid = true;
                int vehicleId = searchVehicle.VehicleId;

                VehicleInfo vInfo = new VehicleInfo();

                var vehicleManufacturerInfo = await _context.tb_VehicleManufacturer
                     .FirstOrDefaultAsync(m => m.VehicleId == vehicleId);
                if (vehicleManufacturerInfo == null)
                {
                    valid = false;
                }

                var manufacturerId = vehicleManufacturerInfo.ManufacturerId;
                var bodyTypeId = searchVehicle.BodyTypeId;

                var manufacturerInfo = await _context.tb_Manufacturer
                     .FirstOrDefaultAsync(m => m.ManufacturerId == manufacturerId);
                var vehicleModel = await _context.tb_VehicleModel
                     .FirstOrDefaultAsync(m => m.VehicleId == vehicleId);
                
                var bodyTypeInfo = await _context.tb_VehicleBodyType
                     .FirstOrDefaultAsync(m => m.BodyTypeId == bodyTypeId);

                if (manufacturerInfo == null || vehicleModel == null || bodyTypeInfo == null)
                {
                    valid = false;
                }

                var model = await _context.tb_Model
                     .FirstOrDefaultAsync(m => m.ModelId == vehicleModel.ModelId);

                if (model == null)
                {
                    valid = false;
                }    


                vInfo.Power = searchVehicle.Power;
                vInfo.AdditionalInfo = searchVehicle.AdditionalInfo;
                vInfo.Displacement = searchVehicle.Displacement;
                vInfo.BodyType = bodyTypeInfo.BodyType;
                vInfo.Year = searchVehicle.Year;
                vInfo.ManufacturerId = manufacturerId;
                vInfo.Torque = searchVehicle.Torque;
                vInfo.Weight = searchVehicle.Weight;
                vInfo.Price = searchVehicle.Price;
                vInfo.ModelName = model.ModelName;
                vInfo.FuelType = searchVehicle.FuelType;
                vInfo.VehicleId = searchVehicle.VehicleId;
                vInfo.ManufacturerName = manufacturerInfo.ManufacturerName;
                vInfo.Transmission = searchVehicle.Transmission;

                if(valid)
                {
                    returnList.Add(vInfo);
                }
            }

            return returnList;
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
            var vehicleModel = await _context.tb_VehicleModel
                    .FirstOrDefaultAsync(m => m.VehicleId == searchVehicle.VehicleId);
            
            var bodyTypeInfo = await _context.tb_VehicleBodyType
                 .FirstOrDefaultAsync(m => m.BodyTypeId == bodyTypeId);

            if (manufacturerInfo == null || vehicleModel == null || bodyTypeInfo == null)
            {
                return null;
            }

            var model = await _context.tb_Model
                     .FirstOrDefaultAsync(m => m.ModelId == vehicleModel.ModelId);

            if(model == null)
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
            returnObject.ModelName = model.ModelName;
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

        public async Task<List<Model>> GetAllModels()
        {
            return await _context.tb_Model.ToListAsync();
        }

        public async Task<List<VehicleSpecs>> GetAllVehicles()
        {
            return await _context.tb_VehicleSpecs.ToListAsync();
        }
    }
}
