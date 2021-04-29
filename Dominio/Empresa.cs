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
            AgregarCanal("canal1", Resolucion.RES1, true, 180);
            AgregarCanal("canal2", Resolucion.RES1, true, 190);
            AgregarCanal("canal3", Resolucion.RES2, true, 100);
            AgregarCanal("canal4", Resolucion.RES2, true, 120);
            AgregarCanal("canal5", Resolucion.RES1, true, 130);
            AgregarCanal("canal6", Resolucion.RES1, true, 145);
            AgregarCanal("canal7", Resolucion.RES2, true, 150);
            AgregarCanal("canal8", Resolucion.RES2, true, 155);
            AgregarCanal("canal9", Resolucion.RES1, true, 160);
            AgregarCanal("canal10", Resolucion.RES1, true, 165);
            AgregarCanal("canal11", Resolucion.RES2, true, 170);
            AgregarCanal("canal12", Resolucion.RES2, true, 180);
            AgregarCanal("canal13", Resolucion.RES1, true, 180);
            AgregarCanal("canal14", Resolucion.RES2, true, 181);
            AgregarCanal("canal15", Resolucion.RES2, true, 182);
            AgregarCanal("canal16", Resolucion.RES1, true, 183);
            AgregarCanal("canal17", Resolucion.RES1, true, 184);
            AgregarCanal("canal18", Resolucion.RES2, true, 185);
            AgregarCanal("canal19", Resolucion.RES2, true, 186);
            AgregarCanal("canal20", Resolucion.RES1, true, 180);
            AgregarCanal("canal21", Resolucion.RES1, true, 180);
            AgregarCanal("canal22", Resolucion.RES2, true, 1950);
            AgregarCanal("canal23", Resolucion.RES2, true, 196);
            AgregarCanal("canal24", Resolucion.RES1, true, 112);
            AgregarCanal("canal25", Resolucion.RES1, true, 113);
            AgregarCanal("canal26", Resolucion.RES2, true, 114);
            AgregarCanal("canal27", Resolucion.RES2, true, 180);
            AgregarCanal("canal28", Resolucion.RES1, true, 116);
            AgregarCanal("canal29", Resolucion.RES1, true, 180);
            AgregarCanal("canal30", Resolucion.RES2, true, 180);
            AgregarCanal("canal31", Resolucion.RES2, true, 117);
            AgregarCanal("canal32", Resolucion.RES1, true, 118);
            AgregarCanal("canal33", Resolucion.RES1, true, 119);
            AgregarCanal("canal34", Resolucion.RES2, true, 132);
            AgregarCanal("canal35", Resolucion.RES2, true, 133);
            AgregarCanal("canal36", Resolucion.RES1, true, 134);
            AgregarCanal("canal37", Resolucion.RES1, true, 180);
            AgregarCanal("canal38", Resolucion.RES2, true, 180);
            AgregarCanal("canal39", Resolucion.RES2, true, 180);
            AgregarCanal("canal40", Resolucion.RES1, true, 180);
            AgregarCanal("canal41", Resolucion.RES1, true, 180);
            AgregarCanal("canal42", Resolucion.RES2, true, 180);
            AgregarCanal("canal43", Resolucion.RES2, true, 180);
            AgregarCanal("canal44", Resolucion.RES1, true, 180);
            AgregarCanal("canal45", Resolucion.RES1, true, 135);
            AgregarCanal("canal46", Resolucion.RES2, true, 136);
            AgregarCanal("canal47", Resolucion.RES2, true, 137);
            AgregarCanal("canal48", Resolucion.RES1, true, 188);
            AgregarCanal("canal49", Resolucion.RES1, true, 139);
            AgregarCanal("canal50", Resolucion.RES1, true, 184);
        }

        /// <summary>
        /// dado un nombre resolucion, multilenguaje y precio crea un canal nuevo y lo agrega a la lista de canales
        /// </summary>
        /// <param name="nombre"></param>
        /// <param name="resolucion"></param>
        /// <param name="multilenguaje"></param>
        /// <param name="precio"></param>
        /// <returns></returns>
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

        /// <summary>
        /// retorna toda la lista de paquetes del sistema
        /// </summary>
        /// <returns></returns>
        public List<Paquete> ListarPaquetes()
        {

            return Paquetes;
        }

        /// <summary>
        /// retorna toda la lista de canales del sistema
        /// </summary>
        /// <returns></returns>
        public List<Canal> ListarCanales()
        {
            return Canales;
        }

        /// <summary>
        /// lista los paquetes que tienen mayor cantidad de canales asociados
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="nombre"></param>
        /// <returns></returns>
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


        /// <summary>
        /// TODO
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
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

        /// <summary>
        /// lista los paquetes con precio mayor a "precio"
        /// </summary>
        /// <param name="precio"></param>
        /// <returns></returns>
        public List<Paquete> PaquetesMayorPrecio(decimal precioComparar)
        {
            decimal max = int.MinValue;
            List<Paquete> paquetesAux = new List<Paquete>();

            foreach (Paquete paqueteAux in Paquetes)
            {
                decimal precioActual = paqueteAux.PrecioBase;

                if (precioActual > max)
                {
                    max = precioActual;
                    paquetesAux.Clear();
                    paquetesAux.Add(paqueteAux);
                }

                else if (precioActual == max)
                {
                    paquetesAux.Add(paqueteAux);
                }
            }

            return paquetesAux;
        }



    }
}
