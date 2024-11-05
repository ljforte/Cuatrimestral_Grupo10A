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
    public partial class GestionMarcas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
            MarcasNegocio negocio = new MarcasNegocio();
           dgvMarcas.DataSource = negocio.ListarMarcas();
            dgvMarcas.DataBind();

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            MarcasNegocio negocio = new MarcasNegocio();


            try
            {
                if (string.IsNullOrEmpty(txtNombre.Text))
                {
                    lblDato.Text = "Debe ingresar un nombre";
                    lblDato.Visible = true;
                    return;
                }
                if (negocio.BuscarMarca(txtNombre.Text))
                {

                    lblDato.Text = "Error, esa categoria ya existe";
                    lblDato.Visible = true;
                    return;
                }
                else
                {
                    lblDato.Text = "¡Categoria cargada con exito!";
                    lblDato.Visible = true;
                    negocio.AgregarMarca(txtNombre.Text);
                    Page_Load(sender, e);
                    return;
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
        }



    }
}