using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    /// <summary>
    /// TODO
    /// </summary>
    public class PaqueteHD : Paquete
    {

        #region atributos
        //atributos y propiedades EN UNA LINEA SOLA
        public bool GrabacionNube { get; set; }
        public static decimal CostoFijo { get; set; }
        #endregion

        public PaqueteHD(string nombre, bool promocion, decimal precioBase,List<Canal> canales, bool grabacionNube) : base(nombre, promocion, precioBase,canales)
        {
            tipoPaquete = TipoPaquete.HD;
            GrabacionNube = grabacionNube;
        }

        public PaqueteHD(string nombre, bool promocion, decimal precioBase, List<Canal> canales, int id, bool grabacionNube) : base(nombre, promocion, precioBase, canales, id)
        {
            tipoPaquete = TipoPaquete.HD;
            GrabacionNube = grabacionNube;
        }

        //cambio - cambio

        public override Paquete ClonarPaquete()
        {
            return new PaqueteHD(Nombre, Promocion, PrecioBase, Canales, Id, GrabacionNube);
        }

       public override decimal DefinirPrecio()
        {
            decimal result = base.DefinirPrecio();
            if (GrabacionNube == true && Promocion == false) 
            {
                return result + CostoFijo;

            }
            if (GrabacionNube == true && Promocion == true) 
            {
                return (result + CostoFijo) / 2;
            }
            return result ;
        }
    

        public override bool ValidarResolucion()
        {
            throw new NotImplementedException();
        }
    }
}
