using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaST.GUI
{
    public partial class Login : Form
    {
        Boolean _Validado = false;

        public bool Validado
        {
            get
            {
                return _Validado;
            }
        }

        private void Validar()
        {
            try
            {
                SesionManager.CLS.Sesion SesionInicial = SesionManager.CLS.Sesion.Intancia;
                _Validado = SesionInicial.IniciarSesion(txtUsuario.Text, txtClave.Text);
                if(_Validado == true)
                {
                    Close();
                }
                else
                {
                    lblMensaje.Text = "Usuario o clave erroneos, vuelva a intentarlo";
                }
            }
            catch
            {
                _Validado = false;
            }
        }


        public Login()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            Validar();
        }

        private void brnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                txtClave.Focus();
                txtClave.SelectAll();
            }
        }

        private void txtClave_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnEntrar.PerformClick();
            }
        }
    }
}
