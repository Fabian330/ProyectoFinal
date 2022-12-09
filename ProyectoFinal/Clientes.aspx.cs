using ProyectoFinal.Clases;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Security.Claims;

namespace ProyectoFinal
{
    public partial class Clientes : System.Web.UI.Page
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
                using (SqlCommand cmd = new SqlCommand("ConsultaUsuarios"))
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
            ClsUsuarios.nombre = tNombre.Text;
            ClsUsuarios.apellido = tApellido.Text;
            ClsUsuarios.email = tCorreo.Text;
            ClsUsuarios.clave = tClave.Text;
            ClsUsuarios.telefono = tTelefono.Text;
            ClsUsuarios.tipo = DropDownList1.SelectedValue;

            ClsUsuarios.Agregar(ClsUsuarios.email,ClsUsuarios.clave,ClsUsuarios.tipo,ClsUsuarios.nombre,ClsUsuarios.apellido,ClsUsuarios.telefono);

            LlenarGrid();

            tNombre.Text = "";
            tApellido.Text = "";
            tCorreo.Text = "";
            tTelefono.Text = "";
            tID.Text = "";
        }

        protected void bBorrar_Click(object sender, EventArgs e)
        {
            ClsUsuarios.ID = tID.Text;

            ClsUsuarios.Borrar(ClsUsuarios.ID);

            LlenarGrid();

            tNombre.Text = "";
            tApellido.Text = "";
            tCorreo.Text = "";
            tTelefono.Text = "";
            tID.Text = "";
        }

        protected void bModificar_Click(object sender, EventArgs e)
        {
            ClsUsuarios.nombre = tNombre.Text;
            ClsUsuarios.apellido = tApellido.Text;
            ClsUsuarios.email = tCorreo.Text;
            ClsUsuarios.clave = tClave.Text;
            ClsUsuarios.telefono = tTelefono.Text;
            ClsUsuarios.tipo = DropDownList1.SelectedValue;
            ClsUsuarios.ID = tID.Text;

            ClsUsuarios.Modificar(ClsUsuarios.email, ClsUsuarios.clave, ClsUsuarios.tipo, ClsUsuarios.nombre, ClsUsuarios.apellido, ClsUsuarios.telefono, ClsUsuarios.ID);

            LlenarGrid();

            tNombre.Text = "";
            tApellido.Text = "";
            tCorreo.Text = "";
            tTelefono.Text = "";
            tID.Text = "";
        }
    }
}