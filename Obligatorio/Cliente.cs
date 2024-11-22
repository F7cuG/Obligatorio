using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio
{
    public class Cliente
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CI { get; set; }
        public string Direccion { get; set; }
        public long  Telefono { get; set; }
        public string Email { get; set; }

        public Cliente(string nombre,string apellido, string ci, string direccion,long telefono, string email="email x def")
        {
            this.Nombre = nombre;  
            this.Apellido = apellido;
            this.CI = ci;
            this.Direccion = direccion;  
            this.Telefono = telefono;   
            this.Email = email;  
        }

        public string nombreCompletoCli
        {
            get { return Nombre + " " + Apellido; }
        }

        
    }
}