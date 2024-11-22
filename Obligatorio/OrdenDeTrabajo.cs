using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio;

namespace Obligatorio
{
    public partial class OrdenDeTrabajo
    {
        public int NumeroOrden {  get; set; }
        public Cliente ClienteAsociado { get; set; }
        public Tecnico TecnicoDesignado { get; set; }
        public string DescripcionProblema { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estado;
        public string ListaComentarios;

        public OrdenDeTrabajo(int numeroOrden, Cliente clienteAsociado, Tecnico tecnicoDesignado, string descripcionProblema, DateTime fechaCreacion, string estado, string listaComentarios)
        {
            NumeroOrden = numeroOrden;
            ClienteAsociado = clienteAsociado;
            TecnicoDesignado = tecnicoDesignado;
            DescripcionProblema = descripcionProblema;
            FechaCreacion = fechaCreacion;
            Estado = estado;
            ListaComentarios = listaComentarios;
        }
    }
}