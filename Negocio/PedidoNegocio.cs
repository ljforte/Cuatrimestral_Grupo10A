﻿using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Negocio
{
    public class PedidoNegocio
    {
        private AccesoDatos datos = new AccesoDatos();
        private Pedidos Pedido = new Pedidos();
        private List<Pedidos> lista = new List<Pedidos>();
        private Pedidos _pedido = new Pedidos();
        private PedidoDetalleNegocio pedidoNegocio = new PedidoDetalleNegocio();
        private AccesoDatos datos2 = new AccesoDatos();



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
                        Pedido.Usuario.Nombre = datos.Lector["NombreCliente"].ToString();

                    if (!(datos.Lector["EstadoPedido"] is DBNull))

                        switch (datos.Lector["EstadoPedido"].ToString())
                        {
                            case "Envio":
                                Pedido.Estado = EstadoPedido.Envio;
                                break;

                            case "Retiro":
                                Pedido.Estado = EstadoPedido.Retiro;
                                break;

                            case "Entregado":
                                Pedido.Estado = EstadoPedido.Entregado;
                                break;

                            case "NoData":
                                Pedido.Estado = EstadoPedido.NoData;
                                break;

                            default:
                                break;
                        }

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
        /*
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


          }


        public bool CrearPedido(Usuarios usuario, Direcciones direccion, Pago metodoDePago, EstadoPedido estado, List<CarritoDetalle> carritoDetalle, int total)
        {
            int pedidoID, usuID;

            try
            {
                try
                {
                    // Consulta para insertar el pedido
                    string consulta = @"
            INSERT INTO Pedidos (UsuarioID, DireccionID, FechaPedido, EstadoPedido, Total, MetodoDePago) 
            VALUES (@UsuarioID, @DireccionID, GETDATE(), @EstadoPedido, @Total, @MetodoDePago);";

                    datos.setearConsulta(consulta);
                    datos.setearParametro("@UsuarioID", usuario.UsuarioID);
                    datos.setearParametro("@DireccionID", direccion.DireccionID);
                    datos.setearParametro("@EstadoPedido", estado.ToString());
                    datos.setearParametro("@Total", total);
                    datos.setearParametro("@MetodoDePago", metodoDePago.ToString());
                    datos.ejecutarAccion();

                    usuID = usuario.UsuarioID;
                }
                catch (Exception ex)
                {
                    throw new Exception("Error al crear el pedido.", ex);
                }
                finally
                {
                    datos.cerrarConexion();
                }


                pedidoID = ObtenerUltimoPedidoPorUsuario(usuID);

                bool resultado = pedidoNegocio.GuardarDetallesPedido(carritoDetalle, pedidoID);
                return resultado;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear los detalles del pedido.", ex);
            }
        }
        */

        public bool CrearPedido(int pedidoID, Usuarios usuario, Direcciones direccion, Pago metodoDePago, EstadoPedido estado, int total)
        {
            try
            {
                string consulta = @"
            UPDATE Pedidos
            SET UsuarioID = @UsuarioID,
                DireccionID = @DireccionID,
                FechaPedido = GETDATE(),
                EstadoPedido = @EstadoPedido,
                Total = @Total,
                MetodoDePago = @MetodoDePago
            WHERE PedidoID = @PedidoID;
        ";

                datos.setearConsulta(consulta);
                datos.setearParametro("@PedidoID", pedidoID);  // PedidoID a actualizar
                datos.setearParametro("@UsuarioID", usuario.UsuarioID);
                datos.setearParametro("@DireccionID", direccion.DireccionID);
                datos.setearParametro("@EstadoPedido", estado.ToString());
                datos.setearParametro("@Total", total);
                datos.setearParametro("@MetodoDePago", metodoDePago.ToString());

                datos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al actualizar el pedido.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public int ObtenerUltimoPedidoPorUsuario(int usuarioID)
        {
            try
            {
                // Obtenemos el pedido con el PedidoID más alto para el usuario
                datos2.setearConsulta(@"
                SELECT TOP 1 PedidoID 
                FROM Pedidos 
                WHERE UsuarioID = @UsuarioID 
                ORDER BY PedidoID DESC;");
                datos2.setearParametro("@UsuarioID", usuarioID);
                datos2.ejecutarLectura();

                if (datos2.Lector.Read())
                {
                    int id = Convert.ToInt32(datos2.Lector["PedidoID"]);
                    return id;
                }
                else
                {
                    return 0;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el último pedido por UsuarioID.", ex);
            }
            finally
            {
                datos2.cerrarConexion();
            }
        }



        public void CrearCarritoVacio(int UsuarioID, Direcciones dire)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = @"
                INSERT INTO Pedidos (UsuarioID, DireccionID, FechaPedido, EstadoPedido, Total, MetodoDePago)
                VALUES (@UsuarioID, @DireccionID, GETDATE(), 'NoData', 0.0, 'Efectivo');";

                datos.setearConsulta(consulta);
                datos.setearParametro("UsuarioID", UsuarioID);
                datos.setearParametro("DireccionID", dire.DireccionID);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al crear el carrito vacío.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public Pedidos ObtenerPedidoPorID(int pedidoID)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                string consulta = @"
    SELECT 
        p.PedidoID, 
        p.FechaPedido, 
        p.EstadoPedido, 
        p.Total, 
        p.MetodoDePago,
        u.UsuarioID, 
        u.Nombre AS UsuarioNombre, 
        u.Apellido AS UsuarioApellido, 
        u.Email as Email,
        d.DireccionID, 
        d.UsuarioID AS DireccionUsuarioID, 
        d.Calle, 
        d.Ciudad, 
        d.CodigoPostal, 
        d.Pais, 
        d.Telefono
    FROM Pedidos p
    LEFT JOIN Usuarios u ON p.UsuarioID = u.UsuarioID
    LEFT JOIN Direcciones d ON p.DireccionID = d.DireccionID
    WHERE p.PedidoID = @PedidoID;
";

                datos.setearConsulta(consulta);
                datos.setearParametro("@PedidoID", pedidoID);
                datos.ejecutarLectura();

                Pedidos pedido = null;

                // Si se encuentra el pedido, lo instanciamos
                if (datos.Lector.Read())
                {
                    pedido = new Pedidos
                    {
                        PedidoID = Convert.ToInt32(datos.Lector["PedidoID"]),
                        FechaPedido = Convert.ToDateTime(datos.Lector["FechaPedido"]),
                        Estado = Enum.TryParse<EstadoPedido>(datos.Lector["EstadoPedido"].ToString(), true, out var estadoPedido) ? estadoPedido : EstadoPedido.NoData,
                        Total = Convert.ToSingle(datos.Lector["Total"]),
                        MetodoDePago = Enum.TryParse<Pago>(datos.Lector["MetodoDePago"].ToString(), true, out var metodoDePago) ? metodoDePago : Pago.Efectivo,
                        Usuario = new Usuarios(
                                Convert.ToInt32(datos.Lector["UsuarioID"]),
                                datos.Lector["UsuarioNombre"].ToString(),
                                datos.Lector["UsuarioApellido"].ToString(),
                                datos.Lector["Email"].ToString()
                        ),
                        Direcciones = new Direcciones
                        {
                            DireccionID = Convert.ToInt32(datos.Lector["DireccionID"]),
                            UsuarioID = Convert.ToInt32(datos.Lector["DireccionUsuarioID"]),
                            Calle = datos.Lector["Calle"].ToString(),
                            Ciudad = datos.Lector["Ciudad"].ToString(),
                            CodigoPostal = datos.Lector["CodigoPostal"].ToString(),
                            Pais = datos.Lector["Pais"].ToString(),
                            Telefono = Convert.ToInt32(datos.Lector["Telefono"])
                        }
                    };
                }

                // Consulta para obtener los detalles del pedido
                if (pedido != null)
                {
                    pedido.Detalles = ObtenerDetallesPorPedidoID(pedido.PedidoID);
                }

                return pedido;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el pedido por ID.", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        private List<PedidosDetalle> ObtenerDetallesPorPedidoID(int pedidoID)
        {
            AccesoDatos datos = new AccesoDatos();
            List<PedidosDetalle> detalles = new List<PedidosDetalle>();

            try
            {
                string consulta = @"
            SELECT 
                pd.ProductoID, 
                pd.Cantidad, 
                pd.PrecioUnitario, 
                pr.Nombre AS ProductoNombre
            FROM PedidosDetalle pd
            INNER JOIN Productos pr ON pd.ProductoID = pr.ProductoID
            WHERE pd.PedidoID = @PedidoID;
        ";

                datos.setearConsulta(consulta);
                datos.setearParametro("@PedidoID", pedidoID);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    var detalle = new PedidosDetalle
                    {
                        ProductoID = Convert.ToInt32(datos.Lector["ProductoID"]),
                        Cantidad = Convert.ToInt32(datos.Lector["Cantidad"]),
                        PrecioUnitario = Convert.ToDecimal(datos.Lector["PrecioUnitario"]),
                        producto = new Productos
                        {
                            ProductoID = Convert.ToInt32(datos.Lector["ProductoID"]),
                            Nombre = datos.Lector["ProductoNombre"].ToString()
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
