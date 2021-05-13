using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Productos.GUI
{
    public partial class PresentacionGestion : Form
    {
        BindingSource _DATOS = new BindingSource();
        private void Cargar()
        {
            _DATOS.DataSource = CacheManager.CLS.Cache.TODAS_LAS_PRESENTACIONES();
            FiltrarLocalmente();
        }
        private void FiltrarLocalmente()
        {
            if (txtFiltrar.TextLength > 0)
            {
                _DATOS.Filter = "Presentacion like '%" + txtFiltrar.Text + "%'";

            }
            else
            {
                _DATOS.RemoveFilter();
            }
            dtgPresentacion.AutoGenerateColumns = false;
            dtgPresentacion.DataSource = _DATOS;
            lblRegistros.Text = dtgPresentacion.Rows.Count.ToString() + " Registros encontrados.";
        }
        public PresentacionGestion()
        {
            InitializeComponent();
        }

        private void PresentacionGestion_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                PresentacionEdicion f = new PresentacionEdicion();
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
                    PresentacionEdicion f = new PresentacionEdicion();
                    f.txtIDPresentacion.Text = dtgPresentacion.CurrentRow.Cells["IDPresentacion"].Value.ToString();
                    f.txtPresentacion.Text = dtgPresentacion.CurrentRow.Cells["Presentacion"].Value.ToString();
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
                    CLS.Presentaciones oEntidad = new CLS.Presentaciones();
                    oEntidad.IDPresentacion = dtgPresentacion.CurrentRow.Cells["IDPresentacion"].Value.ToString();
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

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }
    }
}
