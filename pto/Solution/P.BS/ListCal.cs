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
    public class ListCal : ICRUD<data.ListCal>
    {
        private dal.ListCal context;

        public ListCal(CalculoMateContext _context)
        {
            context = new dal.ListCal(_context);
        }
    
        public void Delete(data.ListCal t)
        {
            context.Delete(t);
        }

        public IEnumerable<data.ListCal> GetAll()
        {
            return context.GetAll();
        }

        public Task<IEnumerable<data.ListCal>> GetAllAsync()
        {
            return context.GetAllAsync();
        }

        public data.ListCal GetOneById(int id)
        {
            return context.GetOneById(id);
        }

        public Task<data.ListCal> GetOneByIdAsync(int id)
        {
            return context.GetOneByIdAsync(id);
        }

        public void Insert(data.ListCal t)
        {
            context.Insert(t);
        }

        public void Update(data.ListCal t)
        {
            context.Update(t);
        }
    }
}
