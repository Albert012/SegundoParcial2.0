﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SegundoParcial.Entidades
{
    public class Mantenimiento
    {
        [Key]
        public int MantenimientoId { get; set; }
        public int VehiculoId { get; set; }
        public DateTime Fecha { get; set; }
        public Decimal SubTotal { get; set; }
        public Decimal Itbis { get; set; }
        public Decimal  Total { get; set; }

        public virtual ICollection<MantenimientosDetalle> Detalle { get; set; }

        public Mantenimiento()
        {
            this.Detalle = new List<MantenimientosDetalle>();
        }


        public void AgregarDetalle(int id, int mantenimientoId, int vehiculoId, int tallerId, int articuloId, int cantidad, decimal precio, decimal importe)
        {
            this.Detalle.Add(new MantenimientosDetalle(id, mantenimientoId, vehiculoId, tallerId, articuloId, cantidad, precio, importe, this.Total));
        }

    }
}
