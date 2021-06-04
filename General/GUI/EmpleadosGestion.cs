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
    public partial class EmpleadosGestion : Form
    {
        BindingSource _DATOS = new BindingSource();
        private void Cargar()
        {
            _DATOS.DataSource = CacheManager.CLS.Cache.TODOS_LOS_EMPLEADOS();
            FiltrarLocalmente();
        }
        private void FiltrarLocalmente()
        {
            if(txtFiltrar.TextLength > 0)
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
        public EmpleadosGestion()
        {
            InitializeComponent();
        }
        private void EmpleadosGestion_Load(object sender, EventArgs e)
        {
            Cargar();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                EmpleadosEdicion f = new EmpleadosEdicion();
                f.ShowDialog();
                Cargar();
            }
            catch
            {

            }
        }
        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Realmente desea EDITAR el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    EmpleadosEdicion f = new EmpleadosEdicion();
                    f.txtIDEmpleado.Text = dtgEmpleados.CurrentRow.Cells["IDEmpleado"].Value.ToString();
                    f.txtNombres.Text = dtgEmpleados.CurrentRow.Cells["Nombres"].Value.ToString();
                    f.txtApellidos.Text = dtgEmpleados.CurrentRow.Cells["Apellidos"].Value.ToString();
                    f.dtpFechaNacimiento.Text = dtgEmpleados.CurrentRow.Cells["FechaNacimiento"].Value.ToString();
                    f.ShowDialog();
                    Cargar();
                }
            }
            catch
            {

            }
        }
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Realmente desea ELIMINAR el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CLS.Empleados oEntidad = new CLS.Empleados();
                    oEntidad.IDEmpleado = dtgEmpleados.CurrentRow.Cells["IDEmpleado"].Value.ToString();
                    if (oEntidad.Eliminar())
                    {
                        MessageBox.Show("Registro eliminado correctamente", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Cargar();
                    }
                    else
                    {
                        MessageBox.Show("El registro no pudo ser eliminado.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch
            {

            }
        }
    }
}
