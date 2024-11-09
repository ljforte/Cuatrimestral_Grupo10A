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
        public bool ConfirmarEliminacion { get; set; }
        public int Id = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            CategoriaNegocio negocio = new CategoriaNegocio();
            List<Categorias> categorias = new List<Categorias>();
            categorias = negocio.ListarCategorias();
            dgvCategoria.DataSource = categorias;
            dgvCategoria.DataBind();
            ConfirmarEliminacion = false;
            btnConfirmarEliminacion.Visible = false;
        }

        protected void dgvCategoria_SelectIndexChanged(object sender, GridViewCommandEventArgs e)
        {
            List<Categorias> categorias = new List<Categorias>();
            CategoriaNegocio neg = new CategoriaNegocio();
            categorias = neg.ListarCategorias();
            //categorias. = dgvCategoria.SelectedDataKey.Value.ToString();
            //Response.Redirect($"EliminarCategoria.aspx?CategoriaID={categoriaID}");

            //neg.EliminarCat();

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
                else if (string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    lblDato.Text = "Debe ingresar una descripcion";
                    lblDato.Visible = true;
                    return;
                }
                if (negocio.BuscarCat(txtNombre.Text))
                {
                    lblDato.Text = "Error, esa categoria ya existe";
                    lblDato.Visible = true;
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

        protected void dgvCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            
          //  Id = int.Parse(dgvCategoria.SelectedDataKey.Value.ToString());

          //  btnConfirmarEliminacion.Visible = true;
          //  ConfirmarEliminacion = true;

          //  if (ConfirmarEliminacion)
          //  {
               
           // }
            lblDato.Text = "modificar";
            lblDato.Visible= true;
        }
        protected void btnConfirmarEliminacion_Click(object sender, EventArgs e)
        {
        }

        protected void dgvCategoria_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            CategoriaNegocio neg = new CategoriaNegocio();

            int index = e.RowIndex;

            int catID = Convert.ToInt32(dgvCategoria.DataKeys[index].Value);

            if (neg.EliminarCat(catID))
            {
                lblDato.Text = "¡Categoria eliminada con exito!";
                lblDato.Visible = true;
            ConfirmarEliminacion = false;
            btnConfirmarEliminacion.Visible = false;
            Page_Load(sender, e);

            }
            else
            {
                lblDato.Text = "No se pudo eliminar la categoria";
                lblDato.Visible = true;
            }
        }
    }
}