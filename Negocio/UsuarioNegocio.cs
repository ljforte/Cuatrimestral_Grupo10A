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
        private AccesoDatos datos = new AccesoDatos();
        private AccesoDatos datos2 = new AccesoDatos();

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



        public void CrearUsuario(Usuarios usuario, Direcciones direccion)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                // Insertar usuario en la tabla Usuarios
                datos.setearConsulta(
                    "INSERT INTO Usuarios (Nombre, Apellido, Email, UsuarioPassword, Rol, FechaRegistro, Estado) " +
                    "VALUES (@nombre, @apellido, @email, @password, @rol, GETDATE(), 1);"
                );
                datos.setearParametro("@nombre", usuario.Nombre);
                datos.setearParametro("@apellido", usuario.Apellido);
                datos.setearParametro("@email", usuario.Email);
                datos.setearParametro("@password", usuario.UsuarioPassword);
                datos.setearParametro("@rol", (int)usuario.Tipo);
                datos.ejecutarAccion();

                usuario.UsuarioID = BuscarUsuarioID(usuario);

                if (direccion != null)
                {
                    try
                    {
                        datos2.setearConsulta(
                               "INSERT INTO Direcciones (UsuarioID, Calle, Ciudad, CodigoPostal, Pais, Telefono) " +
                               "VALUES (@usuarioID, @calle, @ciudad, @codigoPostal, @pais, @telefono);"
                           );
                        datos2.setearParametro("@usuarioID", usuario.UsuarioID);
                        datos2.setearParametro("@calle", direccion.Calle);
                        datos2.setearParametro("@ciudad", direccion.Ciudad);
                        datos2.setearParametro("@codigoPostal", direccion.CodigoPostal);
                        datos2.setearParametro("@pais", direccion.Pais);
                        datos2.setearParametro("@telefono", direccion.Telefono);
                        datos2.ejecutarAccion();

                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                    finally
                    {
                        datos2.cerrarConexion();
                    }
                }
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


        public int BuscarUsuarioID(Usuarios usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta(
                    "SELECT UsuarioID FROM Usuarios WHERE Email = @email "
                );
                datos.setearParametro("@email", usuario.Email);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return (int)datos.Lector["UsuarioID"];
                }
  
                throw new Exception("Usuario no encontrado.");
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

        public bool ValidarRegistroExistente(string email)
        {
            try 
            {
                datos.setearConsulta(
             "SELECT COUNT(*) FROM Usuarios WHERE Email = @Email"
                );
                datos.setearParametro("@Email", email);
                datos.ejecutarLectura();
                return datos.Lector.Read(); // devuelve segun encuentre o no resultados
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
    }

}
