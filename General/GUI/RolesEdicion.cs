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
    public partial class RolesEdicion : Form
    {
        private void Procesar()
        {
            CLS.Roles oEntidad = new CLS.Roles();
            oEntidad.IDRol = txtIDRol.Text;
            oEntidad.Rol = txtRol.Text;
            try
            {
                if (txtIDRol.TextLength > 0)
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
            if(txtRol.TextLength == 0)
            {
                Resultado = false;
                Notificador.SetError(txtRol, "Este campo no puede quedar vacio");
            }
            return Resultado;
        }
        public RolesEdicion()
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

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
