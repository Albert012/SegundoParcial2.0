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
    public partial class rTalleres : Form
    {
        public rTalleres()
        {
            InitializeComponent();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            TallerId_numericUpDown.Value = 0;
            Nombre_textBox.Clear();
        }

        private bool Validar()
        {
            bool Validar = false;

            if(string.IsNullOrWhiteSpace(Nombre_textBox.Text))
            {
                ValidarErrorProvider.SetError(Nombre_textBox, "Favor Digite El Nombre");
                Validar = true;
            }
            return Validar;
        }

        private Talleres LlenaClase()
        {
            Talleres taller = new Talleres();

            taller.TallerId = Convert.ToInt32(TallerId_numericUpDown.Value);
            taller.Nombre = Nombre_textBox.Text;

            return taller;
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Talleres> repositorio = new Repositorio<Talleres>(new Contexto());
            bool paso = false;
            Talleres taller;

            if(Validar())
            {
                MessageBox.Show("Favor Revisar Los Campos", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            taller = LlenaClase();

            if (TallerId_numericUpDown.Value == 0)
                paso = repositorio.Guardar(taller);            
            else
                paso = repositorio.Modificar(taller);

            if (paso)
            {
                MessageBox.Show("Guardado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NuevoButton.PerformClick();
            }
            else
                MessageBox.Show("No Se Pudo Guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Question);


        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TallerId_numericUpDown.Value);
            Repositorio<Talleres> repositorio = new Repositorio<Talleres>(new Contexto());
            Talleres taller = repositorio.Buscar(id);

            if (taller != null)
            {
                repositorio.Eliminar(id);
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NuevoButton.PerformClick();
            }
            else
                MessageBox.Show("NO SE PUDO ELIMINAR", "FALLO", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(TallerId_numericUpDown.Value);
            Repositorio<Talleres> repositorio = new Repositorio<Talleres>(new Contexto());
            Talleres taller = repositorio.Buscar(id);

            if (taller != null)
            {
                Nombre_textBox.Text = taller.Nombre;
            }
            else
                MessageBox.Show("NO SE PUDO ENCONTRAR", "FALLO", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
