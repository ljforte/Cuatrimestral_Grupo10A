using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PedidoNegocio
    {
        public AccesoDatos datos = new AccesoDatos();
        public Pedidos Pedido = new Pedidos();
        public List<Pedidos> lista = new List<Pedidos>();
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
    }
}
