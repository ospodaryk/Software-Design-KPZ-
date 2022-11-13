using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CD_first_withDI.CustomerData;
using CD_first_withDI.Data;
using CD_first_withDI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CD_first_withDI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CrewController : ControllerBase
    {
      
            private readonly DataContext _context;

            public CrewController(DataContext context)
            {
                _context = context;
            }

            [HttpPost]
            public async Task<ActionResult<List<Employee>>> AddEmployee(Employee character)
            {
                _context.Crew.Add(character);
                await _context.SaveChangesAsync();

                return Ok(await _context.Crew.ToListAsync());
            }

            [HttpGet]
            public async Task<ActionResult<List<Employee>>> GetCrewList()
            {
                return Ok(await _context.Crew.ToListAsync());
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<Employee>> GetEmployee(int id)
            {
                var character = await _context.Crew.FindAsync(id);
                if (character == null)
                {
                    return BadRequest("Employee not found.");
                }
                return Ok(character);
            }
            [HttpDelete("{id}")]
            public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
            {
                var dbuser = await _context.Crew.FindAsync(id);
                if (dbuser == null) return BadRequest("Not Found Employee");
                _context.Crew.Remove(dbuser);
                await _context.SaveChangesAsync();
                return Ok(await _context.Crew.ToListAsync());

            }

        [HttpPut]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee hero)
        {
            var dbHero = await _context.Crew.FindAsync(hero.IdEmployee);
            if (dbHero == null)
                return BadRequest("Employee not found.");

            dbHero.Name = hero.Name;
            dbHero.Surname = hero.Surname;
            dbHero.PhoneNumber = hero.PhoneNumber;
            dbHero.Email = hero.Email;
            dbHero.Position = hero.Position;

            await _context.SaveChangesAsync();

            return Ok(await _context.Crew.ToListAsync());
        }

    }
}
