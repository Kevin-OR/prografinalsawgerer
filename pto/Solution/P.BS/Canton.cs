using System;
using System.Collections.Generic;
using System.Text;
using P.DAL.EF;
using data = P.DAL.DO.Objects;
using P.DAL;
using dal = P.DAL;
using System.Threading.Tasks;
using P.DAL.DO.Interfaces;

namespace P.BS
{
    public class Canton : ICRUD<data.Canton>
    {
        private dal.Canton context;

        public Canton(CalculoMateContext _context)
        {
            context = new dal.Canton(_context);
        }
        public void Delete(data.Canton t)
        {
            context.Delete(t);
        }

        public IEnumerable<data.Canton> GetAll()
        {
            return context.GetAll();
        }

        public Task<IEnumerable<data.Canton>> GetAllAsync()
        {
            return context.GetAllAsync();
        }

        public data.Canton GetOneById(int id)
        {
            return context.GetOneById(id);
        }

        public Task<data.Canton> GetOneByIdAsync(int id)
        {
            return context.GetOneByIdAsync(id);
        }

        public void Insert(data.Canton t)
        {
            context.Insert(t);
        }

        public void Update(data.Canton t)
        {
            context.Update(t);
        }
    }
}
