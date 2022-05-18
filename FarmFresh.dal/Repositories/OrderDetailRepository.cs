using FarmFresh.Interfaces.IRepositories;
using FarmFresh.Models.Domain_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Repository.Repositories
{
    public class OrderDetailRepository : BaseRepository<OrderDetails>, IOrderDetailRepository
    {
        public OrderDetailRepository(FarmFreshDbContext conetxt) : base(conetxt)
        { }

        public async Task<OrderDetails> GetOrderDetailByIdAsync(Guid id)
        {
            return await _context.OrderDetails.Where(x => x.Id == id)
                                              .Include(u => u.OrderItems)
                                              .ThenInclude(u => u.Product)
                                              .FirstOrDefaultAsync();
        }
    }
}
