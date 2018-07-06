﻿using SegundoParcial.UI.Registros;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SegundoParcial
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void articulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rArticulos articulo = new rArticulos();
            articulo.MdiParent = this.MdiParent;
            articulo.Show();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void talleresToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rTalleres taller = new rTalleres();
            taller.MdiParent = this.MdiParent;
            taller.Show();
        }

        private void vehiculosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rVehiculos vehiculo = new rVehiculos();
            vehiculo.MdiParent = this.MdiParent;
            vehiculo.Show();
        }

        private void entradasArticulosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rEntradasArticulos entrada = new rEntradasArticulos();
            entrada.MdiParent = this.MdiParent;
            entrada.Show();
        }

        private void mantenimientoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rMantenimiento mantenimiento = new rMantenimiento();
            mantenimiento.MdiParent = this.MdiParent;
            mantenimiento.Show();
        }
    }
}