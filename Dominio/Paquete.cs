﻿using System;
using System.Collections.Generic;

namespace Dominio
{
    public class Paquete
    {
        //id autogenerado
        private static int internalID;
        private int Id;
        public string Nombre { get; set; }

        //depende de la clase que se este (por herencia)
        private TipoPaquete tipoPaquete;
        public TipoPaquete TipoPaquete { get; }
        //Mathi - herencia
        //public TipoPaquete
        // SD
        // public  bool MejoraCionImagen
        //HD
        //        public bool GrabacionNube { get; set; }
        // public decimal CostoFijoNube {get;set;}

        private List<Canal> canales;
        public List<Canal> Canales { get { return canales; } }
        
        public bool Promocion { get; set; }
        public decimal PrecioBase { get; set; }


        public Paquete(string nombre, bool promocion, decimal precioBase)
        {
            canales = new List<Canal>();
            Id = ++internalID;

            Nombre = nombre;
            Promocion = promocion;
            PrecioBase = precioBase;

            //para pruebas, quitar esto despues
            TipoPaquete = TipoPaquete.HD;
        }

        public bool AsignarCanal(Canal c)
        {
            canales.Add(c);
            return true;
        }

        //
        public override string ToString()
        {
            return $"Nombre : {Nombre} | Promocion : {Promocion} | Precio Base : {PrecioBase}";
        }

    }

    public enum TipoPaquete
    {
        SD =1,
        HD =2
    }
}
