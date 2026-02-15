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
    public class AggressorsController : Controller
    {
        private readonly ProjetWeltrettungContext _context;

        public AggressorsController(ProjetWeltrettungContext context)
        {
            _context = context;
        }

        // GET: Aggressors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Aggressoren.ToListAsync());
        }

        // GET: Aggressors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aggressor = await _context.Aggressoren
                .FirstOrDefaultAsync(m => m.AggressorId == id);
            if (aggressor == null)
            {
                return NotFound();
            }

            return View(aggressor);
        }

        // GET: Aggressors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Aggressors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AggressorId,Vorname,Nachname,Spezialgebiet")] Aggressor aggressor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aggressor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(aggressor);
        }

        // GET: Aggressors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aggressor = await _context.Aggressoren.FindAsync(id);
            if (aggressor == null)
            {
                return NotFound();
            }
            return View(aggressor);
        }

        // POST: Aggressors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AggressorId,Vorname,Nachname,Spezialgebiet")] Aggressor aggressor)
        {
            if (id != aggressor.AggressorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aggressor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AggressorExists(aggressor.AggressorId))
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
            return View(aggressor);
        }

        // GET: Aggressors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aggressor = await _context.Aggressoren
                .FirstOrDefaultAsync(m => m.AggressorId == id);
            if (aggressor == null)
            {
                return NotFound();
            }

            return View(aggressor);
        }

        // POST: Aggressors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aggressor = await _context.Aggressoren.FindAsync(id);
            if (aggressor != null)
            {
                _context.Aggressoren.Remove(aggressor);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AggressorExists(int id)
        {
            return _context.Aggressoren.Any(e => e.AggressorId == id);
        }
    }
}
