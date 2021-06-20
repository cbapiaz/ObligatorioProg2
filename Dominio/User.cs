using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class User : IComparable
    {

        //cliente

        #region fields

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

        public List<Compra> Compras { get; set; }

        #endregion

        #region constructors
        public User() {
            Compras = new List<Compra>();
        }

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
            Compras = new List<Compra>();
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
            Compras = new List<Compra>();

        }

      
        #endregion

        #region methods
        //La cédula será un numérico de entre 7 y 9 dígitos
        public static bool ValidarCedula(int cedula)
        {
            string cedulaStr = cedula.ToString();
            return cedulaStr.Length >= 7 && cedulaStr.Length <= 9;
        }

        //validacion para nombre y apellido
        public static bool ValidarNombreApellido(string val)
        {
            return val.Length >= 2;
        }

        //validar consistencia de la constraseña
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

        public bool AgregarCompra(Compra compra)
        {
            Compras.Add(compra);
            return true;
        }

        public string GetCompras()
        {
            var res = "";
            foreach(var c in Compras)
            {
                res += c.GetDetalleCompra() + " | ";
            }
            return res;
        }


        /// <summary>
        /// dado una cantidad de dias retorna true si el cliente tiene compras que vencen en esos dias
        /// </summary>
        /// <param name="ultimosDias"></param>
        /// <returns></returns>
        internal bool TieneCompraUltimosDias(int ultimosDias)
        {
            bool res = false;
            foreach (var compra in Compras)
            {
                double diffDias = (DateTime.Now.AddDays(ultimosDias) - compra.FechaVencimiento).TotalDays;
                diffDias = Math.Abs(diffDias);
                if (diffDias >= 0 && diffDias <= ultimosDias)
                {
                    res = true;
                }
            }
            return res;
        }

        public int CompareTo(object obj)
        {
            User anotherU = (User)obj;
            var index = String.Compare(this.Apellido, anotherU.Apellido);

            if (index == 0)
            {
               index= String.Compare(this.Nombre, anotherU.Nombre);
            } 
            return index;
            
        }


        #endregion
    }
}
