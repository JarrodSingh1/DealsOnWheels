using DealsOnWheelsAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

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


        public async Task<int?> AddNewUser(NewUser newUser)
        {
            var valid = true;
            var userID = 0;

            try
            {
                if (newUser != null)
                {
                    User user = new User();
                    user.EmailAddress = newUser.EmailAddress;
                    user.Password = newUser.Password;

                    try
                    {
                        _context.tb_UserCredentials.Add(user);
                        await _context.SaveChangesAsync();

                        var searchUser = await _context.tb_UserCredentials
                 .FirstOrDefaultAsync(m => m.EmailAddress == newUser.EmailAddress);

                        if (searchUser == null)
                        {
                            valid = false;
                        }
                        else
                        {
                            userID = searchUser.UserId;

                            if(userID < 1)
                            {
                                valid = false;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine("Error adding new user to tb_UserCredentials: " + ex.Message);
                        valid = false;
                    }

                    if (valid)
                    {
                        UserPersonalDetails userPersonalDetails = new UserPersonalDetails();
                        userPersonalDetails.UserId = userID;
                        userPersonalDetails.FirstName = newUser.FirstName;
                        userPersonalDetails.LastName = newUser.LastName;
                        userPersonalDetails.IDNumber = newUser.IDNumber;

                        try
                        {
                            _context.tb_UserPersonalDetails.Add(userPersonalDetails);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("Error adding new user to tb_UserPersonalDetails: " + ex.Message);
                            valid = false;
                        }

                    }

                    if (valid)
                    {
                        UserContactDetails userContactDetails = new UserContactDetails();
                        userContactDetails.UserId = userID;
                        userContactDetails.PhoneNumber = newUser.PhoneNumber;

                        try
                        {
                            _context.tb_UserContactDetails.Add(userContactDetails);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("Error adding new user to tb_UserContactDetails: " + ex.Message);
                            valid = false;
                        }

                    }

                    if (valid)
                    {
                        UserPaymentDetails userPaymentDetails = new UserPaymentDetails();
                        userPaymentDetails.UserId = userID;
                        userPaymentDetails.AccountNumber = newUser.AccountNumber;

                        try
                        {
                            _context.tb_UserPaymentDetails.Add(userPaymentDetails);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("Error adding new user to tb_userPaymentDetails: " + ex.Message);
                            valid = false;
                        }
                    }

                    if (valid)
                    {
                        UserAddressDetails userAddressDetails = new UserAddressDetails();
                        userAddressDetails.UserId = userID;
                        userAddressDetails.StreetAddress = newUser.StreetAddress;
                        userAddressDetails.City = newUser.City;
                        userAddressDetails.Country = newUser.Country;
                        userAddressDetails.State = newUser.State;
                        userAddressDetails.ZipCode = newUser.ZipCode;

                        try
                        {
                            _context.tb_UserAddressDetails.Add(userAddressDetails);
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine("Error adding new user to tb_UserAddressDetails: " + ex.Message);
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

                    if (userID > 0)
                    {
                        return userID;
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
                Debug.WriteLine("Error adding new user: " + ex.Message);
                return null;
            }
        }
    }
}
