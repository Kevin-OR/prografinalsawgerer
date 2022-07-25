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
    public class CalculoMateriController : ControllerBase
    {
        private readonly CalculoMateContext _context;

        public CalculoMateriController(CalculoMateContext context)
        {
            _context = context;
        }

        // GET: api/CalculoMateris
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.CalculoMateri>>> GetCalculoMateri()
        {
            var res = await new P.BS.CalculoMateri(_context).GetAllAsync();
            return res.ToList();
        }

        // GET: api/CalculoMateris/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.CalculoMateri>> GetCalculoMateri(int id)
        {
            var calculoMateri = await new P.BS.CalculoMateri(_context).GetOneByIdAsync(id);

            if (calculoMateri == null)
            {
                return NotFound();
            }

            return calculoMateri;
        }

        // PUT: api/CalculoMateris/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalculoMateri(int id, data.CalculoMateri calculoMateri)
        {
            if (id != calculoMateri.IdCalMateri)
            {
                return BadRequest();
            }

            try
            {
                new P.BS.CalculoMateri(_context).Update(calculoMateri);
            }
            catch (Exception ee)
            {
                if (!CalculoMateriExists(id))
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

        // POST: api/CalculoMateris
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<data.CalculoMateri>> PostCalculoMateri(data.CalculoMateri calculoMateri)
        {
            try
            {
                new P.BS.CalculoMateri(_context).Insert(calculoMateri);
            }
            catch (Exception ee)
            {
                if (CalculoMateriExists(calculoMateri.IdCalMateri))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            return CreatedAtAction("GetCalculoMateri", new { id = calculoMateri.IdCalMateri }, calculoMateri);
        }

        // DELETE: api/CalculoMateris/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.CalculoMateri>> DeleteCalculoMateri(int id)
        {
            var calculoMateri = new P.BS.CalculoMateri(_context).GetOneById(id);
            if (calculoMateri == null)
            {
                return NotFound();
            }

            new P.BS.CalculoMateri(_context).Delete(calculoMateri);


            return calculoMateri;
        }

        private bool CalculoMateriExists(int id)
        {
            return (new P.BS.CalculoMateri(_context).GetOneById(id) != null);
        }
    }
    }
