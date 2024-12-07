using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLogueado"] != null)
            {
                Response.Redirect("Default.aspx"); // Redirige si ya está logueado
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string usuario = tbUsuario.Text.Trim();
            string contraseña = tbContraseña.Text.Trim();

            var usuarioValido = BaseDeDatos.listaUsuarios.FirstOrDefault(u => u.NombreUsuario == usuario && u.Contraseña == contraseña);

            if (usuarioValido != null)
            {
                Session["UsuarioLogueado"] = usuarioValido.NombreUsuario;
                Response.Redirect("Default.aspx");
            }
            else
            {
                lblError.Text = "Usuario o contraseña incorrectos.";
            }
        }
    }
}
