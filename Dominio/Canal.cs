using System;

namespace Dominio
{
    public class Canal
    {
        #region atributos
            private static int internalID;
            private int Id;

            public string Nombre { get; set; }
            public Resolucion Resolucion { get; set; }
            public bool MultiLenguaje { get; set; }
            public decimal Precio { get; set; }
        #endregion atributos

        public Canal(string nombre, Resolucion resolucion, bool multilenguaje, decimal precio)
        {
            Id = ++internalID;
            Nombre = nombre;
            Resolucion = resolucion;
            MultiLenguaje = multilenguaje;
            Precio = precio;
        }

        public Canal(int id, string nombre, Resolucion resolucion, bool multilenguaje, decimal precio)
        {
            Id = ++internalID;
            Nombre = nombre;
            Resolucion = resolucion;
            MultiLenguaje = multilenguaje;
            Precio = precio;
        }

        public Canal ClonarCanal()
        {
            Canal canalAux = new Canal(Id, Nombre, Resolucion, MultiLenguaje, Precio);

            return canalAux;

        }


        public static bool ValidarPrecio(decimal precio)
        {
            return precio > 0;
        }

        public static bool ValidarNombre(string nombre)
        {
            return nombre.Length > 3;
        }

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
