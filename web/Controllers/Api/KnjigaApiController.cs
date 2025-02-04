using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web.Data;
using web.Models;
using web.Filters;

namespace web.Controllers_Api
{
    [Route("api/KnjigaAPI")]
    [ApiController]
    [ApiKeyAuth]
    public class KnjigaApiController : ControllerBase
    {
        private readonly SvetKnjigContext _context;

        public KnjigaApiController(SvetKnjigContext context)
        {
            _context = context;
        }

        // GET: api/KnjigaApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Knjiga>>> GetKnjige()
        {
          if (_context.Knjige == null)
          {
              return NotFound();
          }
            return await _context.Knjige.ToListAsync();
        }

        // GET: api/KnjigaApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Knjiga>> GetKnjiga(int id)
        {
          if (_context.Knjige == null)
          {
              return NotFound();
          }
            var knjiga = await _context.Knjige.FindAsync(id);

            if (knjiga == null)
            {
                return NotFound();
            }

            return knjiga;
        }

        // PUT: api/KnjigaApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKnjiga(int id, Knjiga knjiga)
        {
            if (id != knjiga.Id)
            {
                return BadRequest();
            }

            _context.Entry(knjiga).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnjigaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/KnjigaApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Knjiga>> PostKnjiga(Knjiga knjiga)
        {
          if (_context.Knjige == null)
          {
              return Problem("Entity set 'SvetKnjigContext.Knjige'  is null.");
          }
            _context.Knjige.Add(knjiga);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKnjiga", new { id = knjiga.Id }, knjiga);
        }

        // DELETE: api/KnjigaApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKnjiga(int id)
        {
            if (_context.Knjige == null)
            {
                return NotFound();
            }
            var knjiga = await _context.Knjige.FindAsync(id);
            if (knjiga == null)
            {
                return NotFound();
            }

            _context.Knjige.Remove(knjiga);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KnjigaExists(int id)
        {
            return (_context.Knjige?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
