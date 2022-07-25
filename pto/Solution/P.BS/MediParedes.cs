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
    public class MediParedes : ICRUD<data.MediParedes>
    {
        private CalculoMateContext context;

        public MediParedes(CalculoMateContext _context)
        {
            context = _context;
        }

        public void Delete(data.MediParedes t)
        {
            new P.DAL.MediParedes(context).Delete(t);
        }

        public IEnumerable<data.MediParedes> GetAll()
        {
            return new P.DAL.MediParedes(context).GetAll();
        }

        public Task<IEnumerable<data.MediParedes>> GetAllAsync()
        {
            return new P.DAL.MediParedes(context).GetAllAsync();
        }

        public data.MediParedes GetOneById(int id)
        {
            return new P.DAL.MediParedes(context).GetOneById(id);
        }

        public Task<data.MediParedes> GetOneByIdAsync(int id)
        {
            return new P.DAL.MediParedes(context).GetOneByIdAsync(id);
        }

        public void Insert(data.MediParedes t)
        {
            new P.DAL.MediParedes(context).Insert(t);
        }

        public void Update(data.MediParedes t)
        {
            new P.DAL.MediParedes(context).Update(t);
        }
    }
}
