using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TryLog.Services.App;
using TryLog.Services.ViewModel;

namespace TryLog.WebApi.Controllers.V1
{
    [ApiController, Produces("application/json"), Consumes("application/json")]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserManagerService _service;
        public UserController(UserManagerService service)
        {
            _service = service;
        }

        /// <summary>
        /// Realiza o Login do usuário.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] UserLoginViewModel user)
        {
            var userLoginOut = await _service.Login(user);
            return Ok(userLoginOut);
        }

        /// <summary>
        /// Reseta senha do usuário.
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns>Envia email com token para reset de senha.</returns>
        [HttpPost]
        [Route("forgotpassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ForgotPassword(ResetPasswordViewModel resetPassword)
        {
            string callback = Url.Action(nameof(ConfirmPassword), "User", null, Request.Scheme);
            var result = await _service.ResetPassword(resetPassword.Email, callback);

            if (result) return Ok();

            return NotFound();
        }

        /// <summary>
        /// Confirma token de reset de senha.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("ConfirmPassword")]
        [AllowAnonymous]
        public async Task<IActionResult> ConfirmPassword(string id, string token)
        {
            return Ok(await _service.ConfirmTokenPasswordReset(id, token));
        }

        /// <summary>
        /// Confirma token de (re)ativação de conta.
        /// </summary>
        /// <param name="email"></param>
        /// <param name="token"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Activate")]
        [AllowAnonymous]
        public async Task<IActionResult> Activate(string email, string token)
        {
            return Ok(await _service.Activate(email, token));
        }

        /// <summary>
        /// Reativa usuário deletado/desativado.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Envia email com token para reativação da conta.</returns>
        [HttpPost]
        [Route("sendreactivationemail")]
        [AllowAnonymous]
        public async Task<IActionResult> SendReactivationEmail(UserReactivateAccountView user)
        {
            string callback = Url.Action(nameof(Activate), "User", null, Request.Scheme);
            var result = await _service.SendReactivationEmail(user, callback);
            if (result) return Ok(new
            {
                result = "Reactivation email sent.",
                message = "Waiting for confirmation."
            });
            return Ok(new
            {
                result = "Failed.",
                message = "Non-inactive user."
            });
        }
        /// <summary>
        /// Troca senha do usuário logado.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>Código de status mensagem.</returns>
        [HttpPut]
        [Route("changepassword")]
        [Authorize]
        public async Task<IActionResult> ChangePassword(UserChangePasswordViewModel user)
        {
            var result = await _service.ChangePassword(user);
            return StatusCode(result.Code, new { message = result.Description });
        }
    }
}