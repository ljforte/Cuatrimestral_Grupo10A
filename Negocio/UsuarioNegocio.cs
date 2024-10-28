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
        public bool Loguear(Usuarios user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select UsuarioID, Rol from Usuarios Where Email = @mail AND UsuarioPassword = @pass");
                datos.setearParametro("@mail", user.Email);
                datos.setearParametro("@pass", user.UsuarioPassword);

                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    user.UsuarioID = (int)datos.Lector["UsuarioID"];
                    user.Tipo = (int)(datos.Lector["Rol"]) == 2 ? TipoUsuario.Admin : TipoUsuario.Cliente;
                    return true;
                }
                return false;
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
