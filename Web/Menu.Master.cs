using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Web
{
    public partial class Menu : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Si el usuario está identificado compruebo si es administrador y en caso afirmativo añado un item de admin al menú
            if (Session["admin"] != null && Session["admin"].ToString() == "Si" ) {
                MenuItem menuAdmin = new MenuItem();
                menuAdmin.Text = "Admin";
                menuAdmin.NavigateUrl = "~/Admin.aspx";

                MenuIdentificado.Items.Add(menuAdmin);
            }

            // Como esta es la página maestra, cada vez que se muestre aumento el contador de páginas vistas en la aplicación
            if (Application["contadorVisitas"] != null)
            {
                Application["contadorVisitas"] = (int)Application["contadorVisitas"] + 1;
            }
            else {
                Application["contadorVisitas"] = 1;
            }
        }
    }
}