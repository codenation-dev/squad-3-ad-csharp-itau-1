using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TryLog.Core.Model;
using TryLog.UseCase;
using TryLog.UseCase.DTO;

namespace TryLog.WebApi.Controllers.V1
{
    [ApiController]
    [Route("api/account/")]
    public class AccountController : ControllerBase
    {
        private readonly UserManagerUC _userUC;

        public AccountController(UserManagerUC userUC)
        {
            _userUC = userUC;
        }

        [HttpPost]
        [Route("create")]
        [AllowAnonymous]
        public IActionResult Create([FromBody] User user)
        {
           return Ok(_userUC.Create(user));
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public IActionResult Auth([FromBody] UserAuthDTO userAuth)
        {
            return Ok(_userUC.Login(userAuth));
        }
    }
}
