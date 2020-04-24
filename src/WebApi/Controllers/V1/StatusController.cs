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
    public class StatusController : ControllerBase
    {
        private readonly IStatusRepository _repo;
        public StatusController(IStatusRepository repo)
        {
            _repo = repo;
        }
        // GET: api/Status
        [HttpGet]
        public IEnumerable<Status> Get()
        {
            return _repo.SelectAll();
        }

        // GET: api/Status/5
        [HttpGet("{id}")]
        public Status Get(int id)
        {
            return _repo.Get(id);
        }

        // POST: api/Status
        [HttpPost]
        public Status Post([FromBody] Status status)
        {
            _repo.Add(status);
            return status;
        }

        // PUT: api/Status/5
        [HttpPut("{id}")]
        public Status Put(int id, [FromBody] Status status)
        {
            _repo.SaveOrUpdate(status);
            return status;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<Status> Delete(int id)
        {
            _repo.Delete(x => x.Id == id);
            return _repo.SelectAll();
        }
    }
}
