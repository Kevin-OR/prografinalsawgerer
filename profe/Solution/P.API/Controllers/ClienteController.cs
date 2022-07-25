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
    public class ClienteController : ControllerBase
    {
        private readonly CalculoMateContext _context;

        public ClienteController(CalculoMateContext context)
        {
            _context = context;
        }

        // GET: api/Clientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<data.Cliente>>> GetCliente()
        {
            var res = await new P.BS.Cliente(_context).GetAllAsync();
            return res.ToList();
        }

        // GET: api/Clientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<data.Cliente>> GetCliente(int id)
        {
            var cliente = await new P.BS.Cliente(_context).GetOneByIdAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        // PUT: api/Clientes/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, data.Cliente cliente)
        {
            if (id != cliente.IdClie)
            {
                return BadRequest();
            }


            try
            {
                new P.BS.Cliente(_context).Update(cliente);
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
        public async Task<ActionResult<data.Cliente>> PostCliente(data.Cliente cliente)
        {
            try
            {
                new P.BS.Cliente(_context).Insert(cliente);
            }
            catch (Exception ee)
            {
                if (ClienteExists(cliente.IdClie))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetCliente", new { id = cliente.IdClie }, cliente);
        }

        // DELETE: api/Clientes/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<data.Cliente>> DeleteCliente(int id)
        {
            var cliente = new P.BS.Cliente(_context).GetOneById(id);
            if (cliente == null)
            {
                return NotFound();
            }

            new P.BS.Cliente(_context).Delete(cliente);

            return cliente;
        }

        private bool ClienteExists(int id)
        {
            return (new P.BS.Cliente(_context).GetOneById(id) != null);

        }
    }
}
