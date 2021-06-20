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

        public List<Paquete> Paquetes { get; } = new List<Paquete>();

        public Compra()
        {
            Id = uid++;
        }

        public Compra(DateTime fecha, bool cancelada)
        {
            Id = uid++;
            Fecha = fecha;
            FechaVencimiento = fecha.AddYears(1);
            Cancelada = cancelada;
        }

        //seba me parece que se compra 1 solo paquete por compra, no hay multiples compras, es de a una
        //quiero agregar el controlador TerminarCompra que compre solo 1 paquete y lo agrege a la lista del usuario cliente activo
        public Compra(DateTime fecha, bool cancelada, List<Paquete> paquetesComprados)
        {
            Id = uid++;
            Fecha = fecha;
            FechaVencimiento = fecha.AddYears(1);
            Cancelada = cancelada;
            Paquetes = paquetesComprados;
        }

        public bool AgregarPaquete(Paquete paquete)
        {
            Paquetes.Add(paquete);
            return true;
        }

        public string GetDetalleCompra()
        {
            string aux = "";/*$"Compra {Fecha.ToString()} ";*/
            foreach (Paquete paquete in Paquetes)
            {
                aux += paquete.Nombre +",";
            }

            return aux;
        }

        public decimal GetTotalCompra()
        {
            decimal result = 0;
            foreach (Paquete paquete in Paquetes)
            {
                result += paquete.DefinirPrecio();
            }

            return result;
        }
    }
}
