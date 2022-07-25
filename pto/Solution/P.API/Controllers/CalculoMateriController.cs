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
    public class CalculoMateriController : ControllerBase
    {
        private readonly CalculoMateContext _context;
        private readonly IMapper mapper;

        public CalculoMateriController(CalculoMateContext context, IMapper _mapper)
        {
            _context = context;
            mapper = _mapper;
        }

        // GET: api/CalculoMateris
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.CalculoMateri>>> GetCalculoMateri()
        {
            var res = await new P.BS.CalculoMateri(_context).GetAllAsync();
            var mapaux = mapper.Map<IEnumerable<data.CalculoMateri>, IEnumerable<models.CalculoMateri>>(res).ToList();
            return mapaux;
        }

        // GET: api/CalculoMateris/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.CalculoMateri>> GetCalculoMateri(int id)
        {
            var calculoMateri = await new P.BS.CalculoMateri(_context).GetOneByIdAsync(id);
            var mapaux = mapper.Map<data.CalculoMateri, models.CalculoMateri>(calculoMateri);

            if (calculoMateri == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/CalculoMateris/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalculoMateri(int id, models.CalculoMateri calculoMateri)
        {
            if (id != calculoMateri.IdCalMateri)
            {
                return BadRequest();
            }

            try
            {
                var mapaux = mapper.Map<models.CalculoMateri, data.CalculoMateri>(calculoMateri);
                new P.BS.CalculoMateri(_context).Update(mapaux);
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
        public async Task<ActionResult<models.CalculoMateri>> PostCalculoMateri(models.CalculoMateri calculoMateri)
        {
            var mapaux = mapper.Map<models.CalculoMateri, data.CalculoMateri>(calculoMateri);
            new P.BS.CalculoMateri(_context).Insert(mapaux);

            return CreatedAtAction("GetCalculoMateri", new { id = calculoMateri.IdCalMateri }, calculoMateri);
        }

        // DELETE: api/CalculoMateris/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.CalculoMateri>> DeleteCalculoMateri(int id)
        {
            var calculoMateri = new P.BS.CalculoMateri(_context).GetOneById(id);
            if (calculoMateri == null)
            {
                return NotFound();
            }

            new P.BS.CalculoMateri(_context).Delete(calculoMateri);

            var mapaux = mapper.Map<data.CalculoMateri, models.CalculoMateri>(calculoMateri);

            return mapaux;
        }

        private bool CalculoMateriExists(int id)
        {
            return (new P.BS.CalculoMateri(_context).GetOneById(id) != null);
        }
    }
    }
