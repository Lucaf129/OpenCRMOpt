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
    public class ModelliLottiController : ControllerBase
    {
        private readonly OptDbContext _context;

        public ModelliLottiController(OptDbContext context)
        {
            _context = context;
        }

        // GET: api/ModelliLotti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModelliLotti>>> GetModelliLottis()
        {
            return await _context.ModelliLottis.ToListAsync();
        }

        // GET: api/ModelliLotti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ModelliLotti>> GetModelliLotti(int id)
        {
            var modelliLotti = await _context.ModelliLottis.FindAsync(id);

            if (modelliLotti == null)
            {
                return NotFound();
            }

            return modelliLotti;
        }

        // PUT: api/ModelliLotti/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutModelliLotti(int id, ModelliLotti modelliLotti)
        {
            if (id != modelliLotti.ModelloId)
            {
                return BadRequest();
            }

            _context.Entry(modelliLotti).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ModelliLottiExists(id))
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

        // POST: api/ModelliLotti
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ModelliLotti>> PostModelliLotti(ModelliLotti modelliLotti)
        {
            _context.ModelliLottis.Add(modelliLotti);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetModelliLotti", new { id = modelliLotti.ModelloId }, modelliLotti);
        }

        // DELETE: api/ModelliLotti/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteModelliLotti(int id)
        {
            var modelliLotti = await _context.ModelliLottis.FindAsync(id);
            if (modelliLotti == null)
            {
                return NotFound();
            }

            _context.ModelliLottis.Remove(modelliLotti);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ModelliLottiExists(int id)
        {
            return _context.ModelliLottis.Any(e => e.ModelloId == id);
        }
    }
}
