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
    public class ListCalController : ControllerBase
    {
        private readonly CalculoMateContext _context;
        private readonly IMapper mapper;

        public ListCalController(CalculoMateContext context, IMapper _mapper)
        {
            _context = context;
            mapper = _mapper;
        }

        // GET: api/ListCals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.ListCal>>> GetListCal()
        {
            var res = await new P.BS.ListCal(_context).GetAllAsync();
            var mapaux = mapper.Map<IEnumerable<data.ListCal>, IEnumerable<models.ListCal>>(res).ToList();
            return mapaux;
        }

        // GET: api/ListCals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.ListCal>> GetListCal(int id)
        {
            var listCal = await new P.BS.ListCal(_context).GetOneByIdAsync(id);
            var mapaux = mapper.Map<data.ListCal, models.ListCal>(listCal);

            if (listCal == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/ListCals/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListCal(int id, models.ListCal listCal)
        {
            if (id != listCal.IdCalculo)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.ListCal, data.ListCal>(listCal);
                new P.BS.ListCal(_context).Update(mapaux);
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
        public async Task<ActionResult<models.ListCal>> PostListCal(models.ListCal listCal)
        {
            var mapaux = mapper.Map<models.ListCal, data.ListCal>(listCal);
            new P.BS.ListCal(_context).Insert(mapaux);

            return CreatedAtAction("GetListCal", new { id = listCal.IdCalculo }, listCal);
        }

        // DELETE: api/ListCals/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.ListCal>> DeleteListCal(int id)
        {
            var listCal = new P.BS.ListCal(_context).GetOneById(id);
            if (listCal == null)
            {
                return NotFound();
            }

            new P.BS.ListCal(_context).Delete(listCal);

            var mapaux = mapper.Map<data.ListCal, models.ListCal>(listCal);

            return mapaux;
        }

        private bool ListCalExists(int id)
        {
            return (new P.BS.ListCal(_context).GetOneById(id) != null);
        }
    }
}
