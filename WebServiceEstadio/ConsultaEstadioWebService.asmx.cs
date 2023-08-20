using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace WebServiceEstadio
{
    /// <summary>
    /// Descripción breve de ConsultaEstadioWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ConsultaEstadioWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
        //Vista de DatosEvento + Disponibilidad
        [WebMethod]
        public List<DatosEvento> ListaPuertas(int idevento)
        {
            List<DatosEvento> ListaPuertas = new List<DatosEvento>();
            PersistenciaEstadioUruguay persistencia = Sistema.fabricapersistencia.ObtenerPersistenciaEstadioUruguay();
            ListaPuertas = persistencia.V_DatosEvento(idevento);

            return ListaPuertas;
        }
        //Procedure disponibilidad_evento
        [WebMethod]
        public int Disponibilidad(int idevento,int idpuerta)
        {
            int disponibilidad = 0;
            PersistenciaEstadioUruguay persistencia = Sistema.fabricapersistencia.ObtenerPersistenciaEstadioUruguay();
            disponibilidad=persistencia.DisponivilidadEvento(idevento,idpuerta);
            return disponibilidad;
        }
        [WebMethod]

        public List<Evento> EventoDisponible()
        {
           
            List<Evento> eventosAbiertos = new List<Evento>();

            PersistenciaEstadioUruguay persistencia = Sistema.fabricapersistencia.ObtenerPersistenciaEstadioUruguay();

            eventosAbiertos = persistencia.EventosAbiertos();
            return eventosAbiertos;
        }

        [WebMethod]
        public int VerificarAcceso(int idcompra)
        {
            PersistenciaEstadioUruguay persistencia = Sistema.fabricapersistencia.ObtenerPersistenciaEstadioUruguay();
            int resultado = persistencia.VerificarAcceso(idcompra);
            return resultado;
        }
    }
}
