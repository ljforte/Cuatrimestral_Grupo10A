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
    public partial class Registro : System.Web.UI.Page
    {

        private UsuarioNegocio negocio = new UsuarioNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarse_Click(object sender, EventArgs e)
        {
            try
            {
               
                Usuarios nuevoUsuario = new Usuarios(txtEmail.Text, txtContraseña.Text)
                {
                    Nombre = txtNombre.Text,
                    Apellido = txtApellido.Text,
                    Genero = int.Parse(DropDownList1.SelectedValue),
                    Tipo = TipoUsuario.Cliente, 
                    FechaRegistro = DateTime.Now,
                    Estado = true
                };

                
                if (txtContraseña.Text != txtConfirmarContraseña.Text)
                {
                    Response.Write("<script>alert('Las contraseñas no coinciden.');</script>");
                    return;
                }
               
                Direcciones nuevaDireccion = new Direcciones
                {
                    Calle = txtDireccion.Text,
                    Ciudad = txtCiudad.Text,
                    CodigoPostal = txtCP.Text,
                    Pais = ddlPais.SelectedValue,
                    Telefono = int.Parse(txtTelefono.Text)
                };

                bool validar = negocio.ValidarRegistroExistente(txtEmail.Text);
                if (validar)
                {
                    Response.Redirect("Login.aspx?mensaje=Usuario%20ya%20registrado,%20ingrese%20por%20favor");
                }
                else
                {
                    negocio.CrearUsuario(nuevoUsuario, nuevaDireccion);
                    Usuarios usuarioLogueado = negocio.Loguear(txtEmail.Text, txtContraseña.Text);
                    Session["UsuarioLogueado"] = usuarioLogueado;
                    Response.Redirect("RegistroExitoso.aspx");
                }
            }
            catch (Exception ex)
            {
               
                Response.Write($"<script>alert('Error: {ex.Message}');</script>");
            }
        }
    }

}
