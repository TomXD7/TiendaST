using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.CLS
{
    class Categorias
    {
        String _IDCategoria;
        String _Categoria;
        public string IDCategoria
        {
            get
            {
                return _IDCategoria;
            }

            set
            {
                _IDCategoria = value;
            }
        }
        public string Categoria
        {
            get
            {
                return _Categoria;
            }

            set
            {
                _Categoria = value;
            }
        }
        public Boolean Guardar()
        {
            Boolean Resultado = false;
            String Sentencia = @"insert into categorias(Categoria) values('" + this._Categoria + "')";
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
            String Sentencia = @"update categorias set Categoria = '" + this._Categoria + "' where IDCategoria = " + this._IDCategoria + ";";
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
            String Sentencia = @"delete from categorias where IDCategoria = " + this._IDCategoria + ";";
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
