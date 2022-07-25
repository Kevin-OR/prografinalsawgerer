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
    public class ClienteController : ControllerBase
    {
        private readonly CalculoMateContext _context;
        private readonly IMapper mapper;

        public ClienteController(CalculoMateContext context, IMapper _mapper)
        {
            _context = context;
            mapper = _mapper;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<models.Cliente>>> GetCliente()
        {
            var res = await new P.BS.Cliente(_context).GetAllAsync();
            var mapaux = mapper.Map<IEnumerable<data.Cliente>, IEnumerable<models.Cliente>>(res).ToList();

            return mapaux;
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<models.Cliente>> GetCliente(int id)
        {
            var cliente = await new P.BS.Cliente(_context).GetOneByIdAsync(id);
            var mapaux = mapper.Map<data.Cliente, models.Cliente>(cliente);

            if (cliente == null)
            {
                return NotFound();
            }

            return mapaux;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, models.Cliente cliente)
        {
            if (id != cliente.IdClie)
            {
                return BadRequest();
            }


            try
            {
                var mapaux = mapper.Map<models.Cliente, data.Cliente>(cliente);
                new P.BS.Cliente(_context).Update(mapaux);
            }
            catch (Exception ee)
            {
                if (!ClienteExists(id))
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

        // POST: api/Clientes
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<models.Cliente>> PostCliente(models.Cliente cliente)
        {
            var mapaux = mapper.Map<models.Cliente, data.Cliente>(cliente);
            new P.BS.Cliente(_context).Insert(mapaux);

            return CreatedAtAction("GetCliente", new { id = cliente.IdClie}, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<models.Cliente>> DeleteCliente(int id)
        {
            var cliente = new P.BS.Cliente(_context).GetOneById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            new P.BS.Cliente(_context).Delete(cliente);

            var mapaux = mapper.Map<data.Cliente, models.Cliente>(cliente);

            return mapaux;
        }

        private bool ClienteExists(int id)
        {
            return (new P.BS.Cliente(_context).GetOneById(id) != null);

        }
    }
}
