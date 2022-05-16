using FarmFresh.Domain.Models;
using FarmFresh.Interfaces.IRepositories;
using FarmFresh.Interfaces.IServices;
using FarmFresh.Models.Mappers_Models;
using FarmFresh.Models.Request_Models;
using FarmFresh.Models.Response_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Service.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRespository;

        public CategoryService(ICategoryRepository categoryRespository)
        {
            _categoryRespository = categoryRespository;
        }

        public async Task CreateAsync(CategoryRequestModel model)
        {
            await _categoryRespository.AddAsync(model.MapRequestToDomain());
            _categoryRespository.Complete();
        }
        public async Task<PagedResponse<List<Category>>> GetAllAsync(PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var data = await _categoryRespository.GetPaginatedCategories(validFilter);

            return data;
        }

        public async Task<bool> UpdateAsync(CategoryResponseModel model)
        {
            var category = await _categoryRespository.Find(x => x.Id.Equals(model.Id))
                                                     .FirstOrDefaultAsync();
            if(category == null)
            {
                return false;
            }

            category.Name = model.Name;

            await _categoryRespository.Update(category);

            return true;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var category = await _categoryRespository.Find(c => c.Id.Equals(id))
                                      .FirstOrDefaultAsync();

            if(category == null)
            {
                return false;
            }

            await _categoryRespository.Remove(category);

            return true;
        }
    }
}
