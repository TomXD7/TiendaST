-- Inicio de Sesion
select a.IDUsuario, a.Usuario, a.IDEmpleado,
a.IDRol,
concat(b.Nombres, ' ', b.Apellidos) Empleado,
c.Rol
from usuarios a, empleados b, roles c
where a.Usuario = 'TMORATAYA'
and a.Clave = sha1(md5('12345'))
and a.IDEmpleado = b.IDEmpleado
and a.IDRol = c.IDRol;

-- Permisos asignados
select
a.IDOpcion,
a.Opcion,
if(ifnull((select IDPermiso from permisos z where z.IDRol = 1 and z.IDOpcion = a.IDOpcion), 0) = 0, 0, 1) as Seleccion,
ifnull((select IDPermiso from permisos z where z.IDRol = 1 and z.IDOpcion = a.IDOpcion), 0) as IDPermiso
from 
opciones a order by Opcion asc;

-- Comprobacion de permisos en el inicio de sesion
SELECT distinct a.IDOpcion, b.Opcion 
FROM permisos a, opciones b
where a.IDOpcion = b.IDOpcion
and a.IDRol = 1;

-- Todos los empleados

select IDEmpleado, Nombres, Apellidos, FechaNacimiento from Empleados order by Nombres;