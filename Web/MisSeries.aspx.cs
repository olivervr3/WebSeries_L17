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
    public partial class MisSeries : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Muestro las series que el usuario ya ha adquirido
            // Si llega parámetro de una serie, la borro de mis series

            Session["usuario"] = "vicentcr99@gmail.com";

            ENUsuario usuario = new ENUsuario();
            usuario.emailUsuario = Session["usuario"].ToString();

            // Si llega este parámetro es que hay que borrar la serie de mis series
            string nomSerie = Request.QueryString["nSerie"];
            if (nomSerie != null)
            {
                ENSerie serieBorrar = new ENSerie();
                serieBorrar.nombreSerie = nomSerie;

                ENMisSeries msBorrar = new ENMisSeries();
                msBorrar.Usuario = usuario;
                msBorrar.Serie = serieBorrar;

                msBorrar.EliminarDeMisSeries(msBorrar);
            }

            ENMisSeries ms = new ENMisSeries();
            ms.Usuario = usuario;
            ms.ObtenerMisSeries(ms);

            if (ms.Series.Count > 0)
            {
                labelMisSeries.Text = "Listado de tus series (" + ms.Series.Count + ").";

                DataTable tabla = new DataTable();
                tabla.Columns.Add("nombre");
                tabla.Columns.Add("categoria");
                tabla.Columns.Add("imagen");
                tabla.Columns.Add("descripcion");
                tabla.Columns.Add("trailer");
                tabla.Columns.Add("temporadas");
                tabla.Columns.Add("precio");

                for (int i = 0; i < ms.Series.Count; i++)
                {
                    ENSerie miSerie = ms.Series[i];
                    miSerie.readSerie();

                    DataRow row = tabla.NewRow();
                    row["nombre"] = miSerie.nombreSerie;
                    row["categoria"] = miSerie.categoriaSerie;
                    row["imagen"] = miSerie.imagenSerie;
                    row["descripcion"] = miSerie.descripcionSerie;
                    row["trailer"] = miSerie.trailerSerie;
                    row["temporadas"] = miSerie.temporadasSerie;
                    row["precio"] = miSerie.precioSerie;
                    tabla.Rows.Add(row);

                }
                misSeries.DataSource = tabla;
                misSeries.DataBind();
            }
            else
            {
                labelMisSeries.Text = "Todavía no has agregado series.";
            }

        }
    }
}