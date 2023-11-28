using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;
using Microsoft.AspNetCore.Authorization;

namespace web.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class AvtorController : Controller
    {
        private readonly SvetKnjigContext _context;

        public AvtorController(SvetKnjigContext context)
        {
            _context = context;
        }

        // GET: Avtor
        public async Task<IActionResult> Index()
        {
              return _context.Avtorji != null ? 
                          View(await _context.Avtorji.ToListAsync()) :
                          Problem("Entity set 'SvetKnjigContext.Avtorji'  is null.");
        }

        // GET: Avtor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Avtorji == null)
            {
                return NotFound();
            }

            var avtor = await _context.Avtorji
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avtor == null)
            {
                return NotFound();
            }

            return View(avtor);
        }

        // GET: Avtor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Avtor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime,Priimek,Datum_rojstva")] Avtor avtor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(avtor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(avtor);
        }

        // GET: Avtor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Avtorji == null)
            {
                return NotFound();
            }

            var avtor = await _context.Avtorji.FindAsync(id);
            if (avtor == null)
            {
                return NotFound();
            }
            return View(avtor);
        }

        // POST: Avtor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime,Priimek,Datum_rojstva")] Avtor avtor)
        {
            if (id != avtor.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(avtor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AvtorExists(avtor.Id))
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
            return View(avtor);
        }

        // GET: Avtor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Avtorji == null)
            {
                return NotFound();
            }

            var avtor = await _context.Avtorji
                .FirstOrDefaultAsync(m => m.Id == id);
            if (avtor == null)
            {
                return NotFound();
            }

            return View(avtor);
        }

        // POST: Avtor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Avtorji == null)
            {
                return Problem("Entity set 'SvetKnjigContext.Avtorji'  is null.");
            }
            var avtor = await _context.Avtorji.FindAsync(id);
            if (avtor != null)
            {
                _context.Avtorji.Remove(avtor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AvtorExists(int id)
        {
          return (_context.Avtorji?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
