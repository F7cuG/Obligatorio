﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Obligatorio
{
    public static class BaseDeDatos
    {
        static public List<Cliente> listaClientes = new List<Cliente>();
        public static List<Tecnico> listaTecnicos
        {
            get
            {
                if (HttpContext.Current.Session["listaTecnicos"] == null)
                {
                    HttpContext.Current.Session["listaTecnicos"] = new List<Tecnico>();
                }
                return (List<Tecnico>)HttpContext.Current.Session["listaTecnicos"];
            }
            set
            {
                HttpContext.Current.Session["listaTecnicos"] = value;
            }
        }

        static public List<OrdenDeTrabajo> listaOrdenesDeTrabajo = new List<OrdenDeTrabajo>();

        public static List<Usuario> listaUsuarios = new List<Usuario>
        {
            new Usuario {NombreUsuario = "admin", Contraseña = "12345" },
            new Usuario {NombreUsuario = "tecnico1", Contraseña = "12345"}
        };

    }


}