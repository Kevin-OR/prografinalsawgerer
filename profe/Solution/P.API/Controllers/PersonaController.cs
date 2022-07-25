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
    public class PersonaController : ControllerBase
    {
        private readonly CalculoMateContext _context;

        public PersonaController(CalculoMateContext context)
        {
            _context = context;
        }

        // GET: api/Personas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Persona>>> GetPersona()
        {
            var res = await new P.BS.Persona(_context).GetAllAsync();
            return res.ToList();
        }

        // GET: api/Personas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Persona>> GetPersona(int id)
        {
            var persona = await new P.BS.Persona(_context).GetOneByIdAsync(id);

            if (persona == null)
            {
                return NotFound();
            }

            return persona;
        }

        // PUT: api/Personas/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersona(int id, data.Persona persona)
        {
            if (id != persona.IdPer)
            {
                return BadRequest();
            }

            try
            {
                new P.BS.Persona(_context).Update(persona);
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
        public async Task<ActionResult<data.Persona>> PostPersona(data.Persona persona)
        {
            try
            {
                new P.BS.Persona(_context).Insert(persona);
            }
            catch (Exception ee)
            {
                if (PersonaExists(persona.IdPer))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPersona", new { id = persona.IdPer }, persona);
        }

        // DELETE: api/Personas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Persona>> DeletePersona(int id)
        {
            var persona = new P.BS.Persona(_context).GetOneById(id);
            if (persona == null)
            {
                return NotFound();
            }

            new P.BS.Persona(_context).Delete(persona);

            return persona;
        }

        private bool PersonaExists(int id)
        {
            return (new P.BS.Persona(_context).GetOneById(id) != null);
        }

    }
}
