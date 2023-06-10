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
    public class ReceiptController : ControllerBase
    {
        //Injection
        private IReceiptInfrastructure _receiptInfrastructure;
        private IReceiptDomain _receiptDomain;

        // GET: api/Receipt
        [HttpGet(Name = "GetReceipts")]
        public async Task<IActionResult> Get()
        {
            var list = await _receiptInfrastructure.GetAllAsync();
            if (list.Count == 0) return NotFound();
            return Ok(list);
        }

        // GET: api/Receipt/5
        [HttpGet("{id}", Name = "GetReceipt")]
        public IActionResult Get(int id)
        {
            var receipt = _receiptInfrastructure.GetReceipt(id);
            if (receipt == null) return NotFound();
            return Ok(receipt);
        }

        // POST: api/Receipt
        [HttpPost]
        public void Post([FromBody] Receipt receipt)
        {
            _receiptDomain.SaveReceipt(receipt);
        }

        // PUT: api/Receipt/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Receipt receipt)
        {
            _receiptDomain.UpdateReceipt(id, receipt);
        }

        // DELETE: api/Receipt/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _receiptDomain.DeleteReceipt(id);
        }
    }
}
