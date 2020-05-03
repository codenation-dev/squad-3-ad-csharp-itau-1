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
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _service;
        public StatusController(IStatusService service)
        {
            _service = service;
        }

        // GET: api/Status
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.SelectAll());
        }

        // GET: api/Status/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var status = _service.Get(id);

            if (status is null)
                return NoContent();

            return Ok(status);
        }

        // POST: api/Status
        [HttpPost]
        public IActionResult Post([FromBody] StatusViewModel statusViewModel)
        {
            var status = _service.Add(statusViewModel);

            if (status is null)
                return NoContent();

            return CreatedAtAction(nameof(Get), new { status.Id }, status);
        }

        // PUT: api/Status/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StatusViewModel statusViewModel)
        {
            bool resultUpdate = _service.Update(statusViewModel);

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
