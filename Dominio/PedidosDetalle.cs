using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PedidosDetalle
    {
        public int PedidoDetalleID { get; set; }
        public int PedidoID { get; set; }
        public int ProductoID { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public Productos producto { get; set; }
    }
}