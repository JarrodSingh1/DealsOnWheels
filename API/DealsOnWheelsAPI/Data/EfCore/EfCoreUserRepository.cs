using DealsOnWheelsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DealsOnWheelsAPI.Data.EfCore
{
    public class EfCoreUserRepository : EfCoreRepository<User, DealsOnWheelsAPIContext>
    {
        private readonly DealsOnWheelsAPIContext _context;
        public EfCoreUserRepository(DealsOnWheelsAPIContext context) : base(context)
        {
            _context = context;
        }
        public async Task<bool> Login(User user)
        {
            var searchUser = await _context.tb_UserCredentials
                 .FirstOrDefaultAsync(m => m.EmailAddress == user.EmailAddress && m.Password == user.Password);
            if (searchUser == null)
            {
                return false;
            }
            return true;
        }

        public async Task<UserInfo?> GetUserInfo(int userId)
        {
            UserInfo returnObject = new UserInfo();

            var searchUser = await _context.tb_UserCredentials
                 .FirstOrDefaultAsync(m => m.UserId == userId);
            if (searchUser == null)
            {
                return null;
            }

            var userAddressDetails = await _context.tb_UserAddressDetails
                 .FirstOrDefaultAsync(m => m.UserId == userId);
            var userContactDetails = await _context.tb_UserContactDetails
                 .FirstOrDefaultAsync(m => m.UserId == userId);
            var userPersonalDetails = await _context.tb_UserPersonalDetails
                 .FirstOrDefaultAsync(m => m.UserId == userId);
            if(userAddressDetails == null || userContactDetails == null || userPersonalDetails == null)
            {
                return null;
            }

            returnObject.City = userAddressDetails.City;
            returnObject.Country = userAddressDetails.Country;
            returnObject.StreetAddress = userAddressDetails.StreetAddress;
            returnObject.State = userAddressDetails.State;
            returnObject.ZipCode = userAddressDetails.ZipCode;
            returnObject.LastName = userPersonalDetails.LastName;
            returnObject.FirstName = userPersonalDetails.FirstName;
            returnObject.EmailAddress = searchUser.EmailAddress;
            returnObject.PhoneNumber = userContactDetails.PhoneNumber;
            returnObject.UserId = searchUser.UserId;

            return returnObject;
        }

        public async Task<List<UserInfo>> GetAllUserInfo()
        {
            var returnList = new List<UserInfo>();
            var userList = await _context.tb_UserCredentials.ToListAsync();

            foreach (var searchUser in userList)
            {
                
                bool valid = true;

                UserInfo item = new UserInfo();

                if (searchUser == null)
                {
                    valid = false;
                }
                var userId = searchUser.UserId;

                var userAddressDetails = await _context.tb_UserAddressDetails
                     .FirstOrDefaultAsync(m => m.UserId == userId);
                var userContactDetails = await _context.tb_UserContactDetails
                     .FirstOrDefaultAsync(m => m.UserId == userId);
                var userPersonalDetails = await _context.tb_UserPersonalDetails
                     .FirstOrDefaultAsync(m => m.UserId == userId);
                if (userAddressDetails == null || userContactDetails == null || userPersonalDetails == null)
                {
                    valid = false;
                }

                item.City = userAddressDetails.City;
                item.Country = userAddressDetails.Country;
                item.StreetAddress = userAddressDetails.StreetAddress;
                item.State = userAddressDetails.State;
                item.ZipCode = userAddressDetails.ZipCode;
                item.LastName = userPersonalDetails.LastName;
                item.FirstName = userPersonalDetails.FirstName;
                item.EmailAddress = searchUser.EmailAddress;
                item.PhoneNumber = userContactDetails.PhoneNumber;
                item.UserId = searchUser.UserId;

                if(valid)
                {
                    returnList.Add(item);
                }
            }
            
            return returnList;
        }
    }
}
