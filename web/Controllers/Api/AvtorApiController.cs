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
    [Route("api/AvtorAPI")]
    [ApiController]
    [ApiKeyAuth]
    public class AvtorApiController : ControllerBase
    {
        private readonly SvetKnjigContext _context;

        public AvtorApiController(SvetKnjigContext context)
        {
            _context = context;
        }

        // GET: api/AvtorApi
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Avtor>>> GetAvtorji()
        {
          if (_context.Avtorji == null)
          {
              return NotFound();
          }
            return await _context.Avtorji.ToListAsync();
        }

        // GET: api/AvtorApi/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Avtor>> GetAvtor(int id)
        {
          if (_context.Avtorji == null)
          {
              return NotFound();
          }
            var avtor = await _context.Avtorji.FindAsync(id);

            if (avtor == null)
            {
                return NotFound();
            }

            return avtor;
        }

        // PUT: api/AvtorApi/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAvtor(int id, Avtor avtor)
        {
            if (id != avtor.Id)
            {
                return BadRequest();
            }

            _context.Entry(avtor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AvtorExists(id))
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

        // POST: api/AvtorApi
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Avtor>> PostAvtor(Avtor avtor)
        {
          if (_context.Avtorji == null)
          {
              return Problem("Entity set 'SvetKnjigContext.Avtorji'  is null.");
          }
            _context.Avtorji.Add(avtor);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAvtor", new { id = avtor.Id }, avtor);
        }

        // DELETE: api/AvtorApi/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAvtor(int id)
        {
            if (_context.Avtorji == null)
            {
                return NotFound();
            }
            var avtor = await _context.Avtorji.FindAsync(id);
            if (avtor == null)
            {
                return NotFound();
            }

            _context.Avtorji.Remove(avtor);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AvtorExists(int id)
        {
            return (_context.Avtorji?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
