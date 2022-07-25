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
    public class RepositoryMediPared : Repository<data.MediPared>, IRepositoryMediPared
    {
        public RepositoryMediPared(CalculoMateContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<MediPared>> GetAllAsync()
        {
            return await _db.MediPared
                .Include(m => m.IdMedParedesNavigation)
                .ToListAsync();
        }

        public async Task<MediPared> GetOneByIdAsync(int id)
        {
            return await _db.MediPared
               .Include(m => m.IdMedParedesNavigation)
               .SingleOrDefaultAsync(m => m.IdMedPared == id);
        }

        private CalculoMateContext _db
        {
            get { return dbContext as CalculoMateContext; }
        }
    }
}
