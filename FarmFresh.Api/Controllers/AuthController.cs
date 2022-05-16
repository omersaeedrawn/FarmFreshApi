using FarmFresh.Interfaces.IServices;
using FarmFresh.Models.Request_Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmFresh.Api.Controllers
{
    [Authorize, Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous, HttpPost("login")]
        public async Task<IActionResult> Login ([FromBody] LoginRequestModel model)
        {
            //check email format
            var token = await _authService.Authenticate(model);

            if (token == null)
            {
                return Unauthorized(new
                {
                    message = "Email or password incorrect!"
                });
            }

            return Ok(token);
        }
    }
}
