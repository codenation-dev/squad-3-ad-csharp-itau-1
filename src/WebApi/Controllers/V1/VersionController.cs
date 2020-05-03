using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TryLog.WebApi.Controllers.V1
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [ApiController]
    public class VersionController : ControllerBase
    {
        private readonly IConfiguration _config;

        public VersionController(IConfiguration config)
        {
            _config = config;
        }

        //TODO: documentar o motivo deste endpoint
        [HttpGet]
        [Route("api/Version")]
        [AllowAnonymous]
        public string Get()
        {
            //Resolvendo conflito, removi as demais ações neste endpoint.
            //TODO: retornar de maneira anonima a versão da api
            return "Tudo Certo!";
        }

        //TODO: documentar o motivo deste endpoint
        [HttpGet]
        [Route("api/VersionWithAuthirization")]
        [Authorize]
        public string GetWithAuthirization()
        {
            //Resolvendo conflito, removi as demais ações neste endpoint.
            //TODO: retornar de maneira anonima a versão da api
            return "Tudo Certo!";
        }
    }
}
