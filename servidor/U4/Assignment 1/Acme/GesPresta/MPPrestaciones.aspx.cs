using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GesPresta
{
    public partial class MPPrestaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtCodPre.Focus();
        }

        protected void btnVerPrestaciones_Click(object sender, EventArgs e)
        {
            if (prestacionesBuscar1.Visible == false)
            {
                btnSeleccionar.Visible = true;
                prestacionesBuscar1.Visible = true;
                btnVerPrestaciones.Text = "Ocultar prestaciones";
            }
            else
            {
                btnSeleccionar.Visible = false;
                prestacionesBuscar1.Visible = false;
                btnVerPrestaciones.Text = "Ver prestaciones";
            }
        }

        protected void btnSeleccionar_Click(object sender, EventArgs e)
        {
            txtCodPre.Text = prestacionesBuscar1.Codigo;
            txtDesPre.Text = prestacionesBuscar1.Descripcion;
        }
    }
}