using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SegundoParcial.Entidades
{
    public class EntradasArticulos
    {
        [Key]
        public int EntradaId { get; set; }
        public string Articulo { get; set; }
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }

        //[ForeignKey("ArticuloId")]
        //public virtual Articulos Articulo { get; set; }


        public virtual ICollection<EntradasDetalle> Detalle { get; set; }

        public EntradasArticulos()
        {
            this.Detalle = new List<EntradasDetalle>();
        }

        public void AgregarInventario(int id, int entradaId, int articuloId, int cantidad)
        {
            this.Detalle.Add(new EntradasDetalle(id, entradaId, articuloId, cantidad));
        }



    }
}
