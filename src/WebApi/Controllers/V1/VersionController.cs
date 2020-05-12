using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

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

        /// <summary>
        /// Retorna Versao da Aplicação
        /// </summary>
        /// <returns></returns>
        //TODO: documentar o motivo deste endpoint
        [HttpGet]
        [Route("api/Version")]
        [AllowAnonymous]
        public string Get()
        {
            //TODO: retornar de maneira anonima a versão da api
            return _config.GetValue<string>("ApplicationVersion");
        }

        /// <summary>
        /// Retorna token do Usuario autenticado de acordo com a Versão da Aplicação
        /// </summary>
        /// <returns></returns>
        //TODO: documentar o motivo deste endpoint
        [HttpGet]
        [Route("api/VersionWithAuthorization")]
        [Authorize]
        public string GetWithAuthorization() {
            Request.Headers.TryGetValue("Authorization", out StringValues token);
            //TODO: retornar de maneira autenticada a versão da api
            return string.Format("Version : {0},Token do Usuário Logado:{1}",
                _config.GetValue<string>("ApplicationVersion"), token.ToString());
        }
    }
}
