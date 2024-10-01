using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GesPresta
{
    public partial class Empleados1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCodEmp.Focus();
        }

        protected void cmdEnviar_Click(object sender, EventArgs e)
        {
            lblValores.Visible = true;

            String errorMessage = searchErrors();
            if (errorMessage == "")
            {
                lblValores.BackColor = System.Drawing.ColorTranslator.FromHtml("#66FFFF");
                lblValores.Text = "VALORES DEL FORMULARIO" +
                    "<br/> Código Empleado: " + txtCodEmp.Text +
                    "<br/> NIF: " + txtNifEmp.Text +
                    "<br/> Apellidos y Nombre: " + txtNomEmp.Text +
                    "<br/> Dirección: " + txtDirEmp.Text +
                    "<br/> Ciudad: " + txtCiuEmp.Text +
                    "<br/> Teléfonos: " + txtTelEmp.Text +
                    "<br/> Fecha de Nacimiento: " + txtFnaEmp.Text +
                    "<br/> Fecha de Incorporación: " + txtFinEmp.Text +
                    "<br/> Sexo: " + rblSexEmp.SelectedItem.Value +
                    "<br/> Departamento: " + ddlDepEmp.Text;
            }
            else
            {
                lblValores.BackColor = System.Drawing.ColorTranslator.FromHtml("#FF0000");
                lblValores.Text = $"ERROR: Los siguientes campos están incompletos: {errorMessage}";
            }
        }
        private String searchErrors()
        {
            String errorMessage = "";
            if (txtCodEmp.Text == "")
            {
                errorMessage = " Código Empleado,";
            }
            if (txtNomEmp.Text == "")
            {
                errorMessage += " Apellidos y Nombre,";
            }
            if (txtFinEmp.Text == "")
            {
                errorMessage += " Fecha de Incorporación,";
            }
            return errorMessage.Remove(errorMessage.Length - 1);
        }
    }
}