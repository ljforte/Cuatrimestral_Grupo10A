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
    public partial class DetallePedido : System.Web.UI.Page
    {
         public AccesoDatos datos = new AccesoDatos();
       public DetallePedidoNegocio detallePedidoNegocio = new DetallePedidoNegocio();
     //   public DetallePedido detallePedido = new DetallePedido();
        public PedidoNegocio pedidoNegocio = new PedidoNegocio();
        public Pedidos Pedido = new Pedidos();

        protected void Page_Load(object sender, EventArgs e)
        {
            string PedidoID = Request.QueryString["PedidoID"];
            Pedido = pedidoNegocio.ListarPedidoPorID(PedidoID);
            dgvProductos.DataSource = detallePedidoNegocio.ListarPedidoDetalle(PedidoID);

            dgvProductos.DataBind();


        lblEstadoPedido.Text = Pedido.Estado;
            lblNombreClienteCampo.Text = Pedido.NombreCliente;
            lblFechaCampo.Text = Pedido.FechaPedido.ToString();
        }
    }
}