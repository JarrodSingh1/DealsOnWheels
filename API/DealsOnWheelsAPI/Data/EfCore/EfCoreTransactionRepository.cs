using DealsOnWheelsAPI.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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
                var vehicleModel = await _context.tb_VehicleModel
                .FirstOrDefaultAsync(m => m.VehicleId == item.VehicleId);


                if (soldVehicles == null || vehicleSpecs == null || availableVehicles == null || vehicleManufacturer == null || vehicleModel == null)
                {
                    continue;
                }

                var vehicleBodyType = await _context.tb_VehicleBodyType
                .FirstOrDefaultAsync(m => m.BodyTypeId == vehicleSpecs.BodyTypeId);
    
                var manufacturerId = vehicleManufacturer.ManufacturerId;
                var manufacturer = await _context.tb_Manufacturer
                .FirstOrDefaultAsync(m => m.ManufacturerId == manufacturerId);
                var model = await _context.tb_Model
                .FirstOrDefaultAsync(m => m.ModelId == vehicleModel.ModelId);



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

        public async Task<VehicleTransaction?> AddNewTransaction(NewTransaction newTransaction)
        {
            if (newTransaction != null)
            {
                bool valid = true;
                var vehicle = await _context.tb_VehicleSpecs
               .FirstOrDefaultAsync(m => m.VehicleId == newTransaction.VehicleId);
                var user = await _context.tb_UserCredentials
               .FirstOrDefaultAsync(m => m.UserId == newTransaction.UserId);

                if (user != null && vehicle != null)
                {
                    VehicleTransaction vehicleTransaction = new VehicleTransaction();
                    vehicleTransaction.VehicleId = newTransaction.VehicleId;

                    try
                    {
                        _context.tb_VehicleTransaction.Add(vehicleTransaction);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error adding new vehicleTransaction to tb_VehicleTransaction: " + ex.Message);
                        valid = false;
                    }
                }
                else
                {
                    return null;
                }

                if(valid)
                {
                    SoldVehicles soldVehicles = new SoldVehicles();
                    soldVehicles.VehicleId = newTransaction.VehicleId;
                    soldVehicles.DateSold = DateTime.Now;
                    soldVehicles.UserId = newTransaction.UserId;

                    try
                    {
                        _context.tb_SoldVehicles.Add(soldVehicles);
                        await _context.SaveChangesAsync();
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error adding new soldVehicles to tb_SoldVehicles: " + ex.Message);
                        valid = false;
                    }
                }

                if(valid)
                {
                    var transaction = await _context.tb_VehicleTransaction
               .FirstOrDefaultAsync(m => m.VehicleId == newTransaction.VehicleId);

                    return transaction;
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
    }
}
