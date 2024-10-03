using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GesPresta
{
    public partial class Prestaciones2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCodPre.Focus();
        }

        protected void btnVerPrestaciones_Click(object sender, EventArgs e)
        {
            if (btnSeleccionar.Visible == false)
            {
                btnSeleccionar.Visible = true;
                prestacionesBuscar.Visible = true;
                btnVerPrestaciones.Text = "Ocultar prestaciones";
            }
            else
            {
                btnSeleccionar.Visible = false;
                prestacionesBuscar.Visible = false;
                btnVerPrestaciones.Text = "Ver prestaciones";
            }
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            txtCodPre.Text = prestacionesBuscar.Codigo;
            txtDesPre.Text = prestacionesBuscar.Descripcion;
        }
    }
}