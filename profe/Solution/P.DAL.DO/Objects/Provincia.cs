using System;
using System.Collections.Generic;
using System.Text;

namespace P.DAL.DO.Objects
{
    public partial class Provincia
    {
        public Provincia()
        {
            Canton = new HashSet<Canton>();
        }

        public short CodigoProvincia { get; set; }
        public string NombreProvincia { get; set; }

        public virtual ICollection<Canton> Canton { get; set; }
    }
}

