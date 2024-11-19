using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;


namespace TP_Grupo10A
{
    public partial class Carrito : System.Web.UI.Page
    {
        private CarritoNegocio _carritoNegocio = new CarritoNegocio();
        private CarritoDetalleNegocio _carritoDetalleNegocio = new CarritoDetalleNegocio();
        private Dominio.Carrito carrito;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarCarrito();
            }
        }

        private void CargarCarrito()
        {
         

            Usuarios usuarioLogueado = (Usuarios)Session["UsuarioLogueado"];
            if (usuarioLogueado == null)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            carrito = _carritoNegocio.ObtenerCarritoPorUsuario(usuarioLogueado);


            if (carrito == null)
            {
                lblMensaje.Text = "Tu carrito está vacío.";
                rptCarrito.DataSource = null;
                rptCarrito.DataBind();
                return;
            }

            List<CarritoDetalle> detalles = _carritoDetalleNegocio.VerCarritoDetalles(carrito);
            if (detalles.Count == 0)
            {
                lblMensaje.Text = "Tu carrito está vacío.";
            }
            else
            {
                lblMensaje.Text = string.Empty; // Limpia el mensaje
            }

            rptCarrito.DataSource = detalles;
            rptCarrito.DataBind();
        }



        // NO ESTA FUNCIONANDO, debo verificar.
        protected void rptCarrito_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            if (e.CommandName == "EliminarProducto")
            {
                
                int carritoDetalleID = Convert.ToInt32(e.CommandArgument);

               
                CarritoDetalleNegocio carritoNegocio = new CarritoDetalleNegocio();
                bool resultado = carritoNegocio.EliminarCarritoDetalle(carritoDetalleID);
  
                if (resultado)
                {
                    lblMensaje.Text = "Producto eliminado correctamente.";
                    rptCarrito.DataBind(); 
                }
                else
                {
                    lblMensaje.Text = "Hubo un error al eliminar el producto del carrito.";
                }
            }
        }
    }

}
