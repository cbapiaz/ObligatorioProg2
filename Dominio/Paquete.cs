using System;
using System.Collections.Generic;

namespace Dominio
{
    /// <summary>
    /// Representa un paquete con una lista de canales en el sistema
    /// </summary>
    public abstract class Paquete
    {

        #region atributos
        //id autogenerado
        private static int internalID=0;
        protected int Id;
        public string Nombre { get; set; }

        protected TipoPaquete tipoPaquete;


        private List<Canal> canales;
        public List<Canal> Canales { get { return canales; } }

        public bool Promocion { get; set; }
        public decimal PrecioBase { get; set; }
        #endregion

        #region constructores
        public Paquete(string nombre, bool promocion, decimal precioBase,List<Canal> canales)
        {
            this.canales = canales;
            Id = ++internalID;
            Nombre = nombre;
            Promocion = promocion;
            PrecioBase = precioBase;
        }

        public Paquete(string nombre, bool promocion, decimal precioBase, List<Canal> canales, int id)
        {
            this.canales = canales;
            Id = id;
            Nombre = nombre;
            Promocion = promocion;
            PrecioBase = precioBase;
        }
        #endregion

        #region metodos
        public virtual bool IngresarCanal(Canal c)
        {
            canales.Add(c);
            return true;
        }

        internal int CantCanales()
        {
            return canales.Count;
        }

        public int GetId()
        {
            return Id;
        }

        public abstract Paquete ClonarPaquete();

        public virtual decimal DefinirPrecio()
        {
            decimal result=PrecioBase;
            foreach (Canal c in Canales)
            {
                result += c.Precio;
            }
            return result;
        }

        public bool ValidarCantCanales()
        {
            return canales.Count > 0;
        }
        
        public override string ToString()
        {
            return $"Nombre : {Nombre} | Promocion : {Promocion} | Precio Base : {PrecioBase}";
        }
        #endregion

    }

    public enum TipoPaquete
    {
        SD =1,
        HD =2
    }
}
