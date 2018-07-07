using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SegundoParcial.Entidades
{
    public class MantenimientosDetalle
    {
        public int Id { get; set; }
        public int MantenimientoId { get; set; }
        public int VehiculoId { get; set; }
        public int TallerId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }
        public Decimal Precio { get; set; }
        public Decimal Importe { get; set; }
        public Decimal Total { get; set; }

        [ForeignKey("VehiculoId")]
        public virtual Vehiculos Vehiculo { get; set; }

        [ForeignKey("ArticuloId")]
        public virtual Articulos Articulo { get; set; }


        public MantenimientosDetalle()
        {
            Id = 0;
            MantenimientoId = 0;
                
        }

        public MantenimientosDetalle(int id, int mantenimientoId, int vehiculoId, int tallerId, int articuloId, int cantidad, decimal precio, decimal importe, decimal total)
        {
            Id = id;
            MantenimientoId = mantenimientoId;
            VehiculoId = vehiculoId;
            TallerId = tallerId;
            ArticuloId = articuloId;
            Cantidad = cantidad;
            Precio = precio;
            Importe = importe;
            Total = total;
        }
    }
}
