﻿using DealsOnWheelsAPI.Data.EfCore;
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

        // POST: "api/Vehicles/GetVehicleInfo/5"
        [HttpGet]
        [Route("api/Vehicles/GetVehicleInfo/{vehicleId}")]
        public async Task<VehicleInfo?> GetAllVehicles(int vehicleId)
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

        // POST: "api/Vehicles/GetAllManufacturers"
        [HttpGet]
        [Route("api/Vehicles/GetAllManufacturers")]
        public async Task<List<Manufacturer>> GetAllManufacturers()
        {
           return await _thisRepository.GetAllManufacturers();
        }

        // POST: "api/Vehicles/GetAllModelsForManufacturer/{manufacturerId}"
        [HttpGet]
        [Route("api/Vehicles/GetAllModelsForManufacturer")]
        public async Task<List<ManufacturerModelInfo>> GetAllModelsForManufacturer(int manufacturerId)
        {
            return await _thisRepository.GetAllModelsForManufacturer(manufacturerId);
        }

        // POST: "api/Vehicles/GetAllModels"
        [HttpGet]
        [Route("api/Vehicles/GetAllModels")]
        public async Task<List<ManufacturerModelInfo>> GetAllModels()
        {
            return await _thisRepository.GetAllModels();
        }
    }
}
