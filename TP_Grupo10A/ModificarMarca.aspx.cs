using Dominio;
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
    public partial class ModificarMarca : System.Web.UI.Page
    {
        public MarcasNegocio MarcaNeg;
        public Marcas Marcas;
        public string idMarca { get; set; }
        string nombre;
        string script;
        public ModificarMarca()
        {
            MarcaNeg = new MarcasNegocio();
            Marcas = new Marcas();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            idMarca = Request.QueryString["ID"];

            Marcas = MarcaNeg.BuscarDatosMarca(idMarca);
            nombre = txtNombre.Text;
            if (!IsPostBack) { lblTitulo.Text += Marcas.Nombre; }
            
            
        }

        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("GestionMarcas.aspx", false);
        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            
            if (!string.IsNullOrEmpty(txtNombre.Text))
            {
                
                if (MarcaNeg.ModificarMarca(idMarca, nombre))
                {
                    Mensaje("¡Se modificó correctamente! \n Nuevo Nombre de Marca: "+ nombre.ToUpper());
                    lblDato.ForeColor = System.Drawing.Color.Green;
                    
                }
                else
                {
                    Mensaje("La marca no se pudo modificar");
                }
            }
            else
            {
                Mensaje("Debes agregar un nuevo nombre");
            }
            ClientScript.RegisterStartupScript(this.GetType(), "alert", script, true);
        }

        private void Mensaje(string msj)
        {
            lblDato.Text = msj;
            lblDato.ForeColor = System.Drawing.Color.Red;
        }
    }
}