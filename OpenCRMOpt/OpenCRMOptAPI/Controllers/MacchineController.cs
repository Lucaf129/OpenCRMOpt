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
    public class MacchineController : Controller
    {
        private readonly OptDbContext _context;

        public MacchineController(OptDbContext context)
        {
            _context = context;
        }

        // GET: Macchine
        public async Task<IActionResult> Index()
        {
            return View(await _context.Macchines.ToListAsync());
        }

        // GET: Macchine/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var macchine = await _context.Macchines
                .FirstOrDefaultAsync(m => m.MacchineId == id);
            if (macchine == null)
            {
                return NotFound();
            }

            return View(macchine);
        }

        // GET: Macchine/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Macchine/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MacchineId,Descrizione,Name,Ip")] Macchine macchine)
        {
            if (ModelState.IsValid)
            {
                _context.Add(macchine);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(macchine);
        }

        // GET: Macchine/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var macchine = await _context.Macchines.FindAsync(id);
            if (macchine == null)
            {
                return NotFound();
            }
            return View(macchine);
        }

        // POST: Macchine/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MacchineId,Descrizione,Name,Ip")] Macchine macchine)
        {
            if (id != macchine.MacchineId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(macchine);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MacchineExists(macchine.MacchineId))
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
            return View(macchine);
        }

        // GET: Macchine/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var macchine = await _context.Macchines
                .FirstOrDefaultAsync(m => m.MacchineId == id);
            if (macchine == null)
            {
                return NotFound();
            }

            return View(macchine);
        }

        // POST: Macchine/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var macchine = await _context.Macchines.FindAsync(id);
            if (macchine != null)
            {
                _context.Macchines.Remove(macchine);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MacchineExists(int id)
        {
            return _context.Macchines.Any(e => e.MacchineId == id);
        }
    }
}
