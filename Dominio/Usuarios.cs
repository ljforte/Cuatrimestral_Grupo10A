﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuarios
    {
        public int UsuarioID { get; set; }
        public string? Nombre {  get; set; }
        public string? Email {  get; set; }
        public string? UsuarioPassword {  get; set; }
        public string? Rol {  get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Estado {  get; set; }
    }
}
