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
                    // FUNCION IMPORTANTE, SOLUCIONA PROBLEMAS DE CONEXION OPEN
                    datos.limpiarParametros();

                  
                    datos.setearParametro("@PedidoID", pedidoID);
                    datos.setearParametro("@ProductoID", item.ProductoID);
                    datos.setearParametro("@Cantidad", item.Cantidad);
                    datos.setearParametro("@PrecioUnitario", item.PrecioUnitario);

                    // Ejecuta la inserción
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


        public List<PedidosDetalle> ListarDetallePorPedidoID(int pedidoID)
        {
            AccesoDatos datos = new AccesoDatos();
            List<PedidosDetalle> detalles = new List<PedidosDetalle>();
            try
            {
                // Consulta para obtener los detalles del pedido
                string consulta = @"SELECT 
                                        pd.PedidoDetalleID AS PedidoDetalleID, 
                                        pd.PedidoID AS PedidoID, 
                                        pd.ProductoID AS ProductoID, 
                                        pd.Cantidad AS Cantidad, 
                                        pd.PrecioUnitario AS PrecioUnitario, 
                                        p.Nombre AS ProductoNombre
                                    FROM 
                                        PedidosDetalle pd
                                    INNER JOIN 
                                        Productos p 
                                        ON pd.ProductoID = p.ProductoID
                                    WHERE 
                                        pd.PedidoID = @PedidoID";

                datos.setearConsulta(consulta);
                datos.setearParametro("@PedidoID", pedidoID);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    PedidosDetalle detalle = new PedidosDetalle()
                    {
                        PedidoDetalleID = (int)datos.Lector["PedidoDetalleID"],
                        PedidoID = (int)datos.Lector["PedidoID"],
                        ProductoID = (int)datos.Lector["ProductoID"],
                        Cantidad = (int)datos.Lector["Cantidad"],
                        PrecioUnitario = (decimal)datos.Lector["PrecioUnitario"],
                        producto = new Productos()
                        {
                            Nombre = (string)datos.Lector["ProductoNombre"]
                        }
                    };

                    detalles.Add(detalle);
                }

                return detalles;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener los detalles del pedido.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}

