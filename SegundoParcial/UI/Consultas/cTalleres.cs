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
    public partial class cTalleres : Form
    {
        public cTalleres()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Talleres, bool>> filtro = a => true;
            Repositorio<Talleres> repositorio = new Repositorio<Talleres>(new DAL.Contexto());
            int id;

            switch (FiltroComboBox.SelectedIndex)
            {
                case 0://Todos
                    break;
                case 1://TallerId                    
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = a => a.TallerId == id;
                    break;
                case 2://Descripcion
                    filtro = a => a.Nombre.Contains(CriterioTextBox.Text);
                    break;

            }
            ConsultaDataGridView.DataSource = repositorio.GetList(filtro);
        }
    }
}
