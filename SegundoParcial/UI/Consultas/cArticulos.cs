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
    public partial class cArticulos : Form
    {
        public cArticulos()
        {
            InitializeComponent();
        }

        private void cArticulos_Load(object sender, EventArgs e)
        {

        }

        private void ConsultarButton_Click(object sender, EventArgs e)
        {
            Expression<Func<Articulos, bool>> filtro = a => true;
            Repositorio<Articulos> repositorio = new Repositorio<Articulos>(new DAL.Contexto());
            int id;

            switch (FiltroComboBox.SelectedIndex)
            {
                case 0://Todos
                    break;
                case 1://ArticuloId                    
                    id = Convert.ToInt32(CriterioTextBox.Text);
                    filtro = a => a.ArticuloId == id;
                    break;
                case 2://Descripcion
                    filtro = a => a.Descripcion.Contains(CriterioTextBox.Text);
                    break;               

            }
            ConsultaDataGridView.DataSource = repositorio.GetList(filtro);
        }
    }
}
