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
    public class MaterialesController : ControllerBase
    {
        private readonly CalculoMateContext _context;

        public MaterialesController(CalculoMateContext context)
        {
            _context = context;
        }

        // GET: api/Materiales
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Materiales>>> GetMateriales()
        {
            var res = await new P.BS.Materiales(_context).GetAllAsync();
            return res.ToList();
        }

        // GET: api/Materiales/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Materiales>> GetMateriales(int id)
        {
            var materiales = await new P.BS.Materiales(_context).GetOneByIdAsync(id);

            if (materiales == null)
            {
                return NotFound();
            }

            return materiales;
        }

        // PUT: api/Materiales/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMateriales(int id, data.Materiales materiales)
        {
            if (id != materiales.IdMaterial)
            {
                return BadRequest();
            }

            try
            {
                new P.BS.Materiales(_context).Update(materiales);
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
        public async Task<ActionResult<data.Materiales>> PostMateriales(data.Materiales materiales)
        {
            try
            {
                new P.BS.Materiales(_context).Insert(materiales);
            }
            catch (Exception ee)
            {
                if (MaterialesExists(materiales.IdMaterial))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetMateriales", new { id = materiales.IdMaterial }, materiales);
        }

        // DELETE: api/Materiales/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Materiales>> DeleteMateriales(int id)
        {
            var materiales = new P.BS.Materiales(_context).GetOneById(id);
            if (materiales == null)
            {
                return NotFound();
            }

            new P.BS.Materiales(_context).Delete(materiales);

            return materiales;
        }

        private bool MaterialesExists(int id)
        {
            return (new P.BS.Materiales(_context).GetOneById(id) != null);
        }
    }
}
