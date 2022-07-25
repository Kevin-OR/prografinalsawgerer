using data = P.DAL.DO.Objects;
using P.DAL.DO.Interfaces;
using P.DAL.EF;
using P.DAL.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace P.DAL
{
    public class CalculoMateri : ICRUD<data.CalculoMateri>
    {
        private RepositoryCalculoMateri repo;

        public CalculoMateri(CalculoMateContext _Db)
        {
            repo = new RepositoryCalculoMateri(_Db);
        }
        public void Delete(data.CalculoMateri t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.CalculoMateri> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.CalculoMateri>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.CalculoMateri GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.CalculoMateri> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsync(id);
        }

        public void Insert(data.CalculoMateri t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.CalculoMateri t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
