using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace TP_Grupo10A
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            mensajeError.Visible = false;
        }
        protected void btnIngresar_Click(object sender, EventArgs e)
        {

            try
            {
                UsuarioNegocio negocio = new UsuarioNegocio();
                Usuarios usuarioLogueado = negocio.Loguear(txtEmail.Text, txtContraseña.Text);
                if (usuarioLogueado != null)
                {
                    Session["UsuarioLogueado"] = usuarioLogueado;
                    if (usuarioLogueado.Tipo == TipoUsuario.Cliente)
                    {
                        Response.Redirect("TeLogueaste.aspx", false);
                    }
                    else if (usuarioLogueado.Tipo == TipoUsuario.Admin)
                    {
                        Response.Redirect("GestionPedidos.aspx", false);
                    }
                    
                 
                }
                else
                {
                    mensajeError.Visible = true;
                    Session["error"] = "Usuario o contraseña incorrecta";
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}