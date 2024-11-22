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
    public partial class ModificarMarca : System.Web.UI.Page
    {
        public MarcasNegocio Negocio = new MarcasNegocio();
        public Marcas Marcas = new Marcas();
        public string MarcaID { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            MarcaID = Request.QueryString["ID"];
            Marcas=Negocio.BuscarDatosMarca(MarcaID);
            txtNombre.Text = Marcas.Nombre;
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionMarcas.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {

            if (!string.IsNullOrEmpty(txtNombre.Text))
            {

                if (Negocio.ModificarMarca(MarcaID, txtNombre.Text))
                {
                    lblDato.Text = "¡Se modifico la marca correctamente!";
                    btnCancelar.Text = "Volver";
                }
                else
                {
                    lblDato.Text = "La marca no se pudo modificar";
                }
            }
            else
            {
                lblDato.Text = "Debes agregar un nuevo nombre";
            }
        }
    }
}