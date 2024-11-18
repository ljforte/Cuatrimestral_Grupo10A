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
                if(IdProducto!= " " ) consulta += " WHERE P.ProductoID = "+ id;
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


        public void AgregarDetalle(Carrito carrito, int ProductoID, int Cantidad, float Precio )
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
                return false;
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

    }
}
