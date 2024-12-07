using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio
{
    public partial class BusquedaDeOrdenes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["UsuarioLogueado"] == null)
                {
                    Response.Redirect("Login.aspx");
                }
                if (Session["ListaOrdenesDeTrabajo"] == null)
                {
                    Session["ListaOrdenesDeTrabajo"] = new List<OrdenDeTrabajo>();
                }
                BaseDeDatos.listaOrdenesDeTrabajo = Session["ListaOrdenesDeTrabajo"] as List<OrdenDeTrabajo>;

                if (Session["OrdenBuscada"] != null)
                {
                    OrdenDeTrabajo orden = Session["OrdenBuscada"] as OrdenDeTrabajo;
                    if (orden != null)
                    {
                        MostrarDetallesOrden(orden);
                    }
                }
                
            }
        }

        protected void BuscarOrden(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(tbBuscarNumOrd.Text) || !int.TryParse(tbBuscarNumOrd.Text, out int numeroOrden))
            {
                lblResultadoBusqueda.Text = "Por favor, ingrese un número de orden válido.";
                lblResultadoBusqueda.ForeColor = System.Drawing.Color.Red;
                detalleOrden.Style["display"] = "none";
                return;
            }

            OrdenDeTrabajo orden = BaseDeDatos.listaOrdenesDeTrabajo.FirstOrDefault(o => o.NumeroOrden == numeroOrden);

            if (orden == null)
            {
                lblResultadoBusqueda.Text = "No se encontró ninguna orden con el número ingresado.";
                lblResultadoBusqueda.ForeColor = System.Drawing.Color.Red;
                detalleOrden.Style["display"] = "none";
            }
            else
            {
                Session["OrdenBuscada"] = orden;
                MostrarDetallesOrden(orden);
            }
        }

        protected void AgregarComentario(object sender, EventArgs e)
        {
            string nuevoComentario = tbComentario.Text.Trim();

            if (!string.IsNullOrEmpty(nuevoComentario))
            {
                if (Session["OrdenBuscada"] != null)
                {
                    OrdenDeTrabajo ordenBuscada = Session["OrdenBuscada"] as OrdenDeTrabajo;

                    if (ordenBuscada != null)
                    {
                        ordenBuscada.ListaComentarios.Add(nuevoComentario);

                        lblComentarios.Text = string.Join("<br/>", ordenBuscada.ListaComentarios);

                        lblErrorComentario.Text = "Comentario agregado correctamente.";
                        lblErrorComentario.ForeColor = System.Drawing.Color.Green;
                        tbComentario.Text = "";

                        Session["ListaOrdenesDeTrabajo"] = BaseDeDatos.listaOrdenesDeTrabajo;
                        Session["OrdenBuscada"] = ordenBuscada;
                    }
                }
                else
                {
                    lblErrorComentario.Text = "Debe buscar una orden antes de agregar comentarios.";
                    lblErrorComentario.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                lblErrorComentario.Text = "Debe ingresar un comentario para agregar.";
                lblErrorComentario.ForeColor = System.Drawing.Color.Red;
            }
        }

        private void MostrarDetallesOrden(OrdenDeTrabajo orden)
        {
            if (orden == null)
            {
                detalleOrden.Style["display"] = "none";
                return;
            }

            lblEstado.Text = orden.Estado;
            lblCliente.Text = orden.ClienteOrden.Nombre + " " + orden.ClienteOrden.Apellido + " (CI: " + orden.ClienteOrden.CI + ")";
            lblTecnico.Text = orden.TecnicoOrden.Nombre + " " + orden.TecnicoOrden.Apellido + " (CI: " + orden.TecnicoOrden.CI + ")";
            lblDescripcion.Text = orden.DescripcionProblema;
            lblFecha.Text = orden.FechaCreacion.ToString("dd-MM-yyyy");
            lblComentarios.Text = orden.ListaComentarios.Count == 0 ? "No hay comentarios." : string.Join("<br/>", orden.ListaComentarios);

            detalleOrden.Style["display"] = "block";
            lblResultadoBusqueda.Text = "Orden encontrada:";
            lblResultadoBusqueda.ForeColor = System.Drawing.Color.Green;
        }
    }
}


