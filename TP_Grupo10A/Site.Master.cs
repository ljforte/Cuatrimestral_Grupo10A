﻿
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Grupo10A
{
    public partial class SiteMaster : MasterPage
    {
        public int cantidadProducto = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            CarritoDetalleNegocio _carritoDetalleNeg = new CarritoDetalleNegocio();
            if (!IsPostBack) {
                cantidadProducto = _carritoDetalleNeg.CantidadDeItem(1);
            }
                

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx", false);
        }

        protected void btnPerfil_click(object sender, EventArgs e)
        {
            Response.Redirect("Perfil.aspx", false);
        }



        public void CambiarTextoBotonLogin(string nuevoTexto)
        {
            //btnLogin.Text = nuevoTexto;
        }
        protected void btnBuscar_Click(object sender, EventArgs e)
        {

        }


        protected void btnRegistro_Click(object sender, EventArgs e)
        {

            Response.Redirect("Registro.aspx", false);
        }
        protected void btnSubmitLogin_Click(object sender, EventArgs e)
        {

        }

        protected void btnCarrito_Click(object sender, EventArgs e)
        {

        }

        protected void btnGestion_Click(object sender, EventArgs e)
        {

        }
    }
}
