using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using react_back.Models;
using CRUD;
using Microsoft.EntityFrameworkCore;

namespace react_back.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DBConnection _context;
        private readonly HttpClient _httpClient;

        public CustomerController(DBConnection context, HttpClient httpClient)
        {
            _context = context;
            _httpClient = httpClient;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            var githubUrl = "https://raw.githubusercontent.com/robconery/json-sales-data/master/data/customers.json";
            var response = await _httpClient.GetAsync(githubUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var customers = JsonConvert.DeserializeObject<List<Customer>>(content);
                return Ok(customers);
            }

            return BadRequest("Unable to fetch data from GitHub.");
        }

        [HttpGet("local")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetLocalCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Customer>> CreateCustomer([FromBody] Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCustomers), new { id = customer.Id }, customer);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateCustomer(int id, [FromBody] Customer updatedCustomer)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            customer.First = updatedCustomer.First;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
