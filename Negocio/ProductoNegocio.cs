﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;
using System.Text.RegularExpressions;

namespace Negocio
{

    public class ProductoNegocio
    {
        private AccesoDatos datos = new AccesoDatos();
        private List<Productos> list;
        private ImagenProductoNegocio IMGnegocio = new ImagenProductoNegocio();
        private CategoriaNegocio Cat = new CategoriaNegocio();
        private MarcasNegocio Mar = new MarcasNegocio();

        public List<Productos> ListarArticulos()
        {
            list = new List<Productos>();
            try
            {
                string consulta = @"SELECT P.ProductoID as ProductoID, P.Nombre, M.Nombre AS Marca, P.Precio, P.Descripcion, 
                                   C.Nombre AS Categoria, P.MarcaID, C.CategoriaID
                            FROM Productos AS P
                            LEFT JOIN Marcas AS M ON M.MarcaID = P.MarcaID
                            LEFT JOIN Categorias AS C ON C.CategoriaID = P.CategoriaID
                            WHERE P.Estado = 1 AND P.Stock > 1";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Productos Producto = new Productos();


                    if (!(datos.Lector["ProductoID"] is DBNull))
                        Producto.ProductoID = Convert.ToInt32(datos.Lector["ProductoID"]);

                    if (!(datos.Lector["Nombre"] is DBNull))
                        Producto.Nombre = (string)datos.Lector["Nombre"];

                    if (!(datos.Lector["Precio"] is DBNull))
                        Producto.Precio = Convert.ToSingle(datos.Lector["Precio"]);

                    if (!(datos.Lector["Descripcion"] is DBNull))
                        Producto.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["Categoria"] is DBNull))
                    {
                        Producto.CategoriaID = new Categorias();
                        Producto.CategoriaID.Nombre = (string)datos.Lector["Categoria"];

                        if (!(datos.Lector["CategoriaID"] is DBNull))
                            Producto.CategoriaID.CategoriaID = Convert.ToInt32(datos.Lector["CategoriaID"]);
                    }

                    if (!(datos.Lector["Marca"] is DBNull))
                    {
                        Producto.MarcaID = new Marcas();
                        Producto.MarcaID.Nombre = (string)datos.Lector["Marca"];

                        if (!(datos.Lector["MarcaID"] is DBNull))
                            Producto.MarcaID.MarcaID = Convert.ToInt32(datos.Lector["MarcaID"]);
                    }

                    List<ImagenProducto> img = IMGnegocio.listarImagenes(Producto.ProductoID);
                    if (img.Count > 0)
                        Producto.ListImagenes = img;
                    list.Add(Producto);

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


        public List<Productos> ListarArticulos(string Categoria)
        {
            list = new List<Productos>();
            try
            {
                string consulta = @"SELECT P.ProductoID as ProductoID, P.Nombre, M.Nombre AS Marca, P.Precio, P.Descripcion, 
                                   C.Nombre AS Categoria, P.MarcaID, C.CategoriaID
                            FROM Productos AS P
                            LEFT JOIN Marcas AS M ON M.MarcaID = P.MarcaID
                            LEFT JOIN Categorias AS C ON C.CategoriaID = P.CategoriaID
                            WHERE P.Estado = 1 AND P.Stock > 1 AND C.Nombre = @Categoria";

                datos.setearConsulta(consulta);
                datos.setearParametro("@Categoria", Categoria);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Productos Producto = new Productos();


                    if (!(datos.Lector["ProductoID"] is DBNull))
                        Producto.ProductoID = Convert.ToInt32(datos.Lector["ProductoID"]);

                    if (!(datos.Lector["Nombre"] is DBNull))
                        Producto.Nombre = (string)datos.Lector["Nombre"];

                    if (!(datos.Lector["Precio"] is DBNull))
                        Producto.Precio = Convert.ToSingle(datos.Lector["Precio"]);

                    if (!(datos.Lector["Descripcion"] is DBNull))
                        Producto.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["Categoria"] is DBNull))
                    {
                        Producto.CategoriaID = new Categorias();
                        Producto.CategoriaID.Nombre = (string)datos.Lector["Categoria"];

                        if (!(datos.Lector["CategoriaID"] is DBNull))
                            Producto.CategoriaID.CategoriaID = Convert.ToInt32(datos.Lector["CategoriaID"]);
                    }

                    if (!(datos.Lector["Marca"] is DBNull))
                    {
                        Producto.MarcaID = new Marcas();
                        Producto.MarcaID.Nombre = (string)datos.Lector["Marca"];

                        if (!(datos.Lector["MarcaID"] is DBNull))
                            Producto.MarcaID.MarcaID = Convert.ToInt32(datos.Lector["MarcaID"]);
                    }

