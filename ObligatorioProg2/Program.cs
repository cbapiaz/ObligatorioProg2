using Dominio;
using System;

namespace ObligatorioProg2
{
    class Program
    {
        private static Empresa empresa = new Empresa();
        static void Main(string[] args)
        {

            Canal c = new Canal("pepe",Resolucion.BAJA,false,7878);
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

            Console.ReadLine();

        }
    }
}
