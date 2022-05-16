using FarmFresh.Domain.Models;
using FarmFresh.Models.Request_Models;
using FarmFresh.Models.Response_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarmFresh.Models.Mappers_Models
{
    public static class CategoryMapper
    {
        public static Category MapRequestToDomain(this CategoryRequestModel source)
        {
            return new Category
            {
                Id = new Guid(),
                Name = source.Name
            };
        }

        public static List<CategoryResponseModel> MapDomainToResponseList(this List<Category> source)
        {
            var list = new List<CategoryResponseModel>();
            foreach (var category in source)
            {
                var categoryResponseModel = new CategoryResponseModel();
                categoryResponseModel.Id = category.Id;
                categoryResponseModel.Name = category.Name;
                list.Add(categoryResponseModel);
            }

            return list;
        }

    }
}
