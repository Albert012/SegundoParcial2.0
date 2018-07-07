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
            FiltrarPrecio();
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

        

        private void ArticuloComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            FiltrarPrecio();

        }

        private void NuevoButton_Click(object sender, EventArgs e)
        {
            IdnumericUpDown.Value = 0;
            FechaDateTimePicker.ResetText();
            CantidadNumericUpDown.Value = 0;
            ImporteNumericUpDown.Value = 0;
            SubTotalNumericUpDown.Value = 0;
            ITBISNumericUpDown.Value = 0;
            TotalNumericUpDown.Value = 0;
            DetalleDataGridView.DataSource = null;
            ValidarErrorProvider.Clear();
        }

        private void GuardarButton_Click(object sender, EventArgs e)
        {
            Mantenimiento mantenimiento;
            bool paso = false;

            if(Validar())
            {
                MessageBox.Show("Favor Revise Algunos Campos Que Deben Ser LLenados", "Validacion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            mantenimiento = LlenaClase();

            if (IdnumericUpDown.Value == 0)
                paso = BLL.MantenimientosBLL.Guardar(mantenimiento);
            else
                paso = BLL.MantenimientosBLL.Guardar(mantenimiento);

            if (paso)
            {
                MessageBox.Show("Guardado Correctamente!!", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NuevoButton.PerformClick();
            }
            else
                MessageBox.Show("No Se Pudo Guardar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Question);

        }

        private void EliminarButton_Click(object sender, EventArgs e)
        {
            int id = (int)IdnumericUpDown.Value;
            if (BLL.MantenimientosBLL.Eliminar(id))
            {
                MessageBox.Show("Eliminado Correctamente", "Exito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                NuevoButton.PerformClick();
            }
            else
                MessageBox.Show("NO Se Pudo Eliminar", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);

        }

        private void BuscarButton_Click(object sender, EventArgs e)
        {
            //int id = (int)IdnumericUpDown.Value;
            //Mantenimiento mantenimiento = BLL.MantenimientosBLL.Buscar(id);

            //if (mantemiento != null)
            //{
            //    LlenaCampos(mantenimiento);
            //}
            //else
            //    MessageBox.Show("No Hay Resultados", "Fallo", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void AgregarButton_Click(object sender, EventArgs e)
        {
            List<MantenimientosDetalle> detalle = new List<MantenimientosDetalle>();

            if(DetalleDataGridView.DataSource != null)
            {
                detalle = (List<MantenimientosDetalle>)DetalleDataGridView.DataSource;
            }

            detalle.Add(new MantenimientosDetalle(
                id: 0,
                mantenimientoId: (int)IdnumericUpDown.Value,
                vehiculoId: (int)VehiculoComboBox.SelectedValue,
                tallerId: (int)TallerComboBox.SelectedValue,
                articuloId: (int)ArticuloComboBox.SelectedValue,
                cantidad: (int)CantidadNumericUpDown.Value,
                precio: (int)PrecioNumericUpDown.Value,
                importe: (int)ImporteNumericUpDown.Value
                ));

            DetalleDataGridView.DataSource = null;
            DetalleDataGridView.DataSource = detalle;
            CantidadNumericUpDown.Value = 0;

        }

        private void RemoverButton_Click(object sender, EventArgs e)
        {
            if(DetalleDataGridView.Rows.Count > 0 && DetalleDataGridView.CurrentRow != null)
            {
                List<MantenimientosDetalle> detail = (List<MantenimientosDetalle>)DetalleDataGridView.DataSource;

                detail.RemoveAt(DetalleDataGridView.CurrentRow.Index);
                DetalleDataGridView.DataSource = null;
                DetalleDataGridView.DataSource = detail;
            }

        }

        private bool Validar()
        {
            bool Validar = false;
            if(DetalleDataGridView.RowCount == 0)
            {
                ValidarErrorProvider.SetError(DetalleDataGridView, "No Hay Datos Para Mostrar");
                Validar = true;
            }
            return Validar;
        }

        private void FiltrarPrecio()
        {
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new Contexto());
            Articulos articulo = (Articulos)ArticuloComboBox.SelectedItem;
            PrecioNumericUpDown.Value = articulo.Precio;            
        }


        private Mantenimiento LlenaClase()
        {
            Mantenimiento mantenimiento = new Mantenimiento();

            mantenimiento.MantenimientoId = (int)IdnumericUpDown.Value;
            mantenimiento.Fecha = FechaDateTimePicker.Value.Date;
            mantenimiento.Total = TotalNumericUpDown.Value;

            foreach (DataGridViewRow item in DetalleDataGridView.Rows)
            {
                mantenimiento.AgregarDetalle(
                    ToInt(item.Cells["Id"].Value),
                    ToInt(item.Cells["MantenimientoId"].Value),
                    ToInt(item.Cells["VehiculoId"].Value),
                    ToInt(item.Cells["TallerId"].Value),
                    ToInt(item.Cells["ArticuloId"].Value),
                    ToInt(item.Cells["Cantidad"].Value),
                    ToInt(item.Cells["Precio"].Value),
                    ToInt(item.Cells["Importe"].Value)
                    );
            }
            return mantenimiento;
        }

        private int ToInt(object valor)
        {
            int retorno = 0;
            int.TryParse(valor.ToString(), out retorno);
            return retorno;
        }

        private void LlenaCampos(Mantenimiento mantenimiento)
        {
            IdnumericUpDown.Value = mantenimiento.MantenimientoId;
            FechaDateTimePicker.Value = mantenimiento.Fecha;
            TotalNumericUpDown.Value = mantenimiento.Total;

            DetalleDataGridView.DataSource = mantenimiento.Detalle;

            DetalleDataGridView.Columns["Id"].Visible = false;
            DetalleDataGridView.Columns["MantenimientoId"].Visible = false;
            DetalleDataGridView.Columns["VehiculoId"].Visible = false;
            DetalleDataGridView.Columns["TallerId"].Visible = false;
            DetalleDataGridView.Columns["ArticuloId"].Visible = false;

        }

        private void Importe()
        {
            if (CantidadNumericUpDown.Value != 0 && PrecioNumericUpDown.Value != 0)
            {
                ImporteNumericUpDown.Value = BLL.CalculosBLL.CalcularImporte(CantidadNumericUpDown.Value, PrecioNumericUpDown.Value);
            }
            else
                ImporteNumericUpDown.Value = 0;

        }

        private void CantidadNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            Importe();
        }

        private void rMantenimiento_Load(object sender, EventArgs e)
        {

        }
    }
}
