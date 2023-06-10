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
    public class CategoryController : ControllerBase
    {
        //Injection
        private ICategoryInfrastructure _categoryInfrastructure;
        private ICategoryDomain _categoryDomain;
        
        public CategoryController(ICategoryInfrastructure categoryInfrastructure, ICategoryDomain categoryDomain)
        {
            _categoryInfrastructure = categoryInfrastructure;
            _categoryDomain = categoryDomain;
        }
        
        
        // GET: api/Category
        [HttpGet(Name = "GetCategories")]
        public async Task<IActionResult> Get()
        {
            var list = await _categoryInfrastructure.GetAllAsync();
            if (list.Count == 0) return NotFound();
            return Ok(list);
        }

        // GET: api/Category/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(int id)
        {
            var category = _categoryInfrastructure.GetCategory(id);
            if (category == null) return NotFound();
            return Ok(category);
        }

        // POST: api/Category
        [HttpPost]
        public void Post([FromBody] Category category)
        {
            _categoryDomain.SaveCategory(category);
        }

        // PUT: api/Category/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Category category)
        {
            _categoryDomain.UpdateCategory(id, category);
        }

        // DELETE: api/Category/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _categoryDomain.DeleteCategory(id);
        }
    }
}
