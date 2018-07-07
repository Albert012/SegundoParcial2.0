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
    public partial class rArticulos : Form
    {
        public rArticulos()
        {
            InitializeComponent();
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            ArticuloId_numericUpDown.Value = 0;
            Descripcion_textBox.Clear();
            Costo_numericUpDown.Value = 0;
            Precio_numericUpDown.Value = 0;
            Ganancia_numericUpDown.Value = 0;
            Inventario_numericUpDown.Value = 0;
            ValidarErrorProvider.Clear();
        }
        private bool Validar()
        {
            bool Validar = false;

            if(string.IsNullOrWhiteSpace(Descripcion_textBox.Text))
            {
                ValidarErrorProvider.SetError(Descripcion_textBox, "Debes Llenar La Descripcion");
                Validar = true;
            }

            if(Costo_numericUpDown.Value == 0)
            {
                ValidarErrorProvider.SetError(Costo_numericUpDown, "Ingrese El Costo");
                Validar = true;
            }

            if(Precio_numericUpDown.Value ==0)
            {
                ValidarErrorProvider.SetError(Precio_numericUpDown, "Ingrese El Precio");
                Validar = true;
            }
            
            return Validar;
        }

        private Articulos LLenaClase()
        {
            Articulos articulo = new Articulos();
            articulo.ArticuloId = Convert.ToInt32(ArticuloId_numericUpDown.Value);
            articulo.Descripcion = Descripcion_textBox.Text;
            articulo.Costo = Costo_numericUpDown.Value;
            articulo.Precio = Precio_numericUpDown.Value;
            articulo.Ganancia = Ganancia_numericUpDown.Value;
            articulo.Inventario = Convert.ToInt32(Inventario_numericUpDown.Value);

            return articulo;     
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());
            bool paso = false;
            Articulos articulo;

            if(Validar())
            {
                MessageBox.Show("Favor Revisar El Llenado", "Error Validacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            articulo = LLenaClase();
            if (ArticuloId_numericUpDown.Value == 0)
                paso = repositorio.Guardar(articulo);
            else
                paso = repositorio.Modificar(articulo);

            if (paso)
            {                
                MessageBox.Show("Guardado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NuevoButton.PerformClick();

            }
            else
                MessageBox.Show("No Se Pudo Guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ArticuloId_numericUpDown.Value);
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());
            Articulos articulo = repositorio.Buscar(id);

            if (articulo != null)
            {
                repositorio.Eliminar(id);
                MessageBox.Show("Eliminado", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NuevoButton.PerformClick();

            }
            else
                MessageBox.Show("No Se Pudo Eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(ArticuloId_numericUpDown.Value);
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());
            Articulos articulo = repositorio.Buscar(id);

            if (articulo != null)
            {
                Descripcion_textBox.Text = articulo.Descripcion;
                Costo_numericUpDown.Value = articulo.Costo;
                Precio_numericUpDown.Value = articulo.Precio;
                Ganancia_numericUpDown.Value = articulo.Ganancia;
                Inventario_numericUpDown.Value = articulo.Inventario;
            }
            else
                MessageBox.Show("Datos No Encontrados", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void Costo_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            
            
        }       

        private void Precio_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            
            if (Costo_numericUpDown.Value != 0)
            {
                Ganancia_numericUpDown.Value = BLL.CalculosBLL.CalcularGanancias(Precio_numericUpDown.Value, Costo_numericUpDown.Value);
            }
        }

        private void Ganancia_numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (Precio_numericUpDown.Value != 0)
            {
                Ganancia_numericUpDown.Value = BLL.CalculosBLL.CalcularGanancias(Precio_numericUpDown.Value, Costo_numericUpDown.Value);
            }


        }
    }
}
