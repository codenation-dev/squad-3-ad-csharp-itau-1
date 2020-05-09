using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TryLog.Core.Interfaces;
using TryLog.Services.ViewModel;
using TryLog.Services.Interfaces;
using Environment = TryLog.Core.Model.Environment;
using Microsoft.Data.SqlClient;
using System.Text;
using AutoMapper;

namespace TryLog.WebApi.Controllers.V1
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EnvironmentController : ControllerBase
    {
        private readonly IEnvironmentService _service;
        private readonly IDefaultService<Environment> _serviceEnvironment;
        private readonly IMapper _mapper;
        public EnvironmentController(IEnvironmentService service, IDefaultService<Environment> serviceEnvironment, IMapper mapper)
        {
            _service = service;
            _serviceEnvironment = serviceEnvironment;
            _mapper = mapper;
        }

        // GET: api/Environment
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_service.SelectAll());
            }
            catch (Exception ex)
            {
                throw new Exception(
                "Message: " + ex.Message + "\n" +
                "LineNumber: " + ex.StackTrace + "\n"
                );
            }
        }

        // GET: api/Environment/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var environment = _service.Get(id);

            if (environment is null)
                return NoContent();

            return Ok(environment);
        }

        // POST: api/Environment
        [HttpPost]
        public IActionResult Post([FromBody] EnvironmentViewModel environmentDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                //var environment = _service.Add(environmentDTO);
                var env = _mapper.Map<Environment>(environmentDTO);
                var environment = _mapper.Map<EnvironmentViewModel>(_serviceEnvironment.Add(env));

                if (environment is null)
                    return NoContent();

                return CreatedAtAction(nameof(Get), new { environment.Id }, environment);
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                    "Message: " + ex.Errors[i].Message + "\n" +
                    "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                    "Source: " + ex.Errors[i].Source + "\n" +
                    "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                throw new Exception(errorMessages.ToString());
            }

            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //var environment = _service.Add(environmentDTO);

            //if (environment is null)
            //    return NoContent();

            //return CreatedAtAction(nameof(Get), new { environment.Id }, environment);
        }

        // PUT: api/Environment/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EnvironmentViewModel environmentDTO)
        {
            //if (!ModelState.IsValid)
            //    return BadRequest(ModelState);

            //bool resultUpdate = _service.Update(environmentDTO);

            //if (!resultUpdate)
            //    return NoContent();

            //return Ok();

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                bool resultUpdate = _service.Update(environmentDTO);

                if (!resultUpdate)
                    return NoContent();

                return Ok();
            }
            catch (SqlException ex)
            {
                StringBuilder errorMessages = new StringBuilder();
                for (int i = 0; i < ex.Errors.Count; i++)
                {
                    errorMessages.Append("Index #" + i + "\n" +
                    "Message: " + ex.Errors[i].Message + "\n" +
                    "LineNumber: " + ex.Errors[i].LineNumber + "\n" +
                    "Source: " + ex.Errors[i].Source + "\n" +
                    "Procedure: " + ex.Errors[i].Procedure + "\n");
                }
                throw new Exception(errorMessages.ToString());
            }
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _service.Delete(id);
            return Ok();
        }
    }
}
