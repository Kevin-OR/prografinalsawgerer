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
    public class MediParedController : ControllerBase
    {
        private readonly CalculoMateContext _context;

        public MediParedController(CalculoMateContext context)
        {
            _context = context;
        }

        // GET: api/MediPareds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediPared>>> GetMediPared()
        {
            return await _context.MediPared.ToListAsync();
        }

        // GET: api/MediPareds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MediPared>> GetMediPared(int id)
        {
            var mediPared = await _context.MediPared.FindAsync(id);

            if (mediPared == null)
            {
                return NotFound();
            }

            return mediPared;
        }

        // PUT: api/MediPareds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMediPared(int id, MediPared mediPared)
        {
            if (id != mediPared.IdMedPared)
            {
                return BadRequest();
            }

            _context.Entry(mediPared).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediParedExists(id))
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

        // POST: api/MediPareds
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MediPared>> PostMediPared(MediPared mediPared)
        {
            _context.MediPared.Add(mediPared);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMediPared", new { id = mediPared.IdMedPared }, mediPared);
        }

        // DELETE: api/MediPareds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MediPared>> DeleteMediPared(int id)
        {
            var mediPared = await _context.MediPared.FindAsync(id);
            if (mediPared == null)
            {
                return NotFound();
            }

            _context.MediPared.Remove(mediPared);
            await _context.SaveChangesAsync();

            return mediPared;
        }

        private bool MediParedExists(int id)
        {
            return _context.MediPared.Any(e => e.IdMedPared == id);
        }
    }
}
