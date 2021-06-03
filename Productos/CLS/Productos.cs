using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Productos.CLS
{
    class Productos
    {
        String _IDProducto;
        String _Codigo;
        String _Aux;
        String _Descripcion;
        String _Marca;
        String _IDCategoria;
        String _IDPresentacion;
        public string IDProducto
        {
            get
            {
                return _IDProducto;
            }

            set
            {
                _IDProducto = value;
            }
        }
        public string Codigo
        {
            get
            {
                return _Codigo;
            }

            set
            {
                _Codigo = value;
            }
        }
        public string Descripcion
        {
            get
            {
                return _Descripcion;
            }

            set
            {
                _Descripcion = value;
            }
        }
        public string Marca
        {
            get
            {
                return _Marca;
            }

            set
            {
                _Marca = value;
            }
        }
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
        public string Aux
        {
            get
            {
                return _Aux;
            }

            set
            {
                _Aux = value;
            }
        }
        public Boolean Guardar()
        {
            Boolean Resultado = false;
            String Sentencia = @"insert into productos(Codigo, Descripcion, Marca, IDCategoria, IDPresentacion)
                                values ('" + this._Codigo + "', concat('" + this._Aux + " ', (select Presentacion from presentacion where IDPresentacion = '" + this._IDPresentacion + "'), ' ', (select Categoria from categorias where IDCategoria = '" + this._IDCategoria + "')), '" + this._Marca + "', '" + this._IDCategoria + "', '" + this._IDPresentacion + "');";
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
            String Sentencia = @"update productos set Codigo = '" + this._Codigo + "', Descripcion = concat('" + this._Aux + " ', (select Presentacion from presentacion where IDPresentacion = '" + this._IDPresentacion + "'), ' ', (select Categoria from categorias where IDCategoria = '" + this.IDCategoria + "')), Marca = '" + this._Marca + "', IDCategoria = '" + this._IDCategoria + "', IDPresentacion = '" + this._IDPresentacion + "' where IDProducto = '" + this._IDProducto + "';";
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
            String Sentencia = @"delete from productos where IDProducto = " + this._IDProducto + ";";
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
