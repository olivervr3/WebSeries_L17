using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mail;
using System.Net;
using System.Globalization;

namespace Web
{
    public partial class Pedido : System.Web.UI.Page
    {

        public ENCesta cesta = new ENCesta();
        public ENPedido pedido = new ENPedido();
        public double total = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            label1.Visible = false;
            
            // Recibo "cesta" y con ello muestro el pedido final.
            ENUsuario usuario = new ENUsuario();

            int nCesta1 = 0;
            if (Session["usuario"] != null)
            {
                usuario.emailUsuario = Session["usuario"].ToString();
                cesta.Usuario = usuario;
 
                if (cesta.ObtenerCestaDeUsuario(cesta))
                {
                    nCesta1 = cesta.NumCesta;
                }
            }

            HttpCookie cestaCookie = Request.Cookies["cesta"];
            int nPedido2 = cestaCookie != null ? Int32.Parse(cestaCookie.Value) : 0;

            if (nCesta1 > 0 && nPedido2 > 0 && nCesta1 != nPedido2)
            {
                ENCesta nC2 = new ENCesta();
                ENPedido nP2 = new ENPedido();
                nC2.NumCesta = nPedido2;
                nC2.ObtenerLineasCesta(nC2);
                nP2.readLinPed(nP2);
                for (int i = 0; i < nC2.Lineas.Count; i++)
                {
                    Response.Write("LN" + nC2.Lineas[i].Serie.nombreSerie);
                    ENLineaCesta lnx = new ENLineaCesta();
                    ENLineaPedido lnp = new ENLineaPedido();
                    lnx.Cesta = cesta;
                    lnx.TipoCompra = nC2.Lineas[i].TipoCompra;
                    lnx.Precio = nC2.Lineas[i].Precio;
                    lnx.Serie = nC2.Lineas[i].Serie;

                    lnp.Pedido = pedido;
                    if (!lnx.ObtenerLineaCesta(lnx))
                    {
                        Response.Write("agregada");
                        lnx.AgregarALineaCesta(lnx);
                        lnp.createLineaPedido(lnp);
                    }
                }
                HttpCookie cookie = new HttpCookie("cesta", "" + nCesta1);
                cookie.Expires = DateTime.Now.AddMonths(1);
                Response.Cookies.Add(cookie);
            }
            else if (nPedido2 > 0 && nCesta1 == 0)
            {
                cesta.NumCesta = nPedido2;
            }
            string nomSerie = Request.QueryString["nSerie"];
            if (nomSerie != null)
            {
                ENLineaCesta lineaBorrar = new ENLineaCesta();
                lineaBorrar.Cesta = cesta;
                ENSerie serieBorrar = new ENSerie();
                serieBorrar.nombreSerie = nomSerie;

                lineaBorrar.Serie = serieBorrar;


                lineaBorrar.EliminarDeLineaCesta(lineaBorrar);
            }
            if (nCesta1 > 0 || nPedido2 > 0)
            {
                cesta.ObtenerLineasCesta(cesta);
            }
            if (cesta.Lineas.Count > 0)
            {
                DataTable tabla = new DataTable();
                tabla.Columns.Add("nombre");
                tabla.Columns.Add("tipo");
                tabla.Columns.Add("precio");

                for (int i = 0; i < cesta.Lineas.Count; i++)
                {
                    DataRow row = tabla.NewRow();
                    row["nombre"] = cesta.Lineas[i].Serie.nombreSerie;
                    row["tipo"] = cesta.Lineas[i].TipoCompra;
                    row["precio"] = cesta.Lineas[i].Precio;
                    total += cesta.Lineas[i].Precio;
                    tabla.Rows.Add(row);
                }
                totalLabel.Text = "Total: " + total + "€";
                lineasPedido.DataSource = tabla;
                lineasPedido.DataBind();
            }
        }

        protected void BotonTramitarPedido_Click(object sender, EventArgs e)
        {

            List < ENSerie > serie = new List<ENSerie>();
            for (int i = 0; i < cesta.Lineas.Count; i++)
            {
                serie.Add(cesta.Lineas[i].Serie);
            }
            ENSerie serie1 = new ENSerie();
            ENUsuario usu = new ENUsuario();
            usu.emailUsuario = Session["usuario"].ToString();
            ENMisSeries misSeries = new ENMisSeries(serie1, usu, serie);
            misSeries.AgregarAMisSeries(misSeries);

            ENUsuario usuario = new ENUsuario();
            usuario.emailUsuario = Session["usuario"].ToString();
            usuario.readUsuario();
            try
            {
                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("seriesplus.es@gmail.com");
                msg.To.Add(Session["usuario"].ToString());
                msg.Subject = "Pedido SeriesPlus";
                msg.Body = "Pedido realizado con exito, gracias por confiar en nosotros";
                MailAddress ms = new MailAddress("seriesplus.es@gmail.com");
                msg.CC.Add(ms);
                SmtpClient sc = new SmtpClient("smtp.gmail.com", 587);
                sc.UseDefaultCredentials = false;
                sc.Credentials = new NetworkCredential("seriesplus.es@gmail.com", "seriesplus1234");
                sc.EnableSsl = true;
                sc.Send(msg);
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
            }

            //            

            ENLineaCesta lineas = new ENLineaCesta();
            lineas.Cesta = cesta;
            lineas.EliminarTodasLineaCesta(lineas);
            Response.Redirect("Biblioteca.aspx");
        }

        protected void BotonCancelarPedido_Click(object sender, EventArgs e)
        {
            ENLineaCesta lineas = new ENLineaCesta();
            lineas.Cesta = cesta;
            lineas.EliminarTodasLineaCesta(lineas);
            lineasPedido.DataSource = null;
            lineasPedido.DataBind();
            Response.Redirect("Biblioteca.aspx");
        }
    }
}