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
    public class LayerController : ControllerBase
    {
        private readonly ILayerUC _uC;
        public LayerController(ILayerUC uC)
        {
            _uC = uC;
        }

        // GET: api/Layer
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_uC.SelectAll());
        }

        // GET: api/Layer/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_uC.Get(id));
        }

        // POST: api/Layer
        [HttpPost]
        public IActionResult Post([FromBody] LayerDTO layerDTO)
        {
            var layer = _uC.Add(layerDTO);
            
            if (layer is null)
                return NoContent();

            return CreatedAtAction(nameof(Get), new { layer.Id }, layer);
        }

        // PUT: api/Layer/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LayerDTO layerDTO)
        {
            bool updateResult = _uC.Update(layerDTO);

            if (!updateResult)
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
