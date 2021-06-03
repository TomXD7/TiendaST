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
    public partial class CategoriasEdicion : Form
    {
        private void Procesar()
        {
            CLS.Categorias oEntidad = new CLS.Categorias();
            oEntidad.IDCategoria = txtIDCategoria.Text;
            oEntidad.Categoria = txtCategoria.Text;
            try
            {
                if (txtIDCategoria.TextLength > 0)
                {
                    //Estoy actualizando
                    if (oEntidad.Editar())
                    {
                        MessageBox.Show("Registro actualizado correctamente.", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un problema al actualizar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    //Estoy creando uno nuevo
                    if (oEntidad.Guardar())
                    {
                        MessageBox.Show("Registro ingresado correctamente.", "Confirmacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Close();
                    }
                    else
                    {
                        MessageBox.Show("Ocurrio un problema al guardar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch
            {

            }
        }
        private Boolean Comprobar()
        {
            Boolean Resultado = true;
            Notificador.Clear();
            if (txtCategoria.TextLength == 0)
            {
                Resultado = false;
                Notificador.SetError(txtCategoria, "Este campo no puede quedar vacio");
            }
            return Resultado;
        }
        public CategoriasEdicion()
        {
            InitializeComponent();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Comprobar())
            {
                Procesar();
            }
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void CategoriasEdicion_Load(object sender, EventArgs e)
        {

        }
    }
}
