using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GesPresta
{
    public partial class Prestaciones1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCodPre.Focus();
        }

        protected void cmdEnviar_Click(object sender, EventArgs e)
        {
            // Revisamos que tanto codigo como importe existan en el formulario.
            String errorMessage = "";
            if (txtCodPre.Text == "")
            {
                errorMessage += " Codigo,";
            }
            if (txtImpPre.Text == "")
            {
                errorMessage += " Importe,";
            }
            // En caso de no haber error. Redireccionamos a prestaciones1respuesta.
            if (errorMessage == "")
            {
                cmdEnviar.PostBackUrl = "~/Prestaciones1Respuesta.aspx";
            }
            // Mensaje error.
            else
            {
                lblError.Text = $"Los siguientes valores estan incompletos: {errorMessage.Remove(errorMessage.Length - 1)}";
                lblError.Visible = true;
            }
        }
    }
}