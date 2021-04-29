using Dominio;
using System;

namespace ObligatorioProg2
{
    class Program
    {
        Empresa empresa = new Empresa();
        static void Main(string[] args)
        {

            Canal c = new Canal("pepe",Resolucion.RES1,false,7878);
            Console.WriteLine(c);
            Console.ReadLine();
        }
    }
}
