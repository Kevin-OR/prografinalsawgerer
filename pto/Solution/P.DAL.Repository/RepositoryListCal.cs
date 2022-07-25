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
                .Include(m => m.IdPerNavigation)
                .Include(m => m.IdClieNavigation)
                .ToListAsync();
        }

        public async Task<ListCal> GetOneByIdAsync(int id)
        {
            return await _db.ListCal
               .Include(m => m.IdPerNavigation)
               .Include(m => m.IdClieNavigation)
               .SingleOrDefaultAsync(m => m.IdCalculo == id);
        }

        private CalculoMateContext _db
        {
            get { return dbContext as CalculoMateContext; }
        }
    }
}
