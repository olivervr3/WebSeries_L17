using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web
{
    public partial class CrearSerie : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CrearButton_Click(object sender, EventArgs e)
        {
            if (Page.IsValid) {
                ENSerie serie = new ENSerie();
                serie.nombreSerie = TextBoxNombre.Text;
                serie.categoriaSerie = TextBoxCategoria.Text;
                serie.imagenSerie = TextBoxImagen.Text;
                serie.descripcionSerie = TextBoxDescripcion.Text;
                serie.trailerSerie = TextBoxTrailer.Text;
                serie.precioSerie = Int32.Parse(TextBoxPrecio.Text);
                serie.temporadasSerie = Int32.Parse(TextBoxTemporadas.Text);
                serie.readSerie();

                if (serie.createSerie()) // serie.createSerie()
                {
                    Response.Redirect("InfoSerie.aspx?nSerie=" + serie.nombreSerie);
                }
                else {
                    CrearSerieLabel.Text = "Error inesperado. Vuelve a intentarlo.";
                }
            }
        }
    }
}