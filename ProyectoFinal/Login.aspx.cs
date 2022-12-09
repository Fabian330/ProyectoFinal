using ProyectoFinal.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoFinal
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void bIngresar_Click(object sender, EventArgs e)
        {
            ClsUsuarios.email = tUsuario.Text;
            ClsUsuarios.clave = tClave.Text;

            if (ClsUsuarios.ValidarLogin(ClsUsuarios.email, ClsUsuarios.clave) > 0)
            {
                if (ClsUsuarios.tipo.Equals("Administrador"))
                {
                    Response.Redirect("Inicio.aspx");
                }
                else
                {
                    Response.Redirect("Inicio2.aspx");
                }
            }
            else
            {
                lMensaje.Text = "Usuario o contraseña incorrecto";
            }
        }
    }
}
