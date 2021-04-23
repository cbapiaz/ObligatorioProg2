using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class PaqueteHD : Paquete
    {
        public PaqueteHD(string nombre, bool promocion, decimal precioBase,List<Canal> canales) : base(nombre, promocion, precioBase,canales)
        {
            tipoPaquete = TipoPaquete.HD;
        }

        public override Paquete ClonarPaquete()
        {
            throw new NotImplementedException();
        }

        public override decimal DefinirPrecio()
        {
            throw new NotImplementedException();
        }

        public override bool ValidarResolucion()
        {
            throw new NotImplementedException();
        }
    }
}
