using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.Models
{
    public partial class CalculoMateri
    {
        public int IdCalMateri { get; set; }
        public int IdMaterial { get; set; }
        public int IdCalculo { get; set; }
        public decimal TotalCalculo { get; set; }
        public int IdMedParedes { get; set; }

        public virtual ListCal IdCalculoNavigation { get; set; }
        public virtual Materiales IdMaterialNavigation { get; set; }
        public virtual MediParedes IdMedParedesNavigation { get; set; }
    }
}
