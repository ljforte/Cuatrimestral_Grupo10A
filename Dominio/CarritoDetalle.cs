using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CarritoDetalle
    {
        public int CarritoDetalleID { get; set; }
        public int CarritoID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public float PrecioUnitario {get;set;}
    }
}
