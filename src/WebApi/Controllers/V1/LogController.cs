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
using Microsoft.Extensions.Primitives;
using Microsoft.AspNetCore.Authorization;

namespace TryLog.WebApi.Controllers.V1
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class LogController : ControllerBase
    {
        private readonly ILogService _service;
        public LogController(ILogService service)
        {
            _service = service;
        }
        // GET: api/Log
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.SelectAll());
        }

        // GET: api/Log/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var log = _service.Get(id);

            if (log is null)
                return NoContent();

            return Ok(log);
        }

        // POST: api/Log
        [HttpPost]
        public IActionResult Post([FromBody] LogViewModel logViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            Request.Headers.TryGetValue("Authorization", out StringValues token);

            var test = token.ToString().Replace("Bearer ","");

            var log = _service.Add(logViewModel);

            if (log is null)
                return NoContent();

            return CreatedAtAction(nameof(Get), new { log.Id }, log);
        }

        // PUT: api/Log/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LogViewModel logViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool resultUpdate = _service.Update(logViewModel);

            if (!resultUpdate)
                return NoContent();

            return Ok();
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
