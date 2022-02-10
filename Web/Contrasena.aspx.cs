using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;


namespace Web
{
    public partial class Contrasena : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        //Si el correo existe en la BBDD envio un correo con la contraseña, si no muestro error
        protected void Button_Recuperar(object sender, EventArgs e)
        {
            ENUsuario usuario = new ENUsuario();
            usuario.emailUsuario = TBemail.Text;
            usuario.readUsuario();
            try
            {
                if (usuario.existeUsuario() == true) {
                    MailMessage msg = new MailMessage();
                    msg.From = new MailAddress("seriesplus.es@gmail.com");
                    msg.To.Add(usuario.emailUsuario);
                    msg.Subject = "Recuperar Contraseña";
                    msg.Body = "Hola " + usuario.nombreUsuario + ", aquí tienes tu contraseña: " + usuario.contrasenaUsuario + " ";

                    MailAddress ms = new MailAddress("seriesplus.es@gmail.com");
                    msg.CC.Add(ms);
                    SmtpClient sc = new SmtpClient("smtp.gmail.com");
                    sc.Port = 25;
                    sc.Credentials = new NetworkCredential("seriesplus.es@gmail.com", "seriesplus1234");
                    sc.EnableSsl = true;
                    sc.Send(msg);
                    Label1.Text = "Revise tu correo para obtener la contraseña";
                }
                else {
                    Label1.Text = "El correo introducido es incorrecto";
                }
            }
            catch (Exception ex)
            {
                Label1.Text = "Error: " + ex.Message;
                //Response.Write(ex.Message);
            }
        }
    }
}