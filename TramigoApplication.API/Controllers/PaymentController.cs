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
    public class PaymentController : ControllerBase
    {
        //Injection
        private IPaymentInfrastructure _paymentInfrastructure;
        private IPaymentDomain _paymentDomain;
        
        public PaymentController(IPaymentInfrastructure paymentInfrastructure, IPaymentDomain paymentDomain)
        {
            _paymentInfrastructure = paymentInfrastructure;
            _paymentDomain = paymentDomain;
        }
        
        
        // GET: api/Payment
        [HttpGet(Name = "GetPayments")]
        public async Task<IActionResult> Get()
        {
            var list = _paymentInfrastructure.GetAllAsync();
            //if list is empty return notFound
            if (list.Result.Count == 0) return NotFound();
            return Ok(list);
        }

        // GET: api/Payment/5
        [HttpGet("{id}", Name = "GetPayment")]
        public IActionResult Get(int id)
        {
            var payment = _paymentInfrastructure.GetPayment(id);
            if (payment == null) return NotFound();
            return Ok(payment);
        }

        // POST: api/Payment
        [HttpPost]
        public void Post([FromBody] Payment payment)
        {
            _paymentDomain.SavePayment(payment);
        }

        // PUT: api/Payment/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Payment payment)
        {
            _paymentDomain.UpdatePayment(id, payment);
        }

        // DELETE: api/Payment/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _paymentDomain.DeletePayment(id);
        }
    }
}
