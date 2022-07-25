using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Wizard.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
            ListCal = new HashSet<ListCal>();
        }

        public int IdClie { get; set; }
        public string Nombre { get; set; }
        public string PriApellido { get; set; }
        public string SeguApellido { get; set; }
        public string Correo { get; set; }
        public string Direccion { get; set; }
        public int CodigoCanton { get; set; }

        public virtual Canton CodigoCantonNavigation { get; set; }
        public virtual ICollection<ListCal> ListCal { get; set; }
    }
}
