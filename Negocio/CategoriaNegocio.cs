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

namespace Negocio
{
    internal class CategoriaNegocio
    {
        private AccesoDatos datos = new AccesoDatos();
        private List<Categorias> list;

        public List<Categorias> ListarCateogiras()
        {
            list = new List<Categorias>();

            try
            {
                string consulta = @"
                                select Nombre from Categorias;
                                ";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Categorias categoria = new Categorias();

                    if (!(datos.Lector["Nombre"] is DBNull))
                        categoria.Nombre = (string)datos.Lector["Nombre"];
                    list.Add(categoria);
                }
                return list;
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



    }
}
