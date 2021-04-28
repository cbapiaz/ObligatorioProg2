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
            if (Canal.ValidarNombre(nombre) && Canal.ValidarPrecio(precio)) /*TODO Verify this && BuscarCanal(Id) == null*/
            {
                Canal unC = new Canal(nombre, resolucion, multilenguaje, precio);
                Canales.Add(unC);
                exito = true;
            }

            return exito;
        }


        /// <summary>
        /// agregar una nueva instancia de paquete hd al sistema
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="promocion"></param>
        /// <param name="precioBase"></param>
        /// <param name="grabacionNube"></param>
        /// <param name="costoFijo"></param>
        /// <param name="canales"></param>
        /// <returns></returns>
        public bool AgregarPaqueteHD(string nombre, bool promocion, decimal precioBase,bool grabacionNube,decimal costoFijo, List<Canal> canales)
        {
            //bool exito = false; TODO Verify this
            //if (BuscarPaquete(Nombre) == null)
            //{
              Paquete unP = new PaqueteHD(nombre, promocion, precioBase,canales, grabacionNube,costoFijo);
              Paquetes.Add(unP);
            //    exito = true;
            //}

            return true;
        }

        /// <summary>
        /// agregar una nueva instancia de paquete sd al sistema
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="promocion"></param>
        /// <param name="precioBase"></param>
        /// <param name="mejoraImagen"></param>
        /// <param name="canales"></param>
        /// <returns></returns>
        public bool AgregarPaqueteSD(string nombre, bool promocion, decimal precioBase, bool mejoraImagen, List<Canal> canales)
        {

            Paquete unP = new PaqueteSD(nombre, promocion, precioBase, canales, mejoraImagen);
            Paquetes.Add(unP);
            return true;
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

        public Canal BuscarCanal(string nombre)
        {
            Canal unC = null;
            int i = 0;
            while (unC == null && i < Canales.Count)
            {
                if (Canales[i].Nombre == nombre)
                {
                    unC = Canales[i];
                }
                i++;
            }
            return unC;
        }

        public Paquete BuscarPaquete(int id)
        {
            Paquete unP = null;
            int i = 0;
            while (unP == null && i < Paquetes.Count)
            {
                if (Paquetes[i].GetId() == id)
                {
                    unP = Paquetes[i];
                }
                i++;
            }
            return unP;
        }
    }
}
