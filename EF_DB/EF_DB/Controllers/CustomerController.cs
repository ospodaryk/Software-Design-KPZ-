using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EF_DB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly Spodaryk_shoestoreContext _context;
        string ConnectionInformation = "Server=.; Database=Spodaryk_shoestore; Trusted_Connection=true;MultipleActiveResultSets=true";
        public SqlConnection MainConnection;

        public CustomerController(Spodaryk_shoestoreContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Customer>>> GetListCustomer()
        {
            return Ok(await _context.Customers
                .ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Customer>>> Add([FromBody] Customer user)
        {
            var dbHero = await _context.Customers.FindAsync(user.IdCustomer);
            if (dbHero != null)
                return BadRequest("Customer exist with this id");
            _context.Add(user);
            await _context.SaveChangesAsync();
            return Ok(await _context.Customers.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<Customer>>> UpdateCustomer(Customer request)
        {
            var dbHero = await _context.Customers.FindAsync(request.IdCustomer);
            if (dbHero == null)
                return BadRequest("Customer not found.");

            dbHero.Name = request.Name;
            dbHero.Surname = request.Surname;
            dbHero.PhoneNumber = request.PhoneNumber;
            dbHero.Email = request.Email;

            await _context.SaveChangesAsync();

            return Ok(await _context.Crews.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Customer>>> Delete(int id)
        {
            var dbuser = await _context.Customers.FindAsync(id);
            if (dbuser == null) return BadRequest("Not Found Customer");
            _context.Customers.Remove(dbuser);
            await _context.SaveChangesAsync();
            return Ok(await _context.Customers.ToListAsync());

        }


    }
}
