using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class PedidoNegocio
    {
        public List<Pedidos> lista { get; set; }
        public List<Pedidos> ListarPedidos()
        {
            return lista;
        } 
    }
}
