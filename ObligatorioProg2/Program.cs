using Dominio;
using System;

namespace ObligatorioProg2
{
    class Program
    {
        readonly Empresa empresa = new Empresa();
        static void Main(string[] args)
        {

            Canal c = new Canal("pepe",Resolucion.BAJA,false,7878);
            Console.WriteLine(c);
            Console.ReadLine();
        }
    }
}
