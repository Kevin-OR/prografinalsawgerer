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
    public class CantonController : ControllerBase
    {
        private readonly CalculoMateContext _context;
        private readonly IMapper mapper;

        public CantonController(CalculoMateContext context, IMapper _mapper)
        {
            _context = context;
            mapper = _mapper;
        }

        // GET: api/Cantons
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Canton>>> GetCanton()
        {
            var res = await new P.BS.Canton(_context).GetAllAsync();
            var mapaux = mapper.Map<IEnumerable<data.Canton>, IEnumerable<models.Canton>>(res).ToList();
            return mapaux;
        }

        // GET: api/Cantons/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Canton>> GetCanton(short id)
        {
            var canton = await new P.BS.Canton(_context).GetOneByIdAsync(id);
            var mapaux = mapper.Map<data.Canton, models.Canton>(canton);

            if (canton == null)
            {
                return NotFound();
            }

            return mapaux;
            
        }

        // PUT: api/Cantons/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCanton(short id, models.Canton canton)
        {
            if (id != canton.CodigoCanton)
            {
                return BadRequest();
            }


            try
            {
                var mapaux = mapper.Map<models.Canton, data.Canton>(canton);
                new P.BS.Canton(_context).Update(mapaux);
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
        public async Task<ActionResult<models.Canton>> PostCanton(models.Canton canton)
        {
            var mapaux = mapper.Map<models.Canton, data.Canton>(canton);
            new P.BS.Canton(_context).Insert(mapaux);

            return CreatedAtAction("GetCanton", new { id = canton.CodigoCanton }, canton);

            
         
        }

        // DELETE: api/Cantons/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Canton>> DeleteCanton(short id)
        {
            var canton = new P.BS.Canton(_context).GetOneById(id);
            if (canton == null)
            {
                return NotFound();
            }

            new P.BS.Canton(_context).Delete(canton);

            var mapaux = mapper.Map<data.Canton, models.Canton>(canton);

            return mapaux;
        }

        private bool CantonExists(short id)
        {
            return (new P.BS.Canton(_context).GetOneById(id) != null);
        }
    }
}
