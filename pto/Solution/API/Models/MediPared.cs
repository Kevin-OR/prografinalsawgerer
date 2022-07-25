using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.Models
{
    public partial class MediPared
    {
        public int IdMedPared { get; set; }
        public decimal Alto { get; set; }
        public decimal Ancho { get; set; }
        public decimal MetroCuadrado { get; set; }
        public int IdMedParedes { get; set; }

        public virtual MediParedes IdMedParedesNavigation { get; set; }
    }
}
