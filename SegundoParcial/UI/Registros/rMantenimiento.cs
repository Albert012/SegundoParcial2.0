using SegundoParcial.BLL;
using SegundoParcial.DAL;
using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SegundoParcial.UI.Registros
{
    public partial class rMantenimiento : Form
    {
        public rMantenimiento()
        {
            InitializeComponent();
            Meses();
            LLenaComboBox();
        }

        public void Meses()
        {
            ProximoDateTimePicker.Value = FechaDateTimePicker.Value.AddMonths(3);
        }

        private void ProximoDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void FechaDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            Meses();
            
        }

        private void LLenaComboBox()
        {
            Repositorio<Talleres> taller = new Repositorio<Talleres>(new Contexto());
            Repositorio<Vehiculos> vehiculo = new Repositorio<Vehiculos>(new Contexto());
            Repositorio<Articulos> articulo = new Repositorio<Articulos>(new Contexto());

            TallerComboBox.DataSource = taller.GetList(t => true);
            TallerComboBox.ValueMember = "TallerId";
            TallerComboBox.DisplayMember = "Nombre";

            VehiculoComboBox.DataSource = vehiculo.GetList(v => true);
            VehiculoComboBox.ValueMember = "VehiculoId";
            VehiculoComboBox.DisplayMember = "Descripcion";



            ArticuloComboBox.DataSource = articulo.GetList(a => true);
            ArticuloComboBox.ValueMember = "ArticuloId";
            ArticuloComboBox.DisplayMember = "Descripcion";
        }

        private void FiltrarPrecio()
        {
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());
            List<Articulos> articulo = repositorio.GetList(a => a.Descripcion == ArticuloComboBox.Text);
            foreach (var item in articulo)
            {
                PrecioNumericUpDown.Value = item.Precio;
            }
        }

        private void ArticuloComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarPrecio();

        }
    }
}
