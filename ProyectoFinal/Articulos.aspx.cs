using ProyectoFinal.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal
{
    public partial class Articulos : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("ConsultaProducto"))
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
            ClsProductos.nombre = tNombre.Text;
            ClsProductos.precio = float.Parse(tPrecio.Text);

            ClsProductos.Agregar(ClsProductos.nombre, ClsProductos.precio.ToString());

            LlenarGrid();

            tNombre.Text = "";
            tPrecio.Text = "";
            tID.Text = "";
        }

        protected void bBorrar_Click(object sender, EventArgs e)
        {
            ClsProductos.ID = tID.Text;

            ClsProductos.Borrar(ClsProductos.ID);

            LlenarGrid();

            tNombre.Text = "";
            tPrecio.Text = "";
            tID.Text = "";
        }

        protected void bModificar_Click(object sender, EventArgs e)
        {
            ClsProductos.nombre = tNombre.Text;
            ClsProductos.precio = float.Parse(tPrecio.Text);
            ClsProductos.ID= tID.Text;

            ClsProductos.Modificar(ClsProductos.nombre, ClsProductos.precio.ToString(), ClsProductos.ID);

            LlenarGrid();

            tNombre.Text = "";
            tPrecio.Text = "";
            tID.Text = "";
        }
    }
}