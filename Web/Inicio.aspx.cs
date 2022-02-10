using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web
{
    public partial class Inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Button_Login(object sender, EventArgs e)
        {
            ENUsuario en = new ENUsuario();
            en.emailUsuario = TBemail.Text;
            en.contrasenaUsuario = TBpassword.Text;
            if (en.checkUsuario() && Session["nCesta"] == null)
            {
                Session.Clear();
                Session.Add("usuario", en.emailUsuario);
                en.readUsuario();
                if (en.rolUusario == "admin")
                {
                    Session["admin"] = "Si";
                }
                Label1.Text = "Login correcto";
                Response.Redirect("Biblioteca.aspx");
            } 
            else if(en.checkUsuario() && Session["nCesta"] != null) 
            {
                Session.Clear();
                Session.Add("usuario", en.emailUsuario);
                en.readUsuario();
                if (en.rolUusario == "admin")
                {
                    Session["admin"] = "Si";
                }
                Label1.Text = "Login correcto";
                Response.Redirect("TramitarPedido.aspx?nCesta" + Convert.ToString(Session["nCesta"]));
            }
            else if (en.existeUsuario() == false)
            {
                Label1.Text = "No se ha encontrado ninguna cuenta con esta dirección de correo";
            }
            else
            {
                Label1.Text = "Contraseña incorrecta";
            }
        }
    }
}