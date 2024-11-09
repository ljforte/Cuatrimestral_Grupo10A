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
                                select Nombre, MarcaID from Marcas;
                                ";

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Marcas marca = new Marcas();

                    if (!(datos.Lector["Nombre"] is DBNull))
                        marca.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["MarcaID"] is DBNull))
                        marca.MarcaID = (int)datos.Lector["MarcaID"];
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
                 datos.setearConsulta("insert into Marcas (Nombre) VALUES ('"+ marca +"')");
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

        public bool BuscarMarca(string marca)
        {
            try
            {
                datos.setearConsulta("select * from Marcas where Nombre = '" + marca + "'");
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
        public int BuscarIdMarca(string mar)
        {
            try
            {
                datos.setearConsulta("select MarcaID from Marcas where Nombre = '" + mar + "'");
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    Marcas marca = new Marcas();
                    if (!(datos.Lector["MarcaID"] is DBNull))
                        marca.MarcaID = (int)datos.Lector["MarcaID"];
                    return marca.MarcaID;
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

        public bool EliminarMarca(int id)
        {
            try
            {

            datos.setearConsulta("delete from Marcas where MarcaID = @ID ");
            datos.setearParametro("@ID", id);
            datos.ejecutarAccion();
                return true;
            }
            catch (Exception ex)
            {
                return false;
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
