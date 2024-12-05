using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio
{
    public partial class OrdenesDeTrabajo : System.Web.UI.Page
    {
        private static int contadorNumOrden = 1; //agregarle verificacion de secuencialidad y de uniquicidad


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GenerarNumOrden();

                ddlClientes.DataSource = BaseDeDatos.listaClientes;
                ddlClientes.DataTextField = "nombreCompletoCli";
                ddlClientes.DataValueField = "CI";
                ddlClientes.DataBind();

                ddlTecnicos.DataSource = BaseDeDatos.listaTecnicos;
                ddlTecnicos.DataTextField = "nombreCompletoTec";
                ddlTecnicos.DataValueField = "CI";
                ddlTecnicos.DataBind();

                tbFechaOrd.Text = DateTime.Now.ToString("dd-MM-yyyy");
            }
            else
            {
                if (string.IsNullOrEmpty(tbFechaOrd.Text) && ViewState["FechaActual"] != null)
                {
                    tbFechaOrd.Text = ViewState["FechaActual"].ToString();
                }
            }
        }

        protected void seleccionarFecha(object sender, EventArgs e)
        {
            tbFechaOrd.Text = DateTime.Now.ToString("dd-MM-yyyy");
        }


        protected void GenerarNumOrden()
        {
            tbNumOrd.Text = contadorNumOrden.ToString();
            contadorNumOrden++;
        }

        protected void CrearYguardarOrden(object sender, EventArgs e)
        {
            int numeroOrden = int.Parse(tbNumOrd.Text);

            Cliente clienteSeleccionado = BaseDeDatos.listaClientes.FirstOrDefault(c => c.CI.ToString() == ddlClientes.SelectedValue);
            Tecnico tecnicoSeleccionado = BaseDeDatos.listaTecnicos.FirstOrDefault(c => c.CI.ToString() == ddlTecnicos.SelectedValue);
           
            if (clienteSeleccionado == null || tecnicoSeleccionado == null)
            {
                lblMensaje.Text = "Debe seleccionar un cliente y/o tecnico";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrEmpty(ddlEstado.SelectedValue))
            {
                lblMensaje.Text = "Debe seleccionar un estado para la orden";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (BaseDeDatos.listaClientes == null || !BaseDeDatos.listaClientes.Any())
            {
                lblMensaje.Text = "No hay clientes disponibles para seleccionar";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            OrdenDeTrabajo ordenDeTrabajo = new OrdenDeTrabajo(
                numeroOrden,
                clienteSeleccionado,
                tecnicoSeleccionado,
                tbDescOrd.Text,
                DateTime.Now,
                ddlEstado.SelectedItem.Text,
                tbComOrd.Text

            );

            BaseDeDatos.listaOrdenesDeTrabajo.Add(ordenDeTrabajo);
            lblMensaje.Text = "Orden creada exitosamente";

            tablaODT.DataSource = BaseDeDatos.listaOrdenesDeTrabajo;

            CargarTablaODT(null, EventArgs.Empty);

            tbNumOrd.Text = "";
            tbDescOrd.Text = "";
            tbFechaOrd.Text = "";
        }

        protected void CargarTablaODT(object sender, EventArgs e)
        {
            tablaODT.DataSource = BaseDeDatos.listaOrdenesDeTrabajo;
            tablaODT.DataBind();
        }

        //BUSQUEDA DE ORDENES
        protected void BuscarOrden(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbBuscarNumOrd.Text) || !int.TryParse(tbBuscarNumOrd.Text, out int numeroOrden))
            {
                lblResultadoBusqueda.Text = "Por favor, ingrese un número de orden válido.";
                lblResultadoBusqueda.ForeColor = System.Drawing.Color.Red;
                detalleOrden.Visible = false;
                return;
            }

            OrdenDeTrabajo orden = BaseDeDatos.listaOrdenesDeTrabajo.FirstOrDefault(o => o.NumeroOrden == numeroOrden);

            if (orden == null)
            {
                lblResultadoBusqueda.Text = "No se encontró ninguna orden con el número ingresado.";
                lblResultadoBusqueda.ForeColor = System.Drawing.Color.Red;
                detalleOrden.Visible = false;
            }
            else
            {
                lblEstado.Text = orden.Estado;
                lblCliente.Text = orden.ClienteOrden.Nombre + " " + orden.ClienteOrden.Apellido + " (CI: " + orden.ClienteOrden.CI + ")";
                lblTecnico.Text = orden.TecnicoOrden.Nombre + " " + orden.TecnicoOrden.Apellido + " (CI: " + orden.TecnicoOrden.CI + ")";
                lblDescripcion.Text = orden.DescripcionProblema;
                lblFecha.Text = orden.FechaCreacion.ToString("dd-MM-yyyy");
                lblComentarios.Text = string.IsNullOrEmpty(orden.ListaComentarios) ? "No hay comentarios." : orden.ListaComentarios;

                if (string.IsNullOrEmpty(orden.ListaComentarios))
                {
                    lblComentarios.Text = "No hay comentarios.";
                }
                else
                {
                    lblComentarios.Text = orden.ListaComentarios;
                }


                lblResultadoBusqueda.Text = "Orden encontrada:";
                lblResultadoBusqueda.ForeColor = System.Drawing.Color.Green;
                detalleOrden.Visible = true;
            }
        }

        protected void RowDeletingEvent(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndexODT = e.RowIndex;
            string numOrden = tablaODT.DataKeys[rowIndexODT].Values[0].ToString();
            int numeroOrden = int.Parse(numOrden);
            OrdenDeTrabajo ordenDeTrabajo = BaseDeDatos.listaOrdenesDeTrabajo.FirstOrDefault(c => c.NumeroOrden == numeroOrden);

            if (ordenDeTrabajo != null)
            {
                BaseDeDatos.listaOrdenesDeTrabajo.Remove(ordenDeTrabajo);
                lblMensaje.Text = "Orden de trabajo eliminada correctamente";
            }
            else
            {
                lblMensaje.Text = "No se encontro ninguna orden de trabajo bajo ese numero";
            }

            CargarTablaODT(sender, e);
        }
        protected void RowEditingEvent(object sender, GridViewEditEventArgs e)
        {
            tablaODT.EditIndex = e.NewEditIndex;
            CargarTablaODT(sender, e);
        }

        protected void RowUpdatingEvent(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndexODT = e.RowIndex;

            if (tablaODT.DataKeys != null && tablaODT.DataKeys[rowIndexODT] != null)
            {
                string numOrden = tablaODT.DataKeys[rowIndexODT].Values[0].ToString();
                int numeroOrden = int.Parse(numOrden);
                OrdenDeTrabajo ordenDeTrabajo = BaseDeDatos.listaOrdenesDeTrabajo.FirstOrDefault(c => c.NumeroOrden == numeroOrden);

                if (ordenDeTrabajo != null)
                {
                    GridViewRow row = tablaODT.Rows[rowIndexODT];

                    TextBox Cliente = (TextBox)row.Cells[2].Controls[0];
                    TextBox Tecnico = (TextBox)row.Cells[3].Controls[0];
                    TextBox DescProb = (TextBox)row.Cells[4].Controls[0];
                    TextBox Estado = (TextBox)row.Cells[6].Controls[0];
                    TextBox Comentarios = (TextBox)row.Cells[7].Controls[0];

                    ordenDeTrabajo.ClienteOrden.Nombre = Cliente.Text.Trim();
                    ordenDeTrabajo.TecnicoOrden.Nombre = Tecnico.Text.Trim();
                    ordenDeTrabajo.DescripcionProblema = DescProb.Text.Trim();
                    ordenDeTrabajo.Estado = Estado.Text.Trim();
                    ordenDeTrabajo.ListaComentarios = Comentarios.Text.Trim();
                }
                else
                {
                    lblMensaje.Text = "No se encontró ningúna orden de trabajo con el numero indicado.";
                }

                tablaODT.EditIndex = -1;
                CargarTablaODT(sender, e);
            }
            else
            {
                lblMensaje.Text = "Error: no se pudo obtener la clave de la fila seleccionada.";
            }
        }

        protected void RowCancelingEditingEvent(object sender, GridViewCancelEditEventArgs e)
        {
            tablaODT.EditIndex = -1;
            CargarTablaODT(sender, e);
        }

        protected void AgregarComentario(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbBuscarNumOrd.Text) && int.TryParse(tbBuscarNumOrd.Text, out int numeroOrden))
            {
                OrdenDeTrabajo orden = BaseDeDatos.listaOrdenesDeTrabajo.FirstOrDefault(o => o.NumeroOrden == numeroOrden);

                if (orden != null)
                {
                    string nuevoComentario = tbComOrd.Text.Trim();
                    if (!string.IsNullOrEmpty(nuevoComentario))
                    {
                        orden.ListaComentarios += (string.IsNullOrEmpty(orden.ListaComentarios) ? "" : "\n") + nuevoComentario;

                        lblMensaje.Text = "Comentario agregado correctamente";
                        lblMensaje.ForeColor = System.Drawing.Color.Green;
                        tbComOrd.Text = "";
                    }
                    else
                    {
                        lblMensaje.Text = "Debe ingresar un comentario para agregar.";
                        lblMensaje.ForeColor = System.Drawing.Color.Red;
                    }
                }
                else
                {
                    lblMensaje.Text = "No se encontró la orden.";
                    lblMensaje.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblMensaje.Text = "Por favor, ingrese un número de orden válido";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
            }
        }


        protected void MostrarComentarios(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbBuscarNumOrd.Text) && int.TryParse(tbBuscarNumOrd.Text, out int numeroOrden))
            {
                OrdenDeTrabajo orden = BaseDeDatos.listaOrdenesDeTrabajo.FirstOrDefault(o => o.NumeroOrden == numeroOrden);

                if (orden != null)
                {
                    lblComentarios.Text = string.IsNullOrEmpty(orden.ListaComentarios) ? "No hay comentarios." : orden.ListaComentarios;
                    lblComentarios.ForeColor = System.Drawing.Color.Black;
                    detalleOrden.Visible = true;
                }
                else
                {
                    lblComentarios.Text = "No se encontró la orden.";
                    lblComentarios.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblComentarios.Text = "Por favor, ingrese un número de orden válido.";
                lblComentarios.ForeColor = System.Drawing.Color.Red;
            }
        }


    }

} 