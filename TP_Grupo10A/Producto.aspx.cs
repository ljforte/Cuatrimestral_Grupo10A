using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace TP_Grupo10A
{
    public partial class Producto : System.Web.UI.Page
    {
        private int productosPorPagina = 11;
        private int paginaActual = 1;

        public int cantidadProducto = 0;
        public List<Productos> listaProductos;
        public List<Marcas> listaMarcas;
        public List<Categorias> listaCategorias;
        private Carrito _carrito;
        private CarritoDetalleNegocio _carritoDetalle = new CarritoDetalleNegocio();
        private Productos _producto;
        private CarritoNegocio _carritoNegocio = new CarritoNegocio();

        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Categoria = Request.QueryString["CATEGORIA"];

                if (!string.IsNullOrEmpty(Categoria))
                {
                    CargarProductosPorCategoria(Categoria);
                }
                else
                {
                    CargarProductos();
                }
                CargarCategorias();
                CargarMarcas();
            }
        }

        private void CargarCategorias()
        {
            CategoriaNegocio negocio = new CategoriaNegocio();
            listaCategorias = negocio.ListarCategorias();
            RepeaterCategorias.DataSource = listaCategorias;
            RepeaterCategorias.DataBind();
        }

        private void CargarMarcas()
        {
            MarcasNegocio negocio = new MarcasNegocio();
            listaMarcas = negocio.ListarMarcas ();
            RepeaterMarcas.DataSource = listaMarcas;
            RepeaterMarcas.DataBind();
        }

        // Cambie el metodo cargarProductos para que el repeater cargue solo los productos que le indiquemos
        // por pagina. La obtencion de la lista es la misma pero luego calculo el total de paginas.
        // Los botones siguiente y anterior estan siempre pero se juega ocultando y dando vista
        private void CargarProductos()
        {
            try
            {
                ProductoNegocio negocio = new ProductoNegocio();
                listaProductos = negocio.ListarArticulos();

                Paginacion();
            }
            catch (Exception ex)
            {
                // Manejar la excepción (por ejemplo, registrarla y mostrar un mensaje amigable)
                Console.WriteLine("Ocurrió un error: " + ex.Message);
            }
        }

        private void Paginacion()
        {
            ; // Ejemplo de constante para productos por página
            int totalPaginas = (int)Math.Ceiling((double)listaProductos.Count / productosPorPagina);
            // Asegurarse de que paginaActual no exceda totalPaginas
            if (paginaActual > totalPaginas)
            {
                paginaActual = totalPaginas;
            }
            var productosPagina = listaProductos
                .Skip((paginaActual-1) * productosPorPagina)
                .Take(productosPorPagina)
                .ToList();

            RepeaterProductos.DataSource = productosPagina;
            RepeaterProductos.DataBind();

            // Actualizar la interfaz para mostrar botones de paginación si es necesario
            BtnSiguiente.Visible = paginaActual < totalPaginas;
            BtnAnterior.Visible = paginaActual > 1;
        }

        private void CargarProductosPorCategoria(string Categoria)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            listaProductos = negocio.ListarArticulosPorCategoria(Categoria);

            Paginacion();

        }

        protected void BtnAnterior_Click(object sender, EventArgs e)
        {
            if (paginaActual > 1)
            {
                paginaActual--;
                CargarProductos();
            }
        }

        protected void BtnSiguiente_Click(object sender, EventArgs e)
        {
            ProductoNegocio negocio = new ProductoNegocio();
            int totalPaginas = (int)Math.Ceiling((double)negocio.ListarArticulos().Count / productosPorPagina);

            if (paginaActual <= totalPaginas)
            {
                paginaActual++;
                CargarProductos();
            }

        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            // Obtener el ID del producto desde el CommandArgument del botón
            string productoID = ((Button)sender).CommandArgument;

            // Redirigir a la página de detalles del producto con el ID como parámetro de consulta
            Response.Redirect($"DetalleProducto.aspx?productoID={productoID}");

        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Button btnAgregar = (Button)sender;
            RepeaterItem item = (RepeaterItem)btnAgregar.NamingContainer;
            int productoID = int.Parse(((Label)item.FindControl("lblProductoID")).Text);
            float precioUnitario = float.Parse(((Label)item.FindControl("lblPrecio")).Text);
            TextBox txtCantidad = (TextBox)item.FindControl("TxtCantidad");
            int cantidad = int.Parse(txtCantidad.Text);


            if (Session["UsuarioLogueado"] == null || ((Usuarios)Session["UsuarioLogueado"]).Tipo == TipoUsuario.Admin)
            {
                Response.Redirect("~/Login.aspx");
                return;
            }

            Usuarios usuarioLogueado = (Usuarios)Session["UsuarioLogueado"];
            if (usuarioLogueado != null)
            {
                Negocio.CarritoNegocio carritoNegocio = new CarritoNegocio();
                Dominio.Carrito carrito = carritoNegocio.ObtenerCarritoPorUsuario(usuarioLogueado);

                if (carrito != null)
                {
                    Negocio.CarritoDetalleNegocio detalleNegocio = new CarritoDetalleNegocio();
                    bool detalleAgregado = detalleNegocio.AgregarDetalle(carrito, productoID, cantidad, precioUnitario);

                    if (detalleAgregado)
                    {
                      
                        Response.Redirect(Request.RawUrl); // Vuelve a cargar la URL actual
                    }
                }
                else
                {
                    _carritoDetalle.AgregarDetalle(_carritoNegocio.ObtenerCarritoPorUsuario(usuarioLogueado), productoID, cantidad, precioUnitario);
                };
            }
        }

        protected void btnDecrementar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            TextBox txtCantidad = (TextBox)item.FindControl("TxtCantidad");

            int cantidad = int.Parse(txtCantidad.Text);
            if (cantidad > 1)
            {
                cantidad--;
                txtCantidad.Text = cantidad.ToString();
            }
        }

        protected void btnIncrementar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            RepeaterItem item = (RepeaterItem)btn.NamingContainer;
            TextBox txtCantidad = (TextBox)item.FindControl("TxtCantidad");

            int cantidad = int.Parse(txtCantidad.Text);
            cantidad++;
            txtCantidad.Text = cantidad.ToString();
        }
    }
}