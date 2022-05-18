using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Models.Request_Models
{
    public class OrderDetailRequestModel
    {
        public decimal Total { get; set; }
        public List<OrderItemRequestModel> Products { get; set; }
    }
}
