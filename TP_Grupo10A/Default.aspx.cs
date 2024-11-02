using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Grupo10A
{
    public partial class _Default : Page
    {
        private int productosPorPagina = 9;
        private int paginaActual = 1;

        
        public List<Dominio.Categorias> listaCategorias;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                

                CargarCategorias();

            }
        }

        private void CargarCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
                listaCategorias = negocio.ListarCategorias();
            RepeaterCategorias.DataSource = listaCategorias;
            RepeaterCategorias.DataBind();
        }

    }
}