using Microsoft.AspNetCore.Mvc;
using TryLog.Services.ViewModel;
using TryLog.Services.Interfaces;
using Microsoft.Extensions.Primitives;

namespace TryLog.WebApi.Controllers.V1
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogService _service;
        public LogController(ILogService service)
        {
            _service = service;
        }
        /// <summary>
        /// Listar todos os Logs Registrados
        /// </summary>
        /// <returns></returns>
        // GET: api/Log
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.SelectAll());
        }

        /// <summary>
        /// Retorna o Log solicitado por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Log/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var log = _service.Get(id);

            //if (log is null)
            //    return NoContent();

            return Ok(log);
        }

        /// <summary>
        /// Cria um novo Log
        /// </summary>
        /// <param name="logViewModel"></param>
        /// <returns></returns>
        // POST: api/Log
        [HttpPost]
        public IActionResult Post([FromBody] LogViewModel logViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            Request.Headers.TryGetValue("Authorization", out StringValues token);
            var log = _service.Add(logViewModel, token.ToString());

            if (log is null)
                return NoContent();

            return CreatedAtAction(nameof(Get), new { log.Id }, log);
        }

        /// <summary>
        /// Altera um Log existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="logViewModel"></param>
        /// <returns></returns>
        // PUT: api/Log/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LogViewModel logViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            logViewModel.Id = id;
            bool resultUpdate = _service.Update(logViewModel);

            if (!resultUpdate)
                return NoContent();

            return Ok();
        }

        /// <summary>
        /// Remove um Log existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
