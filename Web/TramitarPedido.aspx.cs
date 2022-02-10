using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web
{
    public partial class TramitarPedido : System.Web.UI.Page
    {
        public ENCesta cesta;
        public ENUsuario usuario;

        protected void Page_Load(object sender, EventArgs e)
        {
            // Si llega este parámetro es que hay que borrar la cesta
            string nCesta = Request.QueryString["nCesta"];

            if (nCesta != null)
            {
                cesta = new ENCesta();
                cesta.NumCesta = Int32.Parse(nCesta);

                usuario = new ENUsuario();
                usuario.emailUsuario = Session["usuario"].ToString();
                usuario.readUsuario();

                tarjetaLabel.Text = usuario.numTarjetaUsuario;
                totalLabel.Text = "Total: " + Session["importeCesta"].ToString() + " €";
            }
            else {
                // Si los datos no están bien lo mando a la cesta
                Response.Redirect("Cesta.aspx");
            }
        }

        protected void pagarBoton_Click(object sender, EventArgs e)
        {
            // compruebo que la tarjeta de crédito es correcta con el codigo de seguridad
            if (Page.IsValid) {

                ENUsuario ux = new ENUsuario();
                ux.emailUsuario = Session["usuario"].ToString();
                ux.numSeguridadUsuario = Int32.Parse(codigoTextBox.Text);

                // Guardo las series en mis series y lo envio a pedido para procesarlo
                if (ux.checkTarjeta(ux.numSeguridadUsuario))
                {
                    cesta.ObtenerCesta(cesta);
                    cesta.ObtenerLineasCesta(cesta);

                    for (int i = 0; i < cesta.Lineas.Count; i++)
                    {

                        ENSerie serie = new ENSerie();
                        serie.nombreSerie = cesta.Lineas[i].Serie.nombreSerie;

                        ENUsuario usuario = new ENUsuario();
                        usuario.emailUsuario = Session["usuario"].ToString();

                        ENMisSeries ms = new ENMisSeries();
                        ms.Serie = serie;
                        ms.Usuario = usuario;

                        ms.AgregarAMisSeries(ms);
                    }

                    Session["importeCesta"] = null;

                    HttpCookie cookie = new HttpCookie("cesta");
                    cookie.Expires = DateTime.Now.AddDays(-1);
                    Response.Cookies.Add(cookie);

                    Response.Redirect("Pedido.aspx?nCesta=" + cesta.NumCesta);
                }
                else {
                    codigoEstadoLabel.Text = "El número de seguridad es incorrecto";
                }
            }
        }
    }
}