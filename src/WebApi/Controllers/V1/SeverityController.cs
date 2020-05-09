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

        // GET: api/Severity
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.SelectAll());
        }

        // GET: api/Severity/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var severity = _service.Get(id);

            if (severity is null)
                return NoContent();

            return Ok(severity);
        }

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

        // put: api/severity/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SeverityViewModel severityViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool resultUpdate = _service.Update(severityViewModel);

            if (!resultUpdate)
                return NoContent();

            return Ok();
        }

        // delete: api/apiwithactions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
