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
    public partial class misPedidos : System.Web.UI.Page
    {
        /*
        protected void Page_Load(object sender, EventArgs e)
        {
            ENPedido pedido = new ENPedido();
            ENUsuario usuario = new ENUsuario();
            usuario.emailUsuario = Session["usuario"].ToString();

            ENPedido[] listaEn;

            DataTable tabla = new DataTable();
            tabla.Columns.Add("fecha");
            tabla.Columns.Add("precio");

            for (int i = 0; i < listaEn.Length; i++)
            {
                DataRow row = tabla.NewRow();
                row["fecha"] = listaEn[i].fechaPedido;
                row["precio"] = listaEn[i].precioTotalPedido;
                tabla.Rows.Add(row);
            }
            ListProducts.DataSource = tabla;
            ListProducts.DataBind();
        }
        */
    }
}