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
    public partial class EmailNuevoUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ENUsuario usuario = new ENUsuario();
            usuario.emailUsuario = Session["usuario"].ToString();
            usuario.readUsuario();
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("seriesplus.es@gmail.com");
                msg.To.Add(usuario.emailUsuario);
                msg.Subject = "Bienvenido a SeriesPlus";
                msg.Body = "Hola " + usuario.nombreUsuario + ", gracias por unirte a SeriesPlus. Has completado tu registro y ya puedes comenzar a disfrutar de tus series favoritas. \n\n Información de tu cuenta: \n Tu email de inicio de sesión: " + usuario.emailUsuario + "\n Apellidos y nombre: "+ usuario.apellido1Usuario + " " + usuario.apellido2Usuario + ", " + usuario.nombreUsuario + "\n Número de teléfono: " + usuario.numTelefonoUsuario + "\n Detalles de pago: ************" + usuario.numTarjetaUsuario.Substring(15) + "\n\n Ve lo que quieras, cuando quieras.";
                //msg.Attachments.Add(new Attachment(Server.MapPath("~/logo/logo_size_invert.jpg")));
                
                MailAddress ms = new MailAddress("seriesplus.es@gmail.com");
                msg.CC.Add(ms);
                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                sc.Port = 25;
                sc.Credentials = new NetworkCredential("seriesplus.es@gmail.com", "seriesplus1234");
                sc.EnableSsl = true;
                sc.Send(msg);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }
            Response.Redirect("Biblioteca.aspx");
        }
    }
}