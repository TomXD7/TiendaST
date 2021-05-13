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
    public partial class CategoriasGestion : Form
    {
        BindingSource _DATOS = new BindingSource();
        private void Cargar()
        {
            _DATOS.DataSource = CacheManager.CLS.Cache.TODAS_LAS_CATEGORIAS();
            FiltrarLocalmente();
        }
        private void FiltrarLocalmente()
        {
            if(txtFiltrar.TextLength > 0)
            {
                _DATOS.Filter = "Categoria like '%" + txtFiltrar.Text + "%'";

            }
            else
            {
                _DATOS.RemoveFilter();
            }
            dtgCategorias.AutoGenerateColumns = false;
            dtgCategorias.DataSource = _DATOS;
            lblRegistros.Text = dtgCategorias.Rows.Count.ToString() + " Registros encontrados.";
        }
        public CategoriasGestion()
        {
            InitializeComponent();
        }

        private void CategoriasGestion_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                CategoriasEdicion f = new CategoriasEdicion();
                f.ShowDialog();
                Cargar();
            }
            catch
            {

            }
        }
        private void txtFiltrar_Click(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Realmente desea EDITAR el registro seleccionado?", "Pregunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    CategoriasEdicion f = new CategoriasEdicion();
                    f.txtIDCategoria.Text = dtgCategorias.CurrentRow.Cells["IDCategoria"].Value.ToString();
                    f.txtCategoria.Text = dtgCategorias.CurrentRow.Cells["Categoria"].Value.ToString();
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
                    CLS.Categorias oEntidad = new CLS.Categorias();
                    oEntidad.IDCategoria = dtgCategorias.CurrentRow.Cells["IDCategoria"].Value.ToString();
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
