using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace API.Models
{
    public partial class Provincia
    {
        public Provincia()
        {
            Canton = new HashSet<Canton>();
        }

        public int CodigoProvincia { get; set; }
        public string NombreProvincia { get; set; }

        public virtual ICollection<Canton> Canton { get; set; }
    }
}
