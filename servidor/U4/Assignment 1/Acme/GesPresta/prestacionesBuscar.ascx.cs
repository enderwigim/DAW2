using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GesPresta
{
    public partial class prestacionesBuscar : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public String Codigo
        {
            get
            {
                return lstPrestaciones.SelectedValue;
            }
        }
        public String Descripcion
        {
            get
            {
                return lstPrestaciones.SelectedItem.Text;
            }
        }
    }
}