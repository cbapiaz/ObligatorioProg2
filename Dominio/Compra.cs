using System;
using System.Collections.Generic;
using System.Text;

namespace Dominio
{
    public class Compra
    {
        public DateTime Fecha { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public bool Cancelada { get; set; } = false;

        public Compra()
        {

        }

        public Compra(DateTime fecha, DateTime fechaVencimiento, bool cancelada)
        {
            Fecha = fecha;
            FechaVencimiento = fechaVencimiento;
            Cancelada = cancelada;
        }
    }
}
