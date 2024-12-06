﻿using System;
using System.Linq;
using System.Web.UI;

namespace Obligatorio
{
    public partial class ReporteActividad : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                tbFechaInicio.Text = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");
                tbFechaFin.Text = DateTime.Now.ToString("yyyy-MM-dd");
                FiltrarOrdenes(null, null);
            }
        }

        protected void FiltrarOrdenes(object sender, EventArgs e)
        {
            DateTime fechaInicio;
            DateTime fechaFin;

            if (!DateTime.TryParse(tbFechaInicio.Text, out fechaInicio) || !DateTime.TryParse(tbFechaFin.Text, out fechaFin) ||
                fechaInicio > fechaFin)
            {
                gvResumenTecnicos.DataSource = null;
                gvResumenTecnicos.DataBind();
                gvOrdenesCompletadas.DataSource = null;
                gvOrdenesCompletadas.DataBind();
                return;
            }

            CargarResumenTecnicos(fechaInicio, fechaFin);
            CargarOrdenesCompletadas(fechaInicio, fechaFin);
        }

        private void CargarResumenTecnicos(DateTime fechaInicio, DateTime fechaFin)
        {
            var resumenTecnicos = BaseDeDatos.listaTecnicos.Select(tecnico => new
            {
                NombreTecnico = tecnico.NombreCompletoTec,
                Pendientes = BaseDeDatos.listaOrdenesDeTrabajo.Count(o => o.TecnicoOrden.CI == tecnico.CI && o.Estado == "Pendiente" && o.FechaCreacion >= fechaInicio && o.FechaCreacion <= fechaFin),
                EnProgreso = BaseDeDatos.listaOrdenesDeTrabajo.Count(o => o.TecnicoOrden.CI == tecnico.CI && o.Estado == "En progreso" && o.FechaCreacion >= fechaInicio && o.FechaCreacion <= fechaFin),
                Completadas = BaseDeDatos.listaOrdenesDeTrabajo.Count(o => o.TecnicoOrden.CI == tecnico.CI && o.Estado == "Completada" && o.FechaCreacion >= fechaInicio && o.FechaCreacion <= fechaFin)
            }).ToList();

            gvResumenTecnicos.DataSource = resumenTecnicos;
            gvResumenTecnicos.DataBind();
        }

        private void CargarOrdenesCompletadas(DateTime fechaInicio, DateTime fechaFin)
        {
            var ordenesCompletadas = BaseDeDatos.listaOrdenesDeTrabajo
                .Where(o => o.Estado == "Completada" && o.FechaCreacion >= fechaInicio && o.FechaCreacion <= fechaFin).Select
                (o => new
                {
                    NumeroOrden = o.NumeroOrden,
                    Cliente = o.ClienteOrden.Nombre + " " + o.ClienteOrden.Apellido,
                    Tecnico = o.TecnicoOrden.Nombre + " " + o.TecnicoOrden.Apellido,
                    Descripcion = o.DescripcionProblema,
                    Fecha = o.FechaCreacion.ToString("MM-dd-yyyy")
                }
                ).ToList();

            gvOrdenesCompletadas.DataSource = ordenesCompletadas;
            gvOrdenesCompletadas.DataBind();
        }
    }
}