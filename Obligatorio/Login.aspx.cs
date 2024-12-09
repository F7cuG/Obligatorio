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
                Response.Redirect("Default.aspx");
            }
        }

        protected void Loguear(object sender, EventArgs e)
        {
            string usuarioIngresado = tbUsuario.Text.Trim();
            string contraseñaIngresada = tbContraseña.Text.Trim();

            var usuario = BaseDeDatos.listaUsuarios.FirstOrDefault(u => u.NombreUsuario == usuarioIngresado && u.Contraseña == contraseñaIngresada);

            if (usuario != null)
            {
                Session["UsuarioLogueado"] = true; 
                Session["ID"] = usuario.IdUsuario;
                Session["Nombre"] = usuario.NombreUsuario;
                Session["Rol"] = usuario.Rol;

                Response.Redirect("~/Default.aspx");
            }            else
            {
                lblError.Text = "Usuario o contraseña incorrectos.";
            }
        }

        protected void CerrarSesion(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login.aspx");
        }
    }
}


