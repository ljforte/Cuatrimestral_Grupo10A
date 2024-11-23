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
        public Usuarios Usuario{ get; set; }
        public Direcciones Direcciones { get; set; }
        public DateTime FechaPedido { get; set; }
        public EstadoPedido Estado { get; set; }
        public string EstadoPedido { get; set; }
        public List<PedidosDetalle> Detalles { get; set; } = new List<PedidosDetalle>();
        public float Total { get; set; }
        public string NombreCliente { get; set; }
        public Pago MetodoDePago { get; set; }
    }

    public enum Pago
    {
        Efectivo,
        Tarjeta
    }
    public enum EstadoPedido
    {
        Envio,
        Retiro,
        Entregado,
        NoData
    }
}
