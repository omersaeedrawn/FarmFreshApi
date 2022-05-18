using FarmFresh.Models.Domain_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Interfaces.IRepositories
{
    public interface IOrderDetailRepository : IRepository<OrderDetails, Guid>
    {
        Task<OrderDetails> GetOrderDetailByIdAsync(Guid id);
    }
}
