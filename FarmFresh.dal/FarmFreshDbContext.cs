using FarmFresh.Domain.Models;
using FarmFresh.Interfaces;
using FarmFresh.Models.Domain_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Repository
{
    public class FarmFreshDbContext: DbContext, IFarmFreshDbContext
    {
        public FarmFreshDbContext(DbContextOptions<FarmFreshDbContext> options)
            : base(options)
        {
        }

        public FarmFreshDbContext()

        {
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<User> Users{ get; set; }
    }
}
