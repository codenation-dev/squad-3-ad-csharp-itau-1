using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TryLog.Services.Interfaces;
using TryLog.Services.ViewModel;

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

        /// <summary>
        /// Lista estatísticas de Erros por horas, semanas e meses.
        /// </summary>
        /// <returns></returns>
        // GET: api/Error
        [HttpGet]
        public IActionResult Get()
        {
            var result = new List<ErrorViewModel>();
            result.Add(_service.GetHoursErrors());
            result.Add(_service.WeeksErrors());
            result.Add(_service.MonthsErrors());
            return Ok(result);
        }
    }
}
