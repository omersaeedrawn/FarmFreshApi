using FarmFresh.Interfaces.IRepositories;
using FarmFresh.Interfaces.IServices;
using FarmFresh.Models.Domain_Models;
using FarmFresh.Models.Mappers_Models;
using FarmFresh.Models.Request_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Service.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRespository;
        private readonly IOrderItemRepository _orderItemRespository;
        public OrderDetailService(IOrderDetailRepository orderDetailRespository,
            IOrderItemRepository orderItemRespository)
        {
            _orderDetailRespository = orderDetailRespository;
            _orderItemRespository = orderItemRespository;
        }
        public async Task CreateAsync(OrderDetailRequestModel model)
        {
            var orderDetail = model.MapRequestToDomain(new Guid());
            await _orderDetailRespository.AddAsync(orderDetail);
            _orderDetailRespository.Complete();
        }

        public async Task<OrderDetails> GetByIdAsync(Guid id)
        {
            return await _orderDetailRespository.GetOrderDetailByIdAsync(id);
        }
    }
}
