using data = P.DAL.DO.Objects;
using P.DAL.DO.Interfaces;
using P.DAL.EF;
using P.DAL.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace P.DAL
{
    public class ListCal : ICRUD<data.ListCal>
    {
        private RepositoryListCal repo;

        public ListCal(CalculoMateContext _Db)
        {
            repo = new RepositoryListCal(_Db);
        }
        public void Delete(data.ListCal t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.ListCal> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.ListCal>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.ListCal GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.ListCal> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsync(id);
        }

        public void Insert(data.ListCal t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.ListCal t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
