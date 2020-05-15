using Microsoft.AspNetCore.Mvc;
using TryLog.Services.ViewModel;
using TryLog.Services.Interfaces;
using System;
using Microsoft.AspNetCore.Authorization;

namespace TryLog.WebApi.Controllers.V1
{
    [ApiController, Produces("application/json"), Consumes("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class EnvironmentController : ControllerBase
    {
        private readonly IEnvironmentService _service;
        public EnvironmentController(IEnvironmentService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista todos os Ambientes registrados.
        /// </summary>
        /// <returns></returns>
        // GET: api/Environment
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.SelectAll());
        }

        /// <summary>
        /// Retorna o Ambiente solicitado por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Environment/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        /// <summary>
        /// Cria um novo Ambiente.
        /// </summary>
        /// <param name="environmentViewModel"></param>
        /// <returns></returns>
        // POST: api/Environment
        [HttpPost]
        public IActionResult Post([FromBody] EnvironmentViewModel environmentViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var environment = _service.Add(environmentViewModel);

            if (environment is null)
                return NoContent();

            return CreatedAtAction(nameof(Get), new { environment.Id }, environment);
        }

        /// <summary>
        /// Altera um Ambiente existente.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="environmentViewModel"></param>
        /// <returns></returns>
        // PUT: api/Environment/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EnvironmentViewModel environmentViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            environmentViewModel.Id = id;
            bool resultUpdate = _service.Update(environmentViewModel);

            if (!resultUpdate)
                return NoContent();

            return Ok();
        }

        /// <summary>
        /// Remove um Ambiente existente.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool resultDelete = _service.Delete(id);

            if (!resultDelete)
            {
                throw new InvalidOperationException(string.Format(
                "The environment with an ID of '{0}' could not be found. Make sure that environment exists.",
                id));
            }

            return Ok();
        }
    }
}
