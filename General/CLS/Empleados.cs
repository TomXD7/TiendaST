using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.CLS
{
    class Empleados
    {
        String _IDEmpleado;
        String _Nombres;
        String _Apellidos;
        String _FechaNacimiento;
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
        public string Nombres
        {
            get
            {
                return _Nombres;
            }

            set
            {
                _Nombres = value;
            }
        }
        public string Apellidos
        {
            get
            {
                return _Apellidos;
            }

            set
            {
                _Apellidos = value;
            }
        }
        public string FechaNacimiento
        {
            get
            {
                return _FechaNacimiento;
            }

            set
            {
                _FechaNacimiento = value;
            }
        }
        public Boolean Guardar()
        {
            Boolean Resultado = false;
            String Sentencia = @"insert into Empleados(Nombres, Apellidos, FechaNacimiento) values ('"+ this._Nombres +"', '"+ this._Apellidos +"', '"+ this.FechaNacimiento +"')";
            try
            {
                DataManager.CLS.OperacionDB Operacion = new DataManager.CLS.OperacionDB();
                if(Operacion.Insertar(Sentencia) > 0)
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
            String Sentencia = @"update Empleados set Nombres = '" + this._Nombres + "', Apellidos = '"+ this._Apellidos +"', FechaNacimiento = '"+ this.FechaNacimiento +"' where IDEmpleado = " + this._IDEmpleado + ";";
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
            String Sentencia = @"delete from Empleados where IDRol = " + this._IDEmpleado + ";";
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
