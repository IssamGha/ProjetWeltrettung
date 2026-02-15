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
    public class WeltrettersController : Controller
    {
        private readonly ProjetWeltrettungContext _context;

        public WeltrettersController(ProjetWeltrettungContext context)
        {
            _context = context;
        }

        // GET: Weltretters
        public async Task<IActionResult> Index()
        {
            return View(await _context.Weltretter.ToListAsync());
        }

        // GET: Weltretters/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weltretter = await _context.Weltretter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weltretter == null)
            {
                return NotFound();
            }

            return View(weltretter);
        }

        // GET: Weltretters/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Weltretters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Vorname,Nachname,Email,Faehigkeit,IstVolljaehrig")] Weltretter weltretter)
        {
            if (ModelState.IsValid)
            {
                _context.Add(weltretter);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(weltretter);
        }

        // GET: Weltretters/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weltretter = await _context.Weltretter.FindAsync(id);
            if (weltretter == null)
            {
                return NotFound();
            }
            return View(weltretter);
        }

        // POST: Weltretters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Vorname,Nachname,Email,Faehigkeit,IstVolljaehrig")] Weltretter weltretter)
        {
            if (id != weltretter.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(weltretter);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WeltretterExists(weltretter.Id))
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
            return View(weltretter);
        }

        // GET: Weltretters/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var weltretter = await _context.Weltretter
                .FirstOrDefaultAsync(m => m.Id == id);
            if (weltretter == null)
            {
                return NotFound();
            }

            return View(weltretter);
        }

        // POST: Weltretters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var weltretter = await _context.Weltretter.FindAsync(id);
            if (weltretter != null)
            {
                _context.Weltretter.Remove(weltretter);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WeltretterExists(int id)
        {
            return _context.Weltretter.Any(e => e.Id == id);
        }
    }
}
