using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GesPresta
{
    public partial class Empleados : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Trace.Write("Evento", "Entrando en Page_Load");
            txtCodEmp.Focus();

            // Sitúa el foco en el elemento Código Empleado 
            if (Trace.IsEnabled)
            {
                txtNifEmp.Text = "11111111X";
                // Establece un valor por defecto para el campo 
                Trace.Warn("Asignación", "Cambiado el valor txtNifEmp a: " + txtNifEmp.Text);
            }
            Trace.Write("Evento", "Saliendo de Page_Load");
        }
    }
}   