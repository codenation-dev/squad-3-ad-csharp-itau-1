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
            User newUser = new User("Pedro", "pe", "pedro@gmail.com", "Pedro12!", DateTime.UtcNow, DateTime.UtcNow);
            if (TryValidateModel(newUser))
            {
                return await _userUC.Create(newUser);
             }
            return "Tudo Certo!";

        }
    }
}
