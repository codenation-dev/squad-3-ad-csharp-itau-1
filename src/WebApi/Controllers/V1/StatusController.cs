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
    public class StatusController : ControllerBase
    {
        private readonly IStatusService _service;
        public StatusController(IStatusService service)
        {
            _service = service;
        }

        /// <summary>
        /// Lista todos os Status registrados.
        /// </summary>
        /// <returns></returns>
        // GET: api/Status
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.SelectAll());
        }

        /// <summary>
        /// Retorna o Status solicitado por Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Status/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_service.Get(id));
        }

        /// <summary>
        /// Cria um novo Status.
        /// </summary>
        /// <param name="statusViewModel"></param>
        /// <returns></returns>
        // POST: api/Status
        [HttpPost]
        public IActionResult Post([FromBody] StatusViewModel statusViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var status = _service.Add(statusViewModel);

            if (status is null)
                return NoContent();

            return CreatedAtAction(nameof(Get), new { status.Id }, status);
        }

        /// <summary>
        /// Altera um Status existente.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="statusViewModel"></param>
        /// <returns></returns>
        // PUT: api/Status/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] StatusViewModel statusViewModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            statusViewModel.Id = id;
            bool resultUpdate = _service.Update(statusViewModel);

            if (!resultUpdate)
                return NoContent();

            return Ok();
        }

        /// <summary>
        /// Remove um Status existente.
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
                "The product with an ID of '{0}' could not be found.\n"
                + "Make sure that Product exists.\n",
                id));
            }

            return Ok();
        }
    }
}
