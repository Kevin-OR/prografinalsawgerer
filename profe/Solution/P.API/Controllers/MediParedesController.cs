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
    public class MediParedesController : ControllerBase
    {
        private readonly CalculoMateContext _context;

        public MediParedesController(CalculoMateContext context)
        {
            _context = context;
        }

        // GET: api/MediParedes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.MediParedes>>> GetMediParedes()
        {
            var res = await new P.BS.MediParedes(_context).GetAllAsync();
            return res.ToList();
        }

        // GET: api/MediParedes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.MediParedes>> GetMediParedes(int id)
        {
            var mediParedes = await new P.BS.MediParedes(_context).GetOneByIdAsync(id);

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
        public async Task<IActionResult> PutMediParedes(int id, data.MediParedes mediParedes)
        {
            if (id != mediParedes.IdMedParedes)
            {
                return BadRequest();
            }

            try
            {
                new P.BS.MediParedes(_context).Update(mediParedes);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<data.MediParedes>> PostMediParedes(data.MediParedes mediParedes)
        {
            try
            {
                new P.BS.MediParedes(_context).Insert(mediParedes);
            }
            catch (Exception ee)
            {
                if (MediParedesExists(mediParedes.IdMedParedes))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMediParedes", new { id = mediParedes.IdMedParedes }, mediParedes);
        }

        // DELETE: api/MediParedes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.MediParedes>> DeleteMediParedes(int id)
        {
            var mediParedes = new P.BS.MediParedes(_context).GetOneById(id);
            if (mediParedes == null)
            {
                return NotFound();
            }

            new P.BS.MediParedes(_context).Delete(mediParedes);

            return mediParedes;
        }

        private bool MediParedesExists(int id)
        {
            return (new P.BS.MediParedes(_context).GetOneById(id) != null);
        }

    }
}
