using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class User
    {

        //cliente


        public const string ROL_CLIENTE = "Cliente";
        public const string ROL_OPERADOR = "Operador";

        public string GetRolCliente()
        {
            return ROL_CLIENTE;
        }

        public string GetRolOperador()
        {
            return ROL_OPERADOR;
        }

        public int Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }

        private string nombreUsuario;
        public string NombreUsuario { get { return nombreUsuario; }  }
   
        public string Password { get; set; }

        //Cliente/Operador
        public string Rol { get; set; }


        public User() { }

        // crear usuario operador
        // -> new User(nombre,password,"Operador")
        public User(string nombre, string password,string rol)
        {
            Cedula = -1;
            Nombre = nombre;
            Apellido = null;
            Password = password;
            Rol = rol;

            nombreUsuario = nombre;
        }

        // crear usuario cliente
        // -> new USer(cedula,nombre,apellido,password,"Cliente")
        public User(int cedula, string nombre, string apellido, string password,string rol)
        {
            Cedula = cedula;
            Nombre = nombre;
            Apellido = apellido;
            Password = password;
            Rol = rol;
            nombreUsuario = cedula.ToString();
        }

        //La cédula será un numérico de entre 7 y 9 dígitos
        public static bool ValidarCedula(int cedula)
        {
            string cedulaStr = cedula.ToString();
            return cedulaStr.Length >= 7 && cedulaStr.Length <= 9;
        }

        public static bool ValidarNombreApellido(string nombre)
        {
            return nombre.Length >= 2;
        }

        public static bool ValidarPassword(string password)
        {
            if (password.Length < 6)
            {
                return false;
            }

            bool mayuscula = false;
            bool minuscula = false;
            bool digito = false;
            int i = 0;

            while ( !(mayuscula && minuscula && digito) && i < password.Length)
            {
                if (Char.IsUpper(password[i]))
                {
                    mayuscula = true;
                }
                if(Char.IsLower(password[i]))
                {
                    minuscula = true;
                }

                if(Char.IsDigit(password[i])) {
                    digito = true;
                }
                i++;
            }

            // si no tiene mayuscula o no tiene minuscula o no tiene digito => me voy
            if (!mayuscula || !minuscula || !digito)
            {
                return false;
            }


            return true;


        }
    }



}
