using FarmFresh.Domain.Models;
using FarmFresh.Interfaces.IRepositories;
using FarmFresh.Interfaces.IServices;
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
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository repository)
        {
            _productRepository = repository;
        }
        public async Task Create(ProductRequestModel model)
        {
            var oModel = model.MapRequestToDomain();
            await _productRepository.AddAsync(oModel);
            _productRepository.Complete();
        }
        public async Task<PagedResponse<List<Product>>> GetAllAsync(PaginationFilter filter)
        {
            var validFilter = new PaginationFilter(filter.PageNumber, filter.PageSize);

            var data = await _productRepository.GetPaginatedProducts(validFilter);

            return data;
        }

        public async Task<List<ProductResponseModel>> GetByCategoryIdAsync(Guid categoryId)
        {
            var products = await _productRepository.GetAll()
                .Where(p => p.CategoryId == categoryId)
                .ToListAsync();

            return products.MapDomainToResponseList();
        }
        public async Task<bool> UpdateAsync(ProductResponseModel model)
        {
            var product = await _productRepository.Find(x => x.Id.Equals(model.Id))
                                                     .FirstOrDefaultAsync();
            if (product == null)
            {
                return false;
            }

            product.Name = model.Name;
            product.Description = model.Description;
            product.CategoryId = model.CategoryId;
            product.KeyInformation = model.KeyInformation;
            product.Origin = model.Origin;
            product.Quantity = model.Quantity;

            await _productRepository.Update(product);

            return true;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            var product = await _productRepository.Find(c => c.Id.Equals(id))
                                      .FirstOrDefaultAsync();

            if (product == null)
            {
                return false;
            }

            await _productRepository.Remove(product);

            return true;
        }
    }
}
