using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetWeltrettung.Models;

namespace ProjetWeltrettung.Controllers
{
    public class BedrohungsController : Controller
    {
        private readonly ProjetWeltrettungContext _context;

        public BedrohungsController(ProjetWeltrettungContext context)
        {
            _context = context;
        }

        // GET: Bedrohungs
        public async Task<IActionResult> Index()
        {
            var projetWeltrettungContext = _context.Bedrohungen.Include(b => b.Aggressor).Include(b => b.Held);
            return View(await projetWeltrettungContext.ToListAsync());
        }

        // GET: Bedrohungs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bedrohung = await _context.Bedrohungen
                .Include(b => b.Aggressor)
                .Include(b => b.Held)
                .FirstOrDefaultAsync(m => m.BedrohungId == id);
            if (bedrohung == null)
            {
                return NotFound();
            }

            return View(bedrohung);
        }

        // GET: Bedrohungs/Create
        public IActionResult Create()
        {
            ViewData["AggressorId"] = new SelectList(_context.Aggressoren, "AggressorId", "Nachname");
            ViewData["HeldId"] = new SelectList(_context.Helden, "HeldId", "Nachname");
            return View();
        }

        // POST: Bedrohungs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BedrohungId,Bedrohungsname,Existiert,AggressorId,HeldId")] Bedrohung bedrohung)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bedrohung);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AggressorId"] = new SelectList(_context.Aggressoren, "AggressorId", "Nachname", bedrohung.AggressorId);
            ViewData["HeldId"] = new SelectList(_context.Helden, "HeldId", "Nachname", bedrohung.HeldId);
            return View(bedrohung);
        }

        // GET: Bedrohungs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bedrohung = await _context.Bedrohungen.FindAsync(id);
            if (bedrohung == null)
            {
                return NotFound();
            }
            ViewData["AggressorId"] = new SelectList(_context.Aggressoren, "AggressorId", "Nachname", bedrohung.AggressorId);
            ViewData["HeldId"] = new SelectList(_context.Helden, "HeldId", "Nachname", bedrohung.HeldId);
            return View(bedrohung);
        }

        // POST: Bedrohungs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BedrohungId,Bedrohungsname,Existiert,AggressorId,HeldId")] Bedrohung bedrohung)
        {
            if (id != bedrohung.BedrohungId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bedrohung);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BedrohungExists(bedrohung.BedrohungId))
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
            ViewData["AggressorId"] = new SelectList(_context.Aggressoren, "AggressorId", "Nachname", bedrohung.AggressorId);
            ViewData["HeldId"] = new SelectList(_context.Helden, "HeldId", "Nachname", bedrohung.HeldId);
            return View(bedrohung);
        }

        // GET: Bedrohungs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bedrohung = await _context.Bedrohungen
                .Include(b => b.Aggressor)
                .Include(b => b.Held)
                .FirstOrDefaultAsync(m => m.BedrohungId == id);
            if (bedrohung == null)
            {
                return NotFound();
            }

            return View(bedrohung);
        }

        // POST: Bedrohungs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bedrohung = await _context.Bedrohungen.FindAsync(id);
            if (bedrohung != null)
            {
                _context.Bedrohungen.Remove(bedrohung);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BedrohungExists(int id)
        {
            return _context.Bedrohungen.Any(e => e.BedrohungId == id);
        }
    }
}
