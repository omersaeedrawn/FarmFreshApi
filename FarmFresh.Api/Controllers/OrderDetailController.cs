using FarmFresh.Interfaces.IServices;
using FarmFresh.Models.Request_Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmFresh.Api.Controllers
{
    [Authorize, Route("api/[controller]")]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] OrderDetailRequestModel model)
        {
            await _orderDetailService.CreateAsync(model);
            return Ok();
        }

        [HttpGet("GetByIdAsync")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var orderDetail = await _orderDetailService.GetByIdAsync(id);

            if(orderDetail == null)
            {
                return NotFound();
            }
            return Ok(
                orderDetail
            );
        }
    }
}
