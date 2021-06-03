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
    public partial class ProductosGestion : Form
    {
        BindingSource _DATOS = new BindingSource();
        private void Cargar()
        {
            _DATOS.DataSource = CacheManager.CLS.Cache.TODOS_LOS_PRODUCTOS();
            FiltrarLocalmente();
        }
        private void FiltrarLocalmente()
        {
            if (txtFiltrar.TextLength > 0)
            {
                _DATOS.Filter = "Descripcion like '%" + txtFiltrar.Text + "%' or Marca like '%" + txtFiltrar.Text + "%'";
            }
            else
            {
                _DATOS.RemoveFilter();
            }
            dtgProductos.AutoGenerateColumns = false;
            dtgProductos.DataSource = _DATOS;
            lblRegistros.Text = dtgProductos.Rows.Count.ToString() + " Registros Encontrados.";
        }
        public ProductosGestion()
        {
            InitializeComponent();
        }

        private void ProductosGestion_Load(object sender, EventArgs e)
        {
            Cargar();
        }

        private void txtFiltrar_TextChanged(object sender, EventArgs e)
        {
            FiltrarLocalmente();
        }
    }
}
