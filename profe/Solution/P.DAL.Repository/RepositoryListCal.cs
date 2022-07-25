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
    public class RepositoryListCal : Repository<data.ListCal>, IRepositoryListCal
    {
        public RepositoryListCal(CalculoMateContext _dbContext) : base(_dbContext)
        {

        }

        public async Task<IEnumerable<ListCal>> GetAllAsync()
        {
            return await _db.ListCal
                .Include(m => m.IdPer)
                .Include(m => m.IdClie)
                .ToListAsync();
        }

        public async Task<ListCal> GetOneByIdAsync(int id)
        {
            return await _db.ListCal
               .Include(m => m.IdPer)
               .Include(m => m.IdClie)
               .SingleAsync(m => m.IdCalculo == id);
        }

        private CalculoMateContext _db
        {
            get { return dbContext as CalculoMateContext; }
        }
    }
}
