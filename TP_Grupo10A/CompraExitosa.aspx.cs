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
    public partial class CompraExitosa : System.Web.UI.Page
    {
        private PedidoNegocio negocio = new PedidoNegocio();
        private PedidoDetalleNegocio pedidoDetalleNegocio = new PedidoDetalleNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {             
                if (Request.QueryString["PedidoID"] != null)
                {
                    int pedidoID = Convert.ToInt32(Request.QueryString["PedidoID"]); 
                    CargarDatosPedido(pedidoID);
                }
            }
        }

        private void CargarDatosPedido(int pedidoID)
        {
            try
            {
                Pedidos pedido = negocio.ObtenerPedidoPorID(pedidoID);
                   
                lblNombreUsuario.Text = $"{pedido.Usuario.Nombre} {pedido.Usuario.Apellido}";
                lblDireccionCompleta.Text = $"{pedido.Direcciones.Calle}, {pedido.Direcciones.Ciudad}, {pedido.Direcciones.CodigoPostal} - {pedido.Direcciones.Pais}";
                lblEstadoPedido.Text = pedido.Estado.ToString();
                lblTotalPedido.Text = pedido.Total.ToString("F2");

                List<PedidosDetalle> detalles = pedidoDetalleNegocio.ListarDetallePorPedidoID(pedidoID);

                if (detalles != null && detalles.Count > 0)
                {
                    rptDetallesPedido.DataSource = detalles;
                    rptDetallesPedido.DataBind();
                }
                else
                {
                    rptDetallesPedido.Visible = false;
                    Response.Write("No hay detalles para este pedido.");
                }
            }
            catch (Exception ex)
            {               
                Response.Write($"Error al cargar los datos del pedido: {ex.Message}");
            }
        }
    }
}
