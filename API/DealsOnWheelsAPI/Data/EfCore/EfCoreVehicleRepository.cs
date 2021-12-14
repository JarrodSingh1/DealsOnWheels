using DealsOnWheelsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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

        public async Task<List<VehicleBodyType>> GetAllVehicleBodyTypes()
        {
            return await _context.tb_VehicleBodyType.ToListAsync();
        }

        public async Task<List<Model>> GetAllModels()
        {
            return await _context.tb_Model.ToListAsync();
        }

        public async Task<List<VehicleSpecs>> GetAllVehicles()
        {
            return await _context.tb_VehicleSpecs.ToListAsync();
        }

        public async Task<Manufacturer?> AddManufacturer(String name)
        {
            if(name != null)
            {
                Manufacturer manufacturer = new Manufacturer();
                manufacturer.ManufacturerName = name;

                try
                {
                    _context.tb_Manufacturer.Add(manufacturer);
                    await _context.SaveChangesAsync();
                    return manufacturer;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error adding new manufacturer to tb_Manufacturer: " + ex.Message);
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public async Task<Model?> AddModel(String name)
        {
            if (name != null)
            {
                Model model = new Model();
                model.ModelName = name;

                try
                {
                    _context.tb_Model.Add(model);
                    await _context.SaveChangesAsync();
                    return model;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error adding new model to tb_Model: " + ex.Message);
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public async Task<VehicleBodyType?> AddBodyType(String name)
        {
            if (name != null)
            {
                VehicleBodyType vehicleBodyType = new VehicleBodyType();
                vehicleBodyType.BodyType = name;

                try
                {
                    _context.tb_VehicleBodyType.Add(vehicleBodyType);
                    await _context.SaveChangesAsync();
                    return vehicleBodyType;
                }
                catch (Exception ex)
                {
                    Debug.WriteLine("Error adding new body type to tb_VehicleBodyType: " + ex.Message);
                }
                return null;
            }
            else
            {
                return null;
            }
        }

        public async Task<int?> AddNewVehicle(NewVehicle newVehicle)
        {
            var valid = true;
            var vehicleID = 0;
            try
            {
                if (newVehicle != null)
                {
                    VehicleSpecs vehicle = new VehicleSpecs();
                    vehicle.Year = newVehicle.Year;
                    vehicle.Displacement = newVehicle.Displacement;
                    vehicle.FuelType = newVehicle.FuelType;
                    vehicle.Power = newVehicle.Power;
                    vehicle.Torque = newVehicle.Torque;
                    vehicle.Weight = newVehicle.Weight;
                    vehicle.BodyTypeId = newVehicle.BodyTypeId;
                    vehicle.AdditionalInfo = newVehicle.AdditionalInfo;
                    vehicle.Price = newVehicle.Price;
                    vehicle.Transmission = newVehicle.Transmission;

                    try
                    {
                        _context.tb_VehicleSpecs.Add(vehicle);
                        await _context.SaveChangesAsync();

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error adding new vehicle to tb_VehicleSpecs: " + ex.Message);
                        valid = false;
                    }

                    try
                    {
                        var searchVehicle = await _context.tb_VehicleSpecs
                 .FirstOrDefaultAsync(m => m.Year == newVehicle.Year && m.Displacement == newVehicle.Displacement && m.FuelType == newVehicle.FuelType && m.Power == newVehicle.Power && m.Torque == newVehicle.Torque && m.Weight == newVehicle.Weight && m.BodyTypeId == newVehicle.BodyTypeId && m.AdditionalInfo == newVehicle.AdditionalInfo && m.Price == newVehicle.Price && m.Transmission == newVehicle.Transmission);

                        if (searchVehicle != null)
                        {
                            vehicleID = searchVehicle.VehicleId;
                        }
                        else
                        {
                            valid = false;
                        }

                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error finding newly added vehicle from tb_VehicleSpecs: " + ex.Message);
                        valid = false;
                    }

                    if (valid)
                    {
                        VehicleManufacturer vehicleManufacturer = new VehicleManufacturer();
                        vehicleManufacturer.VehicleId = vehicleID;
                        vehicleManufacturer.ManufacturerId = newVehicle.ManufacturerId;

                        try
                        {
                            _context.tb_VehicleManufacturer.Add(vehicleManufacturer);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("Error adding new manufacturer to tb_VehicleManufacturer: " + ex.Message);
                            valid = false;
                        }

                    }

                    if (valid)
                    {
                        if(newVehicle.ImageURL != null)
                        {
                            VehicleImage vehicleImage = new VehicleImage();
                            vehicleImage.VehicleId = vehicleID;
                            vehicleImage.ImageURL = newVehicle.ImageURL;

                            try
                            {
                                _context.tb_VehicleImage.Add(vehicleImage);
                            }
                            catch (Exception ex)
                            {
                                Debug.WriteLine("Error adding new vehicleImage to tb_VehicleImage: " + ex.Message);
                                valid = false;
                            }
                        }
                    }

                    if (valid)
                    {
                        VehicleModel vehicleModel = new VehicleModel();
                        vehicleModel.VehicleId = vehicleID;
                        vehicleModel.ModelId = newVehicle.ModelId;

                        try
                        {
                            _context.tb_VehicleModel.Add(vehicleModel);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("Error adding new vehicleModel to tb_VehicleModel: " + ex.Message);
                            valid = false;
                        }
                    }
                }
                else
                {
                    return null;
                }

                if (valid)
                {
                    await _context.SaveChangesAsync();


                    if (vehicleID > 0)
                    {
                        return vehicleID;
                    }
                    else
                    {
                        return null;
                    }

                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error adding new vehicle: " + ex.Message);
                return null;
            }
        }
    }
}
