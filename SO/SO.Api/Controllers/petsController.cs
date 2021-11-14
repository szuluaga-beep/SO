using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SO.Api.Data;
using SO.Common.Entities;

namespace SO.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class petsController : ControllerBase
    {
        private readonly DataContext _context;

        public petsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/pets
        [HttpGet]
        public async Task<ActionResult<IEnumerable<pet>>> Getpets()
        {
            return await _context.pets.ToListAsync();
        }

        // GET: api/pets/5
        [HttpGet("{id}")]
        public async Task<ActionResult<pet>> Getpet(int id)
        {
            var pet = await _context.pets.FindAsync(id);

            if (pet == null)
            {
                return NotFound();
            }

            return pet;
        }

        // PUT: api/pets/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> Putpet(int id, pet pet)
        {
            if (id != pet.Id)
            {
                return BadRequest();
            }

            _context.Entry(pet).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!petExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/pets
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<pet>> Postpet(pet pet)
        {
            _context.pets.Add(pet);
            await _context.SaveChangesAsync();

            return CreatedAtAction("Getpet", new { id = pet.Id }, pet);
        }

        // DELETE: api/pets/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletepet(int id)
        {
            var pet = await _context.pets.FindAsync(id);
            if (pet == null)
            {
                return NotFound();
            }

            _context.pets.Remove(pet);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool petExists(int id)
        {
            return _context.pets.Any(e => e.Id == id);
        }
    }
}
