using System;

namespace Dominio
{
    public class Canal
    {
        private static int internalID;
        private int Id;

        public string Nombre { get; set; }
        public Resolucion Resolucion { get; set; }
        public bool MultiLenguaje { get; set; }
        public decimal Precio { get; set; }

        public Canal(string nombre,Resolucion resolucion,bool multilenguaje,decimal precio )
        {
            Id = ++internalID;
            Nombre = nombre;
            Resolucion = resolucion;
            MultiLenguaje = multilenguaje;
            Precio = precio;
        }


        /*LO hace ceci
            public static bool ValidarPrecio()
            {
            }

            public static bool ValidarNombre()
            {
            }

        public static bool 

        */

        public override string ToString()
        {
            return $"Nombre {Nombre} | Resolucion {(int)Resolucion} | MultiLenguaje: {MultiLenguaje} | Precio: {Precio}";
        }

    }

    public enum Resolucion : int
    {
        RES1 = 576,
        RES2 = 1080
    }
}
