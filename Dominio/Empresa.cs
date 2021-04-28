using System;
using System.Collections.Generic;

namespace Dominio
{
    
    
    public class Empresa
    {
        public int Id { get; set; }
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
       

        public bool AgregarCanal(string nombre, Resolucion resolucion, bool multilenguaje, decimal precio)
        {
            bool exito = false;
            if (Canal.ValidarNombre(nombre) && Canal.ValidarPrecio(precio) && BuscarCanal(Id) == null)
            {
                Canal unC = new Canal(nombre, resolucion, multilenguaje, precio);
                Canales.Add(unC);
                exito = true;
            }

            return exito;
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
        public Canal BuscarCanal(int Id)
        {
            Canal unC = null;
            int i = 0;
            while (unC == null && i < Canales.Count)
            {
                if (Canales[i].Id == Id)
                {
                    unC = Canales[i];
                }
                i++;
            }
            return unC;
        }
    }
}
