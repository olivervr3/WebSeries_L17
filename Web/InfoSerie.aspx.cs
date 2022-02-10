using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web
{
    public partial class InfoSerie : System.Web.UI.Page
    {
        string trailer;
        ENSerie getSerie;
        ENUsuario getUsuario;
        ENCesta getCesta;
        string nomSerie;
        protected void Page_Load(object sender, EventArgs e)
        {
            nomSerie = Request.QueryString["nSerie"];
            if (nomSerie == null) {
                Response.Redirect("Biblioteca.aspx");
            }
            else {
                ENSerie en = new ENSerie();
                en.nombreSerie = nomSerie;
                title.Text = en.nombreSerie.ToUpper();
                en.readSerie();
                desc.Text = en.descripcionSerie;
                temporadas.Text = en.temporadasSerie.ToString();
                trailer = en.trailerSerie;
                Image1.ImageUrl = "../imagenes series/" + en.imagenSerie;
                contID.Style["background-image"] = "../wallpaper/" + en.imagenSerie;
                contID.Style["background-size"] = "cover";
                getSerie = en;
                Session.Add("nombreSerieYT", en.nombreSerie);

                if (Session["usuario"] != null){
                    ENUsuario usu = new ENUsuario();
                    usu.emailUsuario = Session["usuario"].ToString();
                    usu.readUsuario();
                    getUsuario = usu;
                }else{
                    getUsuario = null;
                }

                ///////////
                // Obtener cesta
                bool existeCesta = false;
                ENCesta cesta = new ENCesta();

                HttpCookie cestaCookie;
                cestaCookie = Request.Cookies["cesta"];

                // Si el usuario está identificado, buscamos su cesta en la base de datos
                if (Session["usuario"] != null)
                {
                    ENUsuario usuario = new ENUsuario();
                    usuario.emailUsuario = Session["usuario"].ToString();
                    cesta.Usuario = usuario;
                    if (cesta.ObtenerCestaDeUsuario(cesta))
                        existeCesta = true;
                }

                // Si sigue sin existir la cesta la buscamos en las cokies esté identificado o no
                if (!existeCesta && cestaCookie != null && cestaCookie.Value != null)
                {
                    cesta.NumCesta = Int32.Parse(cestaCookie.Value);
                    if (cesta.ObtenerCesta(cesta))
                        existeCesta = true;
                }

                if (!existeCesta)
                {
                    cesta.CrearCesta(cesta);
                    
                    cestaCookie = new HttpCookie("cesta", "" + cesta.NumCesta);
                    cestaCookie.Expires = DateTime.Now.AddMonths(1);
                    Response.Cookies.Add(cestaCookie);
                }
                ///////////
                getCesta = cesta;

                //Oculto los botones para no repetir series
                ENMisSeries ms = new ENMisSeries();
                ENLineaCesta ln = new ENLineaCesta();
                ms.Serie = getSerie;
                if (getUsuario != null)
                {
                    ms.Usuario = getUsuario;
                    if (ms.EstaENMisSeries(ms) || (getCesta.NumCesta > 0 && ln.ExisteSerieEnCestaOMisSeries(getCesta.NumCesta, getSerie.nombreSerie, getUsuario.emailUsuario)))
                    {
                        Button2.Visible = false;
                    }
                }
                else 
                {
                    if ((getCesta.NumCesta > 0 && ln.ExisteSerieEnCestaOMisSeries(getCesta.NumCesta, getSerie.nombreSerie, null)))
                    {
                        Button2.Visible = false;
                    }
                }
                if (getUsuario == null)
                {
                    Button3.Visible = false;
                }
                /*else
                {
                    ENSeriesPendientes ensp = new ENSeriesPendientes();
                    ensp.usuarioPendiente = getUsuario.IDUsuario();
                    if (ensp.usuarioTienePendientes(getSerie.IDSerie())) 
                    {
                        Button3.Visible = false;
                    }
                }*/
                Image1.AlternateText = "Carátula de " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nomSerie);
                Button2.ToolTip = "Añadir " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nomSerie) + " a la cesta";
                Button3.ToolTip = "Añadir " + System.Globalization.CultureInfo.CurrentCulture.TextInfo.ToTitleCase(nomSerie) + " a la lista de series pendientes";
            }
            
            
        }
        protected void Button_TipoCompra(object sender, EventArgs e)
        {
            double precio = getSerie.precioSerie;
            if (cBL1.SelectedValue == "2")
            {
                precio = precio - (precio * 0.7);
                Session["tipocompra"] = "alquiler";
                Session["precioNuevo"] = precio;
                mensaje.Text = "";
            }
            else if (cBL1.SelectedValue == "1")
            {
                Session.Add("tipocompra", "compra");
                Session.Add("precioNuevo", precio);
                mensaje.Text = "";
            }
            else 
            {
                mensaje.Text = "Seleccione una opción en TIPO DE COMPRA";
            }
            pvp.Text = precio.ToString();
        }
        protected void Button_trailer(object sender, EventArgs e)
        {
            Response.Redirect("Trailer.aspx");
        }
        protected void Button_Cesta(object sender, EventArgs e)
        {
            if (cBL1.SelectedValue != "1" && cBL1.SelectedValue != "2") 
            {
                mensaje.Text = "Confirma el TIPO DE COMPRA";
            } 
            else 
            {
                ENLineaCesta linea = new ENLineaCesta();
                linea.Cesta = getCesta;
                linea.Serie = getSerie;
                linea.TipoCompra = (string)Session["tipocompra"];
                double dPVP = Convert.ToDouble(Session["precioNuevo"]);
                
                linea.Precio = dPVP;
                linea.AgregarALineaCesta(linea);
                mensaje.Text = "";
            }
        }
        protected void Button_Pendientes(object sender, EventArgs e)
        {   
            ENSeriesPendientes en = new ENSeriesPendientes();
            en.seriePendiente = getSerie.IDSerie();
            en.usuarioPendiente = getUsuario.IDUsuario();
            en.createPendientes();
            mensaje.Text = "";

        }

        protected void Button_Facebook(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("https://www.facebook.com/sharer/sharer.php?u=https%3A//localhost%3A44366/InfoSerie.aspx?nSerie=" + nomSerie);
        }

        protected void Button_Twitter(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("https://twitter.com/intent/tweet?text=https%3A//localhost%3A44366/InfoSerie.aspx?nSerie=" + nomSerie);
        }
        protected void Button_Back(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Biblioteca.aspx");
        }
    }
}