using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ObligatorioProg2
{
    class Program
    {
        private static Empresa empresa = new Empresa();
        static void Main(string[] args)
        {
            MostrarMenu();
        }

        private static void MostrarPaquetes()
        {
            Console.WriteLine("Paquetes: ");

            foreach (var v in empresa.ListarPaquetes())
            {
                Console.WriteLine(v.ToString());
            }
        }

        private static void MostrarCanales()
        {
            Console.WriteLine("Canales: ");
            foreach (var v in empresa.ListarCanales())
            {
                Console.WriteLine(v.ToString());
            }
        }

        /// <summary>
        /// Programa que se muestra en consola
        /// </summary>
        public static void MostrarMenu()
        {
            Console.WriteLine("****************************\nObligatorio - Programación 2\n****************************");
            int salir = -1;
            do
            {
                Console.WriteLine("");
                salir = CrearMenu();

                switch (salir)
                {
                    case 1:
                        IngresarCanalTV();
                        break;
                    case 2:
                        MostrarPaquetesCanales();
                        break;
                    case 3:
                        ModificarCostoFijo();
                        break;
                    case 4:
                        MostrarPaquetesConMasCanales();
                        break;
                    case 5:
                        MostrarPaquetesPrecioMayorA();
                        break;
                    case 6:
                        MostrarCanales();
                        break;
                    case 7:
                        MostrarPaquetes();
                        break;
                    case 8:
                        salir = 0;
                        break;

                }

            } while (salir != 0);
        }

        /// <summary>
        /// Crea el menu de opciones
        /// </summary>
        /// <returns></returns>
        public static int CrearMenu()
        {
            int opcion = -1;

            Console.WriteLine("Menu:");
            Console.WriteLine("1. Ingresar un canal de TV.");
            Console.WriteLine("2. Visualizar todos los paquetes de canales.");
            Console.WriteLine("3. Modificar el costo fijo de grabación en la nube.");
            Console.WriteLine("4. Mostrar los paquetes con la mayor cantidad de canales.");
            Console.WriteLine("5. Listar los paquetes cuyo precio supere un valor dado.");
            Console.WriteLine("6. Mostrar Todos los Canales");
            Console.WriteLine("7. Mostrar Todos los Paquetes");
            Console.WriteLine("8. Salir");
            Console.WriteLine("Para salir ingrese '0'.");

            opcion = int.Parse(Console.ReadLine());

            return opcion;
        }

        /// <summary>
        /// Guarda resolucion de canal
        /// </summary>
        public static void IngresarCanalTV()
        {
            string nombre = "";
            bool validar = false;
            do
            {
                //nombre, resolucion ATLA o BAJA, multilenguaje TRUE, decimal PRECIO
                Console.WriteLine("Ingrese el nombre del canal: ");
                nombre = Console.ReadLine();

                validar = Canal.ValidarNombre(nombre);

                if (!validar)
                {
                    Console.WriteLine("El nombre del canal debe ser mayor a tres caracteres.");
                }

            } while (!validar);

            string resolucionString = "";
            do
            {
                Console.WriteLine("Ingrese la resolucion del canal, 1080 'alta' o 576 'baja': ");
                resolucionString = Console.ReadLine();
                resolucionString = resolucionString.ToLower();
            } while (resolucionString != "alta" && resolucionString != "baja");

            Resolucion resolucionFinal = (Resolucion)Enum.Parse(typeof(Resolucion), resolucionString.ToUpper());

            //si la respuesta es ALTA se asigna este valor a la resolucion, de no ser asi se asigna BAJA
            //Resolucion resolucionFinal = resolucionString == "alta" ? Resolucion.ALTA : Resolucion.BAJA;

            string multiString;
            do
            {
                Console.WriteLine("Ingrese si tiene multilenguage, 'si' o 'no': ");
                multiString = Console.ReadLine();
                multiString = multiString.ToLower();
            } while (multiString != "si" && multiString != "no");

            //si la respuesta es SI se asigna TRUE a multilenguaje, de no ser asi se asigna FALSE
            bool multiFinal = multiString == "si" ? true : false;
            decimal precioDecimal = -1;
            do
            {
                precioDecimal = GuardarValorDecimal("Ingrese el precio del mismo: ");
 
                if (!Canal.ValidarPrecio(precioDecimal))
                {
                    Console.WriteLine("Ingeese un precio de Canal mayo a 0.");
                }
            } while (!Canal.ValidarPrecio(precioDecimal));

            if (Canal.ValidarPrecio(precioDecimal) && Canal.ValidarNombre(nombre)) { }
            {
                Canal unC = empresa.AgregarCanal(nombre, resolucionFinal, multiFinal, precioDecimal);
                Console.WriteLine("Su canal ha sido creado.");
                Console.WriteLine(unC);
            }

        }

        /// <summary>
        /// Muestra paquetes de canales
        /// </summary>
        public static void MostrarPaquetesCanales()
        {
            Console.WriteLine("Lista de todos los paquetes de canales.");

            List<Paquete> paquetesLista = empresa.ListarPaquetes();
            foreach (Paquete item in paquetesLista)
            {
                Console.WriteLine(item);
            }

        }

        /// <summary>
        /// Modifica el costo fijo de grabacion en la nube
        /// </summary>
        public static void ModificarCostoFijo()
        {
            Console.WriteLine($"Costo fijo de grabacion en la nube actual: {PaqueteHD.CostoFijo}");

            decimal precioACambiar = GuardarValorDecimal("Ingresa un nuevo valor para el costo fijo de grabación en la nube: ");

            if (!PaqueteHD.ValidarPrecioNube(precioACambiar))
            {
                Console.WriteLine("Precio de grabacion en la nube no valido");
            }
            else
            {
                PaqueteHD.CostoFijo = precioACambiar;

                Console.WriteLine("Precio cambiado exitosamente.");

            }
        }

        /// <summary>
        /// Muestra paquetes con mas canales
        /// </summary>
        public static void MostrarPaquetesConMasCanales()
        {
            List<Paquete> listaaux = empresa.ListarPaquetesConMasCanales();

            foreach (Paquete item in listaaux)
            {
                Console.WriteLine($"Cant Canales: {item.Canales.Count}");
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Muestra los paquetes con mayor precio que el comparado ingresado por el usuario
        /// </summary>
        public static void MostrarPaquetesPrecioMayorA()
        {
            decimal precioComparar = GuardarValorDecimal("Ingrese un precio a comparar: ");
            List<Paquete> listaaux = empresa.PaquetesMayorPrecio(precioComparar);
            foreach (Paquete item in listaaux)
            {
                Console.WriteLine(item);
            }
        }

        /// <summary>
        /// Metodo auxiliar que guarda el valor decimal y muestra el mensaje pasado por parametro
        /// </summary>
        /// <param name="mensaje"></param>
        /// <returns></returns>
        public static decimal GuardarValorDecimal(string mensaje)
        {

            decimal nuevoprecio = -1;
            string precioString = "";
            bool exito = false;
            do
            {
                Console.WriteLine(mensaje);
                precioString = Console.ReadLine();
                exito = decimal.TryParse(precioString, out nuevoprecio);

            } while (!exito);

            return nuevoprecio;
        }
    }
}
