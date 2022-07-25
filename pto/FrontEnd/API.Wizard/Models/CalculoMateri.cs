using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Wizard.Models
{
    public class CalculoMateri
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
