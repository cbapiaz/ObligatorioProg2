using Dominio;
using System;

namespace ObligatorioProg2
{
    class Program
    {
        private static Empresa empresa = new Empresa();
        static void Main(string[] args)
        {

            Canal c = new Canal("pepe", Resolucion.BAJA, false, 7878);
            Console.WriteLine(c);

            Console.WriteLine("Canales");
            foreach (var v in empresa.ListarCanales())
            {
                Console.WriteLine(v.ToString());
            }


            Console.WriteLine("Paquetes");

            foreach (var v in empresa.ListarPaquetes())
            {
                Console.WriteLine(v.ToString());
            }

            Mostrar();

            Console.ReadLine();

        }

        public static void Mostrar()
        {
            Console.WriteLine("****************************\nObligatorio - Programación 2\n****************************");
            int salir = -1;
            do
            {
                salir = CrearMenu();


            } while (salir != 0);
        }

        public static int CrearMenu()
        {
            int opcion = -1;

            Console.WriteLine("Menu:");
            Console.WriteLine("1. Ingresar un canal de TV.");
            Console.WriteLine("2. Visualizar todos los paquetes de canales.");
            Console.WriteLine("3.  Modificar el costo fijo de grabación en la nube.");
            Console.WriteLine("4. Mostrar los paquetes con la mayor cantidad de canales.");
            Console.WriteLine("5. Visualizar todos los paquetes de canales.");
            Console.WriteLine("Para salir ingrese '0'.");

            opcion = int.Parse(Console.ReadLine());
        
            return opcion;
        }

        public static void IngresarCanalTV()
        {
            //nombre, resolucion ATLA o BAJA, multilenguaje TRUE, decimal PRECIO
            Console.WriteLine("Ingrese el nombre del canal: ");
            string nombre = Console.ReadLine();

            string resolucionString = "";
            do
            {
                Console.WriteLine("Ingrese la resolucion del canal, 1080 'alta' o 576 'baja': ");
                resolucionString = Console.ReadLine();
            } while (resolucionString == "alta" || resolucionString == "baja");

            //si la respuesta es ALTA se asigna este valor a la resolucion, de no ser asi se asigna BAJA
            Resolucion resolucionFinal = resolucionString == "alta" ? Resolucion.ALTA : Resolucion.BAJA;

            string multiString = Console.ReadLine();
            do
            {
                Console.WriteLine("Ingrese si tiene multilenguage, 'si' o 'no': ");
                multiString = Console.ReadLine();
            } while (multiString == "si" || multiString == "no");

            //si la respuesta es SI se asigna TRUE a multilenguaje, de no ser asi se asigna FALSE
            bool multiFinal = multiString == "si" ? true : false;

            Console.WriteLine("Ingrese el precio del mismo: ");
            string precioString = Console.ReadLine();
            decimal precioDecimal = decimal.Parse(precioString);

            if (Canal.ValidarPrecio(precioDecimal))
            {

            }
        }
    }
}
