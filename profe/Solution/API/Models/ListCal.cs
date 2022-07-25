using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.Models
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
