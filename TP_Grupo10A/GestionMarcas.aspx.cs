using Dominio;
using Microsoft.Ajax.Utilities;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

                    lblDato.Text = "Error, esa marca ya existe";
                    lblDato.Visible = true;
                    return;
                }
                else
                {
                    lblDato.Text = "¡Marca cargada con exito!";
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

        protected void dgvMarcas_SelectedIndexChanged(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            MarcasNegocio neg = new MarcasNegocio();
            int index = dgvMarcas.SelectedIndex;
            int marcaID = Convert.ToInt32(dgvMarcas.DataKeys[index].Value);
            Response.Redirect("ModificarMarca.aspx?ID=" + marcaID , false);


        }
           

        protected void dgvMarcas_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            MarcasNegocio neg = new MarcasNegocio();

            int index = e.RowIndex;
            int marcaID = Convert.ToInt32(dgvMarcas.DataKeys[index].Value);


            if(!neg.BuscarProductoConMarca(marcaID.ToString()))
            {
                if (neg.EliminarMarca(marcaID))
                {
                    lblDato.Text = "¡Marca eliminada con exito!";
                    lblDato.Visible = true;
                }
                else
                {
                    lblDato.Text = "Error, no se puede eliminar esta marca";
                }
                Page_Load(sender,e);
            }
            else
            {
                lblDato.Text = "Error, esta marca pertenece a un producto";
            }
            
            
        }

    }
}