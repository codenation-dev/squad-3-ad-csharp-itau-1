using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TryLog.Services;
using TryLog.Services.ViewModel;

namespace TryLog.WebApi.Controllers.V1
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManagerService _service;

        public UserController(UserManagerService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginInViewModel user)
        {
            var userLoginOut = await _service.Login(user);
            return Ok(userLoginOut);
        }
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPassword)
        {
            string callback = Url.Action(nameof(ConfirmPassword), "User", null, Request.Scheme);
            var result = await _service.ResetPassword(resetPassword.Email, callback);
            
            if(result) return Ok();
            
            return NotFound();
        }

        [HttpGet]
        [Route("ConfirmPassword")]
        public async Task<IActionResult> ConfirmPassword(string id, string token)
        {
            return Ok(await _service.ConfirmTokenPasswordReset(id, token));
        }

        [HttpGet]
        [Route("EmailConfirm")]
        public async Task<IActionResult> EmailConfirm(string id, string token)
        {
            return Ok(await _service.ConfirmTokenEmail(id, token));
        }
    }
}