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

        /// <summary>
        /// Realiza o Login do Usuario
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginViewModel user)
        {
            var userLoginOut = await _service.Login(user);
            return Ok(userLoginOut);
        }

        /// <summary>
        /// Reseta senha do Usuario
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("ResetPassword")]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel resetPassword)
        {
            string callback = Url.Action(nameof(ConfirmPassword), "User", null, Request.Scheme);
            var result = await _service.ResetPassword(resetPassword.Email, callback);
            
            if(result) return Ok();
            
            return NotFound();
        }

        /// <summary>
        /// Confirma senha do Usuario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ConfirmPassword")]
        public async Task<IActionResult> ConfirmPassword(string id, string token)
        {
            return Ok(await _service.ConfirmTokenPasswordReset(id, token));
        }

        /// <summary>
        /// Ativa email do Usuario
        /// </summary>
        /// <param name="email"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Activate")]
        public async Task<IActionResult> Activate(string email, string token)
        {
            return Ok(await _service.Activate(email, token));
        }
    }
}