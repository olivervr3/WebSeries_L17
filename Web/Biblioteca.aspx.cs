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

namespace Web
{
    public partial class Biblioteca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            ENSerie en = new ENSerie();

            ENSerie[] listaEn = en.SacarSeries();
            DataTable tabla = new DataTable();
            tabla.Columns.Add("imagen");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("categoria");
            tabla.Columns.Add("descripcion");
            tabla.Columns.Add("trailer");
            tabla.Columns.Add("temporadas");
            tabla.Columns.Add("precio");

            for (int i = 0; i < listaEn.Length; i++)
            {
                DataRow row = tabla.NewRow();
                row["imagen"] = listaEn[i].imagenSerie;
                row["nombre"] = listaEn[i].nombreSerie;
                row["categoria"] = listaEn[i].categoriaSerie;
                row["descripcion"] = listaEn[i].descripcionSerie;
                row["trailer"] = listaEn[i].trailerSerie;
                row["temporadas"] = listaEn[i].temporadasSerie;
                row["precio"] = listaEn[i].precioSerie;
                tabla.Rows.Add(row);
            }
            ListProducts.DataSource = tabla;
            ListProducts.DataBind();
        }

        /*protected void Button1_Click(object sender, EventArgs e)
        {
            Application.Remove("serie");
            Application.Add("serie", ("nombre"));
            Response.Redirect("infoSerie.aspx");
        }*/

        protected void Button2_Click(object sender, EventArgs e)
        {
            ENSerie en = new ENSerie();

            ENSerie[] listaEn = en.SacarSeries();
            DataTable tabla = new DataTable();
            tabla.Columns.Add("imagen");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("categoria");
            tabla.Columns.Add("descripcion");
            tabla.Columns.Add("trailer");
            tabla.Columns.Add("temporadas");
            tabla.Columns.Add("precio");

            for (int i = 0; i < listaEn.Length; i++)
            {
                DataRow row = tabla.NewRow();
                if(listaEn[i].nombreSerie == TextBox1.Text)
                {
                    row["imagen"] = listaEn[i].imagenSerie;
                    row["nombre"] = listaEn[i].nombreSerie;
                    row["categoria"] = listaEn[i].categoriaSerie;
                    row["descripcion"] = listaEn[i].descripcionSerie;
                    row["trailer"] = listaEn[i].trailerSerie;
                    row["temporadas"] = listaEn[i].temporadasSerie;
                    row["precio"] = listaEn[i].precioSerie;
                    tabla.Rows.Add(row);
                }
            }
            ListProducts.DataSource = tabla;
            ListProducts.DataBind();
        }

        protected void Button3_Click(object sender, EventArgs e)
        {
            string cat = DropDownList1.SelectedValue;
            ENSerie en = new ENSerie();

            ENSerie[] listaEn = en.SacarSeriesPorCategoria(cat);
            DataTable tabla = new DataTable();
            tabla.Columns.Add("imagen");
            tabla.Columns.Add("nombre");
            tabla.Columns.Add("categoria");
            tabla.Columns.Add("descripcion");
            tabla.Columns.Add("trailer");
            tabla.Columns.Add("temporadas");
            tabla.Columns.Add("precio");

            for (int i = 0; i < listaEn.Length; i++)
            {
                DataRow row = tabla.NewRow();
                row["imagen"] = listaEn[i].imagenSerie;
                row["nombre"] = listaEn[i].nombreSerie;
                row["categoria"] = listaEn[i].categoriaSerie;
                row["descripcion"] = listaEn[i].descripcionSerie;
                row["trailer"] = listaEn[i].trailerSerie;
                row["temporadas"] = listaEn[i].temporadasSerie;
                row["precio"] = listaEn[i].precioSerie;
                tabla.Rows.Add(row);
            }
            ListProducts.DataSource = tabla;
            ListProducts.DataBind();
        }
    }
}