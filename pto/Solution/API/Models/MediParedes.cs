using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.Models
{
    public partial class MediParedes
    {
        public MediParedes()
        {
            CalculoMateri = new HashSet<CalculoMateri>();
            MediPared = new HashSet<MediPared>();
        }

        public int IdMedParedes { get; set; }
        public decimal TotalAlto { get; set; }
        public decimal TotalAncho { get; set; }
        public decimal TotalMetroCuadrado { get; set; }

        public virtual ICollection<CalculoMateri> CalculoMateri { get; set; }
        public virtual ICollection<MediPared> MediPared { get; set; }
    }
}
