using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Negocio
{
    public class EstadoNegocio
    {
        public List<Estado> Lista = new List<Estado>();
        public Estado Estado;
        AccesoDatos datos = new AccesoDatos();

        public List<Estado> ListarEstados()
        {
            try
            {
                datos.setearConsulta("select * from EstadoPedido");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Estado = new Estado();
                    if (!(datos.Lector["EstadoID"] is DBNull))
                        Estado.Id = (int)datos.Lector["EstadoID"];

                    if (!(datos.Lector["Descripcion"] is DBNull))
                        Estado.Descripcion = (string)datos.Lector["Descripcion"];

                    Lista.Add(Estado);
                }
                return Lista;
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
