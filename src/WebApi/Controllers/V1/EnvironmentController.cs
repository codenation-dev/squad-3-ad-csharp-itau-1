using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TryLog.Core.Interfaces;
using TryLog.UseCase.DTO;
using TryLog.UseCase.Interfaces;
using Environment = TryLog.Core.Model.Environment;

namespace TryLog.WebApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironmentController : ControllerBase
    {
        private readonly IEnvironmentUC _uC;
        public EnvironmentController(IEnvironmentUC uC)
        {
            _uC = uC;
        }

        // GET: api/Environment
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_uC.SelectAll());
        }

        // GET: api/Environment/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var environment =_uC.Get(id);
            
            if (environment is null)
                return NoContent();

            return Ok(environment);
        }

        // POST: api/Environment
        [HttpPost]
        public IActionResult Post([FromBody] EnvironmentDTO environmentDTO)
        {
            var environment = _uC.Add(environmentDTO);
            
            if (environment is null)
                return NoContent();

            return CreatedAtAction(nameof(Get), new { environment.Id}, environment);
        }

        // PUT: api/Environment/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EnvironmentDTO environmentDTO)
        {
           bool resultUpdate = _uC.Update(environmentDTO);
           
            if (!resultUpdate)
                return NoContent();
            
            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _uC.Delete(id);
            return Ok();
        }
    }
}
