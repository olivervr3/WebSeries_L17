using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web
{
    public partial class Trailer : System.Web.UI.Page
    {
        string serie;
        protected void Page_Load(object sender, EventArgs e)
        {
            serie = Session["nombreSerieYT"].ToString();
            if (serie == null)
            {
                Response.Redirect("Biblioteca.aspx");
            }
            else
            {
                ENSerie en = new ENSerie();
                ENSerie[] listaEn = en.SacarSeries();
                en.nombreSerie = serie;
                en.readSerie();
                youtube.Src = "https://www.youtube.com/embed/" + en.trailerSerie + "?autoplay=1";
            }
        }

        protected void Button_Back(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("InfoSerie.aspx?nSerie=" + serie);
        }
    }
}