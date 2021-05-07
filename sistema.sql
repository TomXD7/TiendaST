-- MySQL Administrator dump 1.4
--
-- ------------------------------------------------------
-- Server version	5.7.28-log


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


--
-- Create schema sistema
--

CREATE DATABASE IF NOT EXISTS sistema;
USE sistema;

--
-- Definition of table `empleados`
--

DROP TABLE IF EXISTS `empleados`;
CREATE TABLE `empleados` (
  `IDEmpleado` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Nombres` varchar(100) NOT NULL,
  `Apellidos` varchar(100) NOT NULL,
  `FechaNacimiento` datetime NOT NULL,
  PRIMARY KEY (`IDEmpleado`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `empleados`
--

/*!40000 ALTER TABLE `empleados` DISABLE KEYS */;
INSERT INTO `empleados` (`IDEmpleado`,`Nombres`,`Apellidos`,`FechaNacimiento`) VALUES 
 (1,'TOMAS','MORATAYA','1999-05-25');
/*!40000 ALTER TABLE `empleados` ENABLE KEYS */;


--
-- Definition of table `opciones`
--

DROP TABLE IF EXISTS `opciones`;
CREATE TABLE `opciones` (
  `IDOpcion` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Opcion` varchar(45) NOT NULL,
  PRIMARY KEY (`IDOpcion`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `opciones`
--

/*!40000 ALTER TABLE `opciones` DISABLE KEYS */;
INSERT INTO `opciones` (`IDOpcion`,`Opcion`) VALUES 
 (1,'INICIAR SESION');
/*!40000 ALTER TABLE `opciones` ENABLE KEYS */;


--
-- Definition of table `permisos`
--

DROP TABLE IF EXISTS `permisos`;
CREATE TABLE `permisos` (
  `IDPermiso` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `IDOpcion` int(10) unsigned NOT NULL,
  `IDRol` int(10) unsigned NOT NULL,
  PRIMARY KEY (`IDPermiso`),
  KEY `fk_permisos_Opciones_idx` (`IDOpcion`),
  KEY `fk_permisos_Roles1_idx` (`IDRol`),
  CONSTRAINT `fk_permisos_Opciones` FOREIGN KEY (`IDOpcion`) REFERENCES `opciones` (`IDOpcion`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_permisos_Roles1` FOREIGN KEY (`IDRol`) REFERENCES `roles` (`IDRol`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `permisos`
--

/*!40000 ALTER TABLE `permisos` DISABLE KEYS */;
INSERT INTO `permisos` (`IDPermiso`,`IDOpcion`,`IDRol`) VALUES 
 (1,1,1);
/*!40000 ALTER TABLE `permisos` ENABLE KEYS */;


--
-- Definition of table `roles`
--

DROP TABLE IF EXISTS `roles`;
CREATE TABLE `roles` (
  `IDRol` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Rol` varchar(45) NOT NULL,
  PRIMARY KEY (`IDRol`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `roles`
--

/*!40000 ALTER TABLE `roles` DISABLE KEYS */;
INSERT INTO `roles` (`IDRol`,`Rol`) VALUES 
 (1,'ADMINISTRADOR'),
 (2,'VENDEDOR');
/*!40000 ALTER TABLE `roles` ENABLE KEYS */;


--
-- Definition of table `usuarios`
--

DROP TABLE IF EXISTS `usuarios`;
CREATE TABLE `usuarios` (
  `IDUsuario` int(11) NOT NULL AUTO_INCREMENT,
  `Usuario` varchar(50) NOT NULL,
  `IDRol` int(10) unsigned NOT NULL,
  `Clave` varchar(250) NOT NULL,
  `IDEmpleado` int(10) unsigned NOT NULL,
  PRIMARY KEY (`IDUsuario`),
  KEY `fk_Usuarios_Roles1_idx` (`IDRol`),
  KEY `fk_Usuarios_empleados1_idx` (`IDEmpleado`),
  CONSTRAINT `fk_Usuarios_Roles1` FOREIGN KEY (`IDRol`) REFERENCES `roles` (`IDRol`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Usuarios_empleados1` FOREIGN KEY (`IDEmpleado`) REFERENCES `empleados` (`IDEmpleado`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `usuarios`
--

/*!40000 ALTER TABLE `usuarios` DISABLE KEYS */;
INSERT INTO `usuarios` (`IDUsuario`,`Usuario`,`IDRol`,`Clave`,`IDEmpleado`) VALUES 
 (1,'TMORATAYA',1,'fe703d258c7ef5f50b71e06565a65aa07194907f',1);
/*!40000 ALTER TABLE `usuarios` ENABLE KEYS */;


--
-- Definition of table `categorias`
--

drop table if exists `categorias`;
create table `categorias`(
  `IDCategoria` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `Categoria` varchar(50) NOT NULL,
  PRIMARY KEY(`IDCategoria`)
)ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `categorias`
--

/*!40000 ALTER TABLE `categorias` DISABLE KEYS */;
insert into `categorias` (`IDCategoria`, `Categoria`) values
(1, 'Desechables');
/*!40000 ALTER TABLE `categorias` ENABLE KEYS */;


--
-- Definition of table `presentacion`
--

drop table if exists `presentacion`;
create table `presentacion`(
  `IDPresentacion` int(11) unsigned NOT NULL AUTO_INCREMENT,
  `Presentacion` varchar(50) NOT NULL,
  PRIMARY KEY (`IDPresentacion`)
)ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Dumping data for tabla `presentacion`
--

/*!40000 ALTER TABLE `presentacion` DISABLE KEYS */;
insert into `presentacion` (`IDPresentacion`, `Presentacion`) values
(1, '5X8');
/*!40000 ALTER TABLE `presentacion` ENABLE KEYS */;


--
-- Definition of table `productos`
--

drop table if exists `productos`;
create table `productos`(
  `IDProducto` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `Codigo` varchar(50) NOT NULL,
  `Nombre` varchar(50) NOT NULL,
  `IDCategoria` int(11) unsigned NOT NULL,
  `IDPresentacion` int(11) unsigned NOT NULL,
  PRIMARY KEY (`IDProducto`),
  KEY `fk_Productos_Categorias1_idx` (`IDCategoria`),
  KEY `fk_Productos_Presentacion1_idx` (`IDPresentacion`),
  CONSTRAINT `fk_Productos_Categorias1` FOREIGN KEY (`IDCategoria`) REFERENCES `categorias` (`IDCategoria`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_Productos_Presentacion1` FOREIGN KEY (`IDPresentacion`) REFERENCES `presentacion` (`IDPresentacion`) ON DELETE NO ACTION ON UPDATE NO ACTION
)ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `productos`
--

/*!40000 ALTER TABLE `productos` DISABLE KEYS */;

/*!40000 ALTER TABLE `productos` ENABLE KEYS */;


--
-- Definition of table `ingreso`
--

drop table if exists `ingreso`;
create table `ingreso`(
	`IDIngreso` int(11) UNSIGNED NOT NULL AUTO_INCREMENT,
    `Fecha` datetime NOT NULL,
    `Tipo_comprobante` varchar(40) NOT NULL,
    `Serie` varchar(4) NOT NULL,
    `Correlativo` varchar(7) NOT NULL,
    `Costo` double(10,2) NOT NULL,
    PRIMARY KEY (`IDIngreso`)
)ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `ingreso`
--

/*!40000 ALTER TABLE `ingreso` DISABLE KEYS */;

/*!40000 ALTER TABLE `ingreso` ENABLE KEYS */;


--
-- Definition of table `detalle_ingreso`
--

drop table if exists `detalle_ingreso`;
create table `detalle_ingreso`(
	`IDDetalle_ingreso` int(11) UNSIGNED NOT NULL AUTO_INCREMENT,
    `IDIngreso` int(11) UNSIGNED NOT NULL,
    `IDProducto` int(10) unsigned NOT NULL,
    `Precio_compra` double(10,2) NOT NULL,
    `Precio_venta` double(10,2) NOT NULL,
    `Stock_inicial` int(10) NOT NULL,
    `Stock_actual` int(10) NOT NULL,
    PRIMARY KEY (`IDDetalle_ingreso`),
    KEY `fk_Detalle_Ingreso1_idx` (`IDIngreso`),
    KEY `fk_Detalle_Producto1_idx` (`IDProducto`),
    CONSTRAINT `fk_Detalle_Ingreso1` FOREIGN KEY (`IDIngreso`) REFERENCES `ingreso` (`IDIngreso`) ON DELETE NO ACTION ON UPDATE NO ACTION,
    CONSTRAINT `fk_Detalle_Producto1` FOREIGN KEY (`IDProducto`) REFERENCES `productos` (`IDProducto`) ON DELETE NO ACTION ON UPDATE NO ACTION
)ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `detalle_ingreso`
--

/*!40000 ALTER TABLE `detalle_ingreso` DISABLE KEYS */;

/*!40000 ALTER TABLE `detalle_ingreso` ENABLE KEYS */;


--
-- Definition of table `venta`
--

drop table if exists `venta`;
create table `venta`(
	`IDVenta` int(10) unsigned NOT NULL AUTO_INCREMENT,
    `Nombre_Cliente` varchar(50) NOT NULL,
    `Fecha` datetime NOT NULL,
    `Documento` enum('Ticket', 'Consumidor Final', 'Credito Fiscal'),
    `Serie` varchar(4) NOT NULL,
    `Correlativo` varchar(7) NOT NULL,
    `Total` double(10,2) NOT NULL,
    PRIMARY KEY (`IDVenta`)
)ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

--
-- Dumping data for table `venta`
--

/*!40000 ALTER TABLE `venta` DISABLE KEYS */;

/*!40000 ALTER TABLE `venta` ENABLE KEYS */;


--
-- Definition of table `detalle_venta`
--

drop table if exists `detalle_venta`;
create table `detalle_venta`(
	`IDDetalle_venta` int(10) unsigned NOT NULL AUTO_INCREMENT,
    `IDVenta` int(10) unsigned NOT NULL,
    `IDDetalle_ingreso` int(11) unsigned NOT NULL,
    `Cantidad` int(7) NOT NULL,
    `Precio_venta` double(10,2) NOT NULL,
    PRIMARY KEY (`IDDetalle_venta`),
    KEY `fk_Detalle_Venta1_idx` (`IDVenta`),
    KEY `fk_Detalle_Detalle1_idx` (`IDDetalle_ingreso`),
    CONSTRAINT `fk_Detalle_Venta1` FOREIGN KEY (`IDVenta`) REFERENCES `venta` (`IDVenta`) ON DELETE NO ACTION ON UPDATE NO ACTION,
    CONSTRAINT `fk_Detalle_Detalle1` FOREIGN KEY (`IDDetalle_ingreso`) REFERENCES `detalle_ingreso` (`IDDetalle_ingreso`) ON DELETE NO ACTION ON UPDATE NO ACTION
)ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;



/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;