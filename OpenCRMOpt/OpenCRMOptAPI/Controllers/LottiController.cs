﻿using System;
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
    public class LottiController : ControllerBase
    {
        private readonly OptDbContext _context;

        public LottiController(OptDbContext context)
        {
            _context = context;
        }

        // GET: api/Lotti
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lotti>>> GetLottis()
        {
            return await _context.Lottis.ToListAsync();
        }

        // GET: api/Lotti/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Lotti>> GetLotti(long id)
        {
            var lotti = await _context.Lottis.FindAsync(id);

            if (lotti == null)
            {
                return NotFound();
            }

            return lotti;
        }

        // PUT: api/Lotti/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLotti(long id, Lotti lotti)
        {
            if (id != lotti.LottoId)
            {
                return BadRequest();
            }

            _context.Entry(lotti).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LottiExists(id))
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

        // POST: api/Lotti
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Lotti>> PostLotti(Lotti lotti)
        {
            _context.Lottis.Add(lotti);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLotti), new { id = lotti.LottoId }, lotti);
        }

        // DELETE: api/Lotti/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLotti(long id)
        {
            var lotti = await _context.Lottis.FindAsync(id);
            if (lotti == null)
            {
                return NotFound();
            }

            _context.Lottis.Remove(lotti);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LottiExists(long id)
        {
            return _context.Lottis.Any(e => e.LottoId == id);
        }
    }
}
