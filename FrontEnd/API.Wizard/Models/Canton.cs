
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Wizard.Models
{
    public class Canton
    {
        public int CodigoCanton { get; set; }
        public int CodigoProvincia { get; set; }
        public string NombreCanton { get; set; }

        public virtual Provincia CodigoProvinciaNavigation { get; set; }
    }
}
