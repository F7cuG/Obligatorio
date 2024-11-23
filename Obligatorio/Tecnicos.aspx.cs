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
       /* protected void cmdTecnico_Click(object sender, EventArgs e)
        {
            Tecnico tecnico = new Tecnico();

            tecnico.Nombre = tb.Text;
            tecnico.Apellido = tbApellidoTec.Text;
            tecnico.CI = tbCITec.Text;
            tecnico.Especialidad = tbEspTec.Text;
        }   //me tira un error que dice que no le estoy poniendo un valor al parametro nombre
    
       */
         protected void CrearYguardarTecnico(object sender, EventArgs e)
         {

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