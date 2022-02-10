using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web
{
    public partial class CrearUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        protected void Button_Create(object sender, EventArgs e)
        {
            ENUsuario en = new ENUsuario();
            en.nombreUsuario = TBNombre.Text;
            en.apellido1Usuario = TBApellido1.Text;
            en.apellido2Usuario = TBApellido2.Text;
            en.emailUsuario = TBEmail.Text;
            en.contrasenaUsuario = TBContrasena.Text;
            en.nifUsuario = TBNif.Text;
            en.numTelefonoUsuario = Convert.ToInt32(TBTelefono.Text);
            en.numTarjetaUsuario = TBTarjeta.Text;
            en.numCaducidadUsuario = TBCaducidad.Text;
            en.numSeguridadUsuario = Convert.ToInt32(TBSeguridad.Text);

            //Compruebo si existe el usuario
            if (en.existeUsuario() == true)
            {
                Label1.Text = "Email incorrecto, ya hay un usuario registrado con ese correo";
            }
            //Compruebo si se cumplen los validators
            else if (Page.IsValid) {
                //Si el usuario pulsa el button check crea el usuario
                if (BTCheck.Checked) {
                    en.createUsuario();
                    Label1.Text = "Usuario creado correctamente";
                    Session.Clear();
                    Session.Add("usuario", en.emailUsuario);
                    Response.Redirect("EmailNuevoUsuario.aspx");
                }
                else{
                    Label1.Text = "Tienes que aceptar las politica de privacidad para poder crear el usuario";
                }
            }
            else {
                Label1.Text = "Error";
            }
        }
    }
}