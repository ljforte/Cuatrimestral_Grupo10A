using Dominio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Negocio
{
    public class UsuarioNegocio
    {
        private Usuarios usuarioLogeado;
        private Usuarios nombre;

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
                    usuarioLogeado  = new Usuarios(email, password)
                    {
                        UsuarioID = (int)datos.Lector["UsuarioID"],
                        Tipo = (int)datos.Lector["Rol"] == 2 ? TipoUsuario.Admin : TipoUsuario.Cliente

                    };
                    

                    return usuarioLogeado;
                    
                }
                else
                {
           
                    Console.WriteLine("No se encontró ningún usuario");
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
        
        public void ActualizarUsuario(Usuarios usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE Usuarios SET UsuarioPassword = @pass WHERE UsuarioID = @id");
                datos.setearParametro("@pass", usuario.UsuarioPassword);
                datos.setearParametro("@id", usuario.UsuarioID);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        //Devuelve NULL
        public Usuarios DevolverUsuarioLogeado()
        {
      
            return usuarioLogeado;
        }
    }

}
