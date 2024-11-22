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
        protected void CrearYguardarCliente(object sender, EventArgs e)
        {
            long telefono = long.Parse(tbTelCli.Text);
            Cliente cliente = new Cliente(
                tbNomCli.Text,
                tbApCli.Text,
                tbCiCli.Text,
                tbDirCli.Text,
                telefono ,
                tbEmailCli.Text
            );

            lblMensaje.Text = "Cliente creado exitosamente";

            BaseDeDatos.listaClientes.Add(cliente);

            tablaClientes.DataSource = BaseDeDatos.listaClientes; 

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
            Page.Validate("EditValidationGroup");
            int rowIndexCli = e.RowIndex;

            if (tablaClientes.DataKeys != null && tablaClientes.DataKeys[rowIndexCli] != null)
            {
                string clienteCI = tablaClientes.DataKeys[rowIndexCli].Values[0].ToString();
                Cliente cliente = BaseDeDatos.listaClientes.FirstOrDefault(c => c.CI == clienteCI);

                if (cliente != null)
                {
                    GridViewRow row = tablaClientes.Rows[rowIndexCli];
                   
                    TextBox a = (TextBox)row.Cells[1].Controls[0];
                    TextBox b = (TextBox)row.Cells[2].Controls[0];
                    TextBox c = (TextBox)row.Cells[3].Controls[0];
                    TextBox d = (TextBox)row.Cells[4].Controls[0];
                    TextBox f = (TextBox)row.Cells[5].Controls[0];
                    TextBox g = (TextBox)row.Cells[6].Controls[0];

                    
                    cliente.Nombre = a.Text.Trim();
                    cliente.Apellido = b.Text.Trim();
                    cliente.CI = c.Text.Trim();
                    cliente.Direccion = d.Text.Trim();
                    cliente.Email = f.Text.Trim();

                    
                    long telefono;
                    if (long.TryParse(g.Text.Trim(), out telefono))
                    {
                        cliente.Telefono = telefono; 
                    }
                    else
                    {
                        lblMensaje.Text = "El teléfono ingresado no es un número válido.";
                        return; 
                    }

                    lblMensaje.Text = "Cliente actualizado correctamente.";
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