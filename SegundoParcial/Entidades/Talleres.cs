﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SegundoParcial.Entidades
{
    public class Talleres
    {
        [Key]
        public int TallerId { get; set; }
        public string Nombre { get; set; }

        public Talleres()
        {
            TallerId = 0;
            Nombre = string.Empty;
        
        }

        public override string ToString()
        {
            return Nombre;
        }

    }
}
