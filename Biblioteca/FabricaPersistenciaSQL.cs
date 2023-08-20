using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebServiceEstadio
{
    public class FabricaPersistenciaSQL : FabricaPersistencia
    {
        public PersistenciaEstadioUruguay ObtenerPersistenciaEstadioUruguay()
        {
            return new PersistenciaEstadioUruguaySQL();
        }
    }
}