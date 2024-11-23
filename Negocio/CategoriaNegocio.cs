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
using System.Collections.Generic;
using System.Xml.Linq;

namespace Negocio
{
    public class CategoriaNegocio
    {
        private AccesoDatos datos = new AccesoDatos();
        private List<Categorias> list;

        public List<Categorias> ListarCategorias()
        {
            list = new List<Categorias>();

            try
            {
                string consulta = @"SELECT 
                    c.CategoriaID,
                    c.Nombre AS Nombre,
                    c.Descripcion AS Descripcion,
                    (SELECT TOP 1 i.ImagenURL 
                    FROM Productos p 

                    JOIN ImagenProducto i ON p.ProductoID = i.ProductoID 

                    WHERE p.CategoriaID = c.CategoriaID) AS ImagenURL

                    FROM Categorias c";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Categorias categoria = new Categorias();

                    if (!(datos.Lector["CategoriaID"] is DBNull))
                        categoria.CategoriaID = (int)datos.Lector["CategoriaID"];

                    if (!(datos.Lector["Nombre"] is DBNull))
                        categoria.Nombre = (string)datos.Lector["Nombre"];

                    if (!(datos.Lector["Descripcion"] is DBNull))
                        categoria.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["ImagenURL"] is DBNull))
                        categoria.ImagenURL = (string)datos.Lector["ImagenURL"];
                    else
                        categoria.ImagenURL = "./Imagenes/ImagenNoEncontrada.jpeg";


                    list.Add(categoria);
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

        public bool EliminarCat(int Id)
        {
            try
            {
                // if (TieneProductoConStock(Id)) return false;

                datos.setearConsulta("delete from Categorias where CategoriaID = @id");
                datos.setearParametro("@id", Id);

                datos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
            finally
            {
                datos.cerrarConexion();
            }


        }
        private bool TieneProductoConStock(int Id)
        {
            datos.setearConsulta("SELECT COUNT(*) FROM Productos WHERE CategoriaID = @id AND Stock > 0");
            datos.setearParametro("@id", Id);
            int count = datos.ejecutarAccionScalar();

            return count > 0;
        }
        public ImagenProducto ObtenerImagen()
        {

            ImagenProducto imagen = new ImagenProducto();
            try

            {

            }
            finally
            {

            }
            return new ImagenProducto();
        }

        public void AgregarCategoria(string cat, string desc)
        {
            try
            {
                datos.setearConsulta("insert into Categorias (Nombre, Descripcion) VALUES ('" + cat + "', '" + desc + "')");
                datos.ejecutarAccion();
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

        public bool BuscarCat(string cat)
        {
            try
            {
                datos.setearConsulta("select * from Categorias where Nombre = '" + cat + "'");
                datos.ejecutarLectura();
                if (datos.Lector.Read())
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
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
        public int BuscarIdCat(string cat)
        {
            try
            {
                datos.setearConsulta("select CategoriaID from Categorias where Nombre = '" + cat + "'");
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Categorias categoria = new Categorias();

                    if (!(datos.Lector["CategoriaID"] is DBNull))
                        categoria.CategoriaID = (int)datos.Lector["CategoriaID"];
                    return categoria.CategoriaID;
                }
                else
                {
                    return 0;
                }

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
        public Categorias BuscarCategoria(String Id) {
            try
            {
                datos.setearConsulta("select * from Categorias where CategoriaID = '" + Id + "'");
                datos.ejecutarLectura();

                Categorias categoria = new Categorias();
                if (datos.Lector.Read())
                {
                    if (!(datos.Lector["CategoriaID"] is DBNull))
                        categoria.CategoriaID = (int)datos.Lector["CategoriaID"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        categoria.Nombre = datos.Lector["Nombre"].ToString();
                    return categoria;
                }
                else
                {
                    return categoria;
                }

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

        public bool modificar(string idCategoria, string Nombre, string Descripcion)
        {
            try
            {
                datos.setearConsulta("UPDATE Categorias SET Nombre=@Nombre, Descripcion=@Descripcion WHERE CategoriaID=@idCategoria");
                datos.setearParametro("@Nombre", Nombre);
                datos.setearParametro("@Descripcion", Descripcion);
                datos.setearParametro("@idCategoria", idCategoria);
                datos.ejecutarAccion();

                //datos.setearConsulta("SELECT 1 FROM Marcas WHERE MarcaID = @MarcaID AND Nombre = @Nombre");
                //datos.ejecutarLectura();
                return true;

            }
            catch (Exception ex)
            {
                throw new Exception("Error al Modificar las Categorias: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
            return false;
        }

        public bool ExisteCategoria(string nombre)
        {
            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Categorias WHERE Nombre = @Nombre");
                datos.setearParametro("@Nombre", nombre);
                datos.ejecutarLectura();

                if (datos.Lector.Read() && Convert.ToInt32(datos.Lector[0]) > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al verificar la existencia de la categoría: " + ex.Message, ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
