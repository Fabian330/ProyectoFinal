using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Clases
{
    public class ClsRutina
    {
        public static string cod { get; set; }
        public static string codigoR { get; set; }
        public static string nombreR { get; set; }

        public static int Agregar(string nombreR)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DboConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("IngresarRutina", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NombreR", nombreR));

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

        public static int Borrar(string codigoR)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DboConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BorrarRutina", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CodigoR", codigoR));

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

        public static int Modificar(string nombreR, string codigoR)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DboConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ActualizarRutina", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NombreR", nombreR));
                    cmd.Parameters.Add(new SqlParameter("@CodigoR", codigoR));


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

        public static int Asignar(string codigoR, string ID)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DboConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("AsignarRutina", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CodigoRutina", codigoR));
                    cmd.Parameters.Add(new SqlParameter("@CodigoCli", ID));

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

        public static int Quitar (string cod)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DboConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("QuitarRutina", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Cod", cod));

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

        public ClsRutina() { }

    }
}