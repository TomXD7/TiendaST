using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.CLS
{
    class Usuarios
    {
        String _IDUsuario;
        String _Usuario;
        String _IDRol;
        String _Clave;
        String _IDEmpleado;
        public string IDUsuario
        {
            get
            {
                return _IDUsuario;
            }

            set
            {
                _IDUsuario = value;
            }
        }
        public string Usuario
        {
            get
            {
                return _Usuario;
            }

            set
            {
                _Usuario = value;
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
        public string Clave
        {
            get
            {
                return _Clave;
            }

            set
            {
                _Clave = value;
            }
        }
        public string IDEmpleado
        {
            get
            {
                return _IDEmpleado;
            }

            set
            {
                _IDEmpleado = value;
            }
        }
        public Boolean Guardar()
        {
            Boolean Resultado = false;
            String Sentencia = @"insert into usuarios(Usuario, IDRol, Clave, IDEmpleado) values ('" + this._Usuario + "', '" + this._IDRol + "', sha1(md5('" + this._Clave + "')), '" + this._IDEmpleado + "')";
            try
            {
                DataManager.CLS.OperacionDB Operacion = new DataManager.CLS.OperacionDB();
                if (Operacion.Insertar(Sentencia) > 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;
                }
            }
            catch
            {
                Resultado = false;
            }
            return Resultado;
        }
        public Boolean Editar()
        {
            Boolean Resultado = false;
            String Sentencia = @"update usuarios set Usuario = '" + this._Usuario + "', IDRol = '" + this._IDRol + "', Clave = sha1(md5('" + this._Clave + "')), IDEmpleado = '" + this._IDEmpleado + "' where IDUsuario = " + this._IDUsuario + ";";
            try
            {
                DataManager.CLS.OperacionDB Operacion = new DataManager.CLS.OperacionDB();
                if (Operacion.Actualizar(Sentencia) > 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;
                }
            }
            catch
            {
                Resultado = false;
            }
            return Resultado;
        }
        public Boolean Eliminar()
        {
            Boolean Resultado = false;
            String Sentencia = @"delete from usuarios where IDUsuario = " + this._IDUsuario + ";";
            try
            {
                DataManager.CLS.OperacionDB Operacion = new DataManager.CLS.OperacionDB();
                if (Operacion.Eliminar(Sentencia) > 0)
                {
                    Resultado = true;
                }
                else
                {
                    Resultado = false;
                }
            }
            catch
            {
                Resultado = false;
            }
            return Resultado;
        }
    }
}
