using System;
using System.Collections.Generic;
using System.Text;
using P.DAL.EF;
using data = P.DAL.DO.Objects;
using P.DAL;
using System.Threading.Tasks;
using P.DAL.DO.Interfaces;

namespace P.BS
{
    public class Canton : ICRUD<data.Canton>
    {
        private CalculoMateContext context;

        public Canton(CalculoMateContext _context)
        {
            context = _context;
        }
        public void Delete(data.Canton t)
        {
            new P.DAL.Canton(context).Delete(t);
        }

        public IEnumerable<data.Canton> GetAll()
        {
            return new P.DAL.Canton(context).GetAll();
        }

        public Task<IEnumerable<data.Canton>> GetAllAsync()
        {
            return new P.DAL.Canton(context).GetAllAsync();
        }

        public data.Canton GetOneById(int id)
        {
            return new P.DAL.Canton(context).GetOneById(id);
        }

        public Task<data.Canton> GetOneByIdAsync(int id)
        {
            return new P.DAL.Canton(context).GetOneByIdAsync(id);
        }

        public void Insert(data.Canton t)
        {
            new P.DAL.Canton(context).Insert(t);
        }

        public void Update(data.Canton t)
        {
            new P.DAL.Canton(context).Update(t);
        }
    }
}
