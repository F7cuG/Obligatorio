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
            if (!IsPostBack)
            {
                CargarTablaClientes(sender, e);
            }
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
                lblMensaje.Text = "Debe ingresar un nombre valido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(apellido) || !apellido.All(char.IsLetter))
            {
                lblMensaje.Text = "Debe ingresar un apellido valido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (!ValidarCedulaUruguaya(ci))
            {
                lblMensaje.Text = "Debe ingresar un CI valido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }
            if (BaseDeDatos.listaClientes.Any(c => c.CI == ci))
            {
                lblMensaje.Text = "Ya existe un cliente con ese CI.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(telefonoTexto) || !long.TryParse(telefonoTexto, out telefono))
            {
                lblMensaje.Text = "Debe ingresar un numero de telefono valido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(email) || !email.Contains("@") || !email.Contains("."))
            {
                lblMensaje.Text = "Debe ingresar un Email valido.";
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
            Session["Clientes"] = BaseDeDatos.listaClientes;

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

                    TextBox Nombre = (TextBox)row.Cells[1].Controls[0];
                    TextBox Apellido = (TextBox)row.Cells[2].Controls[0];
                    TextBox Direccion = (TextBox)row.Cells[4].Controls[0];
                    TextBox Telefono = (TextBox)row.Cells[5].Controls[0];
                    TextBox Email = (TextBox)row.Cells[6].Controls[0];

                    if (string.IsNullOrWhiteSpace(Nombre.Text.Trim()) || !Nombre.Text.All(char.IsLetter))
                    {
                        lblMensaje.Text = "Debe ingresar un nombre valido.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(Apellido.Text.Trim()) || !Apellido.Text.All(char.IsLetter))
                    {
                        lblMensaje.Text = "Debe ingresar un apellido valido.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (!ValidarCedulaUruguaya(cliente.CI))
                    {
                        lblMensaje.Text = "Debe ingresar un CI valido.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (!long.TryParse(Telefono.Text.Trim(), out long telefono))
                    {
                        lblMensaje.Text = "Debe ingresar un numero de telefono valido.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (string.IsNullOrWhiteSpace(Email.Text.Trim()) || !Email.Text.Contains("@") || !Email.Text.Contains("."))
                    {
                        lblMensaje.Text = "Debe ingresar un Email valido.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }
                    if (BaseDeDatos.listaClientes.Any(c => c.CI == cliente.CI && c != cliente))
                    {
                        lblMensaje.Text = "Ya existe un cliente con ese CI.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                        return;
                    }

                    cliente.Nombre = Nombre.Text.Trim();
                    cliente.Apellido = Apellido.Text.Trim();
                    cliente.Direccion = Direccion.Text.Trim();
                    cliente.Email = Email.Text.Trim();
                    cliente.Telefono = telefono;

                    lblMensaje.Text = "Cliente actualizado correctamente.";
                    lblMensaje.ForeColor = System.Drawing.Color.Green;
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