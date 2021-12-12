using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DealsOnWheelsAPI.Models;

namespace DealsOnWheelsAPI.Data
{
    public class DealsOnWheelsAPIContext : DbContext
    {
        public DealsOnWheelsAPIContext (DbContextOptions<DealsOnWheelsAPIContext> options)
            : base(options)
        {
        }

        public DbSet<DealsOnWheelsAPI.Models.User> User { get; set; }
    }
}
