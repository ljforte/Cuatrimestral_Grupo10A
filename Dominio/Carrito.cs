using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Carrito
    {
        public int UsuarioID {  get; set; }
        public int CarritoID {  get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<CarritoDetalle> Detalles { get; set; } = new List<CarritoDetalle>();

        public float Total
        {
            get { return Detalles.Sum(d => d.PrecioUnitario * d.Cantidad); }
        }

        Productos producto { get; set; }
    }
}
