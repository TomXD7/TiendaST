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
        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                UsuarioEdicion f = new UsuarioEdicion();
                f.ShowDialog();
                Cargar();
            }
            catch
            {

            }
        }
        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Realmente desea EDITAR el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    UsuarioEdicion f = new UsuarioEdicion();
                    f.txtIDUsuario.Text = dtgUsuarios.CurrentRow.Cells["IDUsuario"].Value.ToString();
                    f.txtUsuario.Text = dtgUsuarios.CurrentRow.Cells["Usuario"].Value.ToString();
                    f.txtIDEmpleado.Text = dtgUsuarios.CurrentRow.Cells["IDEmpleado"].Value.ToString();
                    f.txtEmpleado.Text = dtgUsuarios.CurrentRow.Cells["Empleado"].Value.ToString();
                    f.txtClave.Text = dtgUsuarios.CurrentRow.Cells["Clave"].Value.ToString();
                    //f.cbbRoles.SelectedIndex = dtgUsuarios.CurrentRow.Cells["IDRol"].Value.ToString();
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
                    CLS.Usuarios oEntidad = new CLS.Usuarios();
                    oEntidad.IDEmpleado = dtgUsuarios.CurrentRow.Cells["IDUsuario"].Value.ToString();
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

