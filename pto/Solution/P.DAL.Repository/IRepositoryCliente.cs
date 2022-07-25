using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using data = P.DAL.DO.Objects;

namespace P.DAL.Repository
{
    public interface IRepositoryCliente : IRepository<data.Cliente>
    {
        Task<IEnumerable<data.Cliente>> GetAllAsync();
        Task<data.Cliente> GetOneByIdAsync(int id);
    }
}
