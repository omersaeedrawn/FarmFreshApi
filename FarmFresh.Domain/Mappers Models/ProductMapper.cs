using FarmFresh.Domain.Models;
using FarmFresh.Models.Response_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Models.Request_Models
{
    public static class ProductMapper
    {
        public static Product MapRequestToDomain(this ProductRequestModel source)
        {
            return new Product
            {
                Id = Guid.NewGuid(),
                Name = source.Name,
                Description = source.Description,
                Origin = source.Origin,
                KeyInformation = source.KeyInformation,
                Quantity = source.Quantity,
                CategoryId = source.CategoryId
            };
        }

        public static List<ProductResponseModel> MapDomainToResponseList(this List<Product> source)
        {
            var list = new List<ProductResponseModel>();
            foreach (var product in source)
            {
                var categoryResponseModel = new ProductResponseModel();
                categoryResponseModel.Id = product.Id;
                categoryResponseModel.Name = product.Name;
                categoryResponseModel.Description = product.Description;
                categoryResponseModel.Origin = product.Origin;
                categoryResponseModel.KeyInformation = product.KeyInformation;
                categoryResponseModel.Quantity = product.Quantity;
                categoryResponseModel.CategoryId = product.CategoryId;
                list.Add(categoryResponseModel);
            }

            return list;
        }
    }
}
