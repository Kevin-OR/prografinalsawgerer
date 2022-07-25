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
    public class MediParedesController : ControllerBase
    {
        private readonly CalculoMateContext _context;

        public MediParedesController(CalculoMateContext context)
        {
            _context = context;
        }

        // GET: api/MediParedes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MediParedes>>> GetMediParedes()
        {
            return await _context.MediParedes.ToListAsync();
        }

        // GET: api/MediParedes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MediParedes>> GetMediParedes(int id)
        {
            var mediParedes = await _context.MediParedes.FindAsync(id);

            if (mediParedes == null)
            {
                return NotFound();
            }

            return mediParedes;
        }

        // PUT: api/MediParedes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMediParedes(int id, MediParedes mediParedes)
        {
            if (id != mediParedes.IdMedParedes)
            {
                return BadRequest();
            }

            _context.Entry(mediParedes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediParedesExists(id))
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

        // POST: api/MediParedes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MediParedes>> PostMediParedes(MediParedes mediParedes)
        {
            _context.MediParedes.Add(mediParedes);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMediParedes", new { id = mediParedes.IdMedParedes }, mediParedes);
        }

        // DELETE: api/MediParedes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MediParedes>> DeleteMediParedes(int id)
        {
            var mediParedes = await _context.MediParedes.FindAsync(id);
            if (mediParedes == null)
            {
                return NotFound();
            }

            _context.MediParedes.Remove(mediParedes);
            await _context.SaveChangesAsync();

            return mediParedes;
        }

        private bool MediParedesExists(int id)
        {
            return _context.MediParedes.Any(e => e.IdMedParedes == id);
        }
    }
}
