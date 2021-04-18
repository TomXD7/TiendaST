using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General.CLS
{
    //Clase entidad
    class Permisos
    {
        //Atributos
        String _IDPermiso;
        String _IDOpcion;
        String _IDRol;
        //Propiedades
        public string IDPermiso
        {
            get
            {
                return _IDPermiso;
            }

            set
            {
                _IDPermiso = value;
            }
        }
        public string IDOpcion
        {
            get
            {
                return _IDOpcion;
            }

            set
            {
                _IDOpcion = value;
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
        //Metodos
        public Boolean Guardar()
        {
            Boolean Resultado = false;
            String Sentencia = @"insert into Permisos(IDRol, IDOpcion) values(" + this.IDRol + ", " + this.IDOpcion + ")";
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
        public Boolean Eliminar()
        {
            Boolean Resultado = false;
            String Sentencia = @"delete from Permisos where IDPermiso = " + this.IDPermiso + ";";
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
