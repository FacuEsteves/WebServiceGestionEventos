using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace WebServiceEstadio
{
    public class PersistenciaEstadioUruguaySQL : PersistenciaEstadioUruguay
    {
        private static SqlConnection conectar()
        {
            String server = @"sql.bsite.net\MSSQL2016";
            String cadena = "Server=" + server + ";Database=fefabees_ESTADIOURUGUAY;User Id=fefabees_ESTADIOURUGUAY;Password=estadioUruguay;";
            SqlConnection conexion = new SqlConnection(cadena);
            conexion.Open();
            return conexion;
        }
        public List<DatosEvento> V_DatosEvento(int idevento)
        {
            List<DatosEvento> resultado = new List<DatosEvento>();

            SqlConnection conexion = conectar();
            DatosEvento de = null;
            SqlCommand sentencia = new SqlCommand("select * from V_DATOSEVENTO where idevento="+idevento, conexion);
            SqlDataReader reader = sentencia.ExecuteReader();


            while (reader.Read())
            {
                de = new DatosEvento();
                de.idevento = idevento;
                de.idpuerta = (int)reader["idpuerta"];
                de.capacidad= (int)reader["capacidad"];
                de.costo = (double)reader["costo"];
                de.disponibilidad = (int)reader["disponible"];
                resultado.Add(de);
            }
            //Corte de Control
            return resultado;
        }
        public int DisponivilidadEvento(int idevento, int idpuerta)
        {
            int resultado = 0;
            SqlConnection conexion = conectar();
            SqlCommand comando = new SqlCommand("[dbo].[disponibilidad_evento]", conexion);

            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter();
            p1.Value = idevento;
            p1.ParameterName = "@idevento";
            p1.SqlDbType = SqlDbType.Int;
            p1.Direction = ParameterDirection.Input;
            comando.Parameters.Add(p1);

            SqlParameter p2 = new SqlParameter();
            p2.Value = idpuerta;
            p2.ParameterName = "@idpuerta";
            p2.SqlDbType = SqlDbType.Int;
            p2.Direction = ParameterDirection.Input;
            comando.Parameters.Add(p2);

            resultado = (int)comando.ExecuteScalar();

            return resultado;
        }

        public List<Evento> EventosAbiertos()
        {
            List<Evento> eventos = new List<Evento>();

            SqlConnection conexion = conectar();
            SqlCommand sentencia1 = new SqlCommand("[dbo].[EventoDisponible]", conexion);
            sentencia1.CommandType = CommandType.StoredProcedure;

            using (SqlDataReader reader = sentencia1.ExecuteReader())
            {
                while (reader.Read())
                {
                    // Crear un objeto Evento y asignar los valores del lector
                    Evento evento = new Evento();
                    evento.nombre_evento = reader["nombre_evento"].ToString();
                    evento.fecha_hora= (DateTime)reader["fecha_hora"];
                    // Asignar otras propiedades según tu estructura de tabla

                    // Agregar el evento a la lista
                    eventos.Add(evento);
                }

                return eventos;
        }
    }

        public int VerificarAcceso(int idcompra)
        {
            int resultado = 0;
            SqlConnection conexion = conectar();
            SqlCommand comando = new SqlCommand("[dbo].[VerificarAcceso]", conexion);
            comando.CommandType = CommandType.StoredProcedure;

            SqlParameter p1 = new SqlParameter();
            p1.Value = idcompra;
            p1.ParameterName = "@idcompra";
            p1.SqlDbType = SqlDbType.Int;
            p1.Direction = ParameterDirection.Input;
            comando.Parameters.Add(p1);

            SqlParameter p2 = new SqlParameter();
            p2.ParameterName = "@mensaje";
            p2.SqlDbType = SqlDbType.Int;
            p2.Direction = ParameterDirection.Output;
            comando.Parameters.Add(p2);

            comando.ExecuteNonQuery();

            resultado = (int)comando.Parameters["@mensaje"].Value;

            return resultado;
        }
    }
}
