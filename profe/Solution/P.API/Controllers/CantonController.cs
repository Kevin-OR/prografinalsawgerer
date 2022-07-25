using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = P.DAL.DO.Objects;


namespace P.API.Controllers
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
        public async Task<ActionResult<IEnumerable<data.Canton>>> GetCanton()
        {
            var res = await new P.BS.Canton(_context).GetAllAsync();
            return res.ToList();
        }

        // GET: api/Cantons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Canton>> GetCanton(short id)
        {
            var canton = await new P.BS.Canton(_context).GetOneByIdAsync(id);

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
        public async Task<IActionResult> PutCanton(short id, data.Canton canton)
        {
            if (id != canton.CodigoCanton)
            {
                return BadRequest();
            }


            try
            {
                new P.BS.Canton(_context).Update(canton);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<data.Canton>> PostCanton(data.Canton canton)
        {
            try
            {
                new P.BS.Canton(_context).Insert(canton);
            }
            catch (Exception ee)
            {
                if (CantonExists(canton.CodigoCanton))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCanton", new { id = canton.CodigoCanton }, canton);

            
         
        }

        // DELETE: api/Cantons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Canton>> DeleteCanton(short id)
        {
            var canton = new P.BS.Canton(_context).GetOneById(id);
            if (canton == null)
            {
                return NotFound();
            }

            new P.BS.Canton(_context).Delete(canton);

            return canton;
        }

        private bool CantonExists(short id)
        {
            return (new P.BS.Canton(_context).GetOneById(id) != null);
        }
    }
}
