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
                    Mensaje("Debe ingresar un nombre");
                    return;
                }
                else if (string.IsNullOrEmpty(txtDescripcion.Text))
                {
                    Mensaje("Debe ingresar una Descripcion");
                    return;
                }
                if (negocio.BuscarCat(txtNombre.Text))
                {
                    Mensaje("Error, esa Categoria ya existe");
                    return;
                }
                else
                { //Agregar marcas
                    negocio.AgregarCategoria(txtNombre.Text, txtDescripcion.Text);
                    Mensaje(txtNombre.Text + " cargada con exito!");
                    lblDato.ForeColor = System.Drawing.Color.Green;
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
            
          Id = int.Parse(dgvCategoria.SelectedDataKey.Value.ToString());

            Response.Redirect("ModificarCategoria.aspx?ID="+Id, false);

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
                Mensaje("¡Categoria eliminada con exito!");
                lblDato.ForeColor = System.Drawing.Color.Green;
                ConfirmarEliminacion = false;
                btnConfirmarEliminacion.Visible = false;
                Page_Load(sender, e);
            }
            else
            {
                Mensaje("No se pudo eliminar la categoria");
            }
        }
        private void Mensaje(string msj, bool visible = true)
        {
            lblDato.Text = msj;
            lblDato.Visible = visible;
            lblDato.ForeColor = System.Drawing.Color.Red;
        }
    }
}