using FarmFresh.Domain.Models;
using FarmFresh.Models.Request_Models;
using FarmFresh.Models.Response_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Interfaces.IServices
{
    public interface IProductService
    {
        Task Create(ProductRequestModel productRequestDto);
        Task<PagedResponse<List<Product>>> GetAllAsync(PaginationFilter filter);
        Task<List<ProductResponseModel>> GetByCategoryIdAsync(Guid categoryId);
        Task<bool> UpdateAsync(ProductResponseModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}
