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
    public class RepositoryCanton : Repository<data.Canton>, IRepositoryCanton
    {
        public RepositoryCanton(CalculoMateContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<Canton>> GetAllAsync()
        {
            return await _db.Canton
                .Include(m => m.CodigoProvincia)
                .ToListAsync();
        }

        public async Task<Canton> GetOneByIdAsync(int id)
        {
            return await _db.Canton
               .Include(m => m.CodigoProvincia)
               .SingleAsync(m => m.CodigoCanton == id);
        }

        private CalculoMateContext _db
        {
            get { return dbContext as CalculoMateContext; }
        }
    }
}
