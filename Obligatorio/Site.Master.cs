using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio
{
    public partial class SiteMaster : MasterPage
    {
        private void PreCargarTecnicos()
        {

            Tecnico tecnicoPreCargado = new Tecnico(
                "Juan",
                "Pérez",
                "12345678",
                "Electricista"
            );

            if (BaseDeDatos.listaTecnicos == null)
            {
                BaseDeDatos.listaTecnicos = new List<Tecnico>();
            }

            BaseDeDatos.listaTecnicos.Add(tecnicoPreCargado);
        }

        private void PreCargarClientes()
        {
            Cliente clientePreCargado = new Cliente(
                "Ana",
                "Gómez",
                "12345678",
                "18 de Julio 1234",
                987654321,
                "ana.gomez@example.com"
            );

            if (BaseDeDatos.listaClientes == null)
            {
                BaseDeDatos.listaClientes = new List<Cliente>();
            }
            BaseDeDatos.listaClientes.Add(clientePreCargado);
        }

        protected void Page_Load(object sender, EventArgs e)
            {
                if (!IsPostBack)
                {

                    if (BaseDeDatos.listaTecnicos == null || !BaseDeDatos.listaTecnicos.Any())
                    {
                        PreCargarTecnicos();
                    }
               
                    if (BaseDeDatos.listaClientes == null || !BaseDeDatos.listaClientes.Any())
                    {
                        PreCargarClientes();
                    }
                }
            }
    }
}