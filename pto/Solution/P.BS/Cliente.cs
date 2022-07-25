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
    public class Cliente : ICRUD<data.Cliente>
    {
        private dal.Cliente context;

        public Cliente(CalculoMateContext _context)
        {
            context = new dal.Cliente(_context);
        }

        public void Delete(data.Cliente t)
        {
            context.Delete(t);
        }

        public IEnumerable<data.Cliente> GetAll()
        {
            return context.GetAll();
        }

        public Task<IEnumerable<data.Cliente>> GetAllAsync()
        {
            return context.GetAllAsync();
        }

        public data.Cliente GetOneById(int id)
        {
            return context.GetOneById(id);
        }

        public Task<data.Cliente> GetOneByIdAsync(int id)
        {
            return context.GetOneByIdAsync(id);
        }

        public void Insert(data.Cliente t)
        {
            context.Insert(t);
        }

        public void Update(data.Cliente t)
        {
            context.Update(t);
        }
    }
}
