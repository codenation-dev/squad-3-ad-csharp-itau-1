using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using TryLog.Core.Model;
using TryLog.UseCase;

namespace TryLog.WebApi.Controllers.V1
{
    [ApiController]
    public class VersionController : Controller
    {
        private readonly UserManagerUC _userUC;

        public VersionController(UserManagerUC userUC)
        {
            _userUC = userUC;
        }

        [HttpGet]
        [Route("api/Version")]
        [AllowAnonymous]
        public async Task<ActionResult<object>> Get()
        {
            User newUser = new User("Pedro", "pe", "pedro@gmail.com", "Pedro12!", DateTime.Now, DateTime.Now);
            if (TryValidateModel(newUser))
            {
                return await _userUC.Create(newUser);

            }
            return "Tudo Certo!";
        }
    }
}
