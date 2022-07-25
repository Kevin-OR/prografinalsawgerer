using System;
using System.Collections.Generic;
using System.Text;

namespace P.DAL.DO.Objects
{
    public partial class Materiales
    {
        public Materiales()
        {
            CalculoMateri = new HashSet<CalculoMateri>();
        }

        public int IdMaterial { get; set; }
        public string NombreMaterial { get; set; }
        public decimal CantiMetro { get; set; }

        public virtual ICollection<CalculoMateri> CalculoMateri { get; set; }
    }
}
