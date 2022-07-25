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
    public class Cliente : ICRUD<data.Cliente>
    {
        private CalculoMateContext context;

        public Cliente(CalculoMateContext _context)
        {
            context = _context;
        }

        public void Delete(data.Cliente t)
        {
            new P.DAL.Cliente(context).Delete(t);
        }

        public IEnumerable<data.Cliente> GetAll()
        {
            return new P.DAL.Cliente(context).GetAll();
        }

        public Task<IEnumerable<data.Cliente>> GetAllAsync()
        {
            return new P.DAL.Cliente(context).GetAllAsync();
        }

        public data.Cliente GetOneById(int id)
        {
            return new P.DAL.Cliente(context).GetOneById(id);
        }

        public Task<data.Cliente> GetOneByIdAsync(int id)
        {
            return new P.DAL.Cliente(context).GetOneByIdAsync(id);
        }

        public void Insert(data.Cliente t)
        {
            new P.DAL.Cliente(context).Insert(t);
        }

        public void Update(data.Cliente t)
        {
            new P.DAL.Cliente(context).Update(t);
        }
    }
}
