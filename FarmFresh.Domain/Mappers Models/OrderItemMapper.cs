using FarmFresh.Models.Domain_Models;
using FarmFresh.Models.Request_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Models.Mappers_Models
{
    public static class OrderItemMapper
    {
        public static OrderItem MapRequestToDomain(this OrderItemRequestModel source, Guid orderId)
        {
            return new OrderItem
            {
                Id = new Guid(),
                OrderId = orderId,
                ProductId = source.ProductId
            };
        }
    }
}
