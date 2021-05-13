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
    public partial class PresentacionEdicion : Form
    {
        private void Procesar()
        {
            CLS.Presentaciones oEntidad = new CLS.Presentaciones();
            oEntidad.IDPresentacion = txtIDPresentacion.Text;
            oEntidad.Presentacion = txtPresentacion.Text;
            try
            {
                if (txtIDPresentacion.TextLength > 0)
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
            if (txtPresentacion.TextLength == 0)
            {
                Resultado = false;
                Notificador.SetError(txtPresentacion, "Este campo no puede quedar vacio");
            }
            return Resultado;
        }
        public PresentacionEdicion()
        {
            InitializeComponent();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (Comprobar())
            {
                Procesar();
            }
        }
    }
}
