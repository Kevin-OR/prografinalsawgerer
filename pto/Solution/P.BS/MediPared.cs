using System;
using System.Collections.Generic;
using System.Text;
using P.DAL.DO.Interfaces;
using P.DAL.EF;
using data = P.DAL.DO.Objects;
using P.DAL;
using dal = P.DAL;
using System.Threading.Tasks;

namespace P.BS
{
    public class MediPared : ICRUD<data.MediPared>
    {
        private dal.MediPared context;

        public MediPared(CalculoMateContext _context)
        {
            context = new dal.MediPared(_context);
        }

        public void Delete(data.MediPared t)
        {
            context.Delete(t);
        }

        public IEnumerable<data.MediPared> GetAll()
        {
            return context.GetAll();
        }

        public Task<IEnumerable<data.MediPared>> GetAllAsync()
        {
            return context.GetAllAsync();
        }

        public data.MediPared GetOneById(int id)
        {
            return context.GetOneById(id);
        }

        public Task<data.MediPared> GetOneByIdAsync(int id)
        {
            return context.GetOneByIdAsync(id);
        }

        public void Insert(data.MediPared t)
        {
            context.Insert(t);
        }

        public void Update(data.MediPared t)
        {
            context.Update(t);
        }
    }
}
