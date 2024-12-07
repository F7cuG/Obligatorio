using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Obligatorio
{
    public partial class Tecnicos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarTablaTecnicos(sender, e);
            }
        }

        private bool ValidarCedulaUruguaya(string ci)
        {
            ci = ci.Replace(".", "").Replace("-", "");

            if (ci.Length < 7 || ci.Length > 8 || !ci.All(char.IsDigit))
            {
                return false;
            }

            ci = ci.PadLeft(8, '0');

            int[] verifNums = { 2, 9, 8, 7, 6, 3, 4 };
            int suma = 0;

            for (int i = 0; i < 7; i++)
            {
                suma += (ci[i] - '0') * verifNums[i];
            }

            int codVerif = (10 - (suma % 10)) % 10;

            int digVerif = ci[7] - '0';
            return codVerif == digVerif;
        }

        protected void CrearYguardarTecnico(object sender, EventArgs e)
        {
            string nombre = tbNomTec.Text.Trim();
            string apellido = tbApTec.Text.Trim();
            string ci = tbCiTec.Text.Trim();
            string especialidad = tbEspTec.Text.Trim();

            if (!ValidarCedulaUruguaya(ci))
            {
                lblMensaje.Text = "El CI ingresado no es válido.";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            if (string.IsNullOrEmpty(nombre) || string.IsNullOrEmpty(apellido))
            {
                lblMensaje.Text = "Debe ingresar un nombre y apellido";
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                return;
            }

            Tecnico tecnico = new Tecnico(
                 tbNomTec.Text,
                 tbApTec.Text,
                 tbCiTec.Text,
                 tbEspTec.Text
             );

            lblMensaje.Text = "Tecnico agregado correctamente";
            BaseDeDatos.listaTecnicos.Add(tecnico);

            tbNomTec.Text = "";
            tbApTec.Text = "";
            tbCiTec.Text = "";
            tbEspTec.Text = "";

            CargarTablaTecnicos(sender, e);
        }

        protected void CargarTablaTecnicos(object sender, EventArgs e)
        {
            tablaTecnicos.DataSource = BaseDeDatos.listaTecnicos;
            tablaTecnicos.DataBind();
        }

        protected void RowDeletingEvent(object sender, GridViewDeleteEventArgs e)
        {
            int rowIndexTec = e.RowIndex;
            string tecnicoCI = tablaTecnicos.DataKeys[rowIndexTec].Values[0].ToString();
            Tecnico tecnico = BaseDeDatos.listaTecnicos.FirstOrDefault(c => c.CI == tecnicoCI);
            if (tecnico != null)
            {
                BaseDeDatos.listaTecnicos.Remove(tecnico);
                lblMensaje.Text = "Tecnico eliminado correctamente";
            }
            else
            {
                lblMensaje.Text = "No se encontro ningun tecnico con ese CI";
            }

            CargarTablaTecnicos(sender, e);
        }

        protected void RowEditingEvent(object sender, GridViewEditEventArgs e)
        {
            tablaTecnicos.EditIndex = e.NewEditIndex;
            CargarTablaTecnicos(sender, e);
        }

        protected void RowUpdatingEvent(object sender, GridViewUpdateEventArgs e)
        {
            int rowIndexTec = e.RowIndex;
            if (tablaTecnicos.DataKeys != null && tablaTecnicos.DataKeys[rowIndexTec] != null)
            {
                string tecnicoCI = tablaTecnicos.DataKeys[rowIndexTec].Values[0].ToString();
                Tecnico tecnico = BaseDeDatos.listaTecnicos.FirstOrDefault(c => c.CI == tecnicoCI);

                if (tecnico != null)
                {
                    GridViewRow row = tablaTecnicos.Rows[rowIndexTec];

                    TextBox a = (TextBox)row.Cells[1].Controls[0];
                    TextBox b = (TextBox)row.Cells[2].Controls[0];
                    TextBox d = (TextBox)row.Cells[4].Controls[0];

                    tecnico.Nombre = a.Text.Trim();
                    tecnico.Apellido = b.Text.Trim();
                    tecnico.Especialidad = d.Text.Trim();

                    lblMensaje.Text = "Tecnico actualizado correctamente";
                }
                else
                {
                    lblMensaje.Text = "No se encontró ningún técnico con el CI ingresado";
                }

                tablaTecnicos.EditIndex = -1;
                CargarTablaTecnicos(sender, e);
            }
            else
            {
                lblMensaje.Text = "Error: no se pudo obtener la clave de la fila seleccionada";
            }
        }

        protected void RowCancelingEditingEvent(object sender, GridViewCancelEditEventArgs e)
        {
            tablaTecnicos.EditIndex = -1;
            CargarTablaTecnicos(sender, e);
        }
    }
}
