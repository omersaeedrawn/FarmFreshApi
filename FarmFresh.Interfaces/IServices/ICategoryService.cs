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
    public interface ICategoryService
    {
        Task CreateAsync(CategoryRequestModel model);
        Task<PagedResponse<List<Category>>> GetAllAsync(PaginationFilter filter);
        Task<bool> UpdateAsync(CategoryResponseModel model);
        Task<bool> DeleteAsync(Guid id);
    }
}
