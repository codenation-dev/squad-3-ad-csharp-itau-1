using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TryLog.Services.Interfaces;

namespace TryLog.WebApi.Controllers.V1
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ErrorController : ControllerBase
    {
        private readonly IErrorService _service;
        public ErrorController(IErrorService service)
        {
            _service = service;
        }

        // GET: api/Error
        [HttpGet]
        [Route("hours")]
        public IActionResult Get()
        {
            return Ok(_service.HoursErrors());
        }

        // GET: api/Error
        [HttpGet]
        [Route("Mouth")]
        public IActionResult GetMouth()
        {
            return Ok(_service.MonthsErrors());
        }

        //// GET: api/Error/5
        //[HttpGet("{id}")]
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Error
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT: api/Error/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE: api/ApiWithActions/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
