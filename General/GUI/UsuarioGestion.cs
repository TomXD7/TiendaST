using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace General.GUI
{
    public partial class UsuarioGestion : Form
    {
        BindingSource _DATOS = new BindingSource();
        private void Cargar()
        {
            _DATOS.DataSource = CacheManager.CLS.Cache.TODOS_LOS_USUARIOS();
            FiltrarLocalmente();
        }
        private void FiltrarLocalmente()
        {
            if (txtFiltrar.TextLength > 0)
            {
                _DATOS.Filter = "Usuario like '%" + txtFiltrar.Text + "%'";
            }
            else
            {
                _DATOS.RemoveFilter();
            }
            dtgUsuarios.AutoGenerateColumns = false;
            dtgUsuarios.DataSource = _DATOS;
            lblRegistros.Text = dtgUsuarios.Rows.Count.ToString() + " Registros encontrados.";
        }
        public UsuarioGestion()
        {
            InitializeComponent();
        }

        private void UsuarioGestion_Load(object sender, EventArgs e)
        {
            Cargar();
        }
    }
}
