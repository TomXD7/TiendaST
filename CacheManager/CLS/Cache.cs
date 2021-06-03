using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CacheManager.CLS
{
    public static class Cache
    {
        public static DataTable INICIAR_SESION(String pUsuario, String pClave)
        {
            DataTable Resultados = new DataTable();
            DataManager.CLS.OperacionDB Consultor = new DataManager.CLS.OperacionDB();
            String Consulta = @"select a.IDUsuario, a.Usuario, a.IDEmpleado,
            a.IDRol, concat(b.Nombres, ' ', b.Apellidos) Empleado, c.Rol
            from usuarios a, empleados b, roles c
            where a.Usuario = '" + pUsuario + @"'
            and a.Clave = sha1(md5('" + pClave + @"'))
            and a.IDEmpleado = b.IDEmpleado
            and a.IDRol = c.IDRol;";
            try
            {
                Resultados = Consultor.Consultar(Consulta);
            }
            catch
            {
                Resultados = new DataTable();
            }
            return Resultados;
        }
        public static DataTable PERMISOS_DE_UN_USUARIO(String pIDRol)
        {
            DataTable Resultados = new DataTable();
            DataManager.CLS.OperacionDB Consultor = new DataManager.CLS.OperacionDB();
            String Consulta = @"SELECT distinct a.IDOpcion, b.Opcion 
            FROM permisos a, opciones b
            where a.IDOpcion = b.IDOpcion
            and a.IDRol = "+ pIDRol +";";
            try
            {
                Resultados = Consultor.Consultar(Consulta);
            }
            catch
            {
                Resultados = new DataTable();
            }
            return Resultados;
        }
        public static DataTable TODOS_LOS_ROLES()
        {
            DataTable Resultados = new DataTable();
            DataManager.CLS.OperacionDB Consultor = new DataManager.CLS.OperacionDB();
            String Consulta = @"select IDRol, Rol from Roles order by Rol;";
            try
            {
                Resultados = Consultor.Consultar(Consulta);
            }
            catch
            {
                Resultados = new DataTable();
            }
            return Resultados;
        }
        public static DataTable TODAS_LAS_CATEGORIAS()
        {
            DataTable Resultados = new DataTable();
            DataManager.CLS.OperacionDB Consultor = new DataManager.CLS.OperacionDB();
            String Consulta = @"select IDCategoria, Categoria from categorias order by Categoria;";
            try
            {
                Resultados = Consultor.Consultar(Consulta);
            }
            catch
            {
                Resultados = new DataTable();
            }
            return Resultados;
        }
        public static DataTable TODAS_LAS_PRESENTACIONES()
        {
            DataTable Resultados = new DataTable();
            DataManager.CLS.OperacionDB Consultor = new DataManager.CLS.OperacionDB();
            String Consulta = @"select IDPresentacion, Presentacion from presentacion order by Presentacion;";
            try
            {
                Resultados = Consultor.Consultar(Consulta);
            }
            catch
            {
                Resultados = new DataTable();
            }
            return Resultados;
        }
        public static DataTable TODOS_LOS_EMPLEADOS()
        {
            DataTable Resultados = new DataTable();
            DataManager.CLS.OperacionDB Consultor = new DataManager.CLS.OperacionDB();
            String Consulta = @"select IDEmpleado, Nombres, Apellidos, FechaNacimiento from Empleados order by Nombres;";
            try
            {
                Resultados = Consultor.Consultar(Consulta);
            }
            catch
            {
                Resultados = new DataTable();
            }
            return Resultados;
        }
        public static DataTable TODOS_LOS_USUARIOS()
        {
            DataTable Resultados = new DataTable();
            DataManager.CLS.OperacionDB Consultor = new DataManager.CLS.OperacionDB();
            String Consulta = @"select us.IDUsuario, us.Usuario, us.Clave, r.IDRol, r.Rol, e.IDEmpleado, concat(e.Nombres, ' ', e.Apellidos) as Empleado  from usuarios us
                                inner join roles r on r.IDRol = us.IDRol
                                inner join empleados e on e.IDEmpleado = us.IDEmpleado;";
            try
            {
                Resultados = Consultor.Consultar(Consulta);
            }
            catch
            {
                Resultados = new DataTable();
            }
            return Resultados;
        }
        public static DataTable TODOS_LOS_PRODUCTOS()
        {
            DataTable Resultados = new DataTable();
            DataManager.CLS.OperacionDB Consultor = new DataManager.CLS.OperacionDB();
            String Consulta = @"select p.IDProducto, p.Codigo, p.Descripcion, p.Marca, ca.IDCategoria, ca.Categoria, pre.IDPresentacion, pre.Presentacion
                    from productos p
                    inner join categorias ca on ca.IDCategoria = p.IDCategoria
                    inner join presentacion pre on pre.IDPresentacion = p.IDPresentacion;";
            try
            {
                Resultados = Consultor.Consultar(Consulta);
            }
            catch
            {
                Resultados = new DataTable();
            }
            return Resultados;
        }
        public static DataTable PERMISOS_DE_UN_ROL(String pIDRol)
        {
            DataTable Resultados = new DataTable();
            DataManager.CLS.OperacionDB Consultor = new DataManager.CLS.OperacionDB();
            String Consulta = @"select
            a.IDOpcion,
            a.Opcion,
            if(ifnull((select IDPermiso from permisos z where z.IDRol = " + pIDRol + @" and z.IDOpcion = a.IDOpcion), 0) = 0, 0, 1) as Seleccion,
            ifnull((select IDPermiso from permisos z where z.IDRol = " + pIDRol +@" and z.IDOpcion = a.IDOpcion), 0) as IDPermiso
            from 
            opciones a order by Opcion asc;";
            try
            {
                Resultados = Consultor.Consultar(Consulta);
            }
            catch
            {
                Resultados = new DataTable();
            }
            return Resultados;
        }
    }
}
