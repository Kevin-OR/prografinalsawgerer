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
    public class ListCal : ICRUD<data.ListCal>
    {
        private CalculoMateContext context;

        public ListCal(CalculoMateContext _context)
        {
            context = _context;
        }
    
        public void Delete(data.ListCal t)
        {
            new P.DAL.ListCal(context).Delete(t);
        }

        public IEnumerable<data.ListCal> GetAll()
        {
            return new P.DAL.ListCal(context).GetAll();
        }

        public Task<IEnumerable<data.ListCal>> GetAllAsync()
        {
            return new P.DAL.ListCal(context).GetAllAsync();
        }

        public data.ListCal GetOneById(int id)
        {
            return new P.DAL.ListCal(context).GetOneById(id);
        }

        public Task<data.ListCal> GetOneByIdAsync(int id)
        {
            return new P.DAL.ListCal(context).GetOneByIdAsync(id);
        }

        public void Insert(data.ListCal t)
        {
            new P.DAL.ListCal(context).Insert(t);
        }

        public void Update(data.ListCal t)
        {
            new P.DAL.ListCal(context).Update(t);
        }
    }
}
