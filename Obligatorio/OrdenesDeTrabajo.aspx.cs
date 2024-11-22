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
            if(ddlClientes.SelectedIndex == -1)
            {
                lblMensaje.Text = "Debe elegir un cliente";
            }
            if (ddlTecnicos.SelectedIndex == -1)
            {
                lblMensaje.Text = "Debe elegir un tecnico";
            }

            Cliente clienteSeleccionado = BaseDeDatos.listaClientes.FirstOrDefault(c => c.CI.ToString() == ddlClientes.SelectedValue);
            Tecnico tecnicoSeleccionado = BaseDeDatos.listaTecnicos.FirstOrDefault(c => c.CI.ToString() == ddlTecnicos.SelectedValue);
           
            if (clienteSeleccionado == null || tecnicoSeleccionado == null)
            {
                lblMensaje.Text = "Debe seleccionar un cliente y/o tecnico";
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

            lblMensaje.Text = "Orden creada exitosamente";

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
    }

} 