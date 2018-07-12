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
        public int ArticuloId { get; set; }        
        public DateTime Fecha { get; set; }
        public int Cantidad { get; set; }
        

        public EntradasArticulos()
        {
            EntradaId = 0;
            ArticuloId = 0;
            Fecha = DateTime.Now;
            Cantidad = 0;
        }

      



    }
}
