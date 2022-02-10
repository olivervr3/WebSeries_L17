using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.Net.Mail;
using Library;

namespace Web
{
    public partial class Info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
         
        }

        protected void EnviarButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("seriesplus.es@gmail.com");
                msg.To.Add( EmailTextBox.Text );
                msg.Subject = "Contacto SeriesPlus - " + NombreTextBox.Text;
                msg.Body = "¡Hola " + NombreTextBox.Text + "!\n\nHemos recibido correctamente tu mensaje. Te contestaremos lo antes posible.\n\nTu mensaje:\n\n" + MensajeTextBox.Text + "\n\n";

                MailAddress ms = new MailAddress("seriesplus.es@gmail.com");
                msg.CC.Add(ms);
                SmtpClient sc = new SmtpClient("smtp.gmail.com");
                sc.Port = 25;
                sc.Credentials = new NetworkCredential("seriesplus.es@gmail.com", "seriesplus1234");
                sc.EnableSsl = true;
                sc.Send(msg);
                labelInfo.Text = "E-mail enviado correctamente. Te hemos enviado una copia a la dirección de e-mail indicada.";
            }
            else {
                labelInfo.Text = "Error";
            }
        }
    }
}