using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using OpenCRMOptModels;

namespace OpenCRMOptAPI.Controllers
{
    public class LottiController : Controller
    {
        private readonly OptDbContext _context;

        public LottiController(OptDbContext context)
        {
            _context = context;
        }

        // GET: Lotti
        public async Task<IActionResult> Index()
        {
            var optDbContext = _context.Lottis.Include(l => l.ModelloNavigation);
            return View(await optDbContext.ToListAsync());
        }

        // GET: Lotti/Details/5
        public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lotti = await _context.Lottis
                .Include(l => l.ModelloNavigation)
                .FirstOrDefaultAsync(m => m.LottoId == id);
            if (lotti == null)
            {
                return NotFound();
            }

            return View(lotti);
        }

        // GET: Lotti/Create
        public IActionResult Create()
        {
            ViewData["Modello"] = new SelectList(_context.ModelliLottis, "ModelloId", "Descrizione");
            return View();
        }

        // POST: Lotti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LottoId,Modello,Note,Quantita")] Lotti lotti)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lotti);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Modello"] = new SelectList(_context.ModelliLottis, "ModelloId", "Descrizione", lotti.Modello);
            return View(lotti);
        }

        // GET: Lotti/Edit/5
        public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lotti = await _context.Lottis.FindAsync(id);
            if (lotti == null)
            {
                return NotFound();
            }
            ViewData["Modello"] = new SelectList(_context.ModelliLottis, "ModelloId", "Descrizione", lotti.Modello);
            return View(lotti);
        }

        // POST: Lotti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("LottoId,Modello,Note,Quantita")] Lotti lotti)
        {
            if (id != lotti.LottoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(lotti);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LottiExists(lotti.LottoId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["Modello"] = new SelectList(_context.ModelliLottis, "ModelloId", "Descrizione", lotti.Modello);
            return View(lotti);
        }

        // GET: Lotti/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lotti = await _context.Lottis
                .Include(l => l.ModelloNavigation)
                .FirstOrDefaultAsync(m => m.LottoId == id);
            if (lotti == null)
            {
                return NotFound();
            }

            return View(lotti);
        }

        // POST: Lotti/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var lotti = await _context.Lottis.FindAsync(id);
            if (lotti != null)
            {
                _context.Lottis.Remove(lotti);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LottiExists(long id)
        {
            return _context.Lottis.Any(e => e.LottoId == id);
        }
    }
}
