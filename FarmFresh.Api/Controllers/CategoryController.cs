using FarmFresh.Interfaces.IServices;
using FarmFresh.Models.Request_Models;
using FarmFresh.Models.Response_Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmFresh.Api.Controllers
{
    [Authorize, Route("api/[controller]")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CategoryRequestModel model)
        {
            await _categoryService.CreateAsync(model);
            return Ok();
        }

        [HttpPost("GetAll")]
        public async Task<IActionResult> GetAllAsync([FromBody] PaginationFilter filter)
        {
            var categoryList = await _categoryService.GetAllAsync(filter);
            return Ok(new
            {
                categoryList
            });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] CategoryResponseModel model)
        {
            var isUpdated = await _categoryService.UpdateAsync(model);

            if (!isUpdated)
            {
                return Ok(new
                {
                    message = "Could not update Category!"
                });
            }

            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var isDeleted = await _categoryService.DeleteAsync(id);

            if (!isDeleted)
            {
                return Ok(new
                {
                    message = "Category does not exist!"
                });
            }

            return Ok();
        }
    }
}
