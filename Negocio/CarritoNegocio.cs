using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;


namespace Negocio
{
    public class CarritoNegocio
    {
        private Usuarios usuario;
        private Carrito carrito = new Carrito();
        private AccesoDatos datos = new AccesoDatos();

        public Carrito ObtenerCarritoPorUsuario(Usuarios usuario)
        {
            try
            {
                string consulta = @"SELECT CarritoID as CarritoID, UsuarioID as Usuario, FechaCreacion as Fecha FROM Carrito where UsuarioID = "
                + usuario.UsuarioID;
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    carrito.CarritoID = (int)datos.Lector["CarritoID"];
                    carrito.UsuarioID = (int)datos.Lector["Usuario"];
                    carrito.FechaCreacion = (DateTime)datos.Lector["Fecha"];
                }
                else
                {
                    carrito = null;
                }
                return carrito;
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

        public void CrearCarrito(Usuarios usuario)
        {
            try
            {
                string consulta = @"INSERT INTO CARRITO (UsuarioID) VALUES(@UsuarioID)";
                datos.setearConsulta(consulta);
                datos.setearParametro("@UsuarioId", usuario.UsuarioID);
                datos.ejecutarLectura();
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
