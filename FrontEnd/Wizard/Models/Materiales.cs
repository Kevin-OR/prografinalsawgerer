using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Wizard.Models
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
