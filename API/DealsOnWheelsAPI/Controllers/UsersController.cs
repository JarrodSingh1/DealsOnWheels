using DealsOnWheelsAPI.Data.EfCore;
using DealsOnWheelsAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace DealsOnWheelsAPI.Controllers
{
    [Route("api/Users")]
    [ApiController]
    public class UsersController : MyMDBController<User, EfCoreUserRepository>
    {
        private readonly EfCoreUserRepository _thisRepository;
        public UsersController(EfCoreUserRepository repository) : base(repository)
        {
            _thisRepository = repository;
        }

        // POST: api/Users/Login
        [HttpPost]
        [Route("/Users/Login")]
        public async Task<ActionResult<User>> Login(User user)
        {
           var validLogin = await _thisRepository.Login(user);
           if(validLogin)
           {
                return Ok();  
           }
           else
           {
                return BadRequest();
           }
        }

        // Get: api/Users/UserInfo/5
        [HttpGet]
        [Route("/Users/UserInfo/{userId}")]
        public async Task<UserInfo?> UserInfo(int userId)
        {
            var userInfo = await _thisRepository.GetUserInfo(userId);
            if (userInfo != null)
            {
                return userInfo;
            }
            else
            {
                return null;
            }
        }

        // Get: api/Users/GetAllUserInfo
        [HttpGet]
        [Route("/Users/GetAllUserInfo")]
        public async Task<List<UserInfo>> GetAllUserInfo()
        {
            return await _thisRepository.GetAllUserInfo();
        }


        // POST: api/Users/AddNewUser
        [HttpPost]
        [Route("/Users/AddNewUser")]
        public async Task<UserInfo?> AddNewUser(NewUser newUser)
        {
           var userId = await _thisRepository.AddNewUser(newUser);

           if(userId != null)
           {
                int id = (int)userId;
                return await UserInfo(id);
           }
           else 
           {
                return null;
           }
        }
    }
}
