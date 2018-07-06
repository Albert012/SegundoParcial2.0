using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SegundoParcial.Entidades
{
    public class Articulos
    {
        [Key]
        public int ArticuloId { get; set; }
        public string Descripcion { get; set; }
        public Decimal Costo { get; set; }
        public Decimal Precio { get; set; }
        public Decimal Ganancia { get; set; }
        public int Inventario { get; set; }

        //public virtual ICollection<EntradasArticulos> Entrada { get; set; }


        public Articulos()
        {
            ArticuloId = 0;
            Descripcion = string.Empty;
            Costo = 0;
            Precio = 0;
            Ganancia = 0;
            Inventario = 0;

            //this.Entrada = new HashSet<EntradasArticulos>();
        }


    }
}
