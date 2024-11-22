using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class DetallePagoTarjeta
    {
        public int DetallePagoID { get; set; }        
        public int NumeroTarjeta { get; set; }       
        public int CodigoSeguridad { get; set; }      
        public string NombreTarjeta { get; set; }     
        public DateTime FechaVencimiento { get; set; }
        public int PedidoID { get; set; }
    }
}
