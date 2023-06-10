using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TramigoApplication.Domain;
using TramigoApplication.Infrastructure;
using TramigoApplication.Infrastructure.Models;

namespace TramigoApplication.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedureController : ControllerBase
    {
        //Injection
        private IProcedureInfrastructure _procedureInfrastructure;
        private IProcedureDomain _procedureDomain;
        
        public ProcedureController(IProcedureInfrastructure procedureInfrastructure, IProcedureDomain procedureDomain)
        {
            _procedureInfrastructure = procedureInfrastructure;
            _procedureDomain = procedureDomain;
        }

        // GET: api/Procedure
        [HttpGet(Name = "GetProcedures")]
        public async Task<IActionResult> Get()
        {
            var list = await _procedureInfrastructure.GetAllAsync();
            if (list.Count == 0) return NotFound();
            return Ok(list);
        }

        // GET: api/Procedure/5
        [HttpGet("{id}", Name = "GetProcedure")]
        public IActionResult Get(int id)
        {
            var procedure = _procedureInfrastructure.GetProcedure(id);
            if (procedure == null) return NotFound();
            return Ok(procedure);
        }

        // POST: api/Procedure
        [HttpPost]
        public void Post([FromBody] Procedure procedure)
        {
            _procedureDomain.SaveProcedure(procedure);
        }

        // PUT: api/Procedure/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Procedure procedure)
        {
            _procedureDomain.UpdateProcedure(id, procedure);
        }

        // DELETE: api/Procedure/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _procedureDomain.DeleteProcedure(id);
        }
    }
}
