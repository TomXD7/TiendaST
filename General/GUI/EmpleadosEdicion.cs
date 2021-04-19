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
    public partial class EmpleadosEdicion : Form
    {
        private void Procesar()
        {
            CLS.Empleados oEntidad = new CLS.Empleados();
            oEntidad.IDEmpleado = txtIDEmpleado.Text;
            oEntidad.Nombres = txtNombres.Text;
            oEntidad.Apellidos = txtApellidos.Text;
            oEntidad.FechaNacimiento = dtpFechaNacimiento.Text;
            try
            {
                if(txtIDEmpleado.TextLength > 0)
                {
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
            if(txtNombres.TextLength == 0)
            {
                Resultado = false;
                Notificador.SetError(txtNombres, "Este campo no puede quedar vacio.");
            }
            if (txtApellidos.TextLength == 0)
            {
                Resultado = false;
                Notificador.SetError(txtApellidos, "Este campo no puede quedar vacio.");
            }
            return Resultado;
        }
        public EmpleadosEdicion()
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
