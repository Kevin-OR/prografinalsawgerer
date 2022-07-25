using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using P.DAL.DO.Objects;
using data = P.DAL.DO.Objects;
using P.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace P.DAL.Repository
{
    public class RepositoryCliente : Repository<data.Cliente>, IRepositoryCliente
    {
        public RepositoryCliente(CalculoMateContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _db.Cliente
                .Include(m => m.CodigoCanton)
                .ToListAsync();
        }

        public async Task<Cliente> GetOneByIdAsync(int id)
        {
            return await _db.Cliente
               .Include(m => m.CodigoCanton)
               .SingleAsync(m => m.IdClie == id);
        }

        private CalculoMateContext _db
        {
            get { return dbContext as CalculoMateContext; }
        }
    }
}
