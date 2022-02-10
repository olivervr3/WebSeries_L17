using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Library;

namespace Web
{
    public partial class ListarUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Esto iría en el CAD
            ENUsuario usu = new ENUsuario();
            DataSet d = usu.SacarUsuarios();

            GridViewUsuarios.DataSource = d;
            GridViewUsuarios.DataBind();

        }

        protected void GridViewUsuarios_PageIndexChanging(object sender, GridViewPageEventArgs e) {

            ENUsuario usu = new ENUsuario();
            DataSet d = usu.SacarUsuarios();

            GridViewUsuarios.PageIndex = e.NewPageIndex;
            GridViewUsuarios.DataSource = d;
            GridViewUsuarios.DataBind();


        }

        protected void GridViewUsuarios_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["usuariomod"] = GridViewUsuarios.SelectedRow.Cells[5].Text;
            Response.Redirect("ModificarUsuario.aspx");
        }
    }
}