using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Muestro el número de páginas vistas en el panel de administración
            visitasLabel.Text = ""+ (int)Application["contadorVisitas"];
        }
    }
}