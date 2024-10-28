﻿using System.ComponentModel.DataAnnotations;

namespace RegistroTecnicos.Models
{
    public class CotizacionDetalles
    {
        [Key]
        public int DetalleId { get; set; }

        public int CotizacionId { get; set; }

        public int ArticuloId { get; set; }

        public int Cantidad { get; set; }

        public double Precio { get; set; }
    }
}
