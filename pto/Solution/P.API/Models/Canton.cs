using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P.API.Models
{
    public class Canton
    {
        public Canton()
        {
           
        }

        public int CodigoCanton { get; set; }
        public int CodigoProvincia { get; set; }
        public string NombreCanton { get; set; }

        public virtual Provincia CodigoProvinciaNavigation { get; set; }
        
    }
}
