using Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class CarritoDetalleNegocio
    {
        private AccesoDatos datos;
        private List<CarritoDetalle> list;
        private CarritoDetalle detalle;


        // Constructor
        public CarritoDetalleNegocio()
        {
            datos = new AccesoDatos();
            list = new List<CarritoDetalle>();
            detalle = new CarritoDetalle();
        }

        // Método para calcular el precio total
        public float CalcularPrecioTotal()
        {
            return detalle.Cantidad * detalle.PrecioUnitario;
        }

        public List<CarritoDetalle> ListarDetalles(string IdProducto)
        {
            list = new List<CarritoDetalle>();

            try
            {
                int id = Convert.ToInt32(IdProducto);
                string consulta = "SELECT CarritoDetalleID, CarritoID, ProductoID, Cantidad, PrecioUnitario FROM CarritoDetalle";
                if (!string.IsNullOrWhiteSpace(IdProducto)) consulta += " WHERE ProductoID = " + id;
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {

                    if (!(datos.Lector["CarritoDetalleID"] is DBNull))
                        detalle.CarritoDetalleID = (int)datos.Lector["CarritoDetalleID"];
                    if (!(datos.Lector["CarritoID"] is DBNull))
                        detalle.CarritoID = (int)datos.Lector["CarritoID"];
                    if (!(datos.Lector["ProductoID"] is DBNull))
                        detalle.ProductoID = (int)datos.Lector["ProductoID"];
                    if (!(datos.Lector["Cantidad"] is DBNull))
                        detalle.Cantidad = (int)datos.Lector["Cantidad"];
                    if (!(datos.Lector["PrecioUnitario"] is DBNull))
                        detalle.PrecioUnitario = (float)datos.Lector["PrecioUnitario"];
                    list.Add(detalle);
                }
                return list;
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

        public void AgregarDetalle(CarritoDetalle detalle)
        {
            try
            {
                string consulta = "INSERT INTO CarritoDetalle (ProductoID, Cantidad, PrecioUnitario) VALUES (@ProductoID, @Cantidad, @PrecioUnitario)";
                datos.setearConsulta(consulta);
                datos.setearParametro("@ProductoID", detalle.ProductoID);
                datos.setearParametro("@Cantidad", detalle.Cantidad);
                datos.setearParametro("@PrecioUnitario", detalle.PrecioUnitario);
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


        public bool AgregarDetalle(Carrito carrito, int ProductoID, int Cantidad, float Precio )
        {
            try
            {
                string consulta = @"INSERT INTO CarritoDetalle (CarritoID, ProductoID, Cantidad, PrecioUnitario) 
                            VALUES (@CarritoID, @ProductoID, @Cantidad, @PrecioUnitario)"; 
                datos.setearConsulta(consulta);
                datos.setearParametro("@CarritoID", carrito.CarritoID);
                datos.setearParametro("@ProductoID", ProductoID);
                datos.setearParametro("@Cantidad", Cantidad);
                datos.setearParametro("@PrecioUnitario", Precio);
                datos.ejecutarAccion();
                return true;
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

        public bool BuscarDetalle(int carritoDetalleID)
        {
            try
            {
                string consulta = "SELECT * FROM CarritoDetalle WHERE CarritoDetalleID = @CarritoDetalleID";
                datos.setearConsulta(consulta);
                datos.setearParametro("@CarritoDetalleID", carritoDetalleID);
                datos.ejecutarLectura();
                return datos.Lector.Read();
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

        public int BuscarIdDetalle(int carritoDetalleID)
        {
            try
            {
                string consulta = "SELECT CarritoDetalleID FROM CarritoDetalle WHERE CarritoDetalleID = @CarritoDetalleID";
                datos.setearConsulta(consulta);
                datos.setearParametro("@CarritoDetalleID", carritoDetalleID);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return (int)datos.Lector["CarritoDetalleID"];
                }
                else
                {
                    return 0;
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

        public bool EliminarDetalle(int carritoDetalleID)
        {
            try
            {
                string consulta = "DELETE FROM CarritoDetalle WHERE CarritoDetalleID = @CarritoDetalleID";
                datos.setearConsulta(consulta);
                datos.setearParametro("@CarritoDetalleID", carritoDetalleID);
                datos.ejecutarAccion();
                return true;
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


        public int CantidadDeItem(int productoID)
        {
            try
            {
                string consulta = "SELECT SUM(Cantidad) AS TotalCantidad FROM CarritoDetalle WHERE ProductoID = @ProductoID";
                datos.setearConsulta(consulta);
                datos.setearParametro("@ProductoID", productoID);
                datos.ejecutarLectura();
                if (datos.Lector.Read() && !(datos.Lector["TotalCantidad"] is DBNull))
                {
                    return (int)datos.Lector["TotalCantidad"];
                }
                else
                {
                    return 0;
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

        public int CantidadDeItems(Carrito carrito)
        {
            int cantidad = 0;
            try
            {
                string consulta = "SELECT SUM(Cantidad) as TotalCantidad FROM CarritoDetalle WHERE CarritoID = @CarritoID"; datos.setearConsulta(consulta);
                datos.setearConsulta(consulta);
                datos.setearParametro("@CarritoID", carrito.CarritoID);
                datos.ejecutarLectura();

                if (datos.Lector.Read() && !(datos.Lector["TotalCantidad"] is DBNull))
                {
                    cantidad = (int)datos.Lector["TotalCantidad"];
                }

                return cantidad;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public List<CarritoDetalle> VerCarritoDetalles(Carrito carrito)
        {
            List<CarritoDetalle> list = new List<CarritoDetalle>();
            try
            {
                string consulta = @"
            SELECT 
                cd.CarritoDetalleID as CarritoDetalleID, 
                cd.CarritoID, 
                cd.ProductoID, 
                cd.Cantidad, 
                cd.PrecioUnitario,
                p.Nombre AS NombreProducto,
                p.Descripcion AS DescripcionProducto,
                p.Precio AS PrecioProducto
                FROM CarritoDetalle cd
            INNER JOIN Productos p ON cd.ProductoID = p.ProductoID
            WHERE cd.CarritoID = @CarritoID";

                datos.setearConsulta(consulta);
                datos.setearParametro("@CarritoID", carrito.CarritoID);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var precioUnitario = datos.Lector["PrecioUnitario"];
                    var precioProducto = datos.Lector["PrecioProducto"];

                    CarritoDetalle detalle = new CarritoDetalle
                    {
                        CarritoDetalleID = (int)datos.Lector["CarritoDetalleID"],
                        CarritoID = (int)datos.Lector["CarritoID"],
                        ProductoID = (int)datos.Lector["ProductoID"],
                        Cantidad = (int)datos.Lector["Cantidad"],
                        PrecioUnitario = precioUnitario == DBNull.Value ? 0f : Convert.ToSingle(precioUnitario),
                        producto = new Productos
                        {
                            Nombre = datos.Lector["NombreProducto"].ToString(),
                            Descripcion = datos.Lector["DescripcionProducto"].ToString(),
                            Precio = precioProducto == DBNull.Value ? 0f : Convert.ToSingle(precioProducto)
                        }

                    };
                    list.Add(detalle);
                }

                return list;
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

        public bool ActualizarCantidad(int carritoID, int productoID, int cantidad)
        {
            try
            {
                string consulta = @"
            UPDATE CarritoDetalle
            SET Cantidad = Cantidad + @Cantidad
            WHERE CarritoID = @CarritoID AND ProductoID = @ProductoID";

                AccesoDatos datos = new AccesoDatos();
                datos.setearConsulta(consulta);
                datos.setearParametro("@Cantidad", cantidad);
                datos.setearParametro("@CarritoID", carritoID);
                datos.setearParametro("@ProductoID", productoID);

                datos.ejecutarAccion();
                return true; 
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


        public bool EliminarCarritoDetalle(int carritoDetalleID)
        {
            try
            {
                datos.setearProcedimiento("spEliminarCarritoDetalle");
                datos.setearParametro("@CarritDetalleID", carritoDetalleID);
                datos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool ValidarCarritoTieneDetalles(int carritoID)
        {
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM CarritoDetalle WHERE CarritoID = @CarritoID");
                datos.setearParametro("@CarritoID", carritoID);
                int detalles = (int)datos.ejecutarAccionScalar();

                if (detalles > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al validar el carrito.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
