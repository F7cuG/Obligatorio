using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio
{
    public class BaseDeDatos
    {
        static public List<Cliente> listaClientes = new List<Cliente>();
        static public List<Tecnico> listaTecnicos = new List<Tecnico>();
        static public List<OrdenDeTrabajo> listaOrdenesDeTrabajo = new List<OrdenDeTrabajo>();
    }
}