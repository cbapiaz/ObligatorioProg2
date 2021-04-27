using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Empresa
    {
        public List<Paquete> Paquetes { get;  }
        public List<Canal> Canales { get; }


        public Empresa()
        {
            Paquetes = new List<Paquete>();
            Canales = new List<Canal>();
        }
        //TODO
        //prepopulacion como vimos en clase - TODO

        public void PrecargaPaquetes()
        {

        }

        public void PrecargaCanales()
        {

        }


        public bool AgregarCanal()
        {
            throw new NotImplementedException();
        }

        public bool AgregarPaquete()
        {
            throw new NotImplementedException();

        }

        public List<Paquete> ListarPaquetes()
        {

            return Paquetes;
        }

        public List<Canal> ListarCanales()
        {
            throw new NotImplementedException();

        }

        public List<Paquete> ListarPaquetesConMasCanales()
        {
            throw new NotImplementedException();

        }

        public List<Paquete> ListarPaquetesConMayorPrecio(decimal precio)
        {
            throw new NotImplementedException();

        }

    }
}
