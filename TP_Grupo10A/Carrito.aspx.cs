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
        private DireccionNegocio direccionNegocio = new DireccionNegocio();
        private UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        private PedidoNegocio pedidoNegocio = new PedidoNegocio();
        private PedidoDetalleNegocio pedidoDetalleNegocio = new PedidoDetalleNegocio();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                /*accordionCarrito.Attributes["class"] = "accordion-item";
                accordionEntrega.Attributes["class"] = "accordion-item disabled";
                accordionPago.Attributes["class"] = "accordion-item disabled";
                direccionContainer.Visible = false;
                */
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

        ///////// MANEJO DE DESPLEGABLES (ACCORDEON) DE CARRITO ENTREGA PAGO ////////////
        // Manehjo de collapse para switchear los accordion de entrega/pago/carrito
        //con show se abre el acordeon y con collapse solo lo cierra, para que no se pueda acceder

        protected void btnConfirmarCarrito_Click(object sender, EventArgs e)
        {

            collapseCarrito.Attributes.Add("class", "collapse");
            collapseEntrega.Attributes.Add("class", "collapse show");
            cargarDirecciones();
        }

        protected void btnConfirmarEntrega_Click(object sender, EventArgs e)
        {
            collapseEntrega.Attributes.Add("class", "collapse");
            collapsePago.Attributes.Add("class", "collapse show");
        }

        protected void btnVolverCarrito_Click(object sender, EventArgs e)
        {
            collapseEntrega.Attributes.Add("class", "collapse");
            collapseCarrito.Attributes.Add("class", "collapse show");
        }

        protected void btnVolverEntrega_Click(object sender, EventArgs e)
        {
            collapsePago.Attributes.Add("class", "collapse");
            collapseEntrega.Attributes.Add("class", "collapse show");
            cargarDirecciones();
        }


        private void cargarDirecciones()
        {
            Usuarios usuarioLogueado = (Usuarios)Session["UsuarioLogueado"];

            if (usuarioLogueado != null)
            {

                int usuarioID = usuarioNegocio.BuscarUsuarioID(usuarioLogueado);
                List<Direcciones> direcciones = direccionNegocio.BuscarDireccionesPorUsuario(usuarioID);


                ddlDirecciones.DataSource = direcciones;
                ddlDirecciones.DataTextField = "DireccionCompleta";
                ddlDirecciones.DataValueField = "DireccionID";
                ddlDirecciones.DataBind();
                ddlDirecciones.Items.Insert(0, new ListItem("Seleccionar direccion..", ""));

            }
        }

        protected void rblEntrega_SelectedIndexChanged(object sender, EventArgs e)
        {
            direccionContainer.Visible = rblEntrega.SelectedValue == "domicilio";
            if (direccionContainer.Visible)
            {
                cargarDirecciones();
            }
        }

        protected void rblPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (rblPago.SelectedValue == "tarjeta")
            {
                tarjetaContainer.Visible = true;
            }
            else
            {
                tarjetaContainer.Visible = false;
            }
        }

        protected void btnConfirmarCompra_Click(object sender, EventArgs e)
        {
            try
            {
                if (rblPago.SelectedValue == "efectivo")
                {
                    

                    // Obtener los detalles del carrito
                    Usuarios usuarioLogueado = (Usuarios)Session["UsuarioLogueado"];
                    carrito = _carritoNegocio.ObtenerCarritoPorUsuario(usuarioLogueado);
                    List<CarritoDetalle> detallesCarrito = _carritoDetalleNegocio.VerCarritoDetalles(carrito);

                    //primer direccion cargada del cliente
                    Direcciones dire = direccionNegocio.BuscarDireccionPorUsuario(usuarioLogueado.UsuarioID);

                    pedidoNegocio.CrearCarritoVacio(usuarioLogueado.UsuarioID, dire);
                    int pedidoID = pedidoNegocio.ObtenerUltimoPedidoPorUsuario(usuarioLogueado.UsuarioID);
                    pedidoDetalleNegocio.GuardarDetallesPedido(detallesCarrito,pedidoID);

                    // Calcular el total del pedido
                    int totalPedido = detallesCarrito.Sum(detalle => (int)(detalle.Cantidad * detalle.PrecioUnitario));

                    // verificacion de seleccion de tipo de envio
                    // si es domicilio setea envio, si no sale por retiro
                    EstadoPedido estadoPedido = rblEntrega.SelectedValue == "domicilio"
                    ? EstadoPedido.Envio
                    : EstadoPedido.Retiro;

                    // Crear el pedido
                    bool pedidoCreado = pedidoNegocio.CrearPedido(
                        pedidoID,
                        usuarioLogueado,
                        dire,
                        Pago.Efectivo,
                        estadoPedido,
                        totalPedido                        
                    );

                    if (pedidoCreado)
                    {
                        Response.Redirect($"~/CompraExitosa.aspx?PedidoID={pedidoID}");
                    }
                    else
                    {
                        lblError.Text = "Hubo un error al procesar el pedido. Inténtelo nuevamente.";
                    }
                }
                else
                {
                    lblError.Text = "Método de pago no soportado en este flujo.";
                }

            }
            catch (Exception ex)
            {
                lblError.Text = "Ocurrió un error al procesar la compra: " + ex.Message;
            }
        }

    }
}

