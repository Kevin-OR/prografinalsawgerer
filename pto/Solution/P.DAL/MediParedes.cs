using data = P.DAL.DO.Objects;
using P.DAL.DO.Interfaces;
using P.DAL.EF;
using P.DAL.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace P.DAL
{
    public class MediParedes : ICRUD<data.MediParedes>
    {
        private Repository<data.MediParedes> repo;

        public MediParedes(CalculoMateContext _Db)
        {
            repo = new Repository<data.MediParedes>(_Db);
        }
        public void Delete(data.MediParedes t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.MediParedes> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.MediParedes>> GetAllAsync()
        {
            return null;
        }

        public data.MediParedes GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.MediParedes> GetOneByIdAsync(int id)
        {
            return null;
        }

        public void Insert(data.MediParedes t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.MediParedes t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
