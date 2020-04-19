using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TryLog.Core.Model;
using TryLog.UseCase;

namespace TryLog.WebApi.Controllers.V1
{
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManagerUC _userUC;

        public AccountController(UserManagerUC userUC)
        {
            _userUC = userUC;
        }

        [HttpPost]
        [Route("api/account")]
        [AllowAnonymous]
        public async Task<ActionResult<object>> Post()
        {
            User newUser = new User("Nick", "Nicolas Silva", "nixc@gmail.com", "wdqD32$sd", DateTime.UtcNow, DateTime.UtcNow);
            bool result = TryValidateModel(newUser);
            if (result)
            {
                var x= await _userUC.Create(newUser);
                return x;
             }
            return "Tudo Certo!";
        }
    }
}
