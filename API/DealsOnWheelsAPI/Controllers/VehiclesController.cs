using DealsOnWheelsAPI.Data.EfCore;
using DealsOnWheelsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DealsOnWheelsAPI.Controllers
{
   
    [Route("api/Vehicles")]
    [ApiController]
    public class VehiclesController : MyMDBController<VehicleSpecs, EfCoreVehicleRepository>
    {
        private readonly EfCoreVehicleRepository _thisRepository;
        public VehiclesController(EfCoreVehicleRepository repository) : base(repository)
        {
            _thisRepository = repository;
        }

        // GET: "api/Vehicles/GetAllVehicles"
        [HttpGet]
        [Route("api/Vehicles/GetAllVehicles")]
        public async Task<List<VehicleSpecs>> GetAllVehicles()
        {
            return await _thisRepository.GetAllVehicles();
        }

        // GET: "api/Vehicles/GetAllVehicleInfo"
        [HttpGet]
        [Route("api/Vehicles/GetAllVehicleInfo")]
        public async Task<List<VehicleInfo>> GetAllVehicleInfo()
        {
            return await _thisRepository.GetAllVehicleInfo();
        }

        // GET: "api/Vehicles/GetVehicleInfo/5"
        [HttpGet]
        [Route("api/Vehicles/GetVehicleInfo/{vehicleId}")]
        public async Task<VehicleInfo?> GetVehicleInfo(int vehicleId)
        {
            var vehicleInfo = await _thisRepository.GetVehicleInfo(vehicleId);
            if (vehicleInfo != null)
            {
                return vehicleInfo;
            }
            else
            {
                return null;
            }
        }

        // GET: "api/Vehicles/GetAllManufacturers"
        [HttpGet]
        [Route("api/Vehicles/GetAllManufacturers")]
        public async Task<List<Manufacturer>> GetAllManufacturers()
        {
           return await _thisRepository.GetAllManufacturers();
        }

        // GET: "api/Vehicles/GetAllVehicleBodyTypes"
        [HttpGet]
        [Route("api/Vehicles/GetAllVehicleBodyTypes")]
        public async Task<List<VehicleBodyType>> GetAllVehicleBodyTypes()
        {
            return await _thisRepository.GetAllVehicleBodyTypes();
        }

        // GET: "api/Vehicles/GetAllModels"
        [HttpGet]
        [Route("api/Vehicles/GetAllModels")]
        public async Task<List<Model>> GetAllModels()
        {
            return await _thisRepository.GetAllModels();
        }

        // POST: api/Vehicles/AddManufacturer
        [HttpPost]
        [Route("api/Vehicles/AddManufacturer")]
        public async Task<Manufacturer?> AddManufacturer(String name)
        {
            return await _thisRepository.AddManufacturer(name);
        }

        // POST: api/Vehicles/AddModel
        [HttpPost]
        [Route("api/Vehicles/AddModel")]
        public async Task<Model?> AddModel(String name)
        {
            return await _thisRepository.AddModel(name);
        }

        // POST: api/Vehicles/AddBodyType
        [HttpPost]
        [Route("api/Vehicles/AddBodyType")]
        public async Task<VehicleBodyType?> AddBodyType(String name)
        {
            return await _thisRepository.AddBodyType(name);
        }

        // POST: api/Vehicles/AddNewVehicle
        [HttpPost]
        [Route("api/Users/AddNewVehicle")]
        public async Task<VehicleInfo?> AddNewVehicle(NewVehicle newVehicle)
        {
            var vehicleId = await _thisRepository.AddNewVehicle(newVehicle);

            if (vehicleId != null)
            {
                int id = (int)vehicleId;
                return await GetVehicleInfo(id);
            }
            else
            {
                return null;
            }
        }
    }
}
