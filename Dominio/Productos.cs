using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Productos
    {
        public int ProductoID {  get; set; }
        public string Nombre {  get; set; }
        [DisplayName("Marcas")]
        public Marcas MarcaID {  get; set; }
        public string Descripcion {  get; set; }
        public float Precio {  get; set; }
        public int stock {  get; set; }
        [DisplayName("Categorias")]
        public List<ImagenProducto> ListImagenes {  get; set; }
        public Categorias CategoriaID {  get; set; }
        public bool Estado { get; set; }
    }
}
