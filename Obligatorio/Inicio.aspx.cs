using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarResumenOrdenes();
            }
        }
        private void CargarResumenOrdenes()
        {
            if (BaseDeDatos.listaOrdenesDeTrabajo != null && BaseDeDatos.listaOrdenesDeTrabajo.Any())
            {
                int pendientes = BaseDeDatos.listaOrdenesDeTrabajo.Count(o => o.Estado == "Pendiente");
                int enProgreso = BaseDeDatos.listaOrdenesDeTrabajo.Count(o => o.Estado == "En Progreso");
                int completadas = BaseDeDatos.listaOrdenesDeTrabajo.Count(o => o.Estado == "Completada");

                lblPendiente.Text = pendientes.ToString();
                lblEnProgreso.Text = enProgreso.ToString();
                lblCompletada.Text = completadas.ToString();
            }
            else
            {
                lblPendiente.Text = "0";
                lblEnProgreso.Text = "0";
                lblCompletada.Text = "0";
            }
        }
    }
}