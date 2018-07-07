using SegundoParcial.BLL;
using SegundoParcial.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Forms;

namespace SegundoParcial.UI.Consultas
{
    public partial class cMantenimiento : Form
    {
        public cMantenimiento()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Mantenimiento, bool>> filtro = a => true;
            Repositorio<Mantenimiento> repositorio = new Repositorio<Mantenimiento>(new DAL.Contexto());
            int id;

            switch (FiltroComboBox.SelectedIndex)
            {
                case 0://Todos
                    break;
                case 1://MantenimientoId                    
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = a => (a.MantenimientoId == id) && (a.Fecha >= DesdeDateTimePicker.Value && a.Fecha <= HastaDateTimePicker.Value);
                    break;
                case 2://SubTotal
                    filtro = a => (a.SubTotal.Equals(CriterioTextBox.Text)) && (a.Fecha >= DesdeDateTimePicker.Value && a.Fecha <= HastaDateTimePicker.Value);
                    break;
                case 3://Total
                    filtro = a => (a.Total.Equals(CriterioTextBox.Text)) && (a.Fecha >= DesdeDateTimePicker.Value && a.Fecha <= HastaDateTimePicker.Value);
                    break;

            }
            ConsultaDataGridView.DataSource = repositorio.GetList(filtro);
        }
    }
}
