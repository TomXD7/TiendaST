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
    public partial class VistaEmpleado : Form
    {
        BindingSource _DATOS = new BindingSource();
        private void Cargar()
        {
            _DATOS.DataSource = CacheManager.CLS.Cache.TODOS_LOS_EMPLEADOS();
            FiltrarLocalmente();
        }
        private void FiltrarLocalmente()
        {
            if (txtFiltrar.TextLength > 0)
            {
                _DATOS.Filter = "Nombres like '%" + txtFiltrar.Text + "%'";
            }
            else
            {
                _DATOS.RemoveFilter();
            }
            dtgEmpleados.AutoGenerateColumns = false;
            dtgEmpleados.DataSource = _DATOS;
            lblRegistros.Text = dtgEmpleados.Rows.Count.ToString() + " Registros encontrados.";
        }
        public VistaEmpleado()
        {
            InitializeComponent();
        }

        private void VistaEmpleado_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void dtgEmpleados_DoubleClick(object sender, EventArgs e)
        {
            UsuarioEdicion f = new UsuarioEdicion();
            //string id, empleado;
            //id = dtgEmpleados.CurrentRow.Cells["IDEmpleado"].Value.ToString();
            //empleado = dtgEmpleados.CurrentRow.Cells["Nombres"].Value.ToString();
            //f.ObtenerEmpleado(id, empleado);
            //f.txtIDEmpleado.Text = dtgEmpleados.CurrentRow.Cells["IDEmpleado"].Value.ToString();
            //f.txtEmpleado.Text = dtgEmpleados.CurrentRow.Cells["Nombres"].Value.ToString() + ' ' + dtgEmpleados.CurrentRow.Cells["Apellidos"].Value.ToString();
            this.Hide();
        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }
    }
}
