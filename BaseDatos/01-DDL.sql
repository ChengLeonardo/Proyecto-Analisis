SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE = 'ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';


-- -----------------------------------------------------
-- Schema Biblioteca
-- -----------------------------------------------------
DROP SCHEMA IF EXISTS `5to_Biblioteca` ;


-- -----------------------------------------------------
-- Schema Biblioteca
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `5to_Biblioteca` DEFAULT CHARACTER SET utf8 ;
USE `5to_Biblioteca` ;


-- -----------------------------------------------------
-- Table `5to_Biblioteca`.`Editorial`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `5to_Biblioteca`.`Editorial` (
  `idEditorial` INT NOT NULL AUTO_INCREMENT,
  `Editorial` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idEditorial`))
;




-- -----------------------------------------------------
-- Table `5to_Biblioteca`.`Autor`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `5to_Biblioteca`.`Autor` (
  `idAutor` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) NOT NULL,
  `apellido` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idAutor`))
;




-- -----------------------------------------------------
-- Table `5to_Biblioteca`.`Socio`
-- -----------------------------------------------------




-- -----------------------------------------------------
-- Table `5to_Biblioteca`.`Titulo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `5to_Biblioteca`.`Titulo` (
  `idTitulo` INT NOT NULL AUTO_INCREMENT,
  `titulo` VARCHAR(50) NOT NULL,
  PRIMARY KEY (`idTitulo`))
;




-- -----------------------------------------------------
-- Table `5to_Biblioteca`.`Libro`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `5to_Biblioteca`.`Libro` (
  `idLibro` INT NOT NULL AUTO_INCREMENT,
  `idEditorial` INT NOT NULL,
  `idTitulo` INT NOT NULL,
  `ISBN` VARCHAR(30) NOT NULL,
  fechaAgregada DATE,
  rutaFoto VARCHAR(255),
  calificacion DOUBLE,
  PRIMARY KEY (`idLibro`),
  UNIQUE INDEX `idbn_UNIQUE` (`ISBN` ASC),
  INDEX `fk_Libro_Titulo1_idx` (`idTitulo` ASC),
  INDEX `fk_Libro_Editorial1_idx` (`idEditorial` ASC),
  CONSTRAINT `fk_Libro_Titulo1`
    FOREIGN KEY (`idTitulo`)
    REFERENCES `5to_Biblioteca`.`Titulo` (`idTitulo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Libro_Editorial1`
    FOREIGN KEY (`idEditorial`)
    REFERENCES `5to_Biblioteca`.`Editorial` (`idEditorial`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;




-- -----------------------------------------------------
-- Table `5to_Biblioteca`.`AutorTitulo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `5to_Biblioteca`.`AutorTitulo` (
  `idAutor` INT NOT NULL,
  `idTitulo` INT NOT NULL,
  PRIMARY KEY (`idAutor`, `idTitulo`),
  INDEX `fk_AutorTitulo_Titulo1_idx` (`idTitulo` ASC),
  CONSTRAINT `fk_AutorTitulo_Autor1`
    FOREIGN KEY (`idAutor`)
    REFERENCES `5to_Biblioteca`.`Autor` (`idAutor`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_AutorTitulo_Titulo1`
    FOREIGN KEY (`idTitulo`)
    REFERENCES `5to_Biblioteca`.`Titulo` (`idTitulo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;




-- -----------------------------------------------------
-- Table `5to_Biblioteca`.`Ejemplar`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `5to_Biblioteca`.`Ejemplar` (
  `idEjemplar` INT UNSIGNED NOT NULL AUTO_INCREMENT,
  `idLibro` INT NOT NULL,
  `nroEjemplar` INT(3) UNSIGNED NOT NULL,
  PRIMARY KEY (`idEjemplar`),
  INDEX `fk_Ejemplar_Libro1_idx` (`idLibro` ASC),
  UNIQUE INDEX `nroEjemplar_UNIQUE` (`nroEjemplar` ASC, `idEjemplar` ASC),
  CONSTRAINT `fk_Ejemplar_Libro1`
    FOREIGN KEY (`idLibro`)
    REFERENCES `5to_Biblioteca`.`Libro` (`idLibro`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;







-- -----------------------------------------------------
-- Table `5to_Biblioteca`.`Prestamo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `5to_Biblioteca`.`Prestamo` (
  `idPrestamo` INT NOT NULL AUTO_INCREMENT,
  `idEjemplar` INT UNSIGNED NOT NULL,
  `idSocio` INT NOT NULL,
  `salida` DATETIME NULL DEFAULT CURRENT_TIMESTAMP,
  `idOperadorEntrega` INT NOT NULL,
  `regreso` DATETIME NULL DEFAULT NULL,
  `idOperadorRegreso` INT NULL DEFAULT NULL,
  PRIMARY KEY (`idPrestamo`),
  INDEX `fk_Prestamo_Ejemplar1_idx` (`idEjemplar` ASC),
  INDEX `fk_Prestamo_Socio1_idx` (`idSocio` ASC),
  UNIQUE INDEX `unicoEjemplarSocio` (`idEjemplar` ASC, `idSocio` ASC),
  INDEX `fk_Prestamo_Operador1_idx` (`idOperadorEntrega` ASC),
  INDEX `fk_Prestamo_Operador2_idx` (`idOperadorRegreso` ASC),
  CONSTRAINT `fk_Prestamo_Ejemplar1`
    FOREIGN KEY (`idEjemplar`)
    REFERENCES `5to_Biblioteca`.`Ejemplar` (`idEjemplar`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Prestamo_Socio1`
    FOREIGN KEY (`idSocio`)
    REFERENCES `5to_Biblioteca`.`Socio` (`idSocio`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION, 
  CONSTRAINT `fk_Prestamo_Operador1`
    FOREIGN KEY (`idOperadorEntrega`)
    REFERENCES `5to_Biblioteca`.`Operador` (`idOperador`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Prestamo_Operador2`
    FOREIGN KEY (`idOperadorRegreso`)
    REFERENCES `5to_Biblioteca`.`Operador` (`idOperador`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;




-- -----------------------------------------------------
-- Table `5to_Biblioteca`.`Genero`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `5to_Biblioteca`.`Genero` (
  `idGenero` INT NOT NULL AUTO_INCREMENT,
  `genero` VARCHAR(30) NOT NULL,
  rutaFoto VARCHAR(255),
  PRIMARY KEY (`idGenero`))
;




-- -----------------------------------------------------
-- Table `5to_Biblioteca`.`GeneroTitulo`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `5to_Biblioteca`.`GeneroTitulo` (
  `idGenero` INT NOT NULL,
  `idTitulo` INT NOT NULL,
  PRIMARY KEY (`idGenero`, `idTitulo`),
  INDEX `fk_GeneroTitulo_Titulo1_idx` (`idTitulo` ASC),
  CONSTRAINT `fk_GeneroLibro_Genero1`
    FOREIGN KEY (`idGenero`)
    REFERENCES `5to_Biblioteca`.`Genero` (`idGenero`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_GeneroTitulo_Titulo1`
    FOREIGN KEY (`idTitulo`)
    REFERENCES `5to_Biblioteca`.`Titulo` (`idTitulo`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
;




-- -----------------------------------------------------
-- Table `5to_Biblioteca`.`Usuario`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `5to_Biblioteca`.`Usuario` (
  `idUsuario` INT NOT NULL AUTO_INCREMENT,
  `nombre` VARCHAR(45) NOT NULL,
  `apellido` VARCHAR(45) NOT NULL,
  `email` VARCHAR(100) NOT NULL,
  `nombreUsuario` VARCHAR(45) NOT NULL,
  `pass` CHAR(64) NOT NULL,
  `tipoUsuario` int not null DEFAULT 1,
  PRIMARY KEY (`idUsuario`),
  UNIQUE INDEX `usuario_UNIQUE` (`nombreUsuario` ASC))
;


-- -----------------------------------------------------
-- Table `5to_Biblioteca`.`Operador`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `5to_Biblioteca`.`Operador` (
  `idOperador` INT NOT NULL AUTO_INCREMENT,
  `idUsuario` INT NOT NULL,
  PRIMARY KEY (`idOperador`),
  CONSTRAINT `fk_Operador_Usuario`
    FOREIGN KEY (`idUsuario`)
    REFERENCES `5to_Biblioteca`.`Usuario` (`idUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
);

CREATE TABLE IF NOT EXISTS `5to_Biblioteca`.`Socio` (
  `idSocio` INT NOT NULL AUTO_INCREMENT,
  `idUsuario` INT NOT NULL,
  `telefono` INT(10) NULL,
  `fechaNacimiento` DATE NULL,
  PRIMARY KEY (`idSocio`),
  CONSTRAINT `fk_Socio_Usuario`
    FOREIGN KEY (`idUsuario`)
    REFERENCES `5to_Biblioteca`.`Usuario` (`idUsuario`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION
);

-- -----------------------------------------------------
-- Data for table `5to_Biblioteca`.`Editorial`
-- -- -----------------------------------------------------
-- START TRANSACTION;
-- USE `5to_Biblioteca`;
-- INSERT INTO `5to_Biblioteca`.`Editorial` (`idEditorial`, `Editorial`) VALUES (1, 'Planeta');


-- COMMIT;




-- -- -----------------------------------------------------
-- -- Data for table `5to_Biblioteca`.`Autor`
-- -- -----------------------------------------------------
-- START TRANSACTION;
-- USE `5to_Biblioteca`;
-- INSERT INTO `5to_Biblioteca`.`Autor` (`idAutor`, `nombre`, `apellido`) VALUES (1, 'Roberto', 'Arlt');


-- COMMIT;




-- -- -----------------------------------------------------
-- -- Data for table `5to_Biblioteca`.`Socio`
-- -- -----------------------------------------------------
-- START TRANSACTION;
-- USE `5to_Biblioteca`;
-- INSERT INTO `5to_Biblioteca`.`Socio` (`idSocio`, `nombre`, `apellido`, `email`, `telefono`, `fechaNacimiento`) VALUES (100, 'Matias', 'Tolaba', NULL, NULL, '2006-05-15');


-- COMMIT;




-- -- -----------------------------------------------------
-- -- Data for table `5to_Biblioteca`.`Titulo`
-- -- -----------------------------------------------------
-- START TRANSACTION;
-- USE `5to_Biblioteca`;
-- INSERT INTO `5to_Biblioteca`.`Titulo` (`idTitulo`, `titulo`) VALUES (1, 'El Juguete Rabioso');


-- COMMIT;




-- -- -----------------------------------------------------
-- -- Data for table `5to_Biblioteca`.`Libro`
-- -- -----------------------------------------------------
-- START TRANSACTION;
-- USE `5to_Biblioteca`;
-- INSERT INTO `5to_Biblioteca`.`Libro` (`idLibro`, `idEditorial`, `idTitulo`, `ISBN`, fechaAgregada, calificacion) VALUES (10, 1, 1, '123456', CURRENT_DATE(), 4.0);


-- COMMIT;




-- -- -----------------------------------------------------
-- -- Data for table `5to_Biblioteca`.`AutorTitulo`
-- -- -----------------------------------------------------
-- START TRANSACTION;
-- USE `5to_Biblioteca`;
-- INSERT INTO `5to_Biblioteca`.`AutorTitulo` (`idAutor`, `idTitulo`) VALUES (1, 1);


-- COMMIT;




-- -- -----------------------------------------------------
-- -- Data for table `5to_Biblioteca`.`Ejemplar`
-- -- -----------------------------------------------------
-- START TRANSACTION;
-- USE `5to_Biblioteca`;
-- INSERT INTO `5to_Biblioteca`.`Ejemplar` (`idEjemplar`, `idLibro`, `nroEjemplar`) VALUES (1, 10, 1);
-- INSERT INTO `5to_Biblioteca`.`Ejemplar` (`idEjemplar`, `idLibro`, `nroEjemplar`) VALUES (2, 10, 2);
-- INSERT INTO `5to_Biblioteca`.`Ejemplar` (`idEjemplar`, `idLibro`, `nroEjemplar`) VALUES (3, 10, 3);


-- COMMIT;




-- -- -----------------------------------------------------
-- -- Data for table `5to_Biblioteca`.`Genero`
-- -- -----------------------------------------------------
-- START TRANSACTION;
-- USE `5to_Biblioteca`;
-- INSERT INTO `5to_Biblioteca`.`Genero` (`idGenero`, `genero`) VALUES (1, 'Ficción');


-- COMMIT;




-- -- -----------------------------------------------------
-- -- Data for table `5to_Biblioteca`.`GeneroTitulo`
-- -- -----------------------------------------------------
-- START TRANSACTION;
-- USE `5to_Biblioteca`;
-- INSERT INTO `5to_Biblioteca`.`GeneroTitulo` (`idGenero`, `idTitulo`) VALUES (1, 1);


-- COMMIT;


