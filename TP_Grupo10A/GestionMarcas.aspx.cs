using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Grupo10A
{
    public partial class GestionMarcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MarcasNegocio negocio = new MarcasNegocio();

            try
            {
                negocio.AgregarMarca(txtNombre.Text);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
        }

    
    
    }
}