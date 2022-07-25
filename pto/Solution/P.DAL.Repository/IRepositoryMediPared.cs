using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = P.DAL.DO.Objects;

namespace P.DAL.Repository
{
    public interface IRepositoryMediPared : IRepository<data.MediPared>
    {
        Task<IEnumerable<data.MediPared>> GetAllAsync();
        Task<data.MediPared> GetOneByIdAsync(int id);
    }
}
