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
    [Route("api/Abend")]
    public class AbendController : Controller
    {
        private readonly SkatContext _context;

        public AbendController(SkatContext context)
        {
            _context = context;
        }

        // GET: api/Abend
        [HttpGet]
        public IEnumerable<Abend> Getabende()
        {
            return _context.abende
                           .Include(s => s.spieler)
                           .Include(s => s.spiele)
                           .Include(s => s.regeln)
                                .ThenInclude(r => r.bockRamsch)
                           .ToList();
        }

        // GET: api/Abend/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetAbend([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var abend = await _context.abende
                                      .Include(a => a.spiele)
                                      .Include(a => a.spieler)
                                      .Include(a => a.regeln)
                                            .ThenInclude(r => r.bockRamsch)
                                      .SingleOrDefaultAsync(m => m.id == id);

            if (abend == null)
            {
                return NotFound();
            }

            return Ok(abend);
        }

        // PUT: api/Abend/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAbend([FromRoute] int id, [FromBody] Abend abend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != abend.id)
            {
                return BadRequest();
            }

            _context.Entry(abend).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbendExists(id))
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

        // POST: api/Abend
        [HttpPost]
        public async Task<IActionResult> PostAbend([FromBody] Abend abend)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.abende.Add(abend);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAbend", new { id = abend.id }, abend);
        }

        // DELETE: api/Abend/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAbend([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var abend = await _context.abende.SingleOrDefaultAsync(m => m.id == id);
            if (abend == null)
            {
                return NotFound();
            }

            _context.abende.Remove(abend);
            await _context.SaveChangesAsync();

            return Ok(abend);
        }

        private bool AbendExists(int id)
        {
            return _context.abende.Any(e => e.id == id);
        }
    }
}