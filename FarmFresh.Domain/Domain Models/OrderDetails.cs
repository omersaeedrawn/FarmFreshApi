using FarmFresh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Models.Domain_Models
{
    public class OrderDetails : BaseModel
    {
        public decimal Total { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
