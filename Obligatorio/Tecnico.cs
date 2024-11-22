using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio
{
    public class Tecnico
    {
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string CI { get; set; }
        public string Especialidad { get; set; }

        public Tecnico(string nombre, string apellido, string ci, string especialidad)
        {
            this.Nombre = nombre;
            this.Apellido = apellido; 
            this.CI = ci;
            this.Especialidad = especialidad;
        }

        public string nombreCompletoTec
        {
            get {return Nombre + " " + Apellido;}
        }
    }
}