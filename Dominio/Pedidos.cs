using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{

    public class Pedidos
    {
        public int PedidoID { get; set; }
        public string NombreCliente { get; set; }
        public DateTime FechaPedido { get; set; }
        public string Estado { get; set; }
        public float Total { get; set; }
    }
}
