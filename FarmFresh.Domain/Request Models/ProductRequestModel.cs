using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Models.Request_Models
{
    public class ProductRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Origin { get; set; }
        public string KeyInformation { get; set; }
        public int Quantity { get; set; }
        public Guid CategoryId { get; set; }
    }
}
