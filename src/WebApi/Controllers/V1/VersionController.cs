using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace TryLog.WebApi.Controllers.V1
{
    [ApiController, Produces("application/json"), Consumes("application/json")]
    [Route("api/[controller]")]
    public class VersionController : ControllerBase
    {
        private readonly IConfiguration _config;
        public VersionController(IConfiguration config)
        {
            _config = config;
        }

        /// <summary>
        /// Retornar de maneira anonima a versão da api.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public string Get()
        {
            return _config.GetValue<string>("ApplicationVersion");
        }
    }
}
