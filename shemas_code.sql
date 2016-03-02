-- MySQL Workbench Synchronization
-- Generated: 2016-03-03 01:19
-- Model: New Model
-- Version: 1.0
-- Project: Name of the project
-- Author: Администратор

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

CREATE SCHEMA IF NOT EXISTS `mydb` DEFAULT CHARACTER SET utf8 ;

CREATE TABLE IF NOT EXISTS `mydb`.`test_table1` (
  `column1` INT(11) NOT NULL,
  `column2` VARCHAR(45) NOT NULL,
  `column3` VARCHAR(45) NOT NULL,
  `column4` VARCHAR(45) NOT NULL,
  `column5` VARCHAR(45) NOT NULL,
  `test_table3_column111` INT(11) NOT NULL,
  `test_table5_column11111` INT(11) NOT NULL,
  `test_table2_column11` INT(11) NOT NULL,
  PRIMARY KEY (`column1`, `test_table3_column111`, `test_table5_column11111`, `test_table2_column11`),
  UNIQUE INDEX `column1_UNIQUE` (`column1` ASC),
  INDEX `fk_test_table1_test_table3_idx` (`test_table3_column111` ASC),
  INDEX `fk_test_table1_test_table51_idx` (`test_table5_column11111` ASC),
  INDEX `fk_test_table1_test_table21_idx` (`test_table2_column11` ASC),
  CONSTRAINT `fk_test_table1_test_table3`
    FOREIGN KEY (`test_table3_column111`)
    REFERENCES `mydb`.`test_table3` (`column111`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_test_table1_test_table51`
    FOREIGN KEY (`test_table5_column11111`)
    REFERENCES `mydb`.`test_table5` (`column11111`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_test_table1_test_table21`
    FOREIGN KEY (`test_table2_column11`)
    REFERENCES `mydb`.`test_table2` (`column11`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `mydb`.`test_table2` (
  `column11` INT(11) NOT NULL,
  `column22` VARCHAR(45) NOT NULL,
  `column33` VARCHAR(45) NOT NULL,
  `column44` VARCHAR(45) NOT NULL,
  `column55` VARCHAR(45) NOT NULL,
  `test_table7_column1111111` INT(11) NOT NULL,
  PRIMARY KEY (`column11`, `test_table7_column1111111`),
  UNIQUE INDEX `column1_UNIQUE` (`column11` ASC),
  INDEX `fk_test_table2_test_table71_idx` (`test_table7_column1111111` ASC),
  CONSTRAINT `fk_test_table2_test_table71`
    FOREIGN KEY (`test_table7_column1111111`)
    REFERENCES `mydb`.`test_table7` (`column1111111`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `mydb`.`test_table3` (
  `column111` INT(11) NOT NULL,
  `column222` VARCHAR(45) NOT NULL,
  `column333` VARCHAR(45) NOT NULL,
  `column444` VARCHAR(45) NOT NULL,
  `column555` VARCHAR(45) NOT NULL,
  `test_table4_column1111` INT(11) NOT NULL,
  `test_table2_column11` INT(11) NOT NULL,
  PRIMARY KEY (`column111`, `test_table4_column1111`, `test_table2_column11`),
  UNIQUE INDEX `column1_UNIQUE` (`column111` ASC),
  INDEX `fk_test_table3_test_table41_idx` (`test_table4_column1111` ASC),
  INDEX `fk_test_table3_test_table21_idx` (`test_table2_column11` ASC),
  CONSTRAINT `fk_test_table3_test_table41`
    FOREIGN KEY (`test_table4_column1111`)
    REFERENCES `mydb`.`test_table4` (`column1111`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_test_table3_test_table21`
    FOREIGN KEY (`test_table2_column11`)
    REFERENCES `mydb`.`test_table2` (`column11`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `mydb`.`test_table4` (
  `column1111` INT(11) NOT NULL,
  `column2222` VARCHAR(45) NOT NULL,
  `column3333` VARCHAR(45) NOT NULL,
  `column4444` VARCHAR(45) NOT NULL,
  `column5555` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`column1111`),
  UNIQUE INDEX `column1_UNIQUE` (`column1111` ASC))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `mydb`.`test_table5` (
  `column11111` INT(11) NOT NULL,
  `column22222` VARCHAR(45) NOT NULL,
  `column33333` VARCHAR(45) NOT NULL,
  `column44444` VARCHAR(45) NOT NULL,
  `column55555` VARCHAR(45) NOT NULL,
  `test_table2_column11` INT(11) NOT NULL,
  `test_table6_column111111` INT(11) NOT NULL,
  PRIMARY KEY (`column11111`, `test_table2_column11`, `test_table6_column111111`),
  UNIQUE INDEX `column11111_UNIQUE` (`column11111` ASC),
  INDEX `fk_test_table5_test_table21_idx` (`test_table2_column11` ASC),
  INDEX `fk_test_table5_test_table61_idx` (`test_table6_column111111` ASC),
  CONSTRAINT `fk_test_table5_test_table21`
    FOREIGN KEY (`test_table2_column11`)
    REFERENCES `mydb`.`test_table2` (`column11`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_test_table5_test_table61`
    FOREIGN KEY (`test_table6_column111111`)
    REFERENCES `mydb`.`test_table6` (`column111111`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `mydb`.`test_table6` (
  `column111111` INT(11) NOT NULL,
  `column222222` VARCHAR(45) NOT NULL,
  `column333333` VARCHAR(45) NOT NULL,
  `column444444` VARCHAR(45) NOT NULL,
  `column555555` VARCHAR(45) NOT NULL,
  `test_table2_column11` INT(11) NOT NULL,
  `test_table2_test_table7_column1111111` INT(11) NOT NULL,
  PRIMARY KEY (`column111111`, `test_table2_column11`, `test_table2_test_table7_column1111111`),
  UNIQUE INDEX `column1_UNIQUE` (`column111111` ASC),
  INDEX `fk_test_table6_test_table21_idx` (`test_table2_column11` ASC, `test_table2_test_table7_column1111111` ASC),
  CONSTRAINT `fk_test_table6_test_table21`
    FOREIGN KEY (`test_table2_column11` , `test_table2_test_table7_column1111111`)
    REFERENCES `mydb`.`test_table2` (`column11` , `test_table7_column1111111`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE IF NOT EXISTS `mydb`.`test_table7` (
  `column1111111` INT(11) NOT NULL,
  `column2222222` VARCHAR(45) NOT NULL,
  `column3333333` VARCHAR(45) NOT NULL,
  `column4444444` VARCHAR(45) NOT NULL,
  `column5555555` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`column1111111`),
  UNIQUE INDEX `column1_UNIQUE` (`column1111111` ASC))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
