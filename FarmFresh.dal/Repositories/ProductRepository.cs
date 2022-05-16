using FarmFresh.Domain.Models;
using FarmFresh.Interfaces.IRepositories;
using FarmFresh.Models.Request_Models;
using FarmFresh.Models.Response_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Repository.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(FarmFreshDbContext conetxt):base(conetxt)
        {}

        public async Task<PagedResponse<List<Product>>> GetPaginatedProducts(PaginationFilter validFilter)
        {
            var pagedData = await _context.Products
               .Skip((validFilter.PageNumber - 1) * validFilter.PageSize)
               .Take(validFilter.PageSize)
               .ToListAsync();

            var totalRecords = await _context.Products.CountAsync();

            return new PagedResponse<List<Product>>(pagedData, totalRecords, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
