using System.Net;
using Customers.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Customers.Api.Controllers
{
    [ApiController]
    [Route("customers")]
    public class CustomerController : ControllerBase
    {
        private readonly IRepository<Customer> _customerRepository;

        public CustomerController(IRepository<Customer> customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet()]
        [ProducesResponseType(typeof(IEnumerable<Customer>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _customerRepository.GetAllAsync());
        }

        [HttpGet("{id:guid}")]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> GetById(Guid id)
        {
            var person = await _customerRepository.GetByIdAsync(id);

            if(person == null)
                return NoContent();

            return Ok(person);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.Created)]
        public async Task<IActionResult> Post(Customer customer)
        {
            customer.Id = Guid.NewGuid();
            _customerRepository.Add(customer);
            await _customerRepository.SaveChangesAsync();
            return Created($"/{customer.Id}", customer);
        }

        [HttpPut("{id:guid}")]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public async Task<IActionResult> Put(Guid id, [FromBody] Customer customer)
        {
            if(id != customer.Id)
                return BadRequest("Os ids dos clientes não correspodem");

            _customerRepository.Update(customer);
            await _customerRepository.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:guid}")]
        [ProducesResponseType(typeof(Customer), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.NoContent)]
        public async Task<IActionResult> Delete(Guid id)
        {
            var client = await _customerRepository.GetByIdAsync(id);
            
            if(client == null)
                return NoContent();

            _customerRepository.Delete(client);
            await _customerRepository.SaveChangesAsync();
            return Ok();
        }
        
    }
}