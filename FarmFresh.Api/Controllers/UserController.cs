using FarmFresh.Interfaces.IServices;
using FarmFresh.Models.Request_Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FarmFresh.Api.Controllers
{
    [Authorize, Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [AllowAnonymous, HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestModel model)
        {
            var user = await _userService.GetUserByEmailAsync(model.Email);
            if(user != null)
            {
                return Ok(new
                {
                    isSuccess = false,
                    message = "User Already Exists!"
                });
            }

            var newUser = await _userService.Create(model);

            return Ok(new
            {
                isSuccess = true,
                user = newUser
            });
        }

        [AllowAnonymous, HttpDelete("Delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var user = await _userService.GetUserByIdAsync(id);

            if(user == null)
            {
                return Ok(new
                {
                    isSuccess = false,
                    message = "User does not exist!"
                });
            }
            await _userService.DeleteUserAsync(user);

            return Ok(new
            {
                isSuccess = true
            });
        }
    }
}
