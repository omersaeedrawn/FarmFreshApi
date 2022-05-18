using FarmFresh.Models.Domain_Models;
using FarmFresh.Models.Request_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Interfaces.IServices
{
    public interface IOrderDetailService
    {
        Task CreateAsync(OrderDetailRequestModel model);
        Task<OrderDetails> GetByIdAsync(Guid id);
    }
}
