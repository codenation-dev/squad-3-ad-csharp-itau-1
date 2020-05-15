using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using TryLog.Services.App;
using TryLog.Services.ViewModel;

namespace TryLog.WebApi.Controllers.V1
{
    [ApiController, Produces("application/json"), Consumes("application/json")]
    [Route("api/[controller]")]
    [Authorize]
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

        /// <summary>
        /// Retorna dados do usuário logado.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _service.Get());
        }

        /// <summary>
        /// Atribui novos valores para o usuário logado.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] UserUpdateView user)
        {
            return Ok(await _service.Update(user));
        }

        /// <summary>
        /// Remove o usuário logado.
        /// </summary>
        /// <returns>ActionResult</returns>
        /// <response code="200">Retorna uma string com o resultado.</response>
        [HttpDelete]
        public async Task<IActionResult> Delete(UserDeleteViewModel user)
        {
            return  Ok(await _service.Delete(user));
        }
    }
}
