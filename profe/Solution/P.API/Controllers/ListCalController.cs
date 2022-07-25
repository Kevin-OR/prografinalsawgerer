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
    public class ListCalController : ControllerBase
    {
        private readonly CalculoMateContext _context;

        public ListCalController(CalculoMateContext context)
        {
            _context = context;
        }

        // GET: api/ListCals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.ListCal>>> GetListCal()
        {
            var res = await new P.BS.ListCal(_context).GetAllAsync();
            return res.ToList();
        }

        // GET: api/ListCals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.ListCal>> GetListCal(int id)
        {
            var listCal = await new P.BS.ListCal(_context).GetOneByIdAsync(id);

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
        public async Task<IActionResult> PutListCal(int id, data.ListCal listCal)
        {
            if (id != listCal.IdCalculo)
            {
                return BadRequest();
            }

            try
            {
                new P.BS.ListCal(_context).Update(listCal);
            }
            catch (Exception ee)
            
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
        public async Task<ActionResult<data.ListCal>> PostListCal(data.ListCal listCal)
        {
            try
            {
                new P.BS.ListCal(_context).Insert(listCal);
            }
            catch (Exception ee)
            {
                if (ListCalExists(listCal.IdCalculo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetListCal", new { id = listCal.IdCalculo }, listCal);
        }

        // DELETE: api/ListCals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.ListCal>> DeleteListCal(int id)
        {
            var listCal = new P.BS.ListCal(_context).GetOneById(id);
            if (listCal == null)
            {
                return NotFound();
            }

            new P.BS.ListCal(_context).Delete(listCal);

            return listCal;
        }

        private bool ListCalExists(int id)
        {
            return (new P.BS.ListCal(_context).GetOneById(id) != null);
        }
    }
}
