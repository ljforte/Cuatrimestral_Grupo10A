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
            Usuarios user;
            UsuarioNegocio negocio = new UsuarioNegocio();
            
            try
            {
                user = new Usuarios(txtEmail.Text, txtContraseña.Text);
               if(negocio.Loguear(user))
                {
                    Session.Add("Usuario", user);
                    if (user.Tipo == TipoUsuario.Admin)
                    {
                        Response.Redirect("Gestion.aspx", false);
                        return;
                    }
                    else if(user.Tipo == TipoUsuario.Cliente)
                    {
                    Response.Redirect("TeLogueaste.aspx", false);
                    return;
                }
                }
                else
                {
                    mensajeError.Visible = true;
                    Session.Add("error", "Usuario o contraseña incorrecta");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex.ToString());
                throw;
            }
        }
    }
}