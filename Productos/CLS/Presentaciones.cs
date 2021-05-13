using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.CLS
{
    class Presentaciones
    {
        String _IDPresentacion;
        String _Presentacion;
        public string IDPresentacion
        {
            get
            {
                return _IDPresentacion;
            }

            set
            {
                _IDPresentacion = value;
            }
        }
        public string Presentacion
        {
            get
            {
                return _Presentacion;
            }

            set
            {
                _Presentacion = value;
            }
        }
        public Boolean Guardar()
        {
            Boolean Resultado = false;
            String Sentencia = @"insert into presentacion(Presentacion) values('" + this._Presentacion + "')";
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
            String Sentencia = @"update presentacion set Presentacion = '" + this._Presentacion + "' where IDPresentacion = " + this._IDPresentacion + ";";
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
            String Sentencia = @"delete from presentacion where IDPresentacion = " + this._IDPresentacion + ";";
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
