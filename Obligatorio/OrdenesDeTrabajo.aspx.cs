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
        private static int contadorNumOrden = 1;

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
            if (Session["ListaOrdenesDeTrabajo"] == null)
            {
                Session["ListaOrdenesDeTrabajo"] = new List<OrdenDeTrabajo>();
            }
            BaseDeDatos.listaOrdenesDeTrabajo = (List<OrdenDeTrabajo>)Session["ListaOrdenesDeTrabajo"];
            CargarTablaODT(null, EventArgs.Empty);
        }

        protected void CrearYguardarOrden(object sender, EventArgs e)
        {
            int numeroOrden = contadorNumOrden;

            Cliente clienteSeleccionado = BaseDeDatos.listaClientes.FirstOrDefault(c => c.CI.ToString() == ddlClientes.SelectedValue);
            Tecnico tecnicoSeleccionado = BaseDeDatos.listaTecnicos.FirstOrDefault(c => c.CI.ToString() == ddlTecnicos.SelectedValue);

            if (clienteSeleccionado == null || tecnicoSeleccionado == null)
            {
                lblMensaje.Text = "Debe seleccionar un cliente y/o técnico.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrWhiteSpace(tbDescOrd.Text))
            {
                lblMensaje.Text = "Debe ingresar una descripción para el problema.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrEmpty(ddlEstado.SelectedValue))
            {
                lblMensaje.Text = "Debe seleccionar un estado para la orden.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (BaseDeDatos.listaClientes == null || !BaseDeDatos.listaClientes.Any())
            {
                lblMensaje.Text = "No hay clientes disponibles para seleccionar.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            List<string> listaDeComentarios = new List<string>();
            listaDeComentarios.Add(tbComOrd.Text);

            OrdenDeTrabajo ordenDeTrabajo = new OrdenDeTrabajo(
                numeroOrden,
                clienteSeleccionado,
                tecnicoSeleccionado,
                tbDescOrd.Text,
                DateTime.Now,
                ddlEstado.SelectedItem.Text,
                listaDeComentarios
            );

            BaseDeDatos.listaOrdenesDeTrabajo.Add(ordenDeTrabajo);

            Session["ListaOrdenesDeTrabajo"] = BaseDeDatos.listaOrdenesDeTrabajo;

            lblMensaje.Text = "Orden creada exitosamente.";
            lblMensaje.ForeColor = System.Drawing.Color.Green;

            contadorNumOrden++;
            tbNumOrd.Text = contadorNumOrden.ToString();

            CargarTablaODT(null, EventArgs.Empty);

            tbDescOrd.Text = "";
            tbComOrd.Text = "";
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

        protected void CargarTablaODT(object sender, EventArgs e)
        {
            var data = BaseDeDatos.listaOrdenesDeTrabajo.Select(orden => new
            {
                orden.NumeroOrden,
                ClienteOrden = orden.ClienteOrden.Nombre + " " + orden.ClienteOrden.Apellido,
                TecnicoOrden = orden.TecnicoOrden.Nombre + " " + orden.TecnicoOrden.Apellido,
                orden.DescripcionProblema,
                FechaCreacion = orden.FechaCreacion.ToString("dd-MM-yyyy"),
                orden.Estado,
                ListaComentarios = string.Join("; ", orden.ListaComentarios)
            }).ToList();

            tablaODT.DataSource = data;
            tablaODT.DataBind();
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
                lblMensaje.Text = "No se encontró ninguna orden de trabajo bajo ese número";
            }

            CargarTablaODT(sender, e);
            Session["ListaOrdenesDeTrabajo"] = BaseDeDatos.listaOrdenesDeTrabajo;
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

                    TextBox clienteNombre = (TextBox)row.FindControl("txtClienteNombre");
                    TextBox tecnicoNombre = (TextBox)row.FindControl("txtTecnicoNombre");
                    TextBox descripcionProblema = (TextBox)row.FindControl("txtDescripcionProblema");
                    DropDownList ddlEstadoEdit = (DropDownList)row.FindControl("ddlEdicionEstado");
                    TextBox comentarios = (TextBox)row.FindControl("txtComentarios");

                    if (clienteNombre != null && !string.IsNullOrWhiteSpace(clienteNombre.Text))
                    {
                        ordenDeTrabajo.ClienteOrden.Nombre = clienteNombre.Text.Trim();
                    }
                    if (tecnicoNombre != null && !string.IsNullOrWhiteSpace(tecnicoNombre.Text))
                    {
                        ordenDeTrabajo.TecnicoOrden.Nombre = tecnicoNombre.Text.Trim();
                    }
                    if (descripcionProblema != null && !string.IsNullOrWhiteSpace(descripcionProblema.Text))
                    {
                        ordenDeTrabajo.DescripcionProblema = descripcionProblema.Text.Trim();
                    }
                    if (ddlEstadoEdit != null)
                    {
                        ordenDeTrabajo.Estado = ddlEstadoEdit.SelectedValue;
                    }
                    if (comentarios != null && !string.IsNullOrWhiteSpace(comentarios.Text))
                    {
                        if (ordenDeTrabajo.ListaComentarios.Count > 0)
                        {
                            ordenDeTrabajo.ListaComentarios[0] = comentarios.Text.Trim();
                        }
                        else
                        {
                            ordenDeTrabajo.ListaComentarios.Add(comentarios.Text.Trim());
                        }
                    }

                    tablaODT.EditIndex = -1;
                    CargarTablaODT(sender, e);
                    Session["ListaOrdenesDeTrabajo"] = BaseDeDatos.listaOrdenesDeTrabajo;
                }
                else
                {
                    lblMensaje.Text = "No se encontró ninguna orden de trabajo con el número indicado.";
                }
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

        public List<Estado> GetEstadoDataSource()
        {
            return new List<Estado>
            {
                new Estado { Id = "Pendiente", Nombre = "Pendiente" },
                new Estado { Id = "En progreso", Nombre = "En progreso" },
                new Estado { Id = "Completada", Nombre = "Completada" }
            };
        }

        public class Estado
        {
            public string Id { get; set; }
            public string Nombre { get; set; }
        }
    }
}
