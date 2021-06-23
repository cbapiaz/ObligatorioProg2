using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Compra
    {
        private static int uid = 0;
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public bool Cancelada { get; set; } = false;

        public Paquete PaqueteComprar;

        public Compra()
        {
            Id = uid++;
        }

        public Compra(DateTime fecha, bool cancelada, Paquete paqueteComprar)
        {
            Id = uid++;
            Fecha = fecha;
            FechaVencimiento = fecha.AddYears(1);
            Cancelada = cancelada;
            PaqueteComprar = paqueteComprar;
        }

        public string GetDetalleCompra()
        {
            string aux = "";

            aux += $"Fecha de compra: {Fecha.ToShortDateString()} | Fecha vencimiento: {FechaVencimiento.ToShortDateString()} | Cancelada: {Cancelada} | Nombre de Paqute: {PaqueteComprar.Nombre} ";

            return aux;
        }

        public decimal GetTotalCompra()
        {
            return PaqueteComprar.DefinirPrecio();
        }

        public decimal PrecioCompra()
        {
            if (PaqueteComprar != null)
            {
                return PaqueteComprar.PrecioBase;
            }
            else
            {
                return  0;
            }
        }

        
        public string NombrePaquete()
        {
            if(PaqueteComprar != null)
            { 
            return PaqueteComprar.Nombre;
            }
            else
            {
                return "";
            }
        }

    }
}
