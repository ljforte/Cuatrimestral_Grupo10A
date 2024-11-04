using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoUsuario
    {
        Cliente = 1,
        Admin= 2,

    }
    public class Usuarios
    {
        public int UsuarioID { get; set; }
        public string Nombre {  get; set; }
        public string Apellido { get; set; }
        public int Genero { get; set; }
        Direcciones Direccion { get; set; }
        public string Email {  get; set; }
        public string UsuarioPassword {  get; set; }
        public TipoUsuario Tipo { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Estado {  get; set; }

        public Usuarios(string mail, string pass)
        {
            Email = mail;
            UsuarioPassword = pass;
        }
    }
}
