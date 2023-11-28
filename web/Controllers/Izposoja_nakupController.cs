using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;

namespace web.Controllers
{
    [Authorize(Roles = "Administrator, Navadni uporabnik")]
    public class Izposoja_nakupController : Controller
    {
        private readonly SvetKnjigContext _context;

        public Izposoja_nakupController(SvetKnjigContext context)
        {
            _context = context;
        }

        // GET: Izposoja_nakup
        public async Task<IActionResult> Index()
        {
              return _context.Izposoje_nakupi != null ? 
                          View(await _context.Izposoje_nakupi.ToListAsync()) :
                          Problem("Entity set 'SvetKnjigContext.Izposoje_nakupi'  is null.");
        }

        // GET: Izposoja_nakup/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Izposoje_nakupi == null)
            {
                return NotFound();
            }

            var izposoja_nakup = await _context.Izposoje_nakupi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (izposoja_nakup == null)
            {
                return NotFound();
            }

            return View(izposoja_nakup);
        }

        // GET: Izposoja_nakup/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Izposoja_nakup/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Datum_izposoje,Datum_vrnitve,Cena")] Izposoja_nakup izposoja_nakup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(izposoja_nakup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(izposoja_nakup);
        }

        // GET: Izposoja_nakup/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Izposoje_nakupi == null)
            {
                return NotFound();
            }

            var izposoja_nakup = await _context.Izposoje_nakupi.FindAsync(id);
            if (izposoja_nakup == null)
            {
                return NotFound();
            }
            return View(izposoja_nakup);
        }

        // POST: Izposoja_nakup/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Datum_izposoje,Datum_vrnitve,Cena")] Izposoja_nakup izposoja_nakup)
        {
            if (id != izposoja_nakup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(izposoja_nakup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Izposoja_nakupExists(izposoja_nakup.Id))
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
            return View(izposoja_nakup);
        }

        // GET: Izposoja_nakup/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Izposoje_nakupi == null)
            {
                return NotFound();
            }

            var izposoja_nakup = await _context.Izposoje_nakupi
                .FirstOrDefaultAsync(m => m.Id == id);
            if (izposoja_nakup == null)
            {
                return NotFound();
            }

            return View(izposoja_nakup);
        }

        // POST: Izposoja_nakup/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Izposoje_nakupi == null)
            {
                return Problem("Entity set 'SvetKnjigContext.Izposoje_nakupi'  is null.");
            }
            var izposoja_nakup = await _context.Izposoje_nakupi.FindAsync(id);
            if (izposoja_nakup != null)
            {
                _context.Izposoje_nakupi.Remove(izposoja_nakup);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Izposoja_nakupExists(int id)
        {
          return (_context.Izposoje_nakupi?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
