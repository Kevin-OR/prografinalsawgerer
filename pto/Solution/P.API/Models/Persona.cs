using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P.API.Models
{
    public class Persona
    {
        public Persona()
        {
            
        }

        public int IdPer { get; set; }
        public string Nombre { get; set; }
        public string PriApellido { get; set; }
        public string SeguApellido { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Usuario { get; set; }

       
    }
}
