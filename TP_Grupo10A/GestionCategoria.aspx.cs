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
    public partial class GestionCategoria : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblDato.Visible = false;
            CategoriaNegocio negocio = new CategoriaNegocio();
           List< Categorias> categorias = new List<Categorias>();
            categorias = negocio.ListarCategorias();
            dgvCategoria.DataSource = categorias;
            dgvCategoria.DataBind();
        }

        protected void dgvCategoria_SelectIndexChanged(object sender, GridViewCommandEventArgs e)
        {
            List<Categorias> categorias = new List<Categorias>();
            CategoriaNegocio neg = new CategoriaNegocio();
            categorias = neg.ListarCategorias();
            //categorias. = dgvCategoria.SelectedDataKey.Value.ToString();
            //Response.Redirect($"EliminarCategoria.aspx?CategoriaID={categoriaID}");
           // neg.EliminarCat();
            
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    lblDato.Text = "Debe ingresar un nombre";
                    lblDato.Visible = true;
                    return;
                }
                else if (string.IsNullOrEmpty(txtDescripcion.Text)){
                    lblDato.Text = "Debe ingresar una descripcion";
                    lblDato.Visible = true;
                    return;
                }
                if (negocio.BuscarCat(txtNombre.Text))
                {
                    lblDato.Text = "Error, esa categoria ya existe";
                    lblDato.Visible=true;
                    return;
                }
                else
                {
                    negocio.AgregarCategoria(txtNombre.Text, txtDescripcion.Text);
                    lblDato.Text = "¡Categoria cargada con exito!";
                    lblDato.Visible = true;
                    Page_Load(sender, e);
                    return;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}