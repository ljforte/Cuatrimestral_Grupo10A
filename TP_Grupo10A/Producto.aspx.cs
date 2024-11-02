using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Grupo10A
{
    public partial class Producto : System.Web.UI.Page
    {
        private int productosPorPagina = 9;
        private int paginaActual = 1;

        public List<Dominio.Productos> listaProductos;
        public List<Dominio.Categorias> listaCategorias;
        public List<Dominio.Marcas> listaMarcas;

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
                    CargarCategorias();
                    CargarMarcas();

                }
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
            ProductoNegocio negocio = new ProductoNegocio();
            listaProductos = negocio.ListarArticulos();

            /* Math ceiling redondea la division, si da 2.3, lo pasa a 3.. redonde hacia arriba
             para siempre tener una pagina aunque de menos de 10*/
            int totalPaginas = (int)Math.Ceiling((double)listaProductos.Count / productosPorPagina);


            var productosPagina = listaProductos
            .Skip((paginaActual - 1) * productosPorPagina)
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
            listaProductos = negocio.ListarArticulos(Categoria);

            /* Math ceiling redondea la division, si da 2.3, lo pasa a 3.. redonde hacia arriba
             para siempre tener una pagina aunque de menos de 10*/
            int totalPaginas = (int)Math.Ceiling((double)listaProductos.Count / productosPorPagina);


            var productosPagina = listaProductos
            .Skip((paginaActual - 1) * productosPorPagina)
            .Take(productosPorPagina)
            .ToList();


            RepeaterProductos.DataSource = productosPagina;
            RepeaterProductos.DataBind();

            // Actualizar la interfaz para mostrar botones de paginación si es necesario
            BtnSiguiente.Visible = paginaActual < totalPaginas;
            BtnAnterior.Visible = paginaActual > 1;

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
            paginaActual++;
            CargarProductos();
        }
    }
}