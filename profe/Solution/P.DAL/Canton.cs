using data = P.DAL.DO.Objects;
using P.DAL.DO.Interfaces;
using P.DAL.EF;
using P.DAL.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace P.DAL
{
    public class Canton : ICRUD<data.Canton>
    {
        private RepositoryCanton repo;

        public Canton(CalculoMateContext _Db)
        {
            repo = new RepositoryCanton(_Db);
        }
        public void Delete(data.Canton t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Canton> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Canton>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.Canton GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Canton> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsync(id);
        }

        public void Insert(data.Canton t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Canton t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
