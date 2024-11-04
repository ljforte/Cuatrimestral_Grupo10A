using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Dominio;
namespace Negocio
{
    public class MarcasNegocio
    {
        private AccesoDatos datos = new AccesoDatos();
        private List<Marcas> list;

        public List<Marcas> ListarMarcas()
        {
            list = new List<Marcas>();

            try
            {
                string consulta = @"
                                select Nombre from Marcas;
                                ";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Marcas marca = new Marcas();

                    if (!(datos.Lector["Nombre"] is DBNull))
                        marca.Nombre = (string)datos.Lector["Nombre"];
                    list.Add(marca);
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

       public void AgregarMarca(string marca)
        {
            try
            {
                 datos.setearConsulta("insert into Marcas (Nombre) VALUES (' "+ marca +"')");
               // datos.setearConsulta("insert into Marcas (Nombre) VALUES ('Asrock')");
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
    }
}
