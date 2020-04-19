using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Threading.Tasks;
using System.Web;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;
using TryLog.Infraestructure.EF;
using TryLog.Infraestructure.Repository;
using TryLog.UseCase;

namespace TryLog.WebApi.Controllers.V1
{
    [ApiController]
    public class VersionController : ControllerBase
    {
        private readonly UserManagerUC _userUC;

        public VersionController(UserManagerUC userUC)
        {
            _userUC = userUC;
        }

        [HttpGet]
        [Route("api/Version")]
        [Authorize]
        public string Get()
        {            
            return "Tudo Certo!";

        }
    }
}
