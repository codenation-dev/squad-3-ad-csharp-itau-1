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
    public class LayerController : ControllerBase
    {
        private readonly ILayerService _service;
        public LayerController(ILayerService service)
        {
            _service = service;
        }

        // GET: api/Layer
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.SelectAll());
        }

        // GET: api/Layer/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        // POST: api/Layer
        [HttpPost]
        public IActionResult Post([FromBody] LayerViewModel layerViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var layer = _service.Add(layerViewModel);

            if (layer is null)
                return NoContent();

            return CreatedAtAction(nameof(Get), new { layer.Id }, layer);
        }

        // PUT: api/Layer/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LayerViewModel layerViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            bool updateResult = _service.Update(layerViewModel);

            if (!updateResult)
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
