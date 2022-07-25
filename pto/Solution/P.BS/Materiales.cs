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
    public class Materiales : ICRUD<data.Materiales>
    {
        private CalculoMateContext context;

        public Materiales(CalculoMateContext _context)
        {
            context = _context;
        }

        public void Delete(data.Materiales t)
        {
            new P.DAL.Materiales(context).Delete(t);
        }

        public IEnumerable<data.Materiales> GetAll()
        {
            return new P.DAL.Materiales(context).GetAll();
        }

        public Task<IEnumerable<data.Materiales>> GetAllAsync()
        {
            return new P.DAL.Materiales(context).GetAllAsync();
        }

        public data.Materiales GetOneById(int id)
        {
            return new P.DAL.Materiales(context).GetOneById(id);
        }

        public Task<data.Materiales> GetOneByIdAsync(int id)
        {
            return new P.DAL.Materiales(context).GetOneByIdAsync(id);
        }

        public void Insert(data.Materiales t)
        {
            new P.DAL.Materiales(context).Insert(t);
        }

        public void Update(data.Materiales t)
        {
            new P.DAL.Materiales(context).Update(t);
        }
    }
}
