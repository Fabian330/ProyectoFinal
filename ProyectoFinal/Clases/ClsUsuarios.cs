using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Clases
{
    public class ClsUsuarios
    {
        public static string email { get; set; }
        public static string clave { get; set; }
        public static string tipo { get; set; }
        public static string nombre { get; set; }
        public static string apellido { get; set; }
        public static string telefono { get; set; }
        public static string ID { get; set; }

        public static int ValidarLogin(string email, string clave)
        {
            int retorno = 0;
            int tipo = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DboConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ValidarUsuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Email", email));
                    cmd.Parameters.Add(new SqlParameter("@Clave", clave));

                    // retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            ClsUsuarios.tipo = rdr["Tipo"].ToString();
                            retorno = 1;
                        }

                    }

                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = -1;
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return retorno;
        }

        public static int Agregar(string email, string clave, string tipo, string nombre, string apellido, string telefono)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DboConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("IngresarCliente", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Email", email));
                    cmd.Parameters.Add(new SqlParameter("@Clave", clave));
                    cmd.Parameters.Add(new SqlParameter("@Tipo", tipo));
                    cmd.Parameters.Add(new SqlParameter("@NombreCl", nombre));
                    cmd.Parameters.Add(new SqlParameter("@Apellido", apellido));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", telefono));

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

        public static int Borrar(string ID)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DboConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("BorrarCliente", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CodigoCl", ID));

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

        public static int Modificar(string email, string clave, string tipo, string nombre, string apellido, string telefono, string ID)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DboConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ActualizarUsuario", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Email", email));
                    cmd.Parameters.Add(new SqlParameter("@Clave", clave));
                    cmd.Parameters.Add(new SqlParameter("@Tipo", tipo));
                    cmd.Parameters.Add(new SqlParameter("@NombreCl", nombre));
                    cmd.Parameters.Add(new SqlParameter("@Apellido", apellido));
                    cmd.Parameters.Add(new SqlParameter("@Telefono", telefono));
                    cmd.Parameters.Add(new SqlParameter("@CodigoCl", ID));

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

        public ClsUsuarios() { }
    }
}