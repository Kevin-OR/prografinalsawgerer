
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
    public class CalculoMateri : ICRUD<data.CalculoMateri>
    {
        private CalculoMateContext context;

        public CalculoMateri(CalculoMateContext _context)
        {
            context = _context;
        }
        public void Delete(data.CalculoMateri t)
        {
            new P.DAL.CalculoMateri(context).Delete(t);

        }

        public IEnumerable<data.CalculoMateri> GetAll()
        {
            return new P.DAL.CalculoMateri(context).GetAll();
        }

        public Task<IEnumerable<data.CalculoMateri>> GetAllAsync()
        {
            return new P.DAL.CalculoMateri(context).GetAllAsync();
        }

        public data.CalculoMateri GetOneById(int id)
        {
            return new P.DAL.CalculoMateri(context).GetOneById(id);
        }

        public Task<data.CalculoMateri> GetOneByIdAsync(int id)
        {
            return new P.DAL.CalculoMateri(context).GetOneByIdAsync(id);

        }

        public void Insert(data.CalculoMateri t)
        {
            new P.DAL.CalculoMateri(context).Insert(t);
        }

        public void Update(data.CalculoMateri t)
        {
            new P.DAL.CalculoMateri(context).Update(t);
        }
    }
}
