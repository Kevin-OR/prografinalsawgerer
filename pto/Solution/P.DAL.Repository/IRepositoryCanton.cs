using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = P.DAL.DO.Objects;

namespace P.DAL.Repository
{
    public interface IRepositoryCanton : IRepository<data.Canton>
    {
        Task<IEnumerable<data.Canton>> GetAllAsync();
        Task<data.Canton> GetOneByIdAsync(int id);
    }
}

