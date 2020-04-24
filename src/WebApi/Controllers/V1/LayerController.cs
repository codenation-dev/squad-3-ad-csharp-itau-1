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
    public class LayerController : ControllerBase
    {
        private readonly ILayerRepository _repo;
        public LayerController(ILayerRepository repo)
        {
            _repo = repo;
        }
        // GET: api/Layer
        [HttpGet]
        public IEnumerable<Layer> Get()
        {
            return _repo.SelectAll();
        }

        // GET: api/Layer/5
        [HttpGet("{id}")]
        public Layer Get(int id)
        {
            return _repo.Get(id);
        }

        // POST: api/Layer
        [HttpPost]
        public Layer Post([FromBody] Layer layer)
        {
            _repo.Add(layer);
            return layer;
        }

        // PUT: api/Layer/5
        [HttpPut("{id}")]
        public Layer Put(int id, [FromBody] Layer layer)
        {
            _repo.SaveOrUpdate(layer);
            return layer;
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public List<Layer> Delete(int id)
        {
            _repo.Delete(x => x.Id == id);
            return _repo.SelectAll();
        }
    }
}
