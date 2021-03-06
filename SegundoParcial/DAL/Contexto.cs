﻿using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace SegundoParcial.DAL
{
    public class Contexto:DbContext
    {
        public DbSet<Articulos> Articulos { get; set; }
        public DbSet<Talleres> Talleres { get; set; }
        public DbSet<Vehiculos> Vehiculos { get; set; }
        public DbSet<EntradasArticulos> Entradas { get; set; }
        public DbSet<Mantenimiento> Mantenimiento { get; set; }


        public Contexto() : base("ConStr")
        {

        }


    }
}
