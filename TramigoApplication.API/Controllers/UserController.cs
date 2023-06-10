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
    public class UserController : ControllerBase
    {
        //Injection
        private IUserInfrastructure _userInfrastructure;
        private IUserDomain _userDomain;
        
        public UserController(IUserInfrastructure userInfrastructure, IUserDomain userDomain)
        {
            _userInfrastructure = userInfrastructure;
            _userDomain = userDomain;
        }
        
        // GET: api/User
        [HttpGet(Name = "GetUsers")]
        public IActionResult Get()
        {
            var list = _userInfrastructure.GetAll();
            //if list is empty return notFound
            if (list.Count == 0) return NotFound();
            return Ok(list);
            
        }

        // GET: api/User/5
        [HttpGet("{id}", Name = "User")]
        public IActionResult Get(int id)
        {
            var user = _userInfrastructure.GetUser(id);
            if (user == null) return NotFound();
            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] User user)
        {
            //log in console
            _userDomain.SaveUser(user);
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] User user)
        {
            _userDomain.UpdateUser(id, user);
        }

        // DELETE: api/User/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _userDomain.DeleteUser(id);
        }
    }
}
