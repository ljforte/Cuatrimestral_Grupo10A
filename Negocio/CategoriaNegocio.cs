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

                    if (!(datos.Lector["Nombre"] is DBNull))
                        categoria.Nombre = (string)datos.Lector["Nombre"];

                    if (!(datos.Lector["Descripcion"] is DBNull))
                        categoria.Descripcion = (string)datos.Lector["Descripcion"];



                    if (!(datos.Lector["ImagenURL"] is DBNull))
                        categoria.ImagenURL = (string)datos.Lector["ImagenURL"];

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

    }
}
