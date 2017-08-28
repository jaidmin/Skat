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
    [Route("api/Spieler")]
    public class SpielerController : Controller
    {
        private readonly SkatContext _context;

        public SpielerController(SkatContext context)
        {
            _context = context;
        }

        // GET: api/Spieler
        [HttpGet]
        public IEnumerable<Spieler> Getspieler()
        {
            return _context.spieler;
        }

        // GET: api/Spieler/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSpieler([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var spieler = await _context.spieler.SingleOrDefaultAsync(m => m.id == id);

            if (spieler == null)
            {
                return NotFound();
            }

            return Ok(spieler);
        }

        // PUT: api/Spieler/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpieler([FromRoute] int id, [FromBody] Spieler spieler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != spieler.id)
            {
                return BadRequest();
            }

            _context.Entry(spieler).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpielerExists(id))
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

        // POST: api/Spieler
        [HttpPost]
        public async Task<IActionResult> PostSpieler([FromBody] Spieler spieler)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.spieler.Add(spieler);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpieler", new { id = spieler.id }, spieler);
        }

        // DELETE: api/Spieler/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpieler([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var spieler = await _context.spieler.SingleOrDefaultAsync(m => m.id == id);
            if (spieler == null)
            {
                return NotFound();
            }

            _context.spieler.Remove(spieler);
            await _context.SaveChangesAsync();

            return Ok(spieler);
        }

        private bool SpielerExists(int id)
        {
            return _context.spieler.Any(e => e.id == id);
        }
    }
}