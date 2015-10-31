SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema Univercity
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `Univercity` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `Univercity` ;

-- -----------------------------------------------------
-- Table `Univercity`.`FACULTIES`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Univercity`.`FACULTIES` (
  `idFaculties` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(50) NULL,
  PRIMARY KEY (`idFaculties`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Univercity`.`DEPARTMANTS`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Univercity`.`DEPARTMANTS` (
  `idDEPARTMANTS` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `FACULTIES_idFaculties` INT NOT NULL,
  PRIMARY KEY (`idDEPARTMANTS`),
  INDEX `fk_DEPARTMANTS_FACULTIES_idx` (`FACULTIES_idFaculties` ASC),
  CONSTRAINT `fk_DEPARTMANTS_FACULTIES`
    FOREIGN KEY (`FACULTIES_idFaculties`)
    REFERENCES `Univercity`.`FACULTIES` (`idFaculties`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Univercity`.`STUDENTS`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Univercity`.`STUDENTS` (
  `idSTUDENTS` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idSTUDENTS`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Univercity`.`PROFESSORS`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Univercity`.`PROFESSORS` (
  `idPROFESSORS` INT NOT NULL AUTO_INCREMENT,
  `mane` VARCHAR(45) NOT NULL,
  `DEPARTMANTS_idDEPARTMANTS` INT NOT NULL,
  PRIMARY KEY (`idPROFESSORS`),
  INDEX `fk_PROFESSORS_DEPARTMANTS1_idx` (`DEPARTMANTS_idDEPARTMANTS` ASC),
  CONSTRAINT `fk_PROFESSORS_DEPARTMANTS1`
    FOREIGN KEY (`DEPARTMANTS_idDEPARTMANTS`)
    REFERENCES `Univercity`.`DEPARTMANTS` (`idDEPARTMANTS`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Univercity`.`COURSES`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Univercity`.`COURSES` (
  `idCOURSES` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `DEPARTMANTS_idDEPARTMANTS` INT NOT NULL,
  `PROFESSORS_idPROFESSORS` INT NOT NULL,
  PRIMARY KEY (`idCOURSES`),
  INDEX `fk_COURSES_DEPARTMANTS1_idx` (`DEPARTMANTS_idDEPARTMANTS` ASC),
  INDEX `fk_COURSES_PROFESSORS1_idx` (`PROFESSORS_idPROFESSORS` ASC),
  CONSTRAINT `fk_COURSES_DEPARTMANTS1`
    FOREIGN KEY (`DEPARTMANTS_idDEPARTMANTS`)
    REFERENCES `Univercity`.`DEPARTMANTS` (`idDEPARTMANTS`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_COURSES_PROFESSORS1`
    FOREIGN KEY (`PROFESSORS_idPROFESSORS`)
    REFERENCES `Univercity`.`PROFESSORS` (`idPROFESSORS`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Univercity`.`COURCES_STUDENTS`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Univercity`.`COURCES_STUDENTS` (
  `COURSES_idCOURSES` INT NOT NULL,
  `STUDENTS_idSTUDENTS` INT NOT NULL,
  INDEX `fk_COURCES_STUDENTS_COURSES1_idx` (`COURSES_idCOURSES` ASC),
  INDEX `fk_COURCES_STUDENTS_STUDENTS1_idx` (`STUDENTS_idSTUDENTS` ASC),
  CONSTRAINT `fk_COURCES_STUDENTS_COURSES1`
    FOREIGN KEY (`COURSES_idCOURSES`)
    REFERENCES `Univercity`.`COURSES` (`idCOURSES`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_COURCES_STUDENTS_STUDENTS1`
    FOREIGN KEY (`STUDENTS_idSTUDENTS`)
    REFERENCES `Univercity`.`STUDENTS` (`idSTUDENTS`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Univercity`.`TITLES`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Univercity`.`TITLES` (
  `idTITLES` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`idTITLES`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `Univercity`.`PROFESSORS_TITLES`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `Univercity`.`PROFESSORS_TITLES` (
  `TITLES_idTITLES` INT NOT NULL,
  `PROFESSORS_idPROFESSORS` INT NOT NULL,
  INDEX `fk_PROFESSORS_TITLES_TITLES1_idx` (`TITLES_idTITLES` ASC),
  INDEX `fk_PROFESSORS_TITLES_PROFESSORS1_idx` (`PROFESSORS_idPROFESSORS` ASC),
  CONSTRAINT `fk_PROFESSORS_TITLES_TITLES1`
    FOREIGN KEY (`TITLES_idTITLES`)
    REFERENCES `Univercity`.`TITLES` (`idTITLES`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_PROFESSORS_TITLES_PROFESSORS1`
    FOREIGN KEY (`PROFESSORS_idPROFESSORS`)
    REFERENCES `Univercity`.`PROFESSORS` (`idPROFESSORS`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
