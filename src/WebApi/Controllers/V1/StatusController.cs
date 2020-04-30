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
    public class StatusController : ControllerBase
    {
        private readonly IStatusUC _uC;
        public StatusController(IStatusUC uC)
        {
            _uC = uC;
        }

        // GET: api/Status
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_uC.SelectAll());
        }

        // GET: api/Status/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var status = _uC.Get(id);
            
            if (status is null)
                return NoContent();
            
            return Ok(status);
        }

        // POST: api/Status
        [HttpPost]
        public IActionResult Post([FromBody] StatusDTO statusDTO)
        {
            var status = _uC.Add(statusDTO);
            
            if (status is null)
                return NoContent();

            return CreatedAtAction(nameof(Get), new { status.Id }, status);
        }

        // PUT: api/Status/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StatusDTO statusDTO)
        {
            bool resultUpdate = _uC.Update(statusDTO);
            
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
