using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public Usuarios Loguear(string email, string password)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select UsuarioID, Rol from Usuarios Where Email = @mail AND UsuarioPassword = @pass");
                datos.setearParametro("@mail", email);
                datos.setearParametro("@pass", password);

                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    return new Usuarios(email, password)
                    {
                        UsuarioID = (int)datos.Lector["UsuarioID"],
                        Tipo = (int)datos.Lector["Rol"] == 2 ? TipoUsuario.Admin : TipoUsuario.Cliente
                    };
                }
                return null;
            }
            catch (Exception ex)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

    }

}
