using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class DetallePedidoNegocio
    {
        public List<PedidosDetalle> ListaPedidoDetalle = new List<PedidosDetalle>();
        public AccesoDatos datos = new AccesoDatos();
        public PedidosDetalle pedidosDetalle = new PedidosDetalle();
       
        public List<PedidosDetalle> ListarPedidoDetalle(string PedidoID) {

            try
            {
                datos.setearConsulta("select PD.PedidoDetalleID, pd.PedidoID, pd.ProductoID, pd.Cantidad, pd.PrecioUnitario from PedidosDetalle PD\r\njoin Productos P on p.ProductoID = pd.ProductoID\r\nwhere PedidoID = @PID");
                datos.setearParametro("@PID", PedidoID);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    if (!(datos.Lector["PedidoDetalleID"] is DBNull))
                        pedidosDetalle.PedidoDetalleID = Convert.ToInt32(datos.Lector["PedidoDetalleID"]);
                    if (!(datos.Lector["PedidoID"] is DBNull))
                        pedidosDetalle.PedidoID = (int)datos.Lector["PedidoID"];
                    if (!(datos.Lector["ProductoID"] is DBNull))
                        pedidosDetalle.ProductoID = (int)(datos.Lector["ProductoID"]);
                    if (!(datos.Lector["Cantidad"] is DBNull))
                        pedidosDetalle.Cantidad = (int)datos.Lector["Cantidad"];
                    if (!(datos.Lector["PrecioUnitario"] is DBNull))
                        pedidosDetalle.PrecioUnitario = Convert.ToSingle(datos.Lector["PrecioUnitario"]);
                    if (!(datos.Lector["ProductoID"] is DBNull))
                        pedidosDetalle.ProductoID = (int)(datos.Lector["ProductoID"]);

                    ListaPedidoDetalle.Add(pedidosDetalle);                
                }
                return ListaPedidoDetalle;
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
