using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TryLog.Core.Model;
using TryLog.Services;
using TryLog.Services.ViewModel;

namespace TryLog.WebApi.Controllers.V1
{
    [ApiController]
    [Route("api/account/")]
    public class AccountController : ControllerBase
    {
        private readonly UserManagerService _service;

        public AccountController(UserManagerService service)
        {
            _service = service;
        }

        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody] User user)
        {
            return Ok(_service.Create(user));
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Auth([FromBody] UserAuthViewModel userAuth)
        {
            return Ok(_service.Login(userAuth));
        }
    }
}
