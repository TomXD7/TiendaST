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
  `FechaNacimiento` date NOT NULL,
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




/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;