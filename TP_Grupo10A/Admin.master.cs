using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Grupo10A
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear(); 
            Response.Redirect("Login.aspx");
        }

        protected void btnInicio_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx", false);
        }

        protected void btnProductos_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionProductos.aspx");
        }

        protected void btnMarcas_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionMarcas.aspx");
        }

        protected void btnCategorias_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionCategoria.aspx");
        }

        protected void btnPedidos_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionPedidos.aspx");
        }
    }
}