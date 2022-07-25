using data = P.DAL.DO.Objects;
using P.DAL.DO.Interfaces;
using P.DAL.EF;
using P.DAL.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace P.DAL
{
    public class Cliente : ICRUD<data.Cliente>
    {
        private RepositoryCliente repo;

        public Cliente(CalculoMateContext _Db)
        {
            repo = new RepositoryCliente(_Db);
        }
        public void Delete(data.Cliente t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Cliente> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Cliente>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Cliente GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Cliente> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsync(id);
        }

        public void Insert(data.Cliente t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Cliente t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
