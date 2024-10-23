using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Direcciones
    {
        public int DireccionID {  get; set; }
        public int UsuarioID {  get; set; }
        public string Calle {  get; set; }
        public string Ciudad {  get; set; }
        public string CodigoPostal { get; set; }
        public string Pais {  get; set; }
        public string Telefono {  get; set; }
    }
}
