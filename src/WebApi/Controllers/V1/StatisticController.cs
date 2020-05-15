using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TryLog.Services.Interfaces;
using TryLog.Services.ViewModel;

namespace TryLog.WebApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StatisticController : ControllerBase
    {
        private readonly IStatisticsService _service;
        public StatisticController(IStatisticsService service)
        {
            _service = service;
        }

        // GET: api/Statistics
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_service.Statistics());
        }        
    }
}
