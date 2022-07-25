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
    public class MediParedController : ControllerBase
    {
        private readonly CalculoMateContext _context;

        public MediParedController(CalculoMateContext context)
        {
            _context = context;
        }

        // GET: api/MediPareds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.MediPared>>> GetMediPared()
        {
            var res = await new P.BS.MediPared(_context).GetAllAsync();
            return res.ToList();
        }

        // GET: api/MediPareds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.MediPared>> GetMediPared(int id)
        {
            var mediPared = await new P.BS.MediPared(_context).GetOneByIdAsync(id);

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
        public async Task<IActionResult> PutMediPared(int id, data.MediPared mediPared)
        {
            if (id != mediPared.IdMedPared)
            {
                return BadRequest();
            }

            try
            {
                new P.BS.MediPared(_context).Update(mediPared);
            }
            catch (Exception ee)
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
        public async Task<ActionResult<data.MediPared>> PostMediPared(data.MediPared mediPared)
        {
            try
            {
                new P.BS.MediPared(_context).Insert(mediPared);
            }
            catch (Exception ee)
            {
                if (MediParedExists(mediPared.IdMedPared))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMediPared", new { id = mediPared.IdMedPared }, mediPared);
        }

        // DELETE: api/MediPareds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.MediPared>> DeleteMediPared(int id)
        {
            var mediPared = new P.BS.MediPared(_context).GetOneById(id);
            if (mediPared == null)
            {
                return NotFound();
            }

            new P.BS.MediPared(_context).Delete(mediPared);

            return mediPared;
        }

        private bool MediParedExists(int id)
        {
            return (new P.BS.MediPared(_context).GetOneById(id) != null);
        }
    }
}
