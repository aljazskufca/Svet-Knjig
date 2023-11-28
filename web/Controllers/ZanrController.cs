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
    [Authorize(Roles = "Administrator")]
    public class ZanrController : Controller
    {
        private readonly SvetKnjigContext _context;

        public ZanrController(SvetKnjigContext context)
        {
            _context = context;
        }

        // GET: Zanr
        public async Task<IActionResult> Index()
        {
              return _context.Zanr != null ? 
                          View(await _context.Zanr.ToListAsync()) :
                          Problem("Entity set 'SvetKnjigContext.Zanr'  is null.");
        }

        // GET: Zanr/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Zanr == null)
            {
                return NotFound();
            }

            var zanr = await _context.Zanr
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zanr == null)
            {
                return NotFound();
            }

            return View(zanr);
        }

        // GET: Zanr/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zanr/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Ime_zanra")] Zanr zanr)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zanr);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zanr);
        }

        // GET: Zanr/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Zanr == null)
            {
                return NotFound();
            }

            var zanr = await _context.Zanr.FindAsync(id);
            if (zanr == null)
            {
                return NotFound();
            }
            return View(zanr);
        }

        // POST: Zanr/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Ime_zanra")] Zanr zanr)
        {
            if (id != zanr.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zanr);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZanrExists(zanr.Id))
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
            return View(zanr);
        }

        // GET: Zanr/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Zanr == null)
            {
                return NotFound();
            }

            var zanr = await _context.Zanr
                .FirstOrDefaultAsync(m => m.Id == id);
            if (zanr == null)
            {
                return NotFound();
            }

            return View(zanr);
        }

        // POST: Zanr/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Zanr == null)
            {
                return Problem("Entity set 'SvetKnjigContext.Zanr'  is null.");
            }
            var zanr = await _context.Zanr.FindAsync(id);
            if (zanr != null)
            {
                _context.Zanr.Remove(zanr);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZanrExists(int id)
        {
          return (_context.Zanr?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
