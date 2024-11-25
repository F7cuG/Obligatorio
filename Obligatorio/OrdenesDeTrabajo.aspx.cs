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
        }

        protected void GenerarNumOrden()
        {
            tbNumOrd.Text = contadorNumOrden.ToString();  //el contador aumenta cada vez que se carga la pagina [ARREGLAR]
            contadorNumOrden++;
        }

        protected void seleccionarFecha(object sender, EventArgs e)
        {
            tbFechaOrd.Text = DateTime.Now.ToString("dd,MM,yyyy");
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
                DateTime.Parse(tbFechaOrd.Text),
                ddlEstado.SelectedItem.Text,
                tbComOrd.Text

            );

            BaseDeDatos.listaOrdenesDeTrabajo.Add(ordenDeTrabajo);
            lblMensaje.Text = "Orden creada exitosamente";

            tablaODT.DataSource = BaseDeDatos.listaOrdenesDeTrabajo;

            CargarTablaODT(null, EventArgs.Empty);

            tbNumOrd.Text = "";
            ddlClientes.Text = "";
            ddlTecnicos.Text = "";
            tbDescOrd.Text = "";
            tbFechaOrd.Text = "";
            ddlEstado.Text = "";

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

    }

} 