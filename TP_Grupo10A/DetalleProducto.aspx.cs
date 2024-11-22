using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace TP_Grupo10A
{
    public partial class DetalleProducto : System.Web.UI.Page
    {
        private ProductoNegocio _productoNeg;
        private CarritoDetalleNegocio _detalleNeg;
        
        private Carrito _carrito;
        private CarritoDetalle _carritoDetalle;
        private Productos _producto;
        public DetalleProducto() {
            _productoNeg = new ProductoNegocio();
            _detalleNeg = new CarritoDetalleNegocio();
            
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener el ID del producto desde el parámetro de consulta
                string productoID = Request.QueryString["productoID"];

                if (!string.IsNullOrEmpty(productoID))
                {
                    // Llamar a un método para obtener los detalles del producto

                    _producto = _productoNeg.ListarArticulosPorID(productoID)[0];

                    // Mostrar los detalles del producto en la interfaz
                    lblNombre.Text= _producto.Nombre;
                    lblDescripcion.Text = _producto.Descripcion;
                    lblMarcas.Text = _producto.MarcaID.Nombre;
                    lblPrecio.Text = _producto.Precio.ToString();
                    lblStock.Text=_producto.stock.ToString();

                    rptImagenes.DataSource = _producto.ListImagenes;
                    rptImagenes.DataBind();
                    // Agregar más campos según sea necesario
                }
            }
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {

        }

        protected void btnAgregarCarrito_Click(object sender, EventArgs e)
        {
            try
            {

                _carritoDetalle = new CarritoDetalle();

                string productoID = Request.QueryString["productoID"];
                _producto = _productoNeg.ListarArticulosPorID(productoID)[0];

                _carritoDetalle.ProductoID = _producto.ProductoID;
                _carritoDetalle.Cantidad = int.Parse(txtCantidad.Text);
                _carritoDetalle.PrecioUnitario = _producto.Precio;

                //_carrito = new Carrito();
                //_carritoDetalle.CarritoID = _carrito.CarritoID;

                _detalleNeg.AgregarDetalle(_carritoDetalle);
                Console.Write(_carritoDetalle);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
