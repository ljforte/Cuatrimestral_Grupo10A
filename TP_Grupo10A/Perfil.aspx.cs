using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace TP_Grupo10A
{
    public partial class Perfil : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ActivarTxt(true);
            Usuarios u = (Usuarios)Session["UsuarioLogueado"];
            if (u!=null)
            {
                txtEmail.Text = u.Email;
                txtContraseña.Text = u.UsuarioPassword;
                txtFechaRegistro.Text = u.FechaRegistro.ToString("yyyy-MM-dd");
            }




        }

        private void ActivarTxt(bool v)
        {
            txtContraseña.ReadOnly = v;
        }



        protected void btnModificar_Click(object sender, EventArgs e)
        {
            string passwordActual = txtContraseña.Text;
            string passwordNueva = txtNueva.Text;
            string passwordConfirmar = txtConfirmar.Text;

            if (passwordNueva != passwordConfirmar)
            {
                lblMensaje.Text = "Las nuevas contraseñas no coinciden.";
                return;
            }
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuarios usuarioLogeado = usuarioNegocio.Loguear(txtEmail.Text,passwordActual);

            if (usuarioLogeado == null)
            {
                lblMensaje.Text = "No se encontró el usuario logeado.";
                return;
            }

            if (usuarioLogeado.UsuarioPassword != passwordActual)
            {
                lblMensaje.Text = "La contraseña actual es incorrecta.";
                return;
            }

            try
            {
                usuarioLogeado.UsuarioPassword = passwordNueva;
                usuarioNegocio.ActualizarUsuario(usuarioLogeado);
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "Contraseña modificada con éxito.";
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Ocurrió un error al modificar la contraseña.";
            }



        }
    }
}