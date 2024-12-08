using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio
{
    public partial class Registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CrearUsuario(object sender, EventArgs e)
        {
            string nombreUsuario = tbNuevoUsuario.Text.Trim();
            string contrasena = tbNuevaContraseña.Text.Trim();

            if (BaseDeDatos.listaUsuarios.Any(u => u.NombreUsuario == nombreUsuario))
            {
                lblMensaje.Text = "El nombre de usuario ya existe.";
                return;
            }

            Usuario nuevoUsuario = new Usuario
            {
                NombreUsuario = nombreUsuario,
                Contraseña = contrasena, 
                Rol = "Usuario" 
            };

            BaseDeDatos.listaUsuarios.Add(nuevoUsuario);
            lblMensaje.Text = "Usuario registrado exitosamente.";
        }

    }
}