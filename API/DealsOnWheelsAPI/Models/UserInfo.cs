using DealsOnWheelsAPI.Data;

namespace DealsOnWheelsAPI.Models
{
    public class UserInfo
    {
        public int UserId { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String EmailAddress { get; set; }

        public String PhoneNumber { get; set; }

        public String StreetAddress { get; set; }

        public String City { get; set; }

        public String Country { get; set; }

        public String State { get; set; }

        public String ZipCode { get; set; }
    }
}
