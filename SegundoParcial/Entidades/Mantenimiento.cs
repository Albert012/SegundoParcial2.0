using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SegundoParcial.Entidades
{
    public class Mantenimiento
    {
        public int MantenimientoId { get; set; }
        public DateTime Fecha { get; set; }
        public Decimal  Total { get; set; }

        public virtual ICollection<MantenimientosDetalle> Detalle { get; set; }

        public Mantenimiento()
        {
            this.Detalle = new List<MantenimientosDetalle>();
        }

        public void AgregarDetalle(int id, int mantenimientoId, int vehiculoId, int tallerId, int articuloId, int cantidad, decimal precio, decimal importe)
        {
            this.Detalle.Add(new MantenimientosDetalle(id, mantenimientoId, vehiculoId, tallerId, articuloId, cantidad, precio, importe));
        }
    }
}
