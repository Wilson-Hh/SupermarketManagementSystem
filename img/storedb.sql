/*
 Navicat Premium Data Transfer

 Source Server         : root
 Source Server Type    : MySQL
 Source Server Version : 50726 (5.7.26)
 Source Host           : localhost:3306
 Source Schema         : storedb

 Target Server Type    : MySQL
 Target Server Version : 50726 (5.7.26)
 File Encoding         : 65001

 Date: 28/02/2024 22:15:05
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for customer
-- ----------------------------
DROP TABLE IF EXISTS `customer`;
CREATE TABLE `customer`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(32) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `Telephone` varchar(32) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `Address` varchar(64) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `Email` varchar(64) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `InsertDate` datetime NULL DEFAULT NULL,
  `Tag` varchar(256) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for goods
-- ----------------------------
DROP TABLE IF EXISTS `goods`;
CREATE TABLE `goods`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Serial` varchar(32) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Name` varchar(64) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Unit` varchar(16) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `Min` float NULL DEFAULT NULL,
  `Max` float NULL DEFAULT NULL,
  `Quant` float NULL DEFAULT NULL,
  `InsertDate` datetime NULL DEFAULT NULL,
  `GoodsTypeld` int(11) NULL DEFAULT NULL,
  `Specld` int(11) NULL DEFAULT NULL,
  `UserInfold` int(11) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `Specld`(`Specld`) USING BTREE,
  INDEX `GoodsTypeld`(`GoodsTypeld`) USING BTREE,
  INDEX `Serial`(`Serial`) USING BTREE,
  CONSTRAINT `goods_ibfk_1` FOREIGN KEY (`Serial`) REFERENCES `instore` (`GoodsSerial`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `goods_ibfk_2` FOREIGN KEY (`Serial`) REFERENCES `outstore` (`GoodsSerial`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `goods_ibfk_3` FOREIGN KEY (`Serial`) REFERENCES `inventory` (`GoodsSerial`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for goodstyoe
-- ----------------------------
DROP TABLE IF EXISTS `goodstyoe`;
CREATE TABLE `goodstyoe`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(32) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `InsertDate` datetime NULL DEFAULT NULL,
  `Tag` varchar(256) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  CONSTRAINT `goodstyoe_ibfk_1` FOREIGN KEY (`Id`) REFERENCES `goods` (`GoodsTypeld`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `goodstyoe_ibfk_2` FOREIGN KEY (`Id`) REFERENCES `instore` (`GoodsTypeld`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `goodstyoe_ibfk_3` FOREIGN KEY (`Id`) REFERENCES `outstore` (`GoodsTypeld`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `goodstyoe_ibfk_4` FOREIGN KEY (`Id`) REFERENCES `inventory` (`GoodsTypeld`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for instore
-- ----------------------------
DROP TABLE IF EXISTS `instore`;
CREATE TABLE `instore`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `GoodsSerial` varchar(32) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Name` varchar(64) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Storeld` int(11) NULL DEFAULT NULL,
  `StoreName` varchar(32) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `Supplierld` int(11) NOT NULL,
  `SupplierName` varchar(128) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `Specld` int(11) NULL DEFAULT NULL,
  `SpecName` varchar(32) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `Price` float NOT NULL,
  `Unit` varchar(16) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `Number` float NOT NULL,
  `IsertDate` datetime NULL DEFAULT NULL,
  `GoodsTypeld` int(11) NULL DEFAULT NULL,
  `UserInfold` int(11) NULL DEFAULT NULL,
  `UserInfoName` varchar(32) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `Tag` varchar(256) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `IsInventory` bit(1) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `Storeld`(`Storeld`) USING BTREE,
  INDEX `Supplierld`(`Supplierld`) USING BTREE,
  INDEX `Specld`(`Specld`) USING BTREE,
  INDEX `GoodsTypeld`(`GoodsTypeld`) USING BTREE,
  INDEX `GoodsSerial`(`GoodsSerial`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for inventory
-- ----------------------------
DROP TABLE IF EXISTS `inventory`;
CREATE TABLE `inventory`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `GoodsSerial` varchar(32) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `Name` varchar(64) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `Unit` varchar(16) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `InsertDate` datetime NULL DEFAULT NULL,
  `Quant` float NOT NULL,
  `GoodsTypeld` int(11) NULL DEFAULT NULL,
  `Specld` int(11) NULL DEFAULT NULL,
  `UserInfold` int(11) NULL DEFAULT NULL,
  `UserInfoName` varchar(32) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `Specld`(`Specld`) USING BTREE,
  INDEX `GoodsTypeld`(`GoodsTypeld`) USING BTREE,
  INDEX `GoodsSerial`(`GoodsSerial`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for outstore
-- ----------------------------
DROP TABLE IF EXISTS `outstore`;
CREATE TABLE `outstore`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `GoodsSerial` varchar(32) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Name` varchar(64) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Storeld` int(11) NULL DEFAULT NULL,
  `StoreName` varchar(32) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `Supplierld` int(11) NOT NULL,
  `SupplierName` varchar(128) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `Specld` int(11) NULL DEFAULT NULL,
  `SpecName` varchar(32) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `Unit` varchar(16) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `Number` float NOT NULL,
  `Price` float NOT NULL,
  `InsertDate` datetime NULL DEFAULT NULL,
  `GoodsTypeld` int(11) NULL DEFAULT NULL,
  `UserInfold` int(11) NULL DEFAULT NULL,
  `UserInfoName` varchar(32) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `Tag` varchar(256) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `IsInventory` bit(1) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `GoodsTypeld`(`GoodsTypeld`) USING BTREE,
  INDEX `Storeld`(`Storeld`) USING BTREE,
  INDEX `Supplierld`(`Supplierld`) USING BTREE,
  INDEX `GoodsSerial`(`GoodsSerial`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for spec
-- ----------------------------
DROP TABLE IF EXISTS `spec`;
CREATE TABLE `spec`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(32) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `InsertDate` datetime NULL DEFAULT NULL,
  `Tag` varchar(256) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  CONSTRAINT `Spec_1` FOREIGN KEY (`Id`) REFERENCES `goods` (`Specld`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `spec_ibfk_1` FOREIGN KEY (`Id`) REFERENCES `instore` (`Specld`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `spec_ibfk_2` FOREIGN KEY (`Id`) REFERENCES `outstore` (`Storeld`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `spec_ibfk_3` FOREIGN KEY (`Id`) REFERENCES `inventory` (`Specld`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for store
-- ----------------------------
DROP TABLE IF EXISTS `store`;
CREATE TABLE `store`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(32) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `InserDate` datetime NULL DEFAULT NULL,
  `Tag` varchar(256) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  CONSTRAINT `store_ibfk_1` FOREIGN KEY (`Id`) REFERENCES `instore` (`Storeld`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `store_ibfk_2` FOREIGN KEY (`Id`) REFERENCES `outstore` (`Storeld`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for supplier
-- ----------------------------
DROP TABLE IF EXISTS `supplier`;
CREATE TABLE `supplier`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(128) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Contact` varchar(32) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Telephone` varchar(32) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Email` varchar(64) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `Address` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `InsertDate` datetime NOT NULL,
  `Tag` varchar(256) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  CONSTRAINT `supplier_ibfk_1` FOREIGN KEY (`Id`) REFERENCES `instore` (`Supplierld`) ON DELETE RESTRICT ON UPDATE RESTRICT,
  CONSTRAINT `supplier_ibfk_2` FOREIGN KEY (`Id`) REFERENCES `outstore` (`Supplierld`) ON DELETE RESTRICT ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Table structure for userinfo
-- ----------------------------
DROP TABLE IF EXISTS `userinfo`;
CREATE TABLE `userinfo`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(32) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Password` varchar(32) CHARACTER SET utf8 COLLATE utf8_unicode_ci NOT NULL,
  `Role` int(11) NOT NULL,
  `Departmentld` int(11) NULL DEFAULT NULL,
  `Email` varchar(64) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `Address` varchar(255) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  `InsertDate` datetime NULL DEFAULT NULL,
  `Tag` varchar(256) CHARACTER SET utf8 COLLATE utf8_unicode_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = MyISAM AUTO_INCREMENT = 3 CHARACTER SET = utf8 COLLATE = utf8_unicode_ci ROW_FORMAT = Dynamic;

SET FOREIGN_KEY_CHECKS = 1;
