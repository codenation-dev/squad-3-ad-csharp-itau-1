using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using TryLog.Core.Interfaces;
using TryLog.Infraestructure.EF;

namespace TryLog.WebApi.Controllers.V1
{
    public class VersionController : ControllerBase
    {
        IConfiguration _config;
        IEventRepository _eventRepo;
        public VersionController(IConfiguration config, IEventRepository eventRepo)
        {
            _config = config;
            _eventRepo = eventRepo;
        }
        [HttpGet]
        [Route("api/Version")]
        [AllowAnonymous]
        public string Get()
        {
            _eventRepo.Add(new Core.Model.Event()
            {
                Layer = new Core.Model.Layer()
                {
                    Description = "Layer 1"
                }
            });

            var allEvents = _eventRepo.Find(x => true);

            return _config.GetSection("ApplicationVersion").Value;
        }
    }
}
