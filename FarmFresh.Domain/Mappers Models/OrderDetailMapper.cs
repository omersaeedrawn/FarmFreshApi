using FarmFresh.Models.Domain_Models;
using FarmFresh.Models.Request_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Models.Mappers_Models
{
    public static class OrderDetailMapper
    {
        public static OrderDetails MapRequestToDomain(this OrderDetailRequestModel source, Guid id)
        {
            return new OrderDetails
            {
                Id = id,
                Total = source.Total,
                OrderItems = source.Products.Select(p => p.MapRequestToDomain(id)).ToList()
            };
        }
    }
}
