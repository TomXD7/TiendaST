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
    public partial class UsuarioEdicion : Form
    {
        CLS.Empleados oEmpleados { get; set; }
        /*private static UsuarioEdicion _Instancia;
        public static UsuarioEdicion ObtenerInstancia()
        {
            if (_Instancia == null)
            {
                _Instancia = new UsuarioEdicion();
            }
            return _Instancia;
        }
        public void ObtenerEmpleado(String idempleado, String empleado)
        {
            this.txtIDEmpleado.Text = idempleado;
            this.txtEmpleado.Text = empleado;
        }*/
        private void Procesar()
        {
            CLS.Usuarios oEntidad = new CLS.Usuarios();
            oEntidad.IDUsuario = txtIDUsuario.Text;
            oEntidad.Usuario = txtUsuario.Text;
            oEntidad.IDEmpleado = txtIDEmpleado.Text;
            oEntidad.Clave = txtClave.Text;
            oEntidad.IDRol = cbbRoles.SelectedIndex.ToString();
            try
            {
                if (txtIDUsuario.TextLength > 0)
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
            if (txtUsuario.TextLength == 0)
            {
                Resultado = false;
                Notificador.SetError(txtUsuario, "Este campo no puede quedar vacio.");
            }
            if (txtClave.TextLength == 0)
            {
                Resultado = false;
                Notificador.SetError(txtClave, "Este campo no puede quedar vacio.");
            }
            if (txtIDEmpleado.TextLength == 0)
            {
                Resultado = false;
                Notificador.SetError(txtIDEmpleado, "Este campo no puede quedar vacio.");
            }
            if (txtEmpleado.TextLength == 0)
            {
                Resultado = false;
                Notificador.SetError(txtEmpleado, "Este campo no puede quedar vacio.");
            }
            return Resultado;
        }
        private void CargarRoles()
        {
            DataTable Roles = new DataTable();
            try
            {
                Roles = CacheManager.CLS.Cache.TODOS_LOS_ROLES();
                cbbRoles.DataSource = Roles;
                cbbRoles.DisplayMember = "Rol";
                cbbRoles.ValueMember = "IDRol";
            }
            catch
            {
                Roles = new DataTable();
            }
        }
        public UsuarioEdicion()
        {
            InitializeComponent();
        }
        private void UsuarioEdicion_Load(object sender, EventArgs e)
        {
            CargarRoles();
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
        private void btnEmpleados_Click(object sender, EventArgs e)
        {
            try
            {
                VistaEmpleado f = new VistaEmpleado();
                f.ShowDialog();
                //this.oEmpleados = f.
                txtEmpleado.Text = oEmpleados.Nombres + " " + oEmpleados.Apellidos;
            }
            catch
            {

            }
        }
    }
}
