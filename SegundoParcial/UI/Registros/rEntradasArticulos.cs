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
    public partial class rEntradasArticulos : Form
    {
        public rEntradasArticulos()
        {
            InitializeComponent();
            LLenaComboBox();
        }

        private void LLenaComboBox()
        {
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());
            Articulo_comboBox.DataSource = repositorio.GetList(a => true);
            Articulo_comboBox.ValueMember = "ArticuloId";
            Articulo_comboBox.DisplayMember = "Descripcion";
        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            EntradaId_numericUpDown.Value = 0;
            FechaDateTimePicker.ResetText();
            Cantidad_numericUpDown.Value = 0;
            ValidarErrorProvider.Clear();

        }

        private bool Validar()
        {
            bool Validar = false;

            if(Cantidad_numericUpDown.Value == 0)
            {
                ValidarErrorProvider.SetError(Cantidad_numericUpDown, "Ingrese Cantidad De Entradas");
                Validar = true;
            }
            return Validar;
        }

        private EntradasArticulos LLenaClase()
        {
            EntradasArticulos articulo = new EntradasArticulos();
            articulo.EntradaId = Convert.ToInt32(EntradaId_numericUpDown.Value);
            articulo.Fecha = FechaDateTimePicker.Value.Date;
            articulo.ArticuloId = (int)Articulo_comboBox.SelectedValue;
            articulo.Cantidad = Convert.ToInt32(Cantidad_numericUpDown.Value);
            return articulo;
        }


        private void GuardarButton_Click(object sender, EventArgs e)
        {
            bool paso = false;
            //int id = (int)EntradaId_numericUpDown.Value;
            //epositorio<EntradasArticulos> repositorio = new Repositorio<EntradasArticulos>(new Contexto());
            EntradasArticulos Entrada;// = BLL.EntradasArticulosBLL.Buscar(id);

            if(Validar())
            {
                MessageBox.Show("Favor Revisar Que Los Campos Esten Debidamente Llenados","Validacion",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }

            Entrada = LLenaClase();

            if (EntradaId_numericUpDown.Value == 0)
            {
                //Inventario();
                paso = BLL.EntradasArticulosBLL.Guardar(Entrada);
            }                
                         
            else
                paso = BLL.EntradasArticulosBLL.Modificar(Entrada);            

            if (paso)
            {              
                MessageBox.Show("Guardado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);                
                NuevoButton.PerformClick();
            }
            else
                MessageBox.Show("No Se Pudo Guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);


        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(EntradaId_numericUpDown.Value);
            //Repositorio<EntradasArticulos> repositorio = new Repositorio<EntradasArticulos>(new Contexto());
            EntradasArticulos articulo = BLL.EntradasArticulosBLL.Buscar(id);

            if(articulo != null)
            {
                BLL.EntradasArticulosBLL.Eliminar(id);
                MessageBox.Show("Eliminado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NuevoButton.PerformClick();
            }
            else
                MessageBox.Show("No Se Pudo Eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(EntradaId_numericUpDown.Value);
            //Repositorio<EntradasArticulos> repositorio = new Repositorio<EntradasArticulos>(new Contexto());
            EntradasArticulos articulo = BLL.EntradasArticulosBLL.Buscar(id);

            if (articulo != null)
            {
                FechaDateTimePicker.Value = articulo.Fecha;
                Articulo_comboBox.Text = articulo.ArticuloId.ToString();
                Cantidad_numericUpDown.Value = articulo.Cantidad;

            }
            else
                MessageBox.Show("No Se Pudo Encontrar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void Inventario()
        {
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());           
            Articulos articulo = (Articulos)Articulo_comboBox.SelectedItem;            
            articulo.Inventario += (int)Cantidad_numericUpDown.Value;            
            repositorio.Modificar(articulo);   
        }

        private void QuitarInventario()
        {
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());          
            Articulos articulo = (Articulos)Articulo_comboBox.SelectedItem;

            articulo.Inventario += (int)Cantidad_numericUpDown.Value ;
            repositorio.Modificar(articulo);
        }


        private void rEntradasArticulos_Load(object sender, EventArgs e)
        {

        }
    }
}
