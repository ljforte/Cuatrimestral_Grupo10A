using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PedidoNegocio
    {
        public AccesoDatos datos = new AccesoDatos();
        public Pedidos Pedido = new Pedidos();
        public List<Pedidos> lista = new List<Pedidos>();
        public Pedidos _pedido = new Pedidos();
        public PedidoDetalleNegocio pedidoNegocio = new PedidoDetalleNegocio();


        /*
          public List<Pedidos> ListarPedidos()
          {

              try
              {
                  datos.setearConsulta("SELECT P.PedidoID, p.FechaPedido, U.Nombre as NombreCliente, E.Descripcion as EstadoPedido, p.Total from Pedidos P\r\njoin Usuarios U on U.UsuarioID = P.UsuarioID\r\nJoin EstadoPedido E on E.EstadoID = P.EstadoPedido\r\njoin PedidosDetalle PD on PD.PedidoDetalleID = p.PedidoID");
                  datos.ejecutarLectura();

                  while (datos.Lector.Read())
                  {
                      Pedido = new Pedidos();
                      if (!(datos.Lector["PedidoID"] is DBNull))
                          Pedido.PedidoID = (int)datos.Lector["PedidoID"];
                      if (!(datos.Lector["FechaPedido"] is DBNull))
                          Pedido.FechaPedido = (DateTime)datos.Lector["FechaPedido"];

                      if (!(datos.Lector["NombreCliente"] is DBNull))
                          Pedido.NombreCliente = datos.Lector["NombreCliente"].ToString();

                      if (!(datos.Lector["EstadoPedido"] is DBNull))
                          Pedido.Estado = datos.Lector["EstadoPedido"].ToString();

                      if (!(datos.Lector["Total"] is DBNull))
                          Pedido.Total = Convert.ToSingle(datos.Lector["Total"]);

                      lista.Add(Pedido);
                  }
                  return lista;

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

          public Pedidos ListarPedidoPorID(string ID)
          {


              try
              {
                  datos.setearConsulta("SELECT P.PedidoID, p.FechaPedido, U.Nombre as NombreCliente, E.Descripcion as EstadoPedido, p.Total from Pedidos P\r\njoin Usuarios U on U.UsuarioID = P.UsuarioID\r\nJoin EstadoPedido E on E.EstadoID = P.EstadoPedido\r\njoin PedidosDetalle PD on PD.PedidoDetalleID = p.PedidoID where P.PedidoID ="+ID);
                  datos.ejecutarLectura();

                  while (datos.Lector.Read())
                  {
                      if (!(datos.Lector["PedidoID"] is DBNull))
                          _pedido.PedidoID = (int)datos.Lector["PedidoID"];
                      if (!(datos.Lector["FechaPedido"] is DBNull))
                          _pedido.FechaPedido = (DateTime)datos.Lector["FechaPedido"];

                      if (!(datos.Lector["NombreCliente"] is DBNull))
                          _pedido.NombreCliente = datos.Lector["NombreCliente"].ToString();

                      if (!(datos.Lector["EstadoPedido"] is DBNull))
                          _pedido.Estado = datos.Lector["EstadoPedido"].ToString();

                      if (!(datos.Lector["Total"] is DBNull))
                          _pedido.Total = Convert.ToSingle(datos.Lector["Total"]);


                  }
                  return _pedido;

              }
              catch (Exception ex)
              {
                  throw;
              }
              finally
              {
                  datos.cerrarConexion();
              }


          }*/


        public bool CrearPedido(Usuarios usuario, Direcciones direccion, Pago metodoDePago, EstadoPedido estado, List<CarritoDetalle> carritoDetalle, int total)
        {

            try
            {
                // scope identity obtiene el ultimo valor generado por la columna identity dentro del mismo contexto

                string consulta = @"
            INSERT INTO Pedidos (UsuarioID, DireccionID, FechaPedido, EstadoPedido, Total, MetodoDePago) 
            VALUES (@UsuarioID, @DireccionID, GETDATE(), @EstadoPedido, @Total, @MetodoDePago);
            SELECT SCOPE_IDENTITY();";

               
                datos.setearConsulta(consulta);
                datos.setearParametro("@UsuarioID", usuario.UsuarioID);
                datos.setearParametro("@DireccionID", direccion.DireccionID);
                datos.setearParametro("@EstadoPedido", estado.ToString());
                datos.setearParametro("@Total", total ); 
                datos.setearParametro("@MetodoDePago", metodoDePago.ToString());
                datos.ejecutarAccion();


                int pedidoID = datos.ejecutarAccionScalar();

                if (pedidoNegocio.GuardarDetallesPedido(carritoDetalle, pedidoID))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el pedido", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }

            


        }
    }
}
