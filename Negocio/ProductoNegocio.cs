using System;
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
        private Productos prod = new Productos();

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


        public List<Productos> ListarArticulosPorCategoria(string Categoria)
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
                                                         bool Activo)
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
                int ProductoID = Convert.ToInt32(ID);
                string consulta = @"SELECT P.ProductoID as ProductoID, P.Nombre, M.Nombre AS Marca, P.Precio, P.Descripcion, 
                                   C.Nombre AS Categoria, P.MarcaID, C.CategoriaID, P.Stock as Stock
                            FROM Productos AS P
                            LEFT JOIN Marcas AS M ON M.MarcaID = P.MarcaID
                            LEFT JOIN Categorias AS C ON C.CategoriaID = P.CategoriaID ";
                if (ID!="") consulta += " WHERE P.ProductoID = "+ ProductoID;
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
                    if (!(datos.Lector["Stock"] is DBNull))
                        Producto.stock = (int)datos.Lector["Stock"];

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

        public void Modificar(Productos prod)
        {
            try
            {

                string consulta = "storedModificarProducto";
                datos.setearProcedimiento(consulta);
                datos.setearParametro("@Nombre", prod.Nombre);
                datos.setearParametro("@MarcaID", prod.MarcaID.MarcaID);
                datos.setearParametro("@Precio", prod.Precio);
                datos.setearParametro("@Stock", prod.stock);
                datos.setearParametro("@Descripcion", prod.Descripcion);
                datos.setearParametro("@CategoriaID", prod.CategoriaID.CategoriaID);
                datos.setearParametro("@Estado", prod.Estado);
                datos.setearParametro("@ProductoID", prod.ProductoID);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw new Exception("Error al modificar el producto", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        //FILTRA POR DESCRIPCION O MARCA
        public List<Productos> Filtrar(string nombre)
        {
            list = new List<Productos>();
            try
            {
                string consulta = @"
            SELECT P.ProductoID, P.Nombre, M.Nombre AS Marca, P.Precio, P.Descripcion, 
                   C.Nombre AS Categoria, P.MarcaID, C.CategoriaID
            FROM Productos AS P
            LEFT JOIN Marcas AS M ON M.MarcaID = P.MarcaID
            LEFT JOIN Categorias AS C ON C.CategoriaID = P.CategoriaID
            WHERE P.Estado = 1 AND P.Stock > 1
            AND P.Descripcion LIKE @Nombre
            OR M.Nombre LIKE @Nombre";
                //AND P.Descripcion LIKE '%emoria%'

                datos.setearConsulta(consulta);
                datos.setearParametro("@Nombre", "%" + nombre + "%");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Productos producto = new Productos();
                    if (!(datos.Lector["ProductoID"] is DBNull))
                        producto.ProductoID = Convert.ToInt32(datos.Lector["ProductoID"]);
                    if (!(datos.Lector["Nombre"] is DBNull))
                        producto.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Precio"] is DBNull))
                        producto.Precio = Convert.ToSingle(datos.Lector["Precio"]);
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        producto.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["Categoria"] is DBNull))
                    {
                        producto.CategoriaID = new Categorias();
                        producto.CategoriaID.Nombre = (string)datos.Lector["Categoria"];
                    }
                    if (!(datos.Lector["Marca"] is DBNull))
                    {
                        producto.MarcaID = new Marcas();
                        producto.MarcaID.Nombre = (string)datos.Lector["Marca"];
                    }

                    List<ImagenProducto> img = IMGnegocio.listarImagenes(producto.ProductoID);
                    if (img.Count > 0)
                        producto.ListImagenes = img;

                    list.Add(producto);
                }
                return list;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al filtrar productos por nombre: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public int ObtenerIdProducto(string nombre)
        {
            int productoID = -1;
            try
            {
                string consulta = @" SELECT ProductoID FROM Productos WHERE Nombre = @Nombre";
                datos.setearConsulta(consulta);
                datos.setearParametro("@Nombre", nombre);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    if (!(datos.Lector["ProductoID"] is DBNull))
                    {
                        productoID = Convert.ToInt32(datos.Lector["ProductoID"]);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener el ID del producto: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
            return productoID;
        }
    }
}
