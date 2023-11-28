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
    public class Ocene_KomentarjiController : Controller
    {
        private readonly SvetKnjigContext _context;

        public Ocene_KomentarjiController(SvetKnjigContext context)
        {
            _context = context;
        }

        // GET: Ocene_Komentarji
        public async Task<IActionResult> Index()
        {
              return _context.Ocene_Komentarji != null ? 
                          View(await _context.Ocene_Komentarji.ToListAsync()) :
                          Problem("Entity set 'SvetKnjigContext.Ocene_Komentarji'  is null.");
        }

        // GET: Ocene_Komentarji/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ocene_Komentarji == null)
            {
                return NotFound();
            }

            var ocene_komentarji = await _context.Ocene_Komentarji
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ocene_komentarji == null)
            {
                return NotFound();
            }

            return View(ocene_komentarji);
        }

        // GET: Ocene_Komentarji/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ocene_Komentarji/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ocena,Komentar,Datum_ocene")] Ocene_komentarji ocene_komentarji)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ocene_komentarji);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ocene_komentarji);
        }

        // GET: Ocene_Komentarji/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ocene_Komentarji == null)
            {
                return NotFound();
            }

            var ocene_komentarji = await _context.Ocene_Komentarji.FindAsync(id);
            if (ocene_komentarji == null)
            {
                return NotFound();
            }
            return View(ocene_komentarji);
        }

        // POST: Ocene_Komentarji/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ocena,Komentar,Datum_ocene")] Ocene_komentarji ocene_komentarji)
        {
            if (id != ocene_komentarji.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ocene_komentarji);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!Ocene_komentarjiExists(ocene_komentarji.Id))
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
            return View(ocene_komentarji);
        }

        // GET: Ocene_Komentarji/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ocene_Komentarji == null)
            {
                return NotFound();
            }

            var ocene_komentarji = await _context.Ocene_Komentarji
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ocene_komentarji == null)
            {
                return NotFound();
            }

            return View(ocene_komentarji);
        }

        // POST: Ocene_Komentarji/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ocene_Komentarji == null)
            {
                return Problem("Entity set 'SvetKnjigContext.Ocene_Komentarji'  is null.");
            }
            var ocene_komentarji = await _context.Ocene_Komentarji.FindAsync(id);
            if (ocene_komentarji != null)
            {
                _context.Ocene_Komentarji.Remove(ocene_komentarji);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Ocene_komentarjiExists(int id)
        {
          return (_context.Ocene_Komentarji?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
