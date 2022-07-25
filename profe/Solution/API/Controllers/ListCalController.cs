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
    public class ListCalController : ControllerBase
    {
        private readonly CalculoMateContext _context;

        public ListCalController(CalculoMateContext context)
        {
            _context = context;
        }

        // GET: api/ListCals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ListCal>>> GetListCal()
        {
            return await _context.ListCal.ToListAsync();
        }

        // GET: api/ListCals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ListCal>> GetListCal(int id)
        {
            var listCal = await _context.ListCal.FindAsync(id);

            if (listCal == null)
            {
                return NotFound();
            }

            return listCal;
        }

        // PUT: api/ListCals/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListCal(int id, ListCal listCal)
        {
            if (id != listCal.IdCalculo)
            {
                return BadRequest();
            }

            _context.Entry(listCal).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListCalExists(id))
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

        // POST: api/ListCals
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<ListCal>> PostListCal(ListCal listCal)
        {
            _context.ListCal.Add(listCal);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetListCal", new { id = listCal.IdCalculo }, listCal);
        }

        // DELETE: api/ListCals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ListCal>> DeleteListCal(int id)
        {
            var listCal = await _context.ListCal.FindAsync(id);
            if (listCal == null)
            {
                return NotFound();
            }

            _context.ListCal.Remove(listCal);
            await _context.SaveChangesAsync();

            return listCal;
        }

        private bool ListCalExists(int id)
        {
            return _context.ListCal.Any(e => e.IdCalculo == id);
        }
    }
}
