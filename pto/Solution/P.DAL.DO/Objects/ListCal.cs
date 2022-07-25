using System;
using System.Collections.Generic;
using System.Text;

namespace P.DAL.DO.Objects
{
    public partial class ListCal
    {
        public ListCal()
        {
            CalculoMateri = new HashSet<CalculoMateri>();
        }

        public int IdCalculo { get; set; }
        public string NombreCalculo { get; set; }
        public int IdPer { get; set; }
        public int IdClie { get; set; }

        public virtual Cliente IdClieNavigation { get; set; }
        public virtual Persona IdPerNavigation { get; set; }
        public virtual ICollection<CalculoMateri> CalculoMateri { get; set; }
    }
}
