using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;

namespace ProyectoFinal.Clases
{
    public class ClsFactura
    {
        public static int Nfactura { get; set; }
        public static float total { get; set; }
        public static int codigoDF { get; set; }
        public static int cantidad { get; set; }
        public static float precio { get; set; }
        public static int codigoClient { get; set; }

        public static int AgregarDetalleFactura(int codigoDF, int Nfactura, int cantidad, float precio)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DboConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("DetFactura", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@CodigoDF", codigoDF));
                    cmd.Parameters.Add(new SqlParameter("@Nfactura", Nfactura));
                    cmd.Parameters.Add(new SqlParameter("@Cantidad", cantidad));
                    cmd.Parameters.Add(new SqlParameter("@Precio_Unitario", precio));

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

        public static int AgregarMaestroFactura(string Nfactura, string total)
        {
            int retorno = 0;

            SqlConnection Conn = new SqlConnection();

            try
            {
                using (Conn = DboConn.obtenerConexion())
                {
                    SqlCommand cmd = new SqlCommand("MaeFactura", Conn)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add(new SqlParameter("@Nfactura", Nfactura));
                    cmd.Parameters.Add(new SqlParameter("@Total", total));


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

        public ClsFactura() { }
    }
}