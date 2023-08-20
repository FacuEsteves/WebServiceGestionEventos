using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceEstadio
{
    public class DatosEvento
    {
        public int idevento { get; set; }
        public int idpuerta { get; set; }
        public int capacidad { get; set; }
        public double costo { get; set; }
        public int disponibilidad { get; set; }
    }
}