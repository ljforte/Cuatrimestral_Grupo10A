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
    public partial class DetalleProducto : System.Web.UI.Page
    {
        ProductoNegocio negocio = new ProductoNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Obtener el ID del producto desde el parámetro de consulta
                string productoID = Request.QueryString["productoID"];

                if (!string.IsNullOrEmpty(productoID))
                {
                    // Llamar a un método para obtener los detalles del producto
                    
                    Productos producto = negocio.ListarArticulosPorID(productoID)[0];

                    // Mostrar los detalles del producto en la interfaz
                    txtNombre.Text= producto.Nombre;
                    txtDescripcion.Text = producto.Descripcion;
                    txtMarcas.Text = producto.MarcaID.Nombre;
                    txtPrecio.Text = producto.Precio.ToString();
                    txtStock.Text=producto.stock.ToString();

                    rptImagenes.DataSource = producto.ListImagenes;
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

        }
    }
}