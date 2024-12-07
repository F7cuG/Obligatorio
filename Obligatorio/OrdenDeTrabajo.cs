using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Obligatorio;

namespace Obligatorio
{
    public partial class OrdenDeTrabajo
    {
        public int NumeroOrden { get; set; }
        public Cliente ClienteOrden { get; set; }
        public Tecnico TecnicoOrden { get; set; }
        public string DescripcionProblema { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string Estado { get; set; }
        public List<string> ListaComentarios { get; set; }

        public OrdenDeTrabajo(int numeroOrden, Cliente clienteOrden, Tecnico tecnicoOrden, string descripcionProblema, DateTime fechaCreacion, string estado, List<string> listaComentarios)
        {
            NumeroOrden = numeroOrden;
            ClienteOrden = clienteOrden;
            TecnicoOrden = tecnicoOrden;
            DescripcionProblema = descripcionProblema;
            FechaCreacion = fechaCreacion;
            Estado = estado;
            ListaComentarios = listaComentarios;
        }
    }
}