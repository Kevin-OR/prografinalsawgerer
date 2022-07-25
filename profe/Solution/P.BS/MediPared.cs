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
    public class MediPared : ICRUD<data.MediPared>
    {
        private CalculoMateContext context;

        public MediPared(CalculoMateContext _context)
        {
            context = _context;
        }

        public void Delete(data.MediPared t)
        {
            new P.DAL.MediPared(context).Delete(t);
        }

        public IEnumerable<data.MediPared> GetAll()
        {
            return new P.DAL.MediPared(context).GetAll();
        }

        public Task<IEnumerable<data.MediPared>> GetAllAsync()
        {
            return new P.DAL.MediPared(context).GetAllAsync();
        }

        public data.MediPared GetOneById(int id)
        {
            return new P.DAL.MediPared(context).GetOneById(id);
        }

        public Task<data.MediPared> GetOneByIdAsync(int id)
        {
            return new P.DAL.MediPared(context).GetOneByIdAsync(id);
        }

        public void Insert(data.MediPared t)
        {
            new P.DAL.MediPared(context).Insert(t);
        }

        public void Update(data.MediPared t)
        {
            new P.DAL.MediPared(context).Update(t);
        }
    }
}
