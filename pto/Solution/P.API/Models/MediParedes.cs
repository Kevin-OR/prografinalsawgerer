using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P.API.Models
{
    public class MediParedes
    {
        public MediParedes()
        {
            
        }

        public int IdMedParedes { get; set; }
        public decimal TotalAlto { get; set; }
        public decimal TotalAncho { get; set; }
        public decimal TotalMetroCuadrado { get; set; }


    }
}
