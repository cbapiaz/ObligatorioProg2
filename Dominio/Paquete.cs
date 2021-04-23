using System;
using System.Collections.Generic;

namespace Dominio
{
    public abstract class Paquete
    {
        //id autogenerado
        #region atributos

        private static int internalID;
        private int Id;
        public string Nombre { get; set; }

        protected TipoPaquete tipoPaquete;


        private List<Canal> canales;
        public List<Canal> Canales { get { return canales; } }

        public bool Promocion { get; set; }
        public decimal PrecioBase { get; set; }
        #endregion

        public Paquete(string nombre, bool promocion, decimal precioBase)
        {
            canales = new List<Canal>();
            Id = ++internalID;

            Nombre = nombre;
            Promocion = promocion;
            PrecioBase = precioBase;

        }

        public bool IngresarCanal(Canal c)
        {
            canales.Add(c);
            return true;
        }

        public abstract decimal DefinirPrecio();

        public abstract bool ValidarResolucion();

        public bool ValidarCantCanales()
        {
            return canales.Count > 0;
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
