using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TryLog.Core.Interfaces;
using TryLog.Core.Model;

namespace TryLog.WebApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly ILogRepository _repo;
        public LogController(ILogRepository repo)
        {
            _repo = repo;
        }
        // GET: api/Log
        [HttpGet]
        public IEnumerable<Log> Get()
        {
            return _repo.SelectAll();
        }

        // GET: api/Log/5
        [HttpGet("{id}")]
        public Log Get(int id)
        {
            return _repo.Get(id);
        }

        // POST: api/Log
        [HttpPost]
        public Log Post([FromBody] Log log)
        {
            _repo.Add(log);
            return log;
        }

        // PUT: api/Log/5
        [HttpPut("{id}")]
        public Log Put(int id, [FromBody] Log log)
        {
            _repo.SaveOrUpdate(log);
            return log;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<Log> Delete(int id)
        {
            _repo.Delete(x => x.Id == id);
            return _repo.SelectAll();
        }
    }
}
