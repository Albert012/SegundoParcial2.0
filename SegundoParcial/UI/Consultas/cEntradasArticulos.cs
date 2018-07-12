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
    public partial class cEntradasArticulos : Form
    {
        public cEntradasArticulos()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<EntradasArticulos, bool>> filtro = a => true;
            Repositorio<EntradasArticulos> repositorio = new Repositorio<EntradasArticulos>(new DAL.Contexto());
            int id;

            switch (FiltroComboBox.SelectedIndex)
            {
                case 0://Todos
                    break;
                case 1://EntradaId                    
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = a => (a.EntradaId == id) && (a.Fecha >= DesdeDateTimePicker.Value && a.Fecha <= HastaDateTimePicker.Value);
                    break;
                //case 2://Descripcion
                //    filtro = a => (a.DesArticulo.Contains(CriterioTextBox.Text)) && (a.Fecha >= DesdeDateTimePicker.Value && a.Fecha <= HastaDateTimePicker.Value);
                //    break;                

            }
            ConsultaDataGridView.DataSource = repositorio.GetList(filtro);
        }
    }
}
