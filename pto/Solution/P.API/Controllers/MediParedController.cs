using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using P.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using data = P.DAL.DO.Objects;
using models = P.API.Models;

namespace P.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediParedController : ControllerBase
    {
        private readonly CalculoMateContext _context;
        private readonly IMapper mapper;

        public MediParedController(CalculoMateContext context, IMapper _mapper)
        {
            _context = context;
            mapper = _mapper;
        }

        // GET: api/MediPareds
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.MediPared>>> GetMediPared()
        {
            var res = await new P.BS.MediPared(_context).GetAllAsync();
            var mapaux = mapper.Map<IEnumerable<data.MediPared>, IEnumerable<models.MediPared>>(res).ToList();

            return mapaux;
        }

        // GET: api/MediPareds/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.MediPared>> GetMediPared(int id)
        {
            var mediPared = await new P.BS.MediPared(_context).GetOneByIdAsync(id);
            var mapaux = mapper.Map<data.MediPared, models.MediPared>(mediPared);

            if (mediPared == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/MediPareds/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMediPared(int id, models.MediPared mediPared)
        {
            if (id != mediPared.IdMedPared)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.MediPared, data.MediPared>(mediPared);
                new P.BS.MediPared(_context).Update(mapaux);
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
        public async Task<ActionResult<models.MediPared>> PostMediPared(models.MediPared mediPared)
        {
            var mapaux = mapper.Map<models.MediPared, data.MediPared>(mediPared);
            new P.BS.MediPared(_context).Insert(mapaux);

            return CreatedAtAction("GetMediPared", new { id = mediPared.IdMedPared }, mediPared);
        }

        // DELETE: api/MediPareds/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.MediPared>> DeleteMediPared(int id)
        {
            var mediPared = new P.BS.MediPared(_context).GetOneById(id);
            if (mediPared == null)
            {
                return NotFound();
            }

            new P.BS.MediPared(_context).Delete(mediPared);
            var mapaux = mapper.Map<data.MediPared, models.MediPared>(mediPared);

            return mapaux;
        }

        private bool MediParedExists(int id)
        {
            return (new P.BS.MediPared(_context).GetOneById(id) != null);
        }
    }
}
