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
    public class Provincia : ICRUD<data.Provincia>
    {
        private CalculoMateContext context;

        public Provincia(CalculoMateContext _context)
        {
            context = _context;
        }

        public void Delete(data.Provincia t)
        {
            new P.DAL.Provincia(context).Delete(t);
        }

        public IEnumerable<data.Provincia> GetAll()
        {
            return new P.DAL.Provincia(context).GetAll();
        }

        public Task<IEnumerable<data.Provincia>> GetAllAsync()
        {
            return new P.DAL.Provincia(context).GetAllAsync();
        }

        public data.Provincia GetOneById(int id)
        {
            return new P.DAL.Provincia(context).GetOneById(id);
        }

        public Task<data.Provincia> GetOneByIdAsync(int id)
        {
            return new P.DAL.Provincia(context).GetOneByIdAsync(id);
        }

        public void Insert(data.Provincia t)
        {
            new P.DAL.Provincia(context).Insert(t);
        }

        public void Update(data.Provincia t)
        {
            new P.DAL.Provincia(context).Update(t);
        }
    }
}
