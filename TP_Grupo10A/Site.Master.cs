
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Grupo10A
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }


        protected void btnRegistro_Click(object sender, EventArgs e)
        {

        Response.Redirect("Registro.aspx", false);
        }
        protected void btnSubmitLogin_Click(object sender, EventArgs e)
        {

        }

        protected void btnCarrito_Click(object sender, EventArgs e)
        {

        }
    }
}