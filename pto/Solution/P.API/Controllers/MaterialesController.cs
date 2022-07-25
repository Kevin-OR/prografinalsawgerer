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
    public class MaterialesController : ControllerBase
    {
        private readonly CalculoMateContext _context;
        private readonly IMapper mapper;

        public MaterialesController(CalculoMateContext context, IMapper _mapper)
        {
            _context = context;
            mapper = _mapper;
        }

        // GET: api/Materiales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Materiales>>> GetMateriales()
        {
            var res = new P.BS.Materiales(_context).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.Materiales>, IEnumerable<models.Materiales>>(res).ToList();
            return mapaux;
        }

        // GET: api/Materiales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Materiales>> GetMateriales(int id)
        {
            var materiales = new P.BS.Materiales(_context).GetOneById(id);
            

            if (materiales == null)
            {
                return NotFound();
            }
            var mapaux = mapper.Map<data.Materiales, models.Materiales>(materiales);
            return mapaux;
        }

        // PUT: api/Materiales/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMateriales(int id, models.Materiales materiales)
        {
            if (id != materiales.IdMaterial)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Materiales, data.Materiales>(materiales);
                new P.BS.Materiales(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!MaterialesExists(id))
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

        // POST: api/Materiales
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Materiales>> PostMateriales(models.Materiales materiales)
        {
            var mapaux = mapper.Map<models.Materiales, data.Materiales>(materiales);
            new P.BS.Materiales(_context).Insert(mapaux);

            return CreatedAtAction("GetMateriales", new { id = materiales.IdMaterial }, materiales);
        }

        // DELETE: api/Materiales/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Materiales>> DeleteMateriales(int id)
        {
            var materiales = new P.BS.Materiales(_context).GetOneById(id);
            if (materiales == null)
            {
                return NotFound();
            }

            new P.BS.Materiales(_context).Delete(materiales);

            var mapaux = mapper.Map<data.Materiales, models.Materiales>(materiales);

            return mapaux;
        }

        private bool MaterialesExists(int id)
        {
            return (new P.BS.Materiales(_context).GetOneById(id) != null);
        }
    }
}
