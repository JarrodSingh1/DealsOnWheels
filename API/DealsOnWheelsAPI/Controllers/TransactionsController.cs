using DealsOnWheelsAPI.Data.EfCore;
using DealsOnWheelsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DealsOnWheelsAPI.Controllers
{
   
    [Route("api/Transactions")]
    [ApiController]
    public class TransactionsController : MyMDBController<VehicleTransaction, EfCoreTransactionRepository>
    {
        private readonly EfCoreTransactionRepository _thisRepository;
        public TransactionsController(EfCoreTransactionRepository repository) : base(repository)
        {
            _thisRepository = repository;
        }

        // GET: "api/Transactions/GetTransactions"
        [HttpGet]
        [Route("/Transactions/GetTransactions")]
        public async Task<List<Transactions>> GetTransactions()
        {
            return await _thisRepository.GetTransactions();
        }

        // GET: "api/Transactions/GetTransactionsInfo"
        [HttpGet]
        [Route("/Transactions/GetTransactionsInfo")]
        public async Task<List<TransactionInfo>> GetTransactionsInfo()
        {
            return await _thisRepository.GetTransactionsInfo();
        }

        // GET: "api/Transactions/GetAllAvaliableVehicles"
        [HttpGet]
        [Route("/Transactions/GetAllAvaliableVehicles")]
        public async Task<List<AvailableVehicles>> GetAllAvaliableVehicles()
        {
            return await _thisRepository.GetAllAvaliableVehicles();
        }

        // POST: "api/Transactions/AddNewTransaction"
        [HttpPost]
        [Route("/Transactions/AddNewTransaction")]
        public async Task<VehicleTransaction?> AddNewTransaction(NewTransaction newTransaction)
        {
            return await _thisRepository.AddNewTransaction(newTransaction);
        }
    }
}
