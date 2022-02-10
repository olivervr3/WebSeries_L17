using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web
{
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["usuario"] != null || Session["usuariomod"] != null)
            {
                ENUsuario en = new ENUsuario();
                //en.emailUsuario = Session["usuario"].ToString();
                en.emailUsuario = Session["usuariomod"] != null ? Session["usuariomod"].ToString() : Session["usuario"].ToString();
                en.readUsuario();
                TBNombre.Text = en.nombreUsuario;
                TBApellido1.Text = en.apellido1Usuario;
                TBApellido2.Text = en.apellido2Usuario;
                Label1.Text = en.emailUsuario;
                TBContrasena.Text = en.contrasenaUsuario;
                TBNif.Text = en.nifUsuario;
                TBTelefono.Text = en.numTelefonoUsuario.ToString();
                TBTarjeta.Text = en.numTarjetaUsuario;
                TBCaducidad.Text = en.numCaducidadUsuario;
                TBSeguridad.Text = en.numSeguridadUsuario.ToString();
                Label1.Text = en.emailUsuario;
            }
            else {
                Response.Redirect("Inicio.aspx");
            }
        }
        protected void Button_Update(object sender, EventArgs e)
        {
            ENUsuario en = new ENUsuario();
            en.nombreUsuario = TBNombre.Text;
            en.apellido1Usuario = TBApellido1.Text;
            en.apellido2Usuario = TBApellido2.Text;
            en.emailUsuario = Label1.Text;
            en.contrasenaUsuario = TBContrasena.Text;
            en.nifUsuario = TBNif.Text;
            en.numTelefonoUsuario = Convert.ToInt32(TBTelefono.Text);
            en.numTarjetaUsuario = TBTarjeta.Text;
            en.numCaducidadUsuario = TBCaducidad.Text;
            en.numSeguridadUsuario = Convert.ToInt32(TBSeguridad.Text);

            if (Page.IsValid)
            {
                en.updateUsuario();
                Label2.Text = "Usuario modificado CORRECTAMENTE";
            }
            else
            {
                Label2.Text = "Error";
            }
        }
        protected void Button_Delete(object sender, EventArgs e)
        {
            ENUsuario en = new ENUsuario();
            en.emailUsuario = Label1.Text;

            en.deleteUsuario();
            Label2.Text = "Usuario borrado CORRECTAMENTE";
            Response.Redirect("Salir.aspx");

        }
    }
}