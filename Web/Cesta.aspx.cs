using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Schema;
using Library;

namespace Web
{

    public partial class Cesta : System.Web.UI.Page
    {

        public ENCesta cesta = new ENCesta();
        public double total = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            ENUsuario usuario = new ENUsuario();

            // Compruebo si hay cestas en la sesión
            int nCesta1 = 0;
            if (Session["usuario"] != null)
            {
                usuario.emailUsuario = Session["usuario"].ToString();
                cesta.Usuario = usuario;
                if (cesta.ObtenerCestaDeUsuario(cesta))
                    nCesta1 = cesta.NumCesta;
            }

            // También compruebo si hay cestas en las cookies
            HttpCookie cestaCookie = Request.Cookies["cesta"];
            int nCesta2 = cestaCookie != null && cestaCookie.Value != null ? Int32.Parse(cestaCookie.Value) : 0;

            // Si hay 2 cestas (cookies + sesion) y son diferentes, las fusiono en la de la sesión y la guardo también en la cookie
            if (nCesta1 > 0 && nCesta2 > 0 && nCesta1 != nCesta2)
            {
                ENCesta nC2 = new ENCesta();
                nC2.NumCesta = nCesta2;
                nC2.ObtenerLineasCesta(nC2);
                for (int i = 0; i < nC2.Lineas.Count; i++)
                {
                    Response.Write("LN" + nC2.Lineas[i].Serie.nombreSerie);
                    ENLineaCesta lnx = new ENLineaCesta();
                    lnx.Cesta = cesta;
                    lnx.TipoCompra = nC2.Lineas[i].TipoCompra;
                    lnx.Precio = nC2.Lineas[i].Precio;
                    lnx.Serie = nC2.Lineas[i].Serie;
                    if (!lnx.ObtenerLineaCesta(lnx))
                    {
                        Response.Write("agregada");
                        lnx.AgregarALineaCesta(lnx);
                    }
                }
                HttpCookie cookie = new HttpCookie("cesta", "" + nCesta1);
                cookie.Expires = DateTime.Now.AddMonths(1);
                Response.Cookies.Add(cookie);
            } // Si no hay cesta en la sesión y si en cookie la pongo la id
            else if (nCesta2 > 0 && nCesta1 == 0) {
                cesta.NumCesta = nCesta2;
            }

            // Si llega este parámetro es que hay que borrar la cesta
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

            // Si existe la cesta buscamos las líneas cesta y las guardamso en la lista lineas
            if(nCesta1 > 0 || nCesta2 > 0)
                cesta.ObtenerLineasCesta(cesta);

            // Comprobamos si hay líneas cesta
            if (cesta.Lineas.Count > 0)
            {
                labelCesta.Text = "Listado de series en tu cesta (" + cesta.Lineas.Count + ").";

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
                lineasCesta.DataSource = tabla;
                lineasCesta.DataBind();
            }
            else
            {
                labelCesta.Text = "Todavía no has agregado series.";
                BotonVaciarCesta.Visible = false;
                BotonTramitarPedido.Visible = false;
            }

        }

        protected void BotonVaciarCesta_Click(object sender, EventArgs e)
        {
            // Borro la cesta por completo
            ENLineaCesta lineas = new ENLineaCesta();
            lineas.Cesta = cesta;
            lineas.EliminarTodasLineaCesta(lineas);

            lineasCesta.DataSource = null;
            lineasCesta.DataBind();

            BotonVaciarCesta.Visible = false;
            BotonTramitarPedido.Visible = false;
            labelCesta.Text = "Has eliminado todos los items de tu cesta";
            totalLabel.Text = "";

        }

        protected void BotonTramitarPedido_Click(object sender, EventArgs e)
        {
            // Tramito la cesta para pagar, si no esta identificado lo mando a login
            Session["importeCesta"] = "" + "" + total;

            if (Session["usuario"] != null)
            {
                Response.Redirect("TramitarPedido.aspx?nCesta="+cesta.NumCesta+"&importe="+total);
            }
            else {
                Session["nCesta"] = "" + cesta.NumCesta;
                
                Response.Redirect("Inicio.aspx");
            }

        }
    }
}