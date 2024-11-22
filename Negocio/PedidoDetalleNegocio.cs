using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PedidoDetalleNegocio
    {

        public bool GuardarDetallesPedido(List<CarritoDetalle> carritoDetalle, int pedidoID)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {                
                string consulta = @"
                    INSERT INTO PedidosDetalle (PedidoID, ProductoID, Cantidad, PrecioUnitario)
                    VALUES (@PedidoID, @ProductoID, @Cantidad, @PrecioUnitario)";

                datos.setearConsulta(consulta);

                foreach (var item in carritoDetalle)
                {
                    datos.setearParametro("@PedidoID", pedidoID);
                    datos.setearParametro("@ProductoID", item.ProductoID);
                    datos.setearParametro("@Cantidad", item.Cantidad);
                    datos.setearParametro("@PrecioUnitario", item.PrecioUnitario);
                    datos.ejecutarAccion();
                }
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar los detalles del pedido.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
