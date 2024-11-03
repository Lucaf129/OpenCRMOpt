using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenCRMOptModels;

namespace OpenCRMOptAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MacchineController : ControllerBase
    {
        private readonly OptDbContext _context;

        public MacchineController(OptDbContext context)
        {
            _context = context;
        }

        // GET: api/Macchine
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Macchine>>> GetMacchines()
        {
            return await _context.Macchines.ToListAsync();
        }

        // GET: api/Macchine/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Macchine>> GetMacchine(int id)
        {
            var macchine = await _context.Macchines.FindAsync(id);

            if (macchine == null)
            {
                return NotFound();
            }

            return macchine;
        }

        // PUT: api/Macchine/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMacchine(int id, Macchine macchine)
        {
            if (id != macchine.MacchineId)
            {
                return BadRequest();
            }

            _context.Entry(macchine).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MacchineExists(id))
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

        // POST: api/Macchine
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Macchine>> PostMacchine(Macchine macchine)
        {
            _context.Macchines.Add(macchine);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMacchine", new { id = macchine.MacchineId }, macchine);
        }

        // DELETE: api/Macchine/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMacchine(int id)
        {
            var macchine = await _context.Macchines.FindAsync(id);
            if (macchine == null)
            {
                return NotFound();
            }

            _context.Macchines.Remove(macchine);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool MacchineExists(int id)
        {
            return _context.Macchines.Any(e => e.MacchineId == id);
        }
    }
}
