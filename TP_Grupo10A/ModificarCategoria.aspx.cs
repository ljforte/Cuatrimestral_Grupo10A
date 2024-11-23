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
    public partial class ModificarCategoria : System.Web.UI.Page
    {
        private CategoriaNegocio CategoriaNeg;
        private Categorias Categoria;
        private string idCategoria;
        private string nombre,descripcion;
        private string script;

        public ModificarCategoria() {
            CategoriaNeg = new CategoriaNegocio();
            Categoria = new Categorias();

       
        }
        protected void Page_Load(object sender, EventArgs e)
        {           
            
            idCategoria = Request.QueryString["ID"];
            Categoria = CategoriaNeg.BuscarCategoria(idCategoria);
            if (!IsPostBack)
            {

                lblTitulo.Text += Categoria.Nombre;
                txtDescripcion.Text = Categoria.Descripcion;
            }      
            nombre = txtNombre.Text;
            descripcion = txtDescripcion.Text;
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtNombre.Text))
                {
                    string descripcion = txtDescripcion.Text;                    
                    
                        if (CategoriaNeg.modificar(idCategoria, nombre, descripcion))
                        {
                    
                            Mensaje("¡Se modificó correctamente! \n Nuevo Nombre de Categoría: " + nombre.ToUpper());
                            lblDato.ForeColor = System.Drawing.Color.Green;
                        }
                        else
                        {
                            Mensaje("La categoría no se pudo modificar");
                        }
                    
                }
                else
                {
                    Mensaje("Debes agregar un nuevo nombre");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al Eliminar las Categorias: " + ex.Message, ex);
            }
            finally
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
            }
        }

    

        protected void btnCancelar_Click1(object sender, EventArgs e)
        {
            Response.Redirect("GestionCategoria.aspx", false);
        }
        private void Mensaje(string msj)
        {
            lblDato.Text = msj;
            lblDato.ForeColor = System.Drawing.Color.Red;
        }
    }
}