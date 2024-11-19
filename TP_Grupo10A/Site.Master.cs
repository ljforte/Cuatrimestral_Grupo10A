
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
    public partial class SiteMaster : MasterPage
    {
        private CarritoNegocio _carritoNegocio = new CarritoNegocio();
        public int cantidadProducto = 0;
        private CarritoDetalleNegocio  _carritoDetalleNegocio = new CarritoDetalleNegocio();
        private Dominio.Carrito carrito;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UsuarioLogueado"] != null)
            { 
                Usuarios usuarioLogueado = (Usuarios)Session["UsuarioLogueado"];
                carrito = _carritoNegocio.ObtenerCarritoPorUsuario(usuarioLogueado);

               
                if (carrito != null)
                {
                    cantidadProducto = _carritoDetalleNegocio.CantidadDeItems(carrito);
                }
                else
                {
                    cantidadProducto = 0;
                }
            }
            else
            {
                cantidadProducto = 0;
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
        protected void btnVerCarrito_Click(object sender, EventArgs e)
        {
            Usuarios usuarioLogueado = (Usuarios)Session["UsuarioLogueado"]; 

            if (usuarioLogueado != null)
            {
                CarritoNegocio carritoNegocio = new CarritoNegocio(); 
                Dominio.Carrito carrito = carritoNegocio.ObtenerCarritoPorUsuario(usuarioLogueado);

                if (carrito != null)
                {
                    int carritoID = carrito.CarritoID; 
                    Response.Redirect($"Carrito.aspx?CarritoID={carritoID}"); 
                }
            }
        }

    }
}
