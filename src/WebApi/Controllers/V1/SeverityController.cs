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
    public class SeverityController : ControllerBase
    {
        private readonly ISeverityRepository _repo;
        public SeverityController(ISeverityRepository repo)
        {
            _repo = repo;
        }
        // GET: api/Severity
        [HttpGet]
        public IEnumerable<Severity> Get()
        {
            return _repo.SelectAll();
        }

        // GET: api/Severity/5
        [HttpGet("{id}")]
        public Severity Get(int id)
        {
            return _repo.Get(id);
        }

        // POST: api/Severity
        [HttpPost]
        public Severity Post([FromBody] Severity severity)
        {
            _repo.Add(severity);
            return severity;
        }

        // put: api/severity/5
        [HttpPut("{id}")]
        public Severity Put(int id, [FromBody] Severity severity)
        {
            _repo.SaveOrUpdate(severity);
            return severity;
        }

        // delete: api/apiwithactions/5
        [HttpDelete("{id}")]
        public List<Severity> Delete(int id)
        {
            _repo.Delete(x => x.Id == id);
            return _repo.SelectAll();
        }
    }
}
