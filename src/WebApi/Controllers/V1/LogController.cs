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
    public class LogController : ControllerBase
    {
        private readonly ILogUC _uC;
        public LogController(ILogUC uC)
        {
            _uC = uC;
        }
        // GET: api/Log
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_uC.SelectAll());
        }

        // GET: api/Log/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var log = _uC.Get(id);
            
            if (log is null)
                return NoContent();

            return Ok(log); 
        }

        // POST: api/Log
        [HttpPost]
        public IActionResult Post([FromBody] LogDTO logDTO)
        {
            _uC.Add(logDTO);
            return Ok();
        }

        // PUT: api/Log/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] LogDTO logDTO)
        {
            _uC.SaveOrUpdate(logDTO);
            return Ok(logDTO);
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
