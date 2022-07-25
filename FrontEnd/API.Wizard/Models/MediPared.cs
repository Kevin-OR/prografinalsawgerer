using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Wizard.Models
{
    public class MediPared
    {
        public int IdMedPared { get; set; }
        public decimal Alto { get; set; }
        public decimal Ancho { get; set; }
        public decimal MetroCuadrado { get; set; }
        public int IdMedParedes { get; set; }

        public virtual MediParedes IdMedParedesNavigation { get; set; }
    }
}
