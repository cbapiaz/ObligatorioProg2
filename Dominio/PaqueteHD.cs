using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class PaqueteHD : Paquete
    {
        public PaqueteHD(string nombre, bool promocion, decimal precioBase) : base(nombre, promocion, precioBase)
        {
            tipoPaquete = TipoPaquete.HD;
        }
    }
}
