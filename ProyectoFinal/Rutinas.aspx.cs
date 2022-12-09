using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoFinal.Clases;

namespace ProyectoFinal
{
    public partial class Rutinas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
            LlenarGrid2();
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["GimnasioConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("ConsultaRutina"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView1.DataSource = dt;
                            GridView1.DataBind();
                        }
                    }
                }
            }
        }

        protected void LlenarGrid2()
        {
            string constr = ConfigurationManager.ConnectionStrings["GimnasioConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("RutinaAsignada"))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = con;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            GridView2.DataSource = dt;
                            GridView2.DataBind();
                        }
                    }
                }
            }
        }

        protected void bIngresar_Click(object sender, EventArgs e)
        {
            ClsRutina.nombreR = tNombreR.Text;

            ClsRutina.Agregar(ClsRutina.nombreR);

            LlenarGrid();

            tNombreR.Text = "";
            tCodigoR.Text = "";
            tCodigoR2.Text = "";
            tCodigoCl.Text = "";

        }

        protected void bBorrar_Click(object sender, EventArgs e)
        {
            ClsRutina.codigoR = tCodigoR.Text;

            ClsRutina.Borrar(ClsRutina.codigoR);

            LlenarGrid();

            tNombreR.Text = "";
            tCodigoR.Text = "";
            tCodigoR2.Text = "";
            tCodigoCl.Text = "";
        }

        protected void bModificar_Click(object sender, EventArgs e)
        {
            ClsRutina.nombreR = tNombreR.Text;
            ClsRutina.codigoR = tCodigoR.Text;

            ClsRutina.Modificar(ClsRutina.nombreR, ClsRutina.codigoR);

            LlenarGrid();

            tNombreR.Text = "";
            tCodigoR.Text = "";
            tCodigoR2.Text = "";
            tCodigoCl.Text = "";
        }

        protected void bAsignar_Click(object sender, EventArgs e)
        {
            ClsRutina.codigoR = tCodigoR2.Text;
            ClsUsuarios.ID = tCodigoCl.Text;

            ClsRutina.Asignar(ClsRutina.codigoR, ClsUsuarios.ID);

            LlenarGrid2();

            tNombreR.Text = "";
            tCodigoR.Text = "";
            tCodigoR2.Text = "";
            tCodigoCl.Text = "";
            tCod.Text = "";
        }

        protected void bQuitar_Click(object sender, EventArgs e)
        {
            ClsRutina.cod = tCod.Text;

            ClsRutina.Quitar(ClsRutina.cod);

            LlenarGrid2();

            tNombreR.Text = "";
            tCodigoR.Text = "";
            tCodigoR2.Text = "";
            tCodigoCl.Text = "";
            tCod.Text = "";
        }
    }
}