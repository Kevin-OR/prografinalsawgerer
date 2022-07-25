using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Wizard.Models
{
    public class ListCal
    {
        public ListCal()
        {
        }

        public int IdCalculo { get; set; }
        public string NombreCalculo { get; set; }
        public int IdPer { get; set; }
        public int IdClie { get; set; }

        public virtual Cliente IdClieNavigation { get; set; }
        public virtual Persona IdPerNavigation { get; set; }
    }
}
