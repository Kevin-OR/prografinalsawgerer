using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.Models
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
