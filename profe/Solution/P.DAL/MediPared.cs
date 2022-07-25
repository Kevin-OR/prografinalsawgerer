using data = P.DAL.DO.Objects;
using P.DAL.DO.Interfaces;
using P.DAL.EF;
using P.DAL.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace P.DAL
{
    public class MediPared : ICRUD<data.MediPared>
    {
        private RepositoryMediPared repo;


        public MediPared(CalculoMateContext _Db)
        {
            repo = new RepositoryMediPared(_Db);
        }
        public void Delete(data.MediPared t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.MediPared> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.MediPared>> GetAllAsync()
        {
            return repo.GetAllAsync();
        }

        public data.MediPared GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.MediPared> GetOneByIdAsync(int id)
        {
            return repo.GetOneByIdAsync(id);
        }

        public void Insert(data.MediPared t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.MediPared t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
