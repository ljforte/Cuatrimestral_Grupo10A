using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class DetallePagoTarjetaNegocio
    {

        public void GuardarPago(DetallePagoTarjeta detallePago)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = @"
                    INSERT INTO DetallePagoTarjeta (NumeroTarjeta, CodigoSeguridad, NombreTarjeta, FechaVencimiento, PedidoID)
                    VALUES (@NumeroTarjeta, @CodigoSeguridad, @NombreTarjeta, @FechaVencimiento, @PedidoID)";
                datos.setearConsulta(consulta);
                datos.setearParametro("@NumeroTarjeta", detallePago.NumeroTarjeta);
                datos.setearParametro("@CodigoSeguridad", detallePago.CodigoSeguridad);
                datos.setearParametro("@NombreTarjeta", detallePago.NombreTarjeta);
                datos.setearParametro("@FechaVencimiento", detallePago.FechaVencimiento);
                datos.setearParametro("@PedidoID", detallePago.PedidoID);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw new Exception("Error al guardar el detalle de pago con tarjeta", ex);
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
