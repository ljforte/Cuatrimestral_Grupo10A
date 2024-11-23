using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TP_Grupo10A
{
    public partial class GestionProductos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ProductoNegocio negocio = new ProductoNegocio();
                dgvListarProductosSP.DataSource = negocio.ListarArticulosConSP();
                dgvListarProductosSP.DataBind();
            }
        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {

        }

        protected void dgvProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string ID = dgvListarProductosSP.SelectedDataKey.Value.ToString();
            Response.Redirect("AltaProducto.aspx?id=" + ID);
        }

        protected void dgvProductos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvListarProductosSP.PageIndex = e.NewPageIndex;
            dgvListarProductosSP.DataBind();
        }
    }
}