using data = P.DAL.DO.Objects;
using P.DAL.DO.Interfaces;
using P.DAL.EF;
using P.DAL.Repository;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace P.DAL
{
    public class Persona : ICRUD<data.Persona>
    {
        private Repository<data.Persona> repo;

        public Persona(CalculoMateContext _Db)
        {
            repo = new Repository<data.Persona>(_Db);
        }
        public void Delete(data.Persona t)
        {
            repo.Delete(t);
            repo.Commit();
        }

        public IEnumerable<data.Persona> GetAll()
        {
            return repo.GetAll();
        }

        public Task<IEnumerable<data.Persona>> GetAllAsync()
        {
            return null;
        }

        public data.Persona GetOneById(int id)
        {
            return repo.GetOnebyID(id);
        }

        public Task<data.Persona> GetOneByIdAsync(int id)
        {
            return null;
        }

        public void Insert(data.Persona t)
        {
            repo.Insert(t);
            repo.Commit();
        }

        public void Update(data.Persona t)
        {
            repo.Update(t);
            repo.Commit();
        }
    }
}
