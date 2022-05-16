using FarmFresh.Domain.Models;
using FarmFresh.Models.Request_Models;
using FarmFresh.Models.Response_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Interfaces.IRepositories
{
    public interface IProductRepository : IRepository<Product, Guid>
    {
        Task<PagedResponse<List<Product>>> GetPaginatedProducts(PaginationFilter validFilter);
    }
}
