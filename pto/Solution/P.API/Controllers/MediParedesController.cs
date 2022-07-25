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
    public class MediParedesController : ControllerBase
    {
        private readonly CalculoMateContext _context;
        private readonly IMapper mapper;
        public MediParedesController(CalculoMateContext context, IMapper _mapper)
        {
            _context = context;
            mapper = _mapper;
        }

        // GET: api/MediParedes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.MediParedes>>> GetMediParedes()
        {
            var res = new P.BS.MediParedes(_context).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.MediParedes>, IEnumerable<models.MediParedes>>(res).ToList();
            return mapaux;
           
        }

        // GET: api/MediParedes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.MediParedes>> GetMediParedes(int id)
        {
            var mediParedes = new P.BS.MediParedes(_context).GetOneById(id);
            

            if (mediParedes == null)
            {
                return NotFound();
            }
            var mapaux = mapper.Map<data.MediParedes, models.MediParedes>(mediParedes);
            return mapaux;
        }

        // PUT: api/MediParedes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMediParedes(int id, models.MediParedes mediParedes)
        {
            if (id != mediParedes.IdMedParedes)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.MediParedes, data.MediParedes>(mediParedes);
                new P.BS.MediParedes(_context).Update(mapaux);
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
        public async Task<ActionResult<models.MediParedes>> PostMediParedes(models.MediParedes mediParedes)
        {

            var mapaux = mapper.Map<models.MediParedes, data.MediParedes>(mediParedes);
            new P.BS.MediParedes(_context).Insert(mapaux);

            return CreatedAtAction("GetMediParedes", new { id = mediParedes.IdMedParedes }, mediParedes);

            
        }

        // DELETE: api/MediParedes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.MediParedes>> DeleteMediParedes(int id)
        {
            var mediParedes = new P.BS.MediParedes(_context).GetOneById(id);
            if (mediParedes == null)
            {
                return NotFound();
            }

            new P.BS.MediParedes(_context).Delete(mediParedes);

            var mapaux = mapper.Map<data.MediParedes, models.MediParedes>(mediParedes);

            return mapaux;
        }

        private bool MediParedesExists(int id)
        {
            return (new P.BS.MediParedes(_context).GetOneById(id) != null);
        }

    }
}
