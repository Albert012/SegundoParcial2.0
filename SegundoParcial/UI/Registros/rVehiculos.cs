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
    public partial class rVehiculos : Form
    {
        public rVehiculos()
        {
            InitializeComponent();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            VehiculoId_numericUpDown.Value = 0;
            Descripcion_textBox.Clear();
            Mantenimiento_numericUpDown.Value = 0;
            ValidarErrorProvider.Clear();
        }

        private bool Validar()
        {
            bool Validar = false;

            if(string.IsNullOrWhiteSpace(Descripcion_textBox.Text))
            {
                ValidarErrorProvider.SetError(Descripcion_textBox, "Favor Ingrese La Descripcion");
                Validar = true;
            }

            return Validar;
        }

        private Vehiculos LlenaClase()
        {
            Vehiculos vehiculo = new Vehiculos();

            vehiculo.VehiculoId = Convert.ToInt32(VehiculoId_numericUpDown.Value);
            vehiculo.Descripcion = Descripcion_textBox.Text;
            vehiculo.Mantenimiento = Convert.ToInt32(Mantenimiento_numericUpDown.Value);

            return vehiculo;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            Repositorio<Vehiculos> repositorio = new Repositorio<Vehiculos>(new Contexto());
            Vehiculos vehiculo;

            if(Validar())
            {
                MessageBox.Show("Favor Revise Que Todos Los Campos Esten Debidamente Llenado", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            vehiculo = LlenaClase();

            if (VehiculoId_numericUpDown.Value == 0)
                paso = repositorio.Guardar(vehiculo);
            else
                paso = repositorio.Modificar(vehiculo);

            if (paso)
            {
                MessageBox.Show("Guardado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NuevoButton.PerformClick();

            }
            else
                MessageBox.Show("No Se Pudo Guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(VehiculoId_numericUpDown.Value);
            Repositorio<Vehiculos> repositorio = new Repositorio<Vehiculos>(new Contexto());
            Vehiculos vehiculo = repositorio.Buscar(id);

            if (vehiculo != null)
            {
                repositorio.Eliminar(id);
                MessageBox.Show("Eliminado Correctamete", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NuevoButton.PerformClick();

            }
            else
                MessageBox.Show("No Se Pudo Eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(VehiculoId_numericUpDown.Value);
            Repositorio<Vehiculos> repositorio = new Repositorio<Vehiculos>(new Contexto());
            Vehiculos vehiculo = repositorio.Buscar(id);

            if (vehiculo != null)
            {
                Descripcion_textBox.Text = vehiculo.Descripcion;
                Mantenimiento_numericUpDown.Value = vehiculo.Mantenimiento;

            }
            else
                MessageBox.Show("No Se Pudo Encontrar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
