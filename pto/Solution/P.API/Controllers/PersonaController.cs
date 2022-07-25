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
    public class PersonaController : ControllerBase
    {
        private readonly CalculoMateContext _context;
        private readonly IMapper mapper;

        public PersonaController(CalculoMateContext context, IMapper _mapper)
        {
            _context = context;
            mapper = _mapper;
        }

        // GET: api/Personas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Persona>>> GetPersona()
        {
            var res = new P.BS.Persona(_context).GetAll();
            var mapaux = mapper.Map<IEnumerable<data.Persona>, IEnumerable<models.Persona>>(res).ToList();
            return mapaux;
           
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Persona>> GetPersona(int id)
        {
            var persona = new P.BS.Persona(_context).GetOneById(id);
            

            if (persona == null)
            {
                return NotFound();
            }
            var mapaux = mapper.Map<data.Persona, models.Persona>(persona);
            return mapaux;
        }

        // PUT: api/Personas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, models.Persona persona)
        {
            if (id != persona.IdPer)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.Persona, data.Persona>(persona);
                new P.BS.Persona(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!PersonaExists(id))
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

        // POST: api/Personas
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Persona>> PostPersona(models.Persona persona)
        {

            var mapaux = mapper.Map<models.Persona, data.Persona>(persona);
            new P.BS.Persona(_context).Insert(mapaux);

            return CreatedAtAction("GetPersona", new { id = persona.IdPer}, persona);

           
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Persona>> DeletePersona(int id)
        {
            var persona = new P.BS.Persona(_context).GetOneById(id);
            if (persona == null)
            {
                return NotFound();
            }

            new P.BS.Persona(_context).Delete(persona);
            var mapaux = mapper.Map<data.Persona, models.Persona>(persona);

            return mapaux;
        }

        private bool PersonaExists(int id)
        {
            return (new P.BS.Persona(_context).GetOneById(id) != null);
        }

    }
}
