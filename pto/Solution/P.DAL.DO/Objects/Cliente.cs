using System;
using System.Collections.Generic;
using System.Text;

namespace P.DAL.DO.Objects
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
