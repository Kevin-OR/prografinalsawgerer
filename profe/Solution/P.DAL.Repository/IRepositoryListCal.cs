using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = P.DAL.DO.Objects;

namespace P.DAL.Repository
{
    public interface IRepositoryListCal : IRepository<data.ListCal>
    {
        Task<IEnumerable<data.ListCal>> GetAllAsync();
        Task<data.ListCal> GetOneByIdAsync(int id);
    }
}
