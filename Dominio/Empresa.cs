using System;
using System.Collections.Generic;

namespace Dominio
{
    
    
    public class Empresa
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Paquete> Paquetes { get;  } =new List<Paquete>();
        public List<Canal> Canales { get; } = new List<Canal>();
        

        public Empresa()
        {
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

        public bool AgregarPaquete(string nombre, bool promocion, decimal precioBase, List<Canal> canales)
        {
            bool exito = false;
            if (BuscarPaquete(Nombre) == null)
            {
                Paquete unP = new Paquete(nombre, promocion, precioBase,List<Canal> canales);
                Paquetes.Add(unP);
                exito = true;
            }

            return exito;
        }

        public List<Paquete> ListarPaquetes()
        {

            return Paquetes;
        }

        public List<Canal> ListarCanales()
        {
            return Canales;

        }

        public List<Paquete> ListarPaquetesConMasCanales()
        {
            int mayor = int.MinValue;
            List<Paquete> aux = new List<Paquete>();

            foreach (Paquete item in Paquetes)
            {
                int cant = item.CantCanales();
                if ( cant > mayor)
                {
                    mayor = cant;
                    
                    aux.Clear();
                    aux.Add(item);

                } else if (cant == mayor)
                {
                    aux.Add(item);
                }
            }

            return aux;
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
                if (Canales[i].GetId() == Id)
                {
                    unC = Canales[i];
                }
                i++;
            }
            return unC;
        }

        public Paquete BuscarPaquete(string Nombre)
        {
            Paquete unP = null;
            int i = 0;
            while (unP == null && i < Paquetes.Count)
            {
                if (Paquetes[i].Nombre == Nombre)
                {
                    unP = Paquetes[i];
                }
                i++;
            }
            return unP;
        }
    }
}
