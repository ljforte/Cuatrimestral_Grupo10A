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
    public partial class AltaProducto : System.Web.UI.Page
    {
        private CategoriaNegocio Categoria = new CategoriaNegocio();
        private MarcasNegocio Marcas = new MarcasNegocio();
        private ProductoNegocio Producto = new ProductoNegocio();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // p DropDownList
                CargarCategorias();
                CargarMarcas();
            }

            if (Request.QueryString["ID"] != null)
            {
                List<Productos> lista = Producto.ListarArticulosPorID(Request.QueryString["ID"]);
                Productos seleccionado = lista[0];

                txtNombre.Text = seleccionado.Nombre;
                txtDescripcion.Text = seleccionado.Descripcion;
                txtStock.Text = seleccionado.stock.ToString();
                txtPrecio.Text = seleccionado.Precio.ToString();
                ddlCategorias.SelectedValue = seleccionado.CategoriaID.Nombre;
                ddlMarca.SelectedValue = seleccionado.MarcaID.Nombre;

            }
        }

        private void CargarMarcas()
        {
            var marcas = Marcas.ListarMarcas();
            ddlMarca.DataSource = marcas;
            ddlMarca.DataTextField = "Nombre";
            ddlMarca.DataBind();
            ddlMarca.Items.Insert(0, new ListItem("Seleccionar..", ""));

        }

        private void CargarCategorias()
        {
            var categorias = Categoria.ListarCategorias();
            ddlCategorias.DataSource = categorias;
            ddlCategorias.DataTextField = "Nombre"; 
            ddlCategorias.DataBind();
            ddlCategorias.Items.Insert(0, new ListItem("Seleccionar..", ""));
        }

        protected void btnAltaProducto_Click(object sender, EventArgs e)
        {
            
            bool Estado = checkBoxIsActive.Checked;
           
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtDescripcion.Text))
            {
                return;
            }


            // Con Try parse validamos si esta nullo el txt, si no esta nulo parsea el txt y lo asigna a la variable
            float precio;
            if (!float.TryParse(txtPrecio.Text, out precio) || precio <= 0)
            {
                return;
            }

            int stock;
            if (!int.TryParse(txtStock.Text, out stock) || stock < 0)
            {
                return;
            }

            try
            {
                if (Request.QueryString["ID"] != null)
                {
                    int ProductoID = int.Parse(Request.QueryString["ID"]);
                    Producto.Modificar(
                    txtNombre.Text,
                    ddlMarca.Text,
                    precio,
                    stock,
                    txtDescripcion.Text,
                    ddlCategorias.Text,
                    Estado,
                    ProductoID);
                    Response.Redirect("GestionProductos.aspx");
                }
                else
                {
                    Producto.AltaProducto(
                        txtNombre.Text,
                        ddlMarca.Text,
                        precio,
                        stock,
                        txtDescripcion.Text,
                        ddlCategorias.Text,
                        Estado
                        );
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionProductos.aspx");
        }
    }
}