using Dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_Grupo10A
{
    public partial class Contacto : System.Web.UI.Page
    {
        private EmailService _emailService = new EmailService();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
    
            string msj;
            msj = txtTelefono.Text + " ";
            msj += txtMensaje;
            //txtNombre = ASunsto
            _emailService.armarCorreo(txtEmail.Text, txtNombre.Text, msj);
            try
            {
                _emailService.enviarEmail();
               
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
            }
            finally {
                txtMensaje.Text = "";
                txtEmail.Text = "";
                txtNombre.Text = " ";
                txtTelefono.Text = " "; 

            }
            
            Response.Write("<script>alert('Gracias por contactarnos. Te responderemos pronto.');</script>");

        }

    }
}