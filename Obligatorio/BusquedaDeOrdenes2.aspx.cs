using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio
{
    public partial class BusquedaDeOrdenes2 : System.Web.UI.Page
    {
        static OrdenDeTrabajo ordenBuscada;
        protected void Page_Load(object sender, EventArgs e)
        {

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
                if(orden.ListaComentarios.Count == 0)
                {
                    lblComentarios.Text = "No hay comentarios.";
                }
                else
                {
                    lblComentarios.Text = "";
                    for (int i = 0; i<orden.ListaComentarios.Count; i++)
                    {
                        lblComentarios.Text += orden.ListaComentarios[i] + ", ";
                    }
                }
                
                BusquedaDeOrdenes2.ordenBuscada = orden;
                lblResultadoBusqueda.Text = "Orden encontrada:";
                lblResultadoBusqueda.ForeColor = System.Drawing.Color.Green;
                detalleOrden.Visible = true;
            }
        }
         
        protected void AgregarComentario(object sender, EventArgs e)
        {

            string nuevoComentario = tbComentario.Text.Trim();
            if (!string.IsNullOrEmpty(nuevoComentario))
            {
                BusquedaDeOrdenes2.ordenBuscada.ListaComentarios.Add(nuevoComentario);

                lblErrorComentario.Text = "Comentario agregado correctamente";
                lblErrorComentario.ForeColor = System.Drawing.Color.Green;
                tbComentario.Text = "";
            }
            else
            {
                lblErrorComentario.Text = "Debe ingresar un comentario para agregar.";
                lblErrorComentario.ForeColor = System.Drawing.Color.Red;
            }
        }
    }
}