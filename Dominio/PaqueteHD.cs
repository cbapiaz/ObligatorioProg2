using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class PaqueteHD : Paquete
    {

        #region atributos
        //atributos y propiedades EN UNA LINEA SOLA
        public bool GrabacionNube { get; set; }
        public decimal CostoFijo { get; set; }
        #endregion

        public PaqueteHD(string nombre, bool promocion, decimal precioBase,List<Canal> canales, bool grabacionNube, decimal costoFijo) : base(nombre, promocion, precioBase,canales)
        {
            tipoPaquete = TipoPaquete.HD;
            GrabacionNube = grabacionNube;
            CostoFijo = costoFijo;
        }

        public PaqueteHD(string nombre, bool promocion, decimal precioBase, List<Canal> canales, int id, bool grabacionNube, decimal costoFijo) : base(nombre, promocion, precioBase, canales, id)
        {
            tipoPaquete = TipoPaquete.HD;
            GrabacionNube = grabacionNube;
            CostoFijo = costoFijo;
        }

        

        public override Paquete ClonarPaquete()
        {
            return new PaqueteHD(Nombre, Promocion, PrecioBase, Canales, Id, GrabacionNube, CostoFijo);
        }

       public override decimal DefinirPrecio()//
        {
            if (GrabacionNube == true && Promocion == false) 
            {
                return PrecioBase + CostoFijo;

            }
            if (GrabacionNube == true && Promocion == true) 
            {
                return PrecioBase + CostoFijo / 2;
            }
            return PrecioBase ;
        }
    

        public override bool ValidarResolucion()
        {
            throw new NotImplementedException();
        }
    }
}
