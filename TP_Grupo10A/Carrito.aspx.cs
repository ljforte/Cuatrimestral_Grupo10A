using System;
using System.Collections.Generic;
using System.Linq;
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
            // verificacion usuario logeado
            Usuarios usuarioLogueado = (Usuarios)Session["UsuarioLogueado"];

            if (usuarioLogueado == null)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }
            //cargo carrito segun usuario

            carrito = _carritoNegocio.ObtenerCarritoPorUsuario(usuarioLogueado);


            if (carrito == null)
            {

                Response.Redirect("CarritoNull.aspx");
                return;
            }

            List<CarritoDetalle> detalles = _carritoDetalleNegocio.VerCarritoDetalles(carrito);
            if (detalles == null || detalles.Count == 0)
            {
                Response.Redirect("CarritoNull.aspx");
                return;
            }
            // Si el carrito tiene productos

            rptCarrito.DataSource = detalles;
            rptCarrito.DataBind();
        }



        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                // Obtener el CarritoDetalleID desde CommandArgument
                int carritoDetalleID = Convert.ToInt32(e.CommandArgument);
                CarritoDetalleNegocio negocio = new CarritoDetalleNegocio();
                negocio.EliminarDetalle(carritoDetalleID);
                CargarCarrito();
            }
        }

    }

}
