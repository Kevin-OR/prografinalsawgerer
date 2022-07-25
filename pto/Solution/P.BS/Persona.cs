using System;
using System.Collections.Generic;
using System.Text;
using P.DAL.DO.Interfaces;
using P.DAL.EF;
using data = P.DAL.DO.Objects;
using P.DAL;
using System.Threading.Tasks;

namespace P.BS
{
    public class Persona : ICRUD<data.Persona>
    {
        private CalculoMateContext context;

        public Persona(CalculoMateContext _context)
        {
            context = _context;
        }

        public void Delete(data.Persona t)
        {
            new P.DAL.Persona(context).Delete(t);
        }

        public IEnumerable<data.Persona> GetAll()
        {
            return new P.DAL.Persona(context).GetAll();
        }

        public Task<IEnumerable<data.Persona>> GetAllAsync()
        {
            return new P.DAL.Persona(context).GetAllAsync();
        }

        public data.Persona GetOneById(int id)
        {
            return new P.DAL.Persona(context).GetOneById(id);
        }

        public Task<data.Persona> GetOneByIdAsync(int id)
        {
            return new P.DAL.Persona(context).GetOneByIdAsync(id);
        }

        public void Insert(data.Persona t)
        {
            new P.DAL.Persona(context).Insert(t);
        }

        public void Update(data.Persona t)
        {
            new P.DAL.Persona(context).Update(t);
        }
    }
}
