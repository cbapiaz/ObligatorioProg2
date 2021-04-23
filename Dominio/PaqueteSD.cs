using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class PaqueteSD : Paquete
    {
        public PaqueteSD(string nombre, bool promocion, decimal precioBase) : base(nombre, promocion, precioBase)
        {
            tipoPaquete = TipoPaquete.SD;
        }
    }
}
