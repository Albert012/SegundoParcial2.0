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
    public partial class cVehiculos : Form
    {
        public cVehiculos()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Vehiculos, bool>> filtro = a => true;
            Repositorio<Vehiculos> repositorio = new Repositorio<Vehiculos>(new DAL.Contexto());
            int id;

            switch (FiltroComboBox.SelectedIndex)
            {
                case 0://Todos
                    break;
                case 1://VehiculoId                    
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = a => a.VehiculoId == id;
                    break;
                case 2://Descripcion
                    filtro = a => a.Descripcion.Contains(CriterioTextBox.Text);
                    break;

            }
            ConsultaDataGridView.DataSource = repositorio.GetList(filtro);
        }
    }
}
