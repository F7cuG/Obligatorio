using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Obligatorio
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        private bool ValidarCedulaUruguaya(string ci)
        {
            ci = ci.Replace(".", "").Replace("-", "");

            if (ci.Length < 7 || ci.Length > 8 || !ci.All(char.IsDigit))
            {
                return false;
            }

            ci = ci.PadLeft(8, '0');

            int[] verNums = { 2, 9, 8, 7, 6, 3, 4 };
            int suma = 0;

            for (int i = 0; i < 7; i++)
            {
                suma += (ci[i] - '0') * verNums[i];
            }

            int codVer = (10 - (suma % 10)) % 10;

            int digVer = ci[7] - '0';
            return codVer == digVer;
        }


        protected void CrearYguardarCliente(object sender, EventArgs e)
        {
            string nombre = tbNomCli.Text.Trim();
            string apellido = tbApCli.Text.Trim();
            string ci = tbCiCli.Text.Trim();
            string direccion = tbDirCli.Text.Trim();
            string email = tbEmailCli.Text.Trim();
            string telefonoTexto = tbTelCli.Text.Trim();
            long telefono;

            if (string.IsNullOrWhiteSpace(nombre) || !nombre.All(char.IsLetter))
            {
                lblMensaje.Text = "El campo Nombre debe contener solo letras.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(apellido) || !apellido.All(char.IsLetter))
            {
                lblMensaje.Text = "El campo Apellido debe contener solo letras.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (!ValidarCedulaUruguaya(ci))
            {
                lblMensaje.Text = "El CI ingresado no es válido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(telefonoTexto) || !long.TryParse(telefonoTexto, out telefono))
            {
                lblMensaje.Text = "El campo Teléfono debe contener solo números.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
            {
                lblMensaje.Text = "El campo Email debe ser una dirección de correo válida.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            Cliente cliente = new Cliente(
                nombre,
                apellido,
                ci,
                direccion,
                telefono,
                email
            );

            lblMensaje.Text = "Cliente creado exitosamente";
            lblMensaje.ForeColor = System.Drawing.Color.Green;
            BaseDeDatos.listaClientes.Add(cliente);

            CargarTablaClientes(null, EventArgs.Empty);

            tbNomCli.Text = "";
            tbApCli.Text = "";
            tbCiCli.Text = "";
            tbDirCli.Text = "";
            tbTelCli.Text = "";
            tbEmailCli.Text = "";
        }

        protected void CargarTablaClientes(object sender, EventArgs e)
        {
            tablaClientes.DataSource = BaseDeDatos.listaClientes;
            tablaClientes.DataBind();
        }

        protected void RowDeletingEvent(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndexCli = e.RowIndex;                                                       
            string clienteCI = tablaClientes.DataKeys[rowIndexCli].Values[0].ToString();        
            Cliente cliente = BaseDeDatos.listaClientes.FirstOrDefault(c => c.CI == clienteCI); 
            if( cliente != null )
            {
                BaseDeDatos.listaClientes.Remove(cliente);
                lblMensaje.Text = "Cliente eliminado correctamente";
            }
            else
            {
                lblMensaje.Text = "No se encontro ningun cliente con ese CI";
            }

            CargarTablaClientes(sender, e); 
        }

        protected void RowEditingEvent(object sender, GridViewEditEventArgs e)
        {
            tablaClientes.EditIndex = e.NewEditIndex;
            CargarTablaClientes(sender, e);
        }

        protected void RowUpdatingEvent(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndexCli = e.RowIndex;

            if (tablaClientes.DataKeys != null && tablaClientes.DataKeys[rowIndexCli] != null)
            {
                string clienteCI = tablaClientes.DataKeys[rowIndexCli].Values[0].ToString();
                Cliente cliente = BaseDeDatos.listaClientes.FirstOrDefault(c => c.CI == clienteCI);

                if (cliente != null)
                {
                    GridViewRow row = tablaClientes.Rows[rowIndexCli];

                    TextBox txtNombre = (TextBox)row.Cells[1].Controls[0];
                    TextBox txtApellido = (TextBox)row.Cells[2].Controls[0];
                    TextBox txtDireccion = (TextBox)row.Cells[4].Controls[0];
                    TextBox txtTelefono = (TextBox)row.Cells[5].Controls[0];
                    TextBox txtEmail = (TextBox)row.Cells[6].Controls[0];

                    cliente.Nombre = txtNombre.Text.Trim();
                    cliente.Apellido = txtApellido.Text.Trim();
                    cliente.Direccion = txtDireccion.Text.Trim();
                    cliente.Email = txtEmail.Text.Trim();

                    if (long.TryParse(txtTelefono.Text.Trim(), out long telefono))
                    {
                        cliente.Telefono = telefono;
                        lblMensaje.Text = "Cliente actualizado correctamente.";
                    }
                    else
                    {
                        lblMensaje.Text = "El teléfono ingresado no es un número válido.";
                        return;
                    }
                }
                else
                {
                    lblMensaje.Text = "No se encontró ningún cliente con el CI ingresado.";
                }

                tablaClientes.EditIndex = -1;
                CargarTablaClientes(sender, e);
            }
            else
            {
                lblMensaje.Text = "Error: no se pudo obtener la clave de la fila seleccionada.";
            }
        }



        protected void RowCancelingEditingEvent(object sender, GridViewCancelEditEventArgs e)
        {
            tablaClientes.EditIndex = -1;
            CargarTablaClientes(sender, e);
        }
    }
}