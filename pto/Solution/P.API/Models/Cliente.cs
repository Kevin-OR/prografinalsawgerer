using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P.API.Models
{
    public class Cliente
    {
        public Cliente()
        {
            
        }

        public int IdClie { get; set; }
        public string Nombre { get; set; }
        public string PriApellido { get; set; }
        public string SeguApellido { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int CodigoCanton { get; set; }

        public virtual Canton CodigoCantonNavigation { get; set; }
    }
}
