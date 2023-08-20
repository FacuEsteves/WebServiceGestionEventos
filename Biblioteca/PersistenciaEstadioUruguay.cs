using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServiceEstadio
{
    public interface PersistenciaEstadioUruguay
    {
        int DisponivilidadEvento(int idevento,int idpuerta);
        List<DatosEvento> V_DatosEvento(int idevento);
        List<Evento> EventosAbiertos();
        int VerificarAcceso(int idcompra);
    }
}
