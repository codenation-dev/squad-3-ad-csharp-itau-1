using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;
using TryLog.Services.ViewModel;
using TryLog.Services.Interfaces;

namespace TryLog.WebApi.Controllers.V1
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SeverityController : ControllerBase
    {
        private readonly ISeverityService _service;
        public SeverityController(ISeverityService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista todas as Severidades registradas
        /// </summary>
        /// <returns></returns>
        // GET: api/Severity
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.SelectAll());
        }

        /// <summary>
        /// Retorna a Severidade por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Severity/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        /// <summary>
        /// Cria uma nova Severidade
        /// </summary>
        /// <param name="severityViewModel"></param>
        /// <returns></returns>
        // POST: api/Severity
        [HttpPost]
        public IActionResult Post([FromBody] SeverityViewModel severityViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var severity = _service.Add(severityViewModel);

            if (severity is null)
                return NoContent();

            return CreatedAtAction(nameof(Get), new { severity.Id }, severity);
        }

        /// <summary>
        /// Altera uma Severidade existente
        /// </summary>
        /// <param name="id"></param>
        /// <param name="severityViewModel"></param>
        /// <returns></returns>
        // put: api/severity/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SeverityViewModel severityViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            severityViewModel.Id = id;
            bool resultUpdate = _service.Update(severityViewModel);

            if (!resultUpdate)
                return NoContent();

            return Ok();
        }

        /// <summary>
        /// Remove uma Severidade existente
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // delete: api/apiwithactions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var resultDelete = _service.Delete(id);

            if (!resultDelete)
            {
                throw new InvalidOperationException(string.Format(
                "The product with an ID of '{0}' could not be found.\n"
                + "Make sure that Product exists.\n",
                id));
            }

            return Ok();
        }
    }
}
