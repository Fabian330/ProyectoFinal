using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Clases
{
    public class ClsDireccion
    {
        public static string codigoDirec { get; set; }
        public static string codigo_Cliente { get; set; }
        public static string provincia { get; set; }
        public static string canton { get; set; }
        public static string distrito { get; set; }

        public static int Agregar(string codigoCliente, string provincia, string canton, string distrito)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DboConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("IngresarDireccion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Codigo_Cliente", codigoCliente));
                    cmd.Parameters.Add(new SqlParameter("@Provincia", provincia));
                    cmd.Parameters.Add(new SqlParameter("@Canton", canton));
                    cmd.Parameters.Add(new SqlParameter("@Distrito", distrito));

                    retorno = cmd.ExecuteNonQuery();

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public static int Borrar(string codigoDirec)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DboConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BorrarDireccion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CodigoDirec", codigoDirec));

                    retorno = cmd.ExecuteNonQuery();
                    string jscript = "<script>alert('YOUR BUTTON HAS BEEN CLICKED')</script>";

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }
            return retorno;
        }

        public static int Modificar(string codigoCliente, string provincia, string canton, string distrito, string codigoDirec)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DboConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ActualizarDireccion", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Codigo_Cliente", codigoCliente));
                    cmd.Parameters.Add(new SqlParameter("@Provincia", provincia));
                    cmd.Parameters.Add(new SqlParameter("@Canton", canton));
                    cmd.Parameters.Add(new SqlParameter("@Distrito", distrito));
                    cmd.Parameters.Add(new SqlParameter("@CodigoDirec", codigoDirec));

                    retorno = cmd.ExecuteNonQuery();
                }
            }
            catch (Exception)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
            }

            return retorno;
        }

        public ClsDireccion() { }
    }
}