using System;
using System.Collections.Generic;
using System.Text;

namespace P.DAL.DO.Objects
{
    public partial class Persona
    {
        public Persona()
        {
            ListCal = new HashSet<ListCal>();
        }

        public int IdPer { get; set; }
        public string Nombre { get; set; }
        public string PriApellido { get; set; }
        public string SeguApellido { get; set; }
        public string Correo { get; set; }
        public string Clave { get; set; }
        public string Usuario { get; set; }

        public virtual ICollection<ListCal> ListCal { get; set; }
    }
}
