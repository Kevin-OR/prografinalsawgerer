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
    public class RepositoryCalculoMateri : Repository<data.CalculoMateri>, IRepositoryCalculoMateri
    {
        public RepositoryCalculoMateri(CalculoMateContext _dbContext) : base(_dbContext)
        {

        }
        public async Task<IEnumerable<CalculoMateri>>GetAllAsync()
        {
            return await _db.CalculoMateri
                .Include(m => m.IdMedParedes)
                .Include(m => m.IdMaterial)
                .Include(m => m.IdCalculo)
                .ToListAsync();
        }
        
        public async Task<CalculoMateri>GetOneByIdAsync(int id)
        {
            return await _db.CalculoMateri
               .Include(m => m.IdMedParedes)
               .Include(m => m.IdMaterial)
               .Include(m => m.IdCalculo)
               .SingleAsync(m => m.IdCalMateri == id);
        }


        private CalculoMateContext _db
        {
            get { return dbContext as CalculoMateContext; }
        }
    }
}
