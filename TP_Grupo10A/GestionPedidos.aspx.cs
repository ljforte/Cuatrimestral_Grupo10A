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
        public PedidoNegocio NegocioPedido = new PedidoNegocio();
        public List<Estado> estados = new List<Estado>();
        public List<Pedidos> Pedidos = new List<Pedidos>();
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

            dgvPedidos.DataSource = NegocioPedido.ListarPedidos();
            dgvPedidos.DataBind();
        }


        protected void dgvPedidos_SelectedIndexChanged(object sender, EventArgs e)
        {

            int Id = int.Parse(dgvPedidos.SelectedDataKey.Value.ToString());

            Response.Redirect("DetallePedido.aspx?id=" + Id, false);

        }


    }
}