using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;
using TryLog.UseCase.DTO;
using TryLog.UseCase.Interfaces;

namespace TryLog.WebApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeverityController : ControllerBase
    {
        private readonly ISeverityUC _uC;
        public SeverityController(ISeverityUC uC)
        {
            _uC = uC;
        }

        // GET: api/Severity
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_uC.SelectAll());
        }

        // GET: api/Severity/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var severity = _uC.Get(id);

            if (severity is null)
                return NoContent();

            return Ok(severity); 
        }

        // POST: api/Severity
        [HttpPost]
        public IActionResult Post([FromBody] SeverityDTO severityDTO)
        {
            var severity = _uC.Add(severityDTO);
            
            if (severity is null)
                return NoContent();

            return CreatedAtAction(nameof(Get), new { severity.Id }, severity);
        }

        // put: api/severity/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] SeverityDTO severityDTO)
        {
            bool resultUpdate = _uC.Update(severityDTO);
            
            if (!resultUpdate)
                return NoContent();

            return Ok();
        }

        // delete: api/apiwithactions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _uC.Delete(id);
            return Ok();
        }
    }
}
