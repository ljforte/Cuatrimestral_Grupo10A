using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Grupo10A
{
    public partial class Producto : System.Web.UI.Page
    {
        public List<Dominio.Productos> listaProductos;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarProductos();
            }
        }

        private void CargarProductos()
        {
            ProductoNegocio negocio = new ProductoNegocio();
            listaProductos = negocio.ListarArticulos();
            RepeaterProductos.DataSource = listaProductos;
            RepeaterProductos.DataBind();

        }
    }
}