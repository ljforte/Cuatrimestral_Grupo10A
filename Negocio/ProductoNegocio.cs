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

        public List<Productos> ListarArticulos()
        {
            list = new List<Productos>();
            try
            {
                string consulta = @"SELECT P.Nombre, M.Nombre AS Marca, P.Precio, P.Descripcion, 
                                   C.Nombre AS Categoria, P.MarcaID, C.CategoriaID
                            FROM Productos AS P
                            LEFT JOIN Marcas AS M ON M.MarcaID = P.MarcaID
                            LEFT JOIN Categorias AS C ON C.CategoriaID = P.CategoriaID
                            WHERE P.Estado = 1 AND P.Stock > 1";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Productos art = new Productos();

                    if (!(datos.Lector["Nombre"] is DBNull))
                        art.Nombre = (string)datos.Lector["Nombre"];

                    if (!(datos.Lector["Precio"] is DBNull))
                        art.Precio = Convert.ToSingle(datos.Lector["Precio"]);

                    if (!(datos.Lector["Descripcion"] is DBNull))
                        art.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["Categoria"] is DBNull))
                    {
                        art.CategoriaID = new Categorias();
                        art.CategoriaID.Nombre = (string)datos.Lector["Categoria"];

                        if (!(datos.Lector["CategoriaID"] is DBNull))
                            art.CategoriaID.CategoriaID = Convert.ToInt32(datos.Lector["CategoriaID"]);
                    }

                    if (!(datos.Lector["Marca"] is DBNull))
                    {
                        art.MarcaID = new Marcas();
                        art.MarcaID.Nombre = (string)datos.Lector["Marca"];

                        if (!(datos.Lector["MarcaID"] is DBNull))
                            art.MarcaID.MarcaID = Convert.ToInt32(datos.Lector["MarcaID"]);
                    }

                    list.Add(art);
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


    }
}
