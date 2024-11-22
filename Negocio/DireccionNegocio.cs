using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using negocio;

namespace Negocio
{
    public class DireccionNegocio
    {
        AccesoDatos datos = new AccesoDatos();

        public List<Direcciones> BuscarDireccionesPorUsuario(int usuarioID)
        {

            List<Direcciones> listDirecciones = new List<Direcciones>();
            try
            {
                string consulta = @"select
                                    d.Calle as Calle,
                                    d.Ciudad as Ciudad,
                                    d.Telefono as Telefono,
                                    d.CodigoPostal as CodigoPostal,
									u.UsuarioID as Usuario
                                    FROM Direcciones d                                      
                                    INNER JOIN Usuarios u ON  u.UsuarioID = d.UsuarioID 
                                    WHERE d.UsuarioID = @UsuarioID";

                datos.setearConsulta(consulta);
                datos.setearParametro("@UsuarioID", usuarioID);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Direcciones dire = new Direcciones
                    {
                        Calle = (string)datos.Lector["Calle"],
                        Ciudad = (string)datos.Lector["Ciudad"],
                        Telefono = (int)datos.Lector["Telefono"],
                        CodigoPostal = (string)datos.Lector["CodigoPostal"]
                    };
                    listDirecciones.Add(dire);
                }

                return listDirecciones;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al cargar libreta de direcciones", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }

        }


        public Direcciones BuscarDireccionPorID(int direccionID)
        {
            try
            {
                Direcciones direccion = null;

                string consulta = @"SELECT 
                                Calle, 
                                Ciudad, 
                                Telefono, 
                                CodigoPostal, 
                                UsuarioID 
                            FROM Direcciones 
                            WHERE DireccionID = @DireccionID";

                datos.setearConsulta(consulta);
                datos.setearParametro("@DireccionID", direccionID);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    direccion = new Direcciones
                    {
                        Calle = (string)datos.Lector["Calle"],
                        Ciudad = (string)datos.Lector["Ciudad"],
                        Telefono = Convert.ToInt32(datos.Lector["Telefono"]),
                        CodigoPostal = (string)datos.Lector["CodigoPostal"],
                        UsuarioID = Convert.ToInt32(datos.Lector["UsuarioID"])
                    };
                }

                return direccion;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al buscar dirección por ID", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}

