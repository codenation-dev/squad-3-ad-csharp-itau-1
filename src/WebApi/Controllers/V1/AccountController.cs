using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TryLog.Services;
using TryLog.Services.ViewModel;

namespace TryLog.WebApi.Controllers.V1
{
    [Authorize]
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManagerService _service;

        public AccountController(UserManagerService service)
        {
            _service = service;
        }

        /// <summary>
        /// Cria um conta de usuário.
        /// </summary>
        /// <param name="user"></param>
        /// <returns>ActionResult</returns>
        /// <response code="201">Se a conta de usuário foi criada com sucesso.</response>
        /// <response code="404">Se os dados para cadastro não forem válidos.</response>
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] UserCreateView user)
        {
            string callBack = Url.Action("Activate", "User", null, Request.Scheme);  
            var userCreateOut = await _service.Create(user, callBack);

            if (userCreateOut is null) 
                return NotFound(new { message = "Invalid username or password."});

            return Ok(new { message = userCreateOut.Description });
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.Get());
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserUpdateView user)
        {
            return Ok(await _service.Update(user));
        }
        // DELETE api/account
        /// <summary>
        /// Define a propriedade Delete e EmailConfirmed para false.
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna string indicando sucesso.</response>
        /// <response code="204">Se o usuário não existir ou não estiver autenticado.</response>  
        [HttpDelete]
        public async Task<IActionResult> Delete(UserDeleteViewModel user)
        {
            return  Ok(await _service.Delete(user));
        }
    }
}
