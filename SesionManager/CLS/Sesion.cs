using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SesionManager.CLS
{
    public sealed class Sesion
    {
        private static Sesion instancia = null;
        private static readonly object padlock = new object();
        //Mis atributos.
        String _Usuario;
        String _IDRol;
        String _Rol;
        String _IDUsuario;
        String _Empleado;
        DataTable _PERMISOS = new DataTable();
        public static Sesion Intancia
        {
            get
            {
                if (instancia == null)
                {
                    lock (padlock)
                    {
                        if (instancia == null)
                        {
                            instancia = new Sesion();
                        }
                    }
                }
                return instancia;
            }
        }
        public string Usuario
        {
            get
            {
                return _Usuario;
            }
        }
        public string Rol
        {
            get
            {
                return _Rol;
            }
        }
        public string IDUsuario
        {
            get
            {
                return _IDUsuario;
            }
        }
        public string Empleado
        {
            get
            {
                return _Empleado;
            }
        }
        public string IDRol
        {
            get
            {
                return _IDRol;
            }

            set
            {
                _IDRol = value;
            }
        }

        private Sesion()
        {
            _Usuario = "N/A";
        }
        public Boolean IniciarSesion(String pUsuario, String pClave)
        {
            Boolean Autorizado = false;
            DataTable DatosSesion = new DataTable();
            try
            {
                DatosSesion = CacheManager.CLS.Cache.INICIAR_SESION(pUsuario, pClave);
                if(DatosSesion.Rows.Count == 1)
                {
                    _Usuario = DatosSesion.Rows[0]["Usuario"].ToString();
                    _IDUsuario = DatosSesion.Rows[0]["IDUsuario"].ToString();
                    _Rol = DatosSesion.Rows[0]["Rol"].ToString();
                    _IDRol = DatosSesion.Rows[0]["IDRol"].ToString();
                    _Empleado = DatosSesion.Rows[0]["Empleado"].ToString();
                    CargarPermisos();
                    Autorizado = true;
                }
                else
                {
                    Autorizado = false;
                }
            }
            catch
            {
                Autorizado = false;
            }
            return Autorizado;
        }
        public void CargarPermisos()
        {
            try
            {
                _PERMISOS = CacheManager.CLS.Cache.PERMISOS_DE_UN_USUARIO(_IDRol);
            }
            catch
            {
                _PERMISOS = new DataTable();
            }
        }
        public Boolean ComprobarPermisos(Int32 pIDOpcion)
        {
            Boolean Autorizado = false;
            Int32 IDOpcion;
            foreach (DataRow Fila in _PERMISOS.Rows)
            {
                try
                {
                    IDOpcion = Convert.ToInt32(Fila["IDOpcion"].ToString());
                    if(IDOpcion == pIDOpcion)
                    {
                        Autorizado = true;
                        break;
                    }
                }
                catch
                {

                }
            }
            if (!Autorizado)
            {
                MessageBox.Show("El usuario no tiene permiso para realizar esta accion", "Opcion " + pIDOpcion, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            return Autorizado;
        }
    }
}
