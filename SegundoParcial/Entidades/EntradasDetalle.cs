using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace SegundoParcial.Entidades
{
    public class EntradasDetalle
    {
        public int Id { get; set; }
        public int EntradaId { get; set; }
        public int ArticuloId { get; set; }
        public int Cantidad { get; set; }

        [ForeignKey("ArticuloId")]
        public virtual Articulos Articulo { get; set; }


        public EntradasDetalle()
        {
            Id = 0;
            EntradaId = 0;

        }

        public EntradasDetalle(int id, int entradaId, int articuloId, int cantidad)
        {
            Id = id;
            EntradaId = entradaId;
            ArticuloId = articuloId;
            Cantidad = cantidad;
        }



    }
}
