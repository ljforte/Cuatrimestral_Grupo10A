using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Grupo10A
{
    public partial class GestionPedidos : System.Web.UI.Page
    {
        public EstadoNegocio Negocio = new EstadoNegocio();
        public List<Estado> estados = new List<Estado>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlEstadosPedido.Items.Add(new ListItem("Estado (Sin especificar)", "0"));

                List<Estado> estados = Negocio.ListarEstados();
                for (int i = 0; i < estados.Count; i++)
                {
                    ddlEstadosPedido.Items.Add(new ListItem(estados[i].Descripcion, estados[i].Id.ToString()));
                }
            }



        }





    }
}