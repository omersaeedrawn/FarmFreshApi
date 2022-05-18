using FarmFresh.Interfaces.IRepositories;
using FarmFresh.Models.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Repository.Repositories
{
    public class OrderItemRepository : BaseRepository<OrderItem>, IOrderItemRepository
    {
        public OrderItemRepository(FarmFreshDbContext conetxt) : base(conetxt)
        { }
    }
}
