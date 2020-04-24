using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TryLog.Core.Interfaces;
using Environment = TryLog.Core.Model.Environment;

namespace TryLog.WebApi.Controllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironmentController : ControllerBase
    {
        private readonly IEnvironmentRepository _repo;
        public EnvironmentController(IEnvironmentRepository repo)
        {
            _repo = repo;
        }
        // GET: api/Environment
        [HttpGet]
        public IEnumerable<Environment> Get()
        {
            return _repo.SelectAll();
        }

        // GET: api/Environment/5
        [HttpGet("{id}")]
        public Environment Get(int id)
        {
            return _repo.Get(id);
        }

        // POST: api/Environment
        [HttpPost]
        public Environment Post([FromBody] Environment environment)
        {
            _repo.Add(environment);
            return environment;
        }

        // PUT: api/Environment/5
        [HttpPut("{id}")]
        public Environment Put(int id, [FromBody] Environment environment)
        {
            _repo.SaveOrUpdate(environment);
            return environment;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<Environment> Delete(int id)
        {
            _repo.Delete(x => x.Id == id);
            return _repo.SelectAll();
        }
    }
}
