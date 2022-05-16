using Microsoft.AspNetCore.Mvc;
using FarmFresh.Models.Request_Models;
using FarmFresh.Interfaces.IServices;
using Microsoft.AspNetCore.Authorization;
using FarmFresh.Models.Response_Models;

namespace FarmFresh.Api.Controllers
{
    [Authorize, Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status404NotFound)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized)]
        //[ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] ProductRequestModel model)
        {
            await _productService.Create(model);
            return Ok();
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllAsync([FromQuery] PaginationFilter filter)
        {
            var productList = await _productService.GetAllAsync(filter);
            return Ok(new
            {
                productList
            });
        }

        [HttpGet("GetByCategoryId")]
        public async Task<IActionResult> GetByCategoryId(Guid id)
        {
            var productList = await _productService.GetByCategoryIdAsync(id);
            return Ok(new
            {
                products = productList
            });
        }

        [HttpPut("Update")]
        public async Task<IActionResult> UpdateAsync([FromBody] ProductResponseModel model)
        {
            var isUpdated = await _productService.UpdateAsync(model);

            if (!isUpdated)
            {
                return Ok(new
                {
                    message = "Could not update Product!"
                });
            }

            return Ok();
        }

        [HttpDelete("Delete")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            var isDeleted = await _productService.DeleteAsync(id);

            if (!isDeleted)
            {
                return Ok(new
                {
                    message = "Product does not exist!"
                });
            }

            return Ok();
        }
    }
}
