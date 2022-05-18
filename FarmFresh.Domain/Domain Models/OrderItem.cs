using FarmFresh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Models.Domain_Models
{
    public class OrderItem : BaseModel
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public virtual OrderDetails Order{ get; set; }
        public virtual Product Product { get; set; }
    }
}
