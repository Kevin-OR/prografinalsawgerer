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
    public class ProvinciaController : ControllerBase
    {

            private readonly CalculoMateContext _context;

            public ProvinciaController(CalculoMateContext context)
            {
                _context = context;
            }

            // GET: api/Provincias
            [HttpGet]
            public async Task<ActionResult<IEnumerable<data.Provincia>>> GetProvincia()
            {
               
            var res = await new P.BS.Provincia(_context).GetAllAsync();
            return res.ToList();
        }

            // GET: api/Provincias/5
            [HttpGet("{id}")]
            public async Task<ActionResult<data.Provincia>> GetProvincia(short id)
            {

            var provincia = await new P.BS.Provincia(_context).GetOneByIdAsync(id);

            if (provincia == null)
            {
                return NotFound();
            }

            return provincia;


            }

            // PUT: api/Provincias/5
            // To protect from overposting attacks, enable the specific properties you want to bind to, for
            // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
            [HttpPut("{id}")]
            public async Task<IActionResult> PutProvincia(short id, data.Provincia provincia)
            {
            if (id != provincia.CodigoProvincia)
            {
                return BadRequest();
            }


            try
            {
                new P.BS.Provincia(_context).Update(provincia);
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
            public async Task<ActionResult<data.Provincia>> PostProvincia(data.Provincia provincia)
            {
            try
            {
                new P.BS.Provincia(_context).Insert(provincia);
            }
            catch (Exception ee)
            {
                if (ProvinciaExists(provincia.CodigoProvincia))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetProvincia", new { id = provincia.CodigoProvincia }, provincia);

           
            }

            // DELETE: api/Provincias/5
            [HttpDelete("{id}")]
            public async Task<ActionResult<data.Provincia>> DeleteProvincia(short id)
            {

            var provincia = new P.BS.Provincia(_context).GetOneById(id);
            if (provincia == null)
            {
                return NotFound();
            }

            new P.BS.Provincia(_context).Delete(provincia);

            return provincia;

            }

        private bool ProvinciaExists(short id)
        {
            return (new P.BS.Provincia(_context).GetOneById(id) != null);
        }
            }
        }

