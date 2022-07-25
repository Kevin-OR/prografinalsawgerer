
using System;
using System.Collections.Generic;
using System.Text;
using dal = P.DAL;
using P.DAL.DO.Interfaces;
using P.DAL.EF;
using data = P.DAL.DO.Objects;
using P.DAL;
using System.Threading.Tasks;

namespace P.BS
{
    public class CalculoMateri : ICRUD<data.CalculoMateri>
    {
        private dal.CalculoMateri context;

        public CalculoMateri(CalculoMateContext _context)
        {
            context = new dal.CalculoMateri(_context);
        }
        public void Delete(data.CalculoMateri t)
        {
            context.Delete(t);

        }

        public IEnumerable<data.CalculoMateri> GetAll()
        {
            return context.GetAll();
        }

        public Task<IEnumerable<data.CalculoMateri>> GetAllAsync()
        {
            return context.GetAllAsync();
        }

        public data.CalculoMateri GetOneById(int id)
        {
            return context.GetOneById(id);
        }

        public Task<data.CalculoMateri> GetOneByIdAsync(int id)
        {
            return context.GetOneByIdAsync(id);

        }

        public void Insert(data.CalculoMateri t)
        {
            context.Insert(t);
        }

        public void Update(data.CalculoMateri t)
        {
            context.Update(t);
        }
    }
}
