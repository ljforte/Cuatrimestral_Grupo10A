using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{

    public class Pedidos
    {
        public int PedidoID {  get; set; }
        public int UsuarioID {  get; set; }
        public DateTime FechaPedido {  get; set; }
        public Estado Estado { get; set; }
        public float Total { get; set; }
    }
}
