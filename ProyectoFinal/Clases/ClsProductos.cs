using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Clases
{
    public class ClsProductos
    {
        public static string nombre { get; set; }
        public static float precio { get; set; }
        public static string ID { get; set; }

        public static int Agregar(string nombre, string precio)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DboConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("IngresarProducto", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NombrePr", nombre));
                    cmd.Parameters.Add(new SqlParameter("@Precio", precio));

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
                    SqlCommand cmd = new SqlCommand("BorrarProducto", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CodigoPr", ID));

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

        public static int Modificar(string nombre, string precio, string ID)
        {
            int retorno = 0;
            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DboConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("ActualizarProducto", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NombrePr", nombre));
                    cmd.Parameters.Add(new SqlParameter("@Precio", precio));
                    cmd.Parameters.Add(new SqlParameter("@CodigoPr", ID));

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

        public static string BuscarProducto(string nombre, string ID)
        {
            string retorno = "";

            SqlConnection Conn = new SqlConnection();
            try
            {
                using (Conn = DboConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("selecproducto", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@NombrePr", nombre));
                    cmd.Parameters.Add(new SqlParameter("@CodigoPr", ID));
                    ;

                    // retorno = cmd.ExecuteNonQuery();
                    using (SqlDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            retorno = rdr["NombrePr"].ToString();
                            precio = float.Parse(rdr["precio"].ToString());
                        }

                    }


                }
            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                retorno = "";
            }
            finally
            {
                Conn.Close();
                Conn.Dispose();
            }

            return retorno;
        }

        public ClsProductos() { }
    }
}