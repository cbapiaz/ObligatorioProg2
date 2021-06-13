using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    class User
    {
        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contrasena { get; set; }

        public User()
        {

        }

        public User(string cedula, string nombre, string apellido, string contrasena)
        {
            Cedula = cedula;
            Nombre = nombre;
            Apellido = apellido;
            Contrasena = contrasena;
        }
    }
}
