using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = P.DAL.DO.Objects;

namespace P.DAL.Repository
{
    public interface IRepositoryCalculoMateri : IRepository<data.CalculoMateri>
    {
        Task<IEnumerable<data.CalculoMateri>> GetAllAsync();
        Task<data.CalculoMateri> GetOneByIdAsync(int id);
    }
}
