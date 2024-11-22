using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                datos.setearConsulta("insert into Marcas (Nombre) VALUES ('" + marca + "')");
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

        public Marcas BuscarDatosMarca(string ID)
        {
            try
            {
                datos.setearConsulta("select * from Marcas where MarcaID = '" + ID + "'");
                datos.ejecutarLectura();

                    Marcas marca = new Marcas();
                if (datos.Lector.Read())
                {
                    if (!(datos.Lector["MarcaID"] is DBNull))
                        marca.MarcaID = (int)datos.Lector["MarcaID"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        marca.Nombre = datos.Lector["Nombre"].ToString();
                    return marca;
                }
                else
                {
                    return marca;
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

        public bool BuscarProductoConMarca(string MarcaID)
        {
            try
            {
                datos.setearConsulta("select * from Productos P join Marcas M on M.MarcaID =  P.MarcaID where M.MarcaID =" + MarcaID);
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

        public bool ModificarMarca(string MarcaID, string Nombre)
        {
            try
            {
                datos.setearConsulta("UPDATE Marcas SET Nombre = @Nombre WHERE MarcaID = @MarcaID");
                datos.setearParametro("@Nombre", Nombre);
                datos.setearParametro("@MarcaID", MarcaID);
                datos.ejecutarAccion();

                datos.cerrarConexion();

                datos.setearConsulta("SELECT 1 FROM Marcas WHERE MarcaID = @MarcaID AND Nombre = @Nombre"); 
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    return true;
                }
                else { return false; }

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
