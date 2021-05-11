using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    /// <summary>
    /// Representa un Paquete SD ( definicion standart) en el sistema
    /// </summary>
    public class PaqueteSD : Paquete
    {
        #region atributos
        public bool MejoraImagen { get; set; }
        #endregion

        #region constructores
        public PaqueteSD(string nombre, bool promocion, decimal precioBase,List<Canal> canales, bool mejoraimagen) 
            : base(nombre, promocion, precioBase, canales)
        {
            tipoPaquete = TipoPaquete.SD;
            MejoraImagen = mejoraimagen;
        }
        public PaqueteSD(string nombre, bool promocion, decimal precioBase, List<Canal> canales, int id, bool mejoraImagen)
             : base(nombre, promocion, precioBase, canales,id)
        {
            tipoPaquete = TipoPaquete.SD;
            MejoraImagen = mejoraImagen;
        }
        #endregion

        #region metodos

        /// <summary>
        /// Clonar un paquete sd a partir de los datos originales
        /// </summary>
        /// <returns>nueva instancia de paquetesd</returns>
        public override Paquete ClonarPaquete()
        {
            return new PaqueteSD(Nombre,Promocion,PrecioBase,Canales,Id,MejoraImagen);
        }

        public override decimal DefinirPrecio()
        {
            decimal result = base.DefinirPrecio();

            //20% mas si tiene mejoramiento de imagen
            if (MejoraImagen)
            {
                result = ((decimal)1.2) * result;
            }
            //15% descuento si esta en promocion
            if (Promocion)
            {
                result = result - result * (decimal)0.15;
            }

            return result;
        }

        public override bool IngresarCanal(Canal c)
        {
            if (c.Resolucion == Resolucion.BAJA)
            {
                Canales.Add(c);
                return true;
            }
            return false;
        }

        #endregion
    }
}
