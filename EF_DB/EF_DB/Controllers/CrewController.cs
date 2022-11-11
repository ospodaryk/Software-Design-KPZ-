using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace EF_DB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrewController : ControllerBase
    {
        private readonly Spodaryk_shoestoreContext _context;
        string ConnectionInformation = "Server=.; Database=Spodaryk_shoestore; Trusted_Connection=true;MultipleActiveResultSets=true";
        public SqlConnection MainConnection;

        public CrewController(Spodaryk_shoestoreContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Crew>>> GetListCrew()
        {
            return Ok(await _context.Crews
                .Include(p => p.Orders)
                .ToListAsync());
        }
        [HttpPost]
        public async Task<ActionResult<List<Crew>>> Add([FromBody] Crew user)
        {
           _context.Add(user);
           await _context.SaveChangesAsync();
            return Ok(await _context.Crews.ToListAsync());
        }
        [HttpPut]
        public async Task<ActionResult<List<Crew>>> UpdateCrew(Crew request)
        {
            var dbHero = await _context.Crews.FindAsync(request.IdEmployee);
            if (dbHero == null)
                return BadRequest("Employee not found.");

            dbHero.Name = request.Name;
            dbHero.Surname = request.Surname;
            dbHero.PhoneNumber = request.PhoneNumber;
            dbHero.Email = request.Email;
            dbHero.Position = request.Position;

            await _context.SaveChangesAsync();

            return Ok(await _context.Crews.ToListAsync());
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Crew>>> Delete(int id)
        {
          var dbuser=await _context.Crews.FindAsync(id);
            if (dbuser == null) return BadRequest("Not Found EMployee");
            _context.Crews.Remove(dbuser);
            await _context.SaveChangesAsync();
            return Ok(await _context.Crews.ToListAsync());

        }
    }
        
    
}
