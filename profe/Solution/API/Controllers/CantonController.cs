using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CantonController : ControllerBase
    {
        private readonly CalculoMateContext _context;

        public CantonController(CalculoMateContext context)
        {
            _context = context;
        }

        // GET: api/Cantons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Canton>>> GetCanton()
        {
            return await _context.Canton.ToListAsync();
        }

        // GET: api/Cantons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Canton>> GetCanton(short id)
        {
            var canton = await _context.Canton.FindAsync(id);

            if (canton == null)
            {
                return NotFound();
            }

            return canton;
        }

        // PUT: api/Cantons/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCanton(short id, Canton canton)
        {
            if (id != canton.CodigoCanton)
            {
                return BadRequest();
            }

            _context.Entry(canton).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CantonExists(id))
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

        // POST: api/Cantons
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Canton>> PostCanton(Canton canton)
        {
            _context.Canton.Add(canton);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCanton", new { id = canton.CodigoCanton }, canton);
        }

        // DELETE: api/Cantons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Canton>> DeleteCanton(short id)
        {
            var canton = await _context.Canton.FindAsync(id);
            if (canton == null)
            {
                return NotFound();
            }

            _context.Canton.Remove(canton);
            await _context.SaveChangesAsync();

            return canton;
        }

        private bool CantonExists(short id)
        {
            return _context.Canton.Any(e => e.CodigoCanton == id);
        }
    }
}
