using FarmFresh.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Models.Response_Models
{
    public class CategoryDataResult
    {
        public IEnumerable<Category> Categories { get; set; }
        public int Count { get; set; }
    }
}
