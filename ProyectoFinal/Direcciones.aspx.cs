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
using System.Security.Cryptography;

namespace ProyectoFinal
{
    public partial class Direcciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrid();
        }

        protected void LlenarGrid()
        {
            string constr = ConfigurationManager.ConnectionStrings["GimnasioConnectionString"].ConnectionString;
            using (SqlConnection con = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("ConsultaDireccion"))
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

        protected void bIngresar_Click(object sender, EventArgs e)
        {
            ClsDireccion.codigo_Cliente = tCodigoCl.Text;
            ClsDireccion.provincia = tProvincia.Text;
            ClsDireccion.canton = tCanton.Text;
            ClsDireccion.distrito = tDistrito.Text;

            ClsDireccion.Agregar(ClsDireccion.codigo_Cliente, ClsDireccion.provincia,ClsDireccion.canton,ClsDireccion.distrito);

            LlenarGrid();

            tCodigoCl.Text = "";
            tProvincia.Text = "";
            tCanton.Text = "";
            tDistrito.Text = "";
            tCodigoD.Text = "";
        }

        protected void bBorrar_Click(object sender, EventArgs e)
        {
            ClsDireccion.codigoDirec = tCodigoD.Text;

            ClsDireccion.Borrar(ClsDireccion.codigoDirec);

            LlenarGrid();

            tCodigoCl.Text = "";
            tProvincia.Text = "";
            tCanton.Text = "";
            tDistrito.Text = "";
            tCodigoD.Text = "";
        }

        protected void bModificar_Click(object sender, EventArgs e)
        {
            ClsDireccion.codigo_Cliente = tCodigoCl.Text;
            ClsDireccion.provincia = tProvincia.Text;
            ClsDireccion.canton = tCanton.Text;
            ClsDireccion.distrito = tDistrito.Text;
            ClsDireccion.codigoDirec = tCodigoD.Text;

            ClsDireccion.Modificar(ClsDireccion.codigo_Cliente, ClsDireccion.provincia, ClsDireccion.canton, ClsDireccion.distrito,ClsDireccion.codigoDirec);

            LlenarGrid();

            tCodigoCl.Text = "";
            tProvincia.Text = "";
            tCanton.Text = "";
            tDistrito.Text = "";
            tCodigoD.Text = "";
        }
    }
}