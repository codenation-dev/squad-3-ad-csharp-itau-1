using System;
using Microsoft.AspNetCore.Mvc;
using TryLog.Services.ViewModel;
using TryLog.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;

namespace TryLog.WebApi.Controllers.V1
{
    [ApiController, Produces("application/json"), Consumes("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    public class LayerController : ControllerBase
    {
        private readonly ILayerService _service;
        public LayerController(ILayerService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista todas as Camadas registradas.
        /// </summary>
        /// <returns></returns>
        // GET: api/Layer
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.SelectAll());
        }

        /// <summary>
        /// Retorna a Camada solicitada por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Layer/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        /// <summary>
        /// Cria uma nova Camada.
        /// </summary>
        /// <param name="layerViewModel"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Altera uma Camada existente.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="layerViewModel"></param>
        /// <returns></returns>
        // PUT: api/Layer/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LayerViewModel layerViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            layerViewModel.Id = id;
            bool updateResult = _service.Update(layerViewModel);

            if (!updateResult)
                return NoContent();

            return Ok();
        }

        /// <summary>
        /// Remove uma Camada existente.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var resultDelete = _service.Delete(id);
            
            if (!resultDelete)
            {
                throw new InvalidOperationException(string.Format(
                "The layer with an ID of '{0}' could not be found. Make sure that layer exists.",
                id));
            }

            return Ok();
        }
    }
}
