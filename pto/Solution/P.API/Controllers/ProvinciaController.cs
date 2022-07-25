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
    public class ProvinciaController : ControllerBase
    {

            private readonly CalculoMateContext _context;
            private readonly IMapper mapper;

        public ProvinciaController(CalculoMateContext context, IMapper _mapper)
            {
                _context = context;
                   mapper = _mapper;
        }

            // GET: api/Provincias
            [HttpGet]
            public async Task<ActionResult<IEnumerable<models.Provincia>>> GetProvincia()
            {
            var res = new P.BS.Provincia(_context).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.Provincia>, IEnumerable<models.Provincia>>(res).ToList();
            return mapaux;

            
        }

            // GET: api/Provincias/5
            [HttpGet("{id}")]
            public async Task<ActionResult<models.Provincia>> GetProvincia(short id)
            {

            var groups = new P.BS.Provincia(_context).GetOneById(id);

            if (groups == null)
            {
                return NotFound();
            }
            var mapaux = mapper.Map<data.Provincia, models.Provincia>(groups);
            return mapaux;

           


            }

            // PUT: api/Provincias/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("{id}")]
            public async Task<IActionResult> PutProvincia(short id, models.Provincia provincia)
            {

            if (id != provincia.CodigoProvincia)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Provincia, data.Provincia>(provincia);
                new P.BS.Provincia(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!ProvinciaExists(id))
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

            // POST: api/Provincias
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPost]
            public async Task<ActionResult<models.Provincia>> PostProvincia(models.Provincia provincia)
            {
            var mapaux = mapper.Map<models.Provincia, data.Provincia>(provincia);
            new P.BS.Provincia(_context).Insert(mapaux);

            return CreatedAtAction("GetProvincia", new { id = provincia.CodigoProvincia }, provincia);

           
            }

            // DELETE: api/Provincias/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<models.Provincia>> DeleteProvincia(short id)
            {

            var provincia = new P.BS.Provincia(_context).GetOneById(id);
            if (provincia == null)
            {
                return NotFound();
            }

            new P.BS.Provincia(_context).Delete(provincia);
            var mapaux = mapper.Map<data.Provincia, models.Provincia>(provincia);

            return mapaux;

            }

        private bool ProvinciaExists(short id)
        {
            return (new P.BS.Provincia(_context).GetOneById(id) != null);
        }
            }
        }

