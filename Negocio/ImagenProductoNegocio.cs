using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using static System.Net.Mime.MediaTypeNames;
namespace Negocio
{
    public class ImagenProductoNegocio
    {
        private AccesoDatos datos = new AccesoDatos();
        private List<ImagenProducto> list;

        public List<ImagenProducto> listarImagenes(int id)
        {
            list = new List<ImagenProducto>();

            datos.setearConsulta("select I.ImagenID as ImagenID,I.ProductoID as ProductoID, I.ImagenURL as ImagenURL from ImagenProducto I join Productos P on P.ProductoID = I.ProductoID where I.ProductoID = " + id);
            try
            {
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    int ProductoID = (int)datos.Lector["ProductoID"];
                    if (ProductoID == id)
                    {
                        ImagenProducto img = new ImagenProducto();
                        img.ImagenID = (int)datos.Lector["ImagenID"];
                        img.ProductoID= ProductoID;
                        img.ImagenURL = (string)datos.Lector["imagenURL"];
                        list.Add(img);
                    }
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