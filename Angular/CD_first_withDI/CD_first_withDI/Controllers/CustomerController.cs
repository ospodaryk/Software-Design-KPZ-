using CD_first_withDI.Data;
using CD_first_withDI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CD_first_withDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly DataContext _context;

        public CustomerController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Customer>>> AddCustomer(Customer character)
        {
            _context.Customers.Add(character);
            await _context.SaveChangesAsync();

            return Ok(await _context.Customers.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetAllCustomers()
        {
            return Ok(await _context.Customers.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var character = await _context.Customers.FindAsync(id);
            if (character == null)
            {
                return BadRequest("Customer not found.");
            }
            return Ok(character);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Customer>>> DeleteCustomer(int id)
        {
            var dbuser = await _context.Customers.FindAsync(id);
            if (dbuser == null) return BadRequest("Not Found Customer");
            _context.Customers.Remove(dbuser);
            await _context.SaveChangesAsync();
            return Ok(await _context.Customers.ToListAsync());

        }
    }
}
