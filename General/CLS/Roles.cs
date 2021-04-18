using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.CLS
{
    //Clase entidad
    class Roles
    {
        //Atributos
        String _IDRol;
        String _Rol;
        //Propiedades
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
        public string Rol
        {
            get
            {
                return _Rol;
            }

            set
            {
                _Rol = value;
            }
        }
        //Metodos
        public Boolean Guardar()
        {
            Boolean Resultado = false;
            String Sentencia = @"insert into Roles(Rol) values('"+ this._Rol +"')";
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
            String Sentencia = @"update Roles set Rol = '" + this._Rol + "' where IDRol = "+ this._IDRol +";";
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
            String Sentencia = @"delete from Roles where IDRol = " + this._IDRol + ";";
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
