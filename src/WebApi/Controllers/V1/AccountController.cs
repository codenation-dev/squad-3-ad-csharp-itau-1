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

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] UserCreateInView user)
        {
            string callBack = Url.Action("EmailConfirm", "User", null, Request.Scheme);  
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

        [HttpDelete]
        public async Task<IActionResult> Delete(UserDeleteViewModel user)
        {
            return  Ok(await _service.Delete(user));
        }
    }
}
