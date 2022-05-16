using FarmFresh.Domain.Models;
using FarmFresh.Models.Domain_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Interfaces
{
    public interface IFarmFreshDbContext
    {
        DbSet<Product> Products { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<User> Users { get; set; }
    }
}
