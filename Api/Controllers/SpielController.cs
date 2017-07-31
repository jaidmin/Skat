using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api;
using SkatLib;

namespace Api.Controllers
{
    [Produces("application/json")]
    [Route("api/Spiel")]
    public class SpielController : Controller
    {
        private readonly SkatContext _context;

        public SpielController(SkatContext context)
        {
            _context = context;
        }

        // GET: api/Spiel
        [HttpGet]
        public IEnumerable<Spiel> Getspiele()
        {
            return _context.spiele;
        }

        // GET: api/Spiel/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpiel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var spiel = await _context.spiele.SingleOrDefaultAsync(m => m.id == id);

            if (spiel == null)
            {
                return NotFound();
            }

            return Ok(spiel);
        }

        // PUT: api/Spiel/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpiel([FromRoute] int id, [FromBody] Spiel spiel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spiel.id)
            {
                return BadRequest();
            }

            _context.Entry(spiel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpielExists(id))
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

        // POST: api/Spiel
        [HttpPost]
        public async Task<IActionResult> PostSpiel([FromBody] Spiel spiel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.spiele.Add(spiel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpiel", new { id = spiel.id }, spiel);
        }

        // DELETE: api/Spiel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpiel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var spiel = await _context.spiele.SingleOrDefaultAsync(m => m.id == id);
            if (spiel == null)
            {
                return NotFound();
            }

            _context.spiele.Remove(spiel);
            await _context.SaveChangesAsync();

            return Ok(spiel);
        }

        private bool SpielExists(int id)
        {
            return _context.spiele.Any(e => e.id == id);
        }
    }
}