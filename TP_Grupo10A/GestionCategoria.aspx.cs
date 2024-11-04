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
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio negocio = new CategoriaNegocio();

            try
            {
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