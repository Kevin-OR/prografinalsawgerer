using System;
using System.Collections.Generic;
using System.Text;

namespace P.DAL.DO.Objects
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
