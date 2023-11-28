using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;

namespace web.Controllers
{
    public class UporabnikController : Controller
    {
        private readonly SvetKnjigContext _context;

        public UporabnikController(SvetKnjigContext context)
        {
            _context = context;
        }

        // GET: Uporabnik
        public async Task<IActionResult> Index()
        {
              return _context.Uporabniki != null ? 
                          View(await _context.Uporabniki.ToListAsync()) :
                          Problem("Entity set 'SvetKnjigContext.Uporabniki'  is null.");
        }

        // GET: Uporabnik/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Uporabniki == null)
            {
                return NotFound();
            }

            var uporabnik = await _context.Uporabniki
                .FirstOrDefaultAsync(m => m.ID == id);
            if (uporabnik == null)
            {
                return NotFound();
            }

            return View(uporabnik);
        }

        // GET: Uporabnik/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Uporabnik/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Ime,Priimek,Uporabnisko_ime,geslo,Datum_rojstva,email,status")] Uporabnik uporabnik)
        {
            if (ModelState.IsValid)
            {
                _context.Add(uporabnik);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(uporabnik);
        }

        // GET: Uporabnik/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Uporabniki == null)
            {
                return NotFound();
            }

            var uporabnik = await _context.Uporabniki.FindAsync(id);
            if (uporabnik == null)
            {
                return NotFound();
            }
            return View(uporabnik);
        }

        // POST: Uporabnik/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Ime,Priimek,Uporabnisko_ime,geslo,Datum_rojstva,email,status")] Uporabnik uporabnik)
        {
            if (id != uporabnik.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(uporabnik);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UporabnikExists(uporabnik.ID))
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
            return View(uporabnik);
        }

        // GET: Uporabnik/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Uporabniki == null)
            {
                return NotFound();
            }

            var uporabnik = await _context.Uporabniki
                .FirstOrDefaultAsync(m => m.ID == id);
            if (uporabnik == null)
            {
                return NotFound();
            }

            return View(uporabnik);
        }

        // POST: Uporabnik/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Uporabniki == null)
            {
                return Problem("Entity set 'SvetKnjigContext.Uporabniki'  is null.");
            }
            var uporabnik = await _context.Uporabniki.FindAsync(id);
            if (uporabnik != null)
            {
                _context.Uporabniki.Remove(uporabnik);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UporabnikExists(int id)
        {
          return (_context.Uporabniki?.Any(e => e.ID == id)).GetValueOrDefault();
        }
    }
}