                    List<ImagenProducto> img = IMGnegocio.listarImagenes(Producto.ProductoID);
                    if (img.Count > 0)
                        Producto.ListImagenes = img;
                    list.Add(Producto);

                }

                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al listar artículos: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void AltaProducto(string Nombre, string Marca, float Precio, int Stock, string Descripcion, string Categoria, 
                                                         bool Activo )
        {
            try
            {
                int CategoriaID = Cat.BuscarIdCat(Categoria);
                int MarcaID = Mar.BuscarIdMarca(Marca);
                
                string consulta = @"INSERT INTO Productos (Nombre, MarcaID, Precio, Stock, Descripcion, CategoriaID, Estado) 
                                   VALUES (@Nombre, @MarcaID, @Precio, @Stock, @Descripcion, @CategoriaID, @Activo)";


                datos.setearConsulta(consulta);
                datos.setearParametro("@Nombre", Nombre);
                datos.setearParametro("@MarcaID", MarcaID);
                datos.setearParametro("@Precio", Precio);
                datos.setearParametro("@Stock", Stock);
                datos.setearParametro("@Descripcion", Descripcion);
                datos.setearParametro("@CategoriaID", CategoriaID);
                datos.setearParametro("@Activo", Activo);
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

        public List<Productos> ListarArticulosConSP()
        {
            list = new List<Productos>();
            try
            {
                string consulta = @"storedListarProductos";

                datos.setearProcedimiento(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Productos Producto = new Productos();


                    if (!(datos.Lector["ProductoID"] is DBNull))
                        Producto.ProductoID = Convert.ToInt32(datos.Lector["ProductoID"]);

                    if (!(datos.Lector["Nombre"] is DBNull))
                        Producto.Nombre = (string)datos.Lector["Nombre"];

                    if (!(datos.Lector["Precio"] is DBNull))
                        Producto.Precio = Convert.ToSingle(datos.Lector["Precio"]);

                    if (!(datos.Lector["Descripcion"] is DBNull))
                        Producto.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["Categoria"] is DBNull))
                    {
                        Producto.CategoriaID = new Categorias();
                        Producto.CategoriaID.Nombre = (string)datos.Lector["Categoria"];

                        if (!(datos.Lector["CategoriaID"] is DBNull))
                            Producto.CategoriaID.CategoriaID = Convert.ToInt32(datos.Lector["CategoriaID"]);
                    }

                    if (!(datos.Lector["Marca"] is DBNull))
                    {
                        Producto.MarcaID = new Marcas();
                        Producto.MarcaID.Nombre = (string)datos.Lector["Marca"];

                        if (!(datos.Lector["MarcaID"] is DBNull))
                            Producto.MarcaID.MarcaID = Convert.ToInt32(datos.Lector["MarcaID"]);
                    }

                    List<ImagenProducto> img = IMGnegocio.listarImagenes(Producto.ProductoID);
                    if (img.Count > 0)
                        Producto.ListImagenes = img;
                    list.Add(Producto);

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

        public List<Productos> ListarArticulosPorID(string ID)
        {
            list = new List<Productos>();
            try
            {
                string consulta = @"SELECT P.ProductoID as ProductoID, P.Nombre, M.Nombre AS Marca, P.Precio, P.Descripcion, 
                                   C.Nombre AS Categoria, P.MarcaID, C.CategoriaID
                            FROM Productos AS P
                            LEFT JOIN Marcas AS M ON M.MarcaID = P.MarcaID
                            LEFT JOIN Categorias AS C ON C.CategoriaID = P.CategoriaID
                            WHERE P.Estado = 1 AND P.Stock > 1";

                consulta += " and P.ProductoID = " + ID;
                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Productos Producto = new Productos();


                    if (!(datos.Lector["ProductoID"] is DBNull))
                        Producto.ProductoID = Convert.ToInt32(datos.Lector["ProductoID"]);

                    if (!(datos.Lector["Nombre"] is DBNull))
                        Producto.Nombre = (string)datos.Lector["Nombre"];

                    if (!(datos.Lector["Precio"] is DBNull))
                        Producto.Precio = Convert.ToSingle(datos.Lector["Precio"]);

                    if (!(datos.Lector["Descripcion"] is DBNull))
                        Producto.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["Categoria"] is DBNull))
                    {
                        Producto.CategoriaID = new Categorias();
                        Producto.CategoriaID.Nombre = (string)datos.Lector["Categoria"];

                        if (!(datos.Lector["CategoriaID"] is DBNull))
                            Producto.CategoriaID.CategoriaID = Convert.ToInt32(datos.Lector["CategoriaID"]);
                    }

                    if (!(datos.Lector["Marca"] is DBNull))
                    {
                        Producto.MarcaID = new Marcas();
                        Producto.MarcaID.Nombre = (string)datos.Lector["Marca"];

                        if (!(datos.Lector["MarcaID"] is DBNull))
                            Producto.MarcaID.MarcaID = Convert.ToInt32(datos.Lector["MarcaID"]);
                    }

                    List<ImagenProducto> img = IMGnegocio.listarImagenes(Producto.ProductoID);
                    if (img.Count > 0)
                        Producto.ListImagenes = img;
                    list.Add(Producto);

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

        public void Modificar(string Nombre, string Marca, float Precio, int Stock, string Descripcion, string Categoria,
                                                         bool Estado, int ProductoID)
        {
            try
            {
                int CategoriaID = Cat.BuscarIdCat(Categoria);
                int MarcaID = Mar.BuscarIdMarca(Marca);

                string consulta = "storedModificarProducto";


                datos.setearProcedimiento(consulta);
                datos.setearParametro("@ProductoID", ProductoID);
                datos.setearParametro("@Nombre", Nombre);
                datos.setearParametro("@MarcaID", MarcaID);
                datos.setearParametro("@Precio", Precio);
                datos.setearParametro("@Stock", Stock);
                datos.setearParametro("@Descripcion", Descripcion);
                datos.setearParametro("@CategoriaID", CategoriaID);
                datos.setearParametro("@Estado", Estado);
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
