using DealsOnWheelsAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DealsOnWheelsAPI.Data.EfCore
{
    public class EfCoreTransactionRepository : EfCoreRepository<VehicleTransaction, DealsOnWheelsAPIContext>
    {
        private readonly DealsOnWheelsAPIContext _context;
        public EfCoreTransactionRepository(DealsOnWheelsAPIContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Transactions>> GetTransactions()
        { 
            var returnList = new List<Transactions>();
            var transactionsList = await _context.tb_VehicleTransaction.ToListAsync();

            foreach (var item in transactionsList)
            {
                Transactions transaction = new Transactions();

                transaction.TransactionId = item.TransactionId;
                transaction.VehicleId = item.VehicleId;

                var soldVehicles = await _context.tb_SoldVehicles
                .FirstOrDefaultAsync(m => m.VehicleId == transaction.VehicleId);
                var vehicleSpecs = await _context.tb_VehicleSpecs
                .FirstOrDefaultAsync(m => m.VehicleId == transaction.VehicleId);
                var availableVehicles = await _context.tb_AvailableVehicles
                .FirstOrDefaultAsync(m => m.VehicleId == transaction.VehicleId);

                if (soldVehicles == null || vehicleSpecs == null || availableVehicles == null)
                {
                    continue;
                }

                transaction.Price = vehicleSpecs.Price;
                transaction.DateAdded = availableVehicles.DateAdded;
                transaction.DateSold = soldVehicles.DateSold;
                transaction.UserId = soldVehicles.UserId;

                returnList.Add(transaction);

            }

            return returnList;
        }

        public async Task<List<TransactionInfo>> GetTransactionsInfo()
        {
            var returnList = new List<TransactionInfo>();
            var transactionsList = await _context.tb_VehicleTransaction.ToListAsync();

            foreach (var item in transactionsList)
            {
                TransactionInfo transaction = new TransactionInfo();

                transaction.TransactionId = item.TransactionId;
                transaction.VehicleId = item.VehicleId;

                var soldVehicles = await _context.tb_SoldVehicles
                .FirstOrDefaultAsync(m => m.VehicleId == transaction.VehicleId);
                var vehicleSpecs = await _context.tb_VehicleSpecs
                .FirstOrDefaultAsync(m => m.VehicleId == transaction.VehicleId);
                var availableVehicles = await _context.tb_AvailableVehicles
                .FirstOrDefaultAsync(m => m.VehicleId == transaction.VehicleId);
                var vehicleManufacturer = await _context.tb_VehicleManufacturer
                .FirstOrDefaultAsync(m => m.VehicleId == transaction.VehicleId);
                
                


                if (soldVehicles == null || vehicleSpecs == null || availableVehicles == null || vehicleManufacturer == null)
                {
                    continue;
                }

                var vehicleBodyType = await _context.tb_VehicleBodyType
                .FirstOrDefaultAsync(m => m.BodyTypeId == vehicleSpecs.BodyTypeId);
    
                var manufacturerId = vehicleManufacturer.ManufacturerId;
                var manufacturer = await _context.tb_Manufacturer
                .FirstOrDefaultAsync(m => m.ManufacturerId == manufacturerId);
                var model = await _context.tb_ManufacturerModelInfo
                .FirstOrDefaultAsync(m => m.ManufacturerId == manufacturerId);



                transaction.Price = vehicleSpecs.Price;
                transaction.DateAdded = availableVehicles.DateAdded;
                transaction.DateSold = soldVehicles.DateSold;
                transaction.UserId = soldVehicles.UserId;

                var userPersonalDetails = await _context.tb_UserPersonalDetails
                .FirstOrDefaultAsync(m => m.UserId == transaction.UserId);
                var userPaymentDetails = await _context.tb_UserPaymentDetails
                .FirstOrDefaultAsync(m => m.UserId == transaction.UserId);

                if (manufacturer == null || userPersonalDetails == null || userPaymentDetails == null || model == null || vehicleBodyType == null)
                {
                    continue;
                }

                transaction.ManufacturerName = manufacturer.ManufacturerName;
                transaction.ModelName = model.ModelName;
                transaction.Year = vehicleSpecs.Year;
                transaction.FuelType = vehicleSpecs.FuelType;
                transaction.Transmission = vehicleSpecs.Transmission;
                transaction.Displacement = vehicleSpecs.Displacement;
                transaction.Torque = vehicleSpecs.Torque;
                transaction.Weight = vehicleSpecs.Weight;
                transaction.BodyType = vehicleBodyType.BodyType;
                transaction.AdditionalInfo = vehicleSpecs.AdditionalInfo;
                transaction.FirstName = userPersonalDetails.FirstName;
                transaction.LastName = userPersonalDetails.LastName;
                transaction.AccountNumber = userPaymentDetails.AccountNumber;


                returnList.Add(transaction);
            }

            return returnList;
        }

        public async Task<List<AvailableVehicles>> GetAllAvaliableVehicles()
        {
            return await _context.tb_AvailableVehicles.ToListAsync();
        }
    }
}
