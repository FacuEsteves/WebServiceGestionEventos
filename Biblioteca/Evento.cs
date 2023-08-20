using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceEstadio
{
    public class Evento
    {
        public int idevento { get;set; }
        public string nombre_evento { get;set; }
	    public DateTime fecha_hora { get;set; }

        public DateTime fecha_hora_fin { get; set; }
    }
}
