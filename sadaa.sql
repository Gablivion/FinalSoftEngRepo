-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: fabpets
-- ------------------------------------------------------
-- Server version	5.7.20-log

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `allergies`
--

DROP TABLE IF EXISTS `allergies`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `allergies` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pets_id` int(11) NOT NULL,
  `pet_allergy` varchar(255) DEFAULT NULL,
  `recorded_on` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`,`pets_id`),
  KEY `fk_allergies_pets1_idx` (`pets_id`),
  CONSTRAINT `fk_allergies_pets1` FOREIGN KEY (`pets_id`) REFERENCES `pets` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `allergies`
--

LOCK TABLES `allergies` WRITE;
/*!40000 ALTER TABLE `allergies` DISABLE KEYS */;
INSERT INTO `allergies` VALUES (2,6,'Dust','2018-08-27 05:19:01'),(3,6,'Water','2018-08-27 05:19:05');
/*!40000 ALTER TABLE `allergies` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `cage`
--

DROP TABLE IF EXISTS `cage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cage` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `price` decimal(20,2) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cage`
--

LOCK TABLES `cage` WRITE;
/*!40000 ALTER TABLE `cage` DISABLE KEYS */;
INSERT INTO `cage` VALUES (6,'Cage 1','first cage on top left','available',150.00),(7,'Cage 2','first cage on top middle','available',200.00),(8,'Deluxe','first cage on top right','available',400.00),(9,'VIP','middle cage on the corner','unavailable',500.00);
/*!40000 ALTER TABLE `cage` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `customers`
--

DROP TABLE IF EXISTS `customers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `customers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `person_id` int(11) NOT NULL,
  `archived` varchar(3) DEFAULT NULL,
  PRIMARY KEY (`id`,`person_id`),
  KEY `fk_customers_person1_idx` (`person_id`),
  CONSTRAINT `fk_customers_person1` FOREIGN KEY (`person_id`) REFERENCES `person` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` VALUES (1,12,'no'),(2,13,'no'),(7,14,'no'),(8,10,'no'),(9,11,'no'),(10,15,'no');
/*!40000 ALTER TABLE `customers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `daily_vitals`
--

DROP TABLE IF EXISTS `daily_vitals`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `daily_vitals` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `hospitalization_id` int(11) NOT NULL,
  `date` timestamp NULL DEFAULT NULL,
  `weight` varchar(45) DEFAULT NULL,
  `temperature` varchar(45) DEFAULT NULL,
  `heart_rate` varchar(45) DEFAULT NULL,
  `respiratory_rate` varchar(45) DEFAULT NULL,
  `appetite_status` varchar(45) DEFAULT NULL,
  `drinking_status` varchar(45) DEFAULT NULL,
  `coughing_status` varchar(45) DEFAULT NULL,
  `urination_status` varchar(45) DEFAULT NULL,
  `vomiting_status` varchar(45) DEFAULT NULL,
  `bowel_status` varchar(45) DEFAULT NULL,
  `attitude_status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`,`hospitalization_id`),
  KEY `fk_daily_vitals_hospitalization1_idx` (`hospitalization_id`),
  CONSTRAINT `fk_daily_vitals_hospitalization1` FOREIGN KEY (`hospitalization_id`) REFERENCES `hospitalization` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `daily_vitals`
--

LOCK TABLES `daily_vitals` WRITE;
/*!40000 ALTER TABLE `daily_vitals` DISABLE KEYS */;
/*!40000 ALTER TABLE `daily_vitals` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `endorsed_prods`
--

DROP TABLE IF EXISTS `endorsed_prods`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `endorsed_prods` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `hospitalization_id` int(11) NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `expiration_date` datetime DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  `medicine` int(5) DEFAULT NULL,
  PRIMARY KEY (`id`,`hospitalization_id`),
  KEY `fk_endorsed_prods_hospitalization1_idx` (`hospitalization_id`),
  CONSTRAINT `fk_endorsed_prods_hospitalization1` FOREIGN KEY (`hospitalization_id`) REFERENCES `hospitalization` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `endorsed_prods`
--

LOCK TABLES `endorsed_prods` WRITE;
/*!40000 ALTER TABLE `endorsed_prods` DISABLE KEYS */;
/*!40000 ALTER TABLE `endorsed_prods` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hosp_prods`
--

DROP TABLE IF EXISTS `hosp_prods`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `hosp_prods` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `hospitalization_id` int(11) NOT NULL,
  `products_id` int(11) NOT NULL,
  `subtotal` varchar(45) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`,`hospitalization_id`,`products_id`),
  KEY `fk_hosp_prods_hospitalization1_idx` (`hospitalization_id`),
  KEY `fk_hosp_prods_products1_idx` (`products_id`),
  CONSTRAINT `fk_hosp_prods_hospitalization1` FOREIGN KEY (`hospitalization_id`) REFERENCES `hospitalization` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_hosp_prods_products1` FOREIGN KEY (`products_id`) REFERENCES `products` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hosp_prods`
--

LOCK TABLES `hosp_prods` WRITE;
/*!40000 ALTER TABLE `hosp_prods` DISABLE KEYS */;
INSERT INTO `hosp_prods` VALUES (9,6,37,'90.00',1);
/*!40000 ALTER TABLE `hosp_prods` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `hospitalization`
--

DROP TABLE IF EXISTS `hospitalization`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `hospitalization` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pets_id` int(11) NOT NULL,
  `cage_id` int(11) NOT NULL,
  `date_in` datetime DEFAULT NULL,
  `date_out` datetime DEFAULT NULL,
  `subtotal` decimal(20,2) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `archived` varchar(3) DEFAULT NULL,
  PRIMARY KEY (`id`,`pets_id`,`cage_id`),
  KEY `fk_hospitalization_pets1_idx` (`pets_id`),
  KEY `fk_hospitalization_cage_idx` (`cage_id`),
  CONSTRAINT `fk_hospitalization_cage` FOREIGN KEY (`cage_id`) REFERENCES `cage` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_hospitalization_pets1` FOREIGN KEY (`pets_id`) REFERENCES `pets` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hospitalization`
--

LOCK TABLES `hospitalization` WRITE;
/*!40000 ALTER TABLE `hospitalization` DISABLE KEYS */;
INSERT INTO `hospitalization` VALUES (6,6,6,'2018-08-27 13:18:49',NULL,0.00,'discharged','no'),(7,7,7,'2018-08-27 14:55:48',NULL,0.00,'discharged','no'),(8,8,9,'2018-09-05 11:33:42',NULL,0.00,'active','no');
/*!40000 ALTER TABLE `hospitalization` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inventory_log`
--

DROP TABLE IF EXISTS `inventory_log`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `inventory_log` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `process_type` varchar(45) DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `product` varchar(45) DEFAULT NULL,
  `quantity` varchar(45) DEFAULT NULL,
  `remarks` varchar(45) DEFAULT NULL,
  `staff_id` int(11) NOT NULL,
  `status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`,`staff_id`)
) ENGINE=InnoDB AUTO_INCREMENT=56 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory_log`
--

LOCK TABLES `inventory_log` WRITE;
/*!40000 ALTER TABLE `inventory_log` DISABLE KEYS */;
INSERT INTO `inventory_log` VALUES (13,'Stock In (Purchased)','2018-08-27 13:07:38','Collar (D)','50','Purchased Item from Gabriel Suazo Pil',1,NULL),(14,'Stock In (Purchased)','2018-08-27 13:07:38','Parainfluenza Vaccine','30','Purchased Item from Gabriel Suazo Pil',1,NULL),(15,'Stock In (Purchased)','2018-08-27 13:07:38','Measles Vaccine','25','Purchased Item from Gabriel Suazo Pil',1,NULL),(16,'Stock Out (Repack)','2018-08-27 13:08:06','Measles Vaccine','25','For Shelf',1,NULL),(17,'Stock Out (Repack)','2018-08-27 13:11:05','Parainfluenza Vaccine','10','For Shelf',1,NULL),(18,'Stock Out (Service Usage)','2018-08-27 13:24:31','Measles Vaccine (Repacked by 25 ml )','2','Stocked out to usage by Gabriel Suazo Pil',1,NULL),(19,'Stock Out (Hospitalization Product)','2018-08-27 13:24:45','Collar (D)','1','Used in hospitalization',1,NULL),(20,'Stock Out (Service Usage)','2018-08-27 14:55:53','Measles Vaccine (Repacked by 25 ml )','2','Stocked out to usage by Gabriel Suazo Pil',1,NULL),(21,'Stock Out (Sales Order)','2018-09-05 11:47:46','Parainfluenza Vaccine (Repacked by 500 ml )','1','Purchased by Gabriel Suazo Pil',1,NULL),(22,'Stock In (Refund)','2018-09-05 11:48:08','Measles Vaccine (Repacked by 25 ml )','1','Purchased Item from Gabriel Suazo Pil',1,NULL),(23,'Stock In (Refund)','2018-09-05 11:59:45','Measles Vaccine (Repacked by 25 ml )','1','Purchased Item from ',0,NULL),(24,'Stock Out (Sales Order)','2018-09-05 12:04:08','Parainfluenza Vaccine (Repacked by 500 ml )','1','Purchased by Cherub  Suazo Pil',1,NULL),(25,'Stock Out (Sales Order)','2018-09-05 12:05:07','Parainfluenza Vaccine','10','Purchased by Ely Santos Suplayan',1,NULL),(26,'Stock In (Refund)','2018-09-05 12:05:40','Parainfluenza Vaccine','9','Purchased Item from Gabriel Suazo Pil',1,NULL),(27,'Stock In (Refund)','2018-09-05 12:05:46','Parainfluenza Vaccine','1','Purchased Item from Gabriel Suazo Pil',1,NULL),(28,'Stock Out (Sales Order)','2018-09-05 12:13:57','Parainfluenza Vaccine (Repacked by 500 ml )','1','Purchased by Gabriel Suazo Pil',1,NULL),(29,'Stock Out (Sales Order)','2018-09-05 12:14:45','Measles Vaccine (Repacked by 25 ml )','2','Purchased by Honey Gallegos Lirasan',1,NULL),(30,'Stock Out (Sales Order)','2018-09-05 12:17:56','Collar (D)','1','Purchased by Gabriel Suazo Pil',1,NULL),(31,'Stock Out (Sales Order)','2018-09-05 12:18:49','Parainfluenza Vaccine (Repacked by 500 ml )','1','Purchased by Cherub  Suazo Pil',1,NULL),(32,'Stock Out (Sales Order)','2018-09-05 12:20:05','Parainfluenza Vaccine (Repacked by 500 ml )','1','Purchased by Ely Santos Suplayan',1,NULL),(33,'Stock Out (Sales Order)','2018-09-05 12:20:05','Parainfluenza Vaccine (Repacked by 500 ml )','1','Purchased by Ely Santos Suplayan',1,NULL),(34,'Stock Out (Sales Order)','2018-09-05 12:20:05','Parainfluenza Vaccine (Repacked by 500 ml )','1','Purchased by Ely Santos Suplayan',1,NULL),(35,'Stock Out (Sales Order)','2018-09-05 12:20:05','Parainfluenza Vaccine (Repacked by 500 ml )','1','Purchased by Ely Santos Suplayan',1,NULL),(36,'Stock Out (Sales Order)','2018-09-05 12:21:21','Collar (D)','46','Purchased by Yvonne Salinas Suazo',1,NULL),(37,'Stock Out (Sales Order)','2018-09-05 12:21:22','Collar (D)','46','Purchased by Yvonne Salinas Suazo',1,NULL),(38,'Stock Out (Sales Order)','2018-09-05 12:21:22','Collar (D)','46','Purchased by Yvonne Salinas Suazo',1,NULL),(39,'Stock Out (Sales Order)','2018-09-05 12:21:22','Collar (D)','46','Purchased by Yvonne Salinas Suazo',1,NULL),(40,'Stock In (Refund)','2018-09-05 12:21:35','Parainfluenza Vaccine (Repacked by 500 ml )','1','Purchased Item from Gabriel Suazo Pil',1,NULL),(41,'Stock In (Refund)','2018-09-05 12:21:45','Parainfluenza Vaccine (Repacked by 500 ml )','1','Purchased Item from Gabriel Suazo Pil',1,NULL),(42,'Stock In (Refund)','2018-09-05 12:22:20','Measles Vaccine (Repacked by 25 ml )','1','Purchased Item from Gabriel Suazo Pil',1,NULL),(43,'Stock In (Refund)','2018-09-05 12:25:44','Parainfluenza Vaccine (Repacked by 500 ml )','4','Purchased Item from Gabriel Suazo Pil',1,NULL),(44,'Stock In (Refund)','2018-09-05 12:26:00','Measles Vaccine (Repacked by 25 ml )','2','Purchased Item from Gabriel Suazo Pil',1,NULL),(45,'Stock In (Refund)','2018-09-05 12:26:06','Measles Vaccine (Repacked by 25 ml )','2','Purchased Item from Gabriel Suazo Pil',1,NULL),(46,'Stock In (Refund)','2018-09-05 12:29:49','Measles Vaccine (Repacked by 25 ml )','1','Purchased Item from Gabriel Suazo Pil',1,NULL),(47,'Stock In (Refund)','2018-09-05 12:30:41','Measles Vaccine (Repacked by 25 ml )','1','Purchased Item from Gabriel Suazo Pil',1,NULL),(48,'Stock In (Refund)','2018-09-05 12:36:45','Collar (D)','1','Purchased Item from Gabriel Suazo Pil',1,NULL),(49,'Stock In (Refund)','2018-09-05 12:36:49','Collar (D)','1','Purchased Item from Gabriel Suazo Pil',1,NULL),(50,'Stock In (Refund)','2018-09-05 12:36:58','Parainfluenza Vaccine','1','Purchased Item from Gabriel Suazo Pil',1,NULL),(51,'Stock In (Refund)','2018-09-05 12:37:02','Parainfluenza Vaccine','1','Purchased Item from Gabriel Suazo Pil',1,NULL),(52,'Stock In (Refund)','2018-09-05 12:37:06','Measles Vaccine (Repacked by 25 ml )','2','Purchased Item from Gabriel Suazo Pil',1,NULL),(53,'Stock In (Refund)','2018-09-05 12:37:10','Parainfluenza Vaccine (Repacked by 500 ml )','3','Purchased Item from Gabriel Suazo Pil',1,NULL),(54,'Stock In (Refund)','2018-09-05 12:39:38','Measles Vaccine (Repacked by 25 ml )','9','Purchased Item from Gabriel Suazo Pil',1,NULL),(55,'Stock In (Refund)','2018-09-10 11:26:18','Measles Vaccine (Repacked by 25 ml )','1','Purchased Item from Gabriel Suazo Pil',1,NULL);
/*!40000 ALTER TABLE `inventory_log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `medical_record`
--

DROP TABLE IF EXISTS `medical_record`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `medical_record` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pets_id` int(11) NOT NULL,
  `weight` varchar(45) DEFAULT NULL,
  `allergies` varchar(45) DEFAULT NULL,
  `medicines_taken` varchar(45) DEFAULT NULL,
  `remarks` varchar(45) DEFAULT NULL,
  `date_recorded` varchar(45) DEFAULT NULL,
  `archived` varchar(3) DEFAULT NULL,
  PRIMARY KEY (`id`,`pets_id`),
  KEY `fk_medical_record_pets1_idx` (`pets_id`),
  CONSTRAINT `fk_medical_record_pets1` FOREIGN KEY (`pets_id`) REFERENCES `pets` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medical_record`
--

LOCK TABLES `medical_record` WRITE;
/*!40000 ALTER TABLE `medical_record` DISABLE KEYS */;
/*!40000 ALTER TABLE `medical_record` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `medicines_given`
--

DROP TABLE IF EXISTS `medicines_given`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `medicines_given` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `pets_id` int(11) NOT NULL,
  `hosp_id` int(11) NOT NULL,
  `medicine_name` varchar(45) DEFAULT NULL,
  `endorsed` varchar(45) DEFAULT NULL,
  `given_on` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`,`pets_id`,`hosp_id`),
  KEY `fk_medicines_given_pets1_idx` (`pets_id`),
  CONSTRAINT `fk_medicines_given_pets1` FOREIGN KEY (`pets_id`) REFERENCES `pets` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medicines_given`
--

LOCK TABLES `medicines_given` WRITE;
/*!40000 ALTER TABLE `medicines_given` DISABLE KEYS */;
/*!40000 ALTER TABLE `medicines_given` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `person`
--

DROP TABLE IF EXISTS `person`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `person` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `firstname` varchar(45) DEFAULT NULL,
  `middlename` varchar(45) DEFAULT NULL,
  `lastname` varchar(45) DEFAULT NULL,
  `gender` varchar(10) DEFAULT NULL,
  `birthdate` date DEFAULT NULL,
  `address` varchar(200) DEFAULT NULL,
  `contact_number` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `date_added` timestamp NULL DEFAULT NULL,
  `date_modified` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `person`
--

LOCK TABLES `person` WRITE;
/*!40000 ALTER TABLE `person` DISABLE KEYS */;
INSERT INTO `person` VALUES (10,'Gabriel','Suazo','Pil','male','1998-04-18','Buhangin, Davao City','09989099365','gablivion@gmail.com',NULL,NULL),(11,'Cherub ','Suazo','Pil','female','2001-03-21','Buhangin, Davao City','09989099342','cherubie@gmai.com',NULL,NULL),(12,'Gerard','Susalo','Pil','male','1972-11-15','Sasa, Davao City','09989443422','gsp@yahoo.com',NULL,NULL),(13,'Yvonne','Salinas','Suazo','female','1964-11-27','Buhangin, Davao City','09983356377','yvonnesal1998@yahoo.com',NULL,NULL),(14,'Ely','Santos','Suplayan','female','1989-04-18','Puan, Davao City','09989883422','Elysup@gmail.com',NULL,NULL),(15,'Honey','Gallegos','Lirasan','female','1989-09-07','Bajada, Davao City','09987743422','honeygal@yahoo.com',NULL,NULL);
/*!40000 ALTER TABLE `person` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `pets`
--

DROP TABLE IF EXISTS `pets`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `pets` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `customer_id` int(11) NOT NULL,
  `name` varchar(45) DEFAULT NULL,
  `color` varchar(45) DEFAULT NULL,
  `species` varchar(45) DEFAULT NULL,
  `breed` varchar(45) DEFAULT NULL,
  `gender` varchar(10) DEFAULT NULL,
  `birthdate` date DEFAULT NULL,
  `microchip_number` varchar(200) DEFAULT NULL,
  `sterilized` varchar(45) DEFAULT NULL,
  `date_added` timestamp NULL DEFAULT NULL,
  `date_modified` timestamp NULL DEFAULT NULL,
  `archived` varchar(3) DEFAULT NULL,
  PRIMARY KEY (`id`,`customer_id`),
  KEY `fk_pets_customers1_idx` (`customer_id`),
  CONSTRAINT `fk_pets_customers1` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=9 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pets`
--

LOCK TABLES `pets` WRITE;
/*!40000 ALTER TABLE `pets` DISABLE KEYS */;
INSERT INTO `pets` VALUES (6,7,'George','White','Cat','Siamese','male','2018-07-24','552015556','yes','2018-08-27 05:16:07','2018-08-27 05:16:07','no'),(7,2,'Connor','Brownish Gold','Dog','Golden Retriever','male','2018-07-09','552015556','yes','2018-08-27 05:16:38','2018-08-27 05:16:38','no'),(8,1,'White','Dirty White','Dog','Labrador Retriever','male','2018-08-27','552035556','yes','2018-08-27 05:17:20','2018-08-27 05:17:20','no');
/*!40000 ALTER TABLE `pets` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `position`
--

DROP TABLE IF EXISTS `position`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `position` (
  `pos_id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`pos_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `position`
--

LOCK TABLES `position` WRITE;
/*!40000 ALTER TABLE `position` DISABLE KEYS */;
INSERT INTO `position` VALUES (1,'owner'),(2,'staff');
/*!40000 ALTER TABLE `position` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `product_inventory`
--

DROP TABLE IF EXISTS `product_inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `product_inventory` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `products_id` int(11) NOT NULL,
  `quantity` varchar(45) DEFAULT NULL,
  `expiration_date` date DEFAULT NULL,
  `status` varchar(20) DEFAULT NULL,
  `IsForPurchase` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`id`,`products_id`),
  KEY `fk_product_inventory_products1_idx` (`products_id`),
  CONSTRAINT `fk_product_inventory_products1` FOREIGN KEY (`products_id`) REFERENCES `products` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_inventory`
--

LOCK TABLES `product_inventory` WRITE;
/*!40000 ALTER TABLE `product_inventory` DISABLE KEYS */;
INSERT INTO `product_inventory` VALUES (3,37,'3','0000-00-00','available',NULL),(4,39,'2','2019-04-01','available',NULL),(5,38,'0','2019-04-01','unavailable',NULL),(6,40,'14','2019-04-01','available',NULL),(7,41,'3','2019-04-01','available',NULL);
/*!40000 ALTER TABLE `product_inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `products`
--

DROP TABLE IF EXISTS `products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `products` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `description` varchar(255) DEFAULT NULL,
  `price` decimal(20,2) DEFAULT NULL,
  `volume` varchar(10) DEFAULT NULL,
  `unit` varchar(10) DEFAULT NULL,
  `expirable` varchar(5) DEFAULT NULL,
  `date_added` timestamp NULL DEFAULT NULL,
  `date_modified` timestamp NULL DEFAULT NULL,
  `archived` varchar(3) DEFAULT NULL,
  `reorder` int(11) DEFAULT NULL,
  `medicine` int(5) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (36,'Food Bowl','Bowl for your Dogs',140.00,'0','N/A','no','2018-08-27 05:01:30','2018-08-27 05:01:30','no',10,0),(37,'Collar (D)','Dog collar',90.00,'0','N/A','no','2018-08-27 05:03:05','2018-08-27 05:03:05','no',10,0),(38,'Measles Vaccine','Vaccine Vial for Measles',200.00,'50','ml','yes','2018-08-27 05:05:17','2018-08-27 05:05:17','no',15,1),(39,'Parainfluenza Vaccine','Vaccine Bottle for Parainfluenza',3000.00,'1000','ml','yes','2018-08-27 05:05:56','2018-08-27 05:05:56','no',5,1),(40,'Measles Vaccine (Repacked by 25 ml )','Vaccine Vial for Measles',4.00,'25','ml','yes','2018-08-27 05:08:06','2018-08-27 05:08:06','no',15,1),(41,'Parainfluenza Vaccine (Repacked by 500 ml )','Vaccine Bottle for Parainfluenza',150.00,'500','ml','yes','2018-08-27 05:11:05','2018-08-27 05:11:05','no',5,1);
/*!40000 ALTER TABLE `products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `purchase_order`
--

DROP TABLE IF EXISTS `purchase_order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `purchase_order` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `suppliers_id` int(11) NOT NULL,
  `staff_id` int(11) NOT NULL,
  `total` decimal(20,2) DEFAULT NULL,
  `date` timestamp NULL DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`,`staff_id`,`suppliers_id`),
  KEY `fk_products_has_suppliers_suppliers1_idx` (`suppliers_id`),
  KEY `fk_purchase_order_staff1_idx` (`staff_id`),
  CONSTRAINT `fk_products_has_suppliers_suppliers1` FOREIGN KEY (`suppliers_id`) REFERENCES `suppliers` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_purchase_order_staff1` FOREIGN KEY (`staff_id`) REFERENCES `staff` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=31 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_order`
--

LOCK TABLES `purchase_order` WRITE;
/*!40000 ALTER TABLE `purchase_order` DISABLE KEYS */;
INSERT INTO `purchase_order` VALUES (30,1,1,90750.00,'2018-08-27 05:06:45','delivered');
/*!40000 ALTER TABLE `purchase_order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `purchase_order_line`
--

DROP TABLE IF EXISTS `purchase_order_line`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `purchase_order_line` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `products_id` int(11) NOT NULL,
  `purchase_order_id` int(11) NOT NULL,
  `quantity` varchar(45) DEFAULT NULL,
  `price` decimal(20,2) DEFAULT NULL,
  `subtotal` decimal(20,2) DEFAULT NULL,
  `stocked_in` varchar(10) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`,`products_id`,`purchase_order_id`),
  KEY `fk_purchase_order_line_products1_idx` (`products_id`),
  KEY `fk_purchase_order_line_purchase_order1_idx` (`purchase_order_id`),
  CONSTRAINT `fk_purchase_order_line_products1` FOREIGN KEY (`products_id`) REFERENCES `products` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_purchase_order_line_purchase_order1` FOREIGN KEY (`purchase_order_id`) REFERENCES `purchase_order` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_order_line`
--

LOCK TABLES `purchase_order_line` WRITE;
/*!40000 ALTER TABLE `purchase_order_line` DISABLE KEYS */;
INSERT INTO `purchase_order_line` VALUES (3,39,30,'30',2800.00,84000.00,'yes','delivered'),(4,38,30,'25',150.00,3750.00,'yes','delivered'),(5,37,30,'50',60.00,3000.00,'yes','delivered'),(6,36,30,'20',90.00,1800.00,'no','cancelled');
/*!40000 ALTER TABLE `purchase_order_line` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sales_order`
--

DROP TABLE IF EXISTS `sales_order`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sales_order` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `transactions_id` int(11) NOT NULL,
  `subtotal` decimal(20,2) DEFAULT NULL,
  `refunded` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`id`,`transactions_id`),
  KEY `fk_order_transactions1_idx` (`transactions_id`),
  CONSTRAINT `fk_order_transactions1` FOREIGN KEY (`transactions_id`) REFERENCES `transactions` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_order`
--

LOCK TABLES `sales_order` WRITE;
/*!40000 ALTER TABLE `sales_order` DISABLE KEYS */;
INSERT INTO `sales_order` VALUES (1,1,208.00,NULL),(2,2,1508.00,NULL),(3,3,300.00,NULL),(4,4,3000.00,NULL),(5,5,18750.00,NULL),(6,6,32.00,NULL),(7,7,24270.00,NULL),(8,8,15732.00,NULL),(9,9,6638.00,NULL),(10,10,3244.00,NULL);
/*!40000 ALTER TABLE `sales_order` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sales_order_line`
--

DROP TABLE IF EXISTS `sales_order_line`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sales_order_line` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `order_id` int(11) NOT NULL,
  `products_id` int(11) NOT NULL,
  `quantity` varchar(45) DEFAULT NULL,
  `price` decimal(20,2) DEFAULT NULL,
  `subtotal` decimal(20,2) DEFAULT NULL,
  `expiration` datetime DEFAULT NULL,
  `refunded` varchar(5) DEFAULT NULL,
  PRIMARY KEY (`id`,`order_id`,`products_id`),
  KEY `fk_order_line_order1_idx` (`order_id`),
  KEY `fk_order_line_products1_idx` (`products_id`),
  CONSTRAINT `fk_order_line_order1` FOREIGN KEY (`order_id`) REFERENCES `sales_order` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_order_line_products1` FOREIGN KEY (`products_id`) REFERENCES `products` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_order_line`
--

LOCK TABLES `sales_order_line` WRITE;
/*!40000 ALTER TABLE `sales_order_line` DISABLE KEYS */;
INSERT INTO `sales_order_line` VALUES (1,2,40,'0',4.00,8.00,'2019-04-01 00:00:00','yes'),(2,3,41,'2',150.00,300.00,'2019-04-01 00:00:00','no'),(3,4,39,'0',3000.00,3000.00,'2019-04-01 00:00:00','yes'),(4,5,39,'6',3000.00,18000.00,'2019-04-01 00:00:00','no'),(5,6,40,'8',4.00,32.00,'2019-04-01 00:00:00','no'),(6,7,39,'8',3000.00,24000.00,'2019-04-01 00:00:00','no'),(7,8,39,'5',3000.00,15000.00,'2019-04-01 00:00:00','no'),(8,9,37,'0',90.00,180.00,'0000-00-00 00:00:00','yes'),(9,9,39,'0',3000.00,6000.00,'2019-04-01 00:00:00','yes'),(10,9,40,'0',4.00,8.00,'2019-04-01 00:00:00','yes'),(11,9,41,'0',150.00,450.00,'2019-04-01 00:00:00','yes'),(12,10,41,'0',150.00,150.00,'2019-04-01 00:00:00','yes'),(13,10,40,'0',4.00,4.00,'2019-04-01 00:00:00','yes'),(14,10,39,'13',3000.00,3000.00,'2019-04-01 00:00:00','no'),(15,10,37,'46',90.00,90.00,'0000-00-00 00:00:00','no');
/*!40000 ALTER TABLE `sales_order_line` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `sales_refund`
--

DROP TABLE IF EXISTS `sales_refund`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sales_refund` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `sales_order_id` int(11) NOT NULL,
  `sales_order_line_id` int(11) NOT NULL,
  `customers_id` int(11) NOT NULL,
  `staff_id` int(11) NOT NULL,
  `product` varchar(45) DEFAULT NULL,
  `quantity` varchar(45) DEFAULT NULL,
  `amount` decimal(20,2) DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  PRIMARY KEY (`id`,`sales_order_id`,`sales_order_line_id`,`customers_id`,`staff_id`),
  KEY `fk_sales_refund_sales_order1_idx` (`sales_order_id`),
  KEY `fk_sales_refund_sales_order_line1_idx` (`sales_order_line_id`),
  CONSTRAINT `fk_sales_refund_sales_order1` FOREIGN KEY (`sales_order_id`) REFERENCES `sales_order` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_sales_refund_sales_order_line1` FOREIGN KEY (`sales_order_line_id`) REFERENCES `sales_order_line` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_refund`
--

LOCK TABLES `sales_refund` WRITE;
/*!40000 ALTER TABLE `sales_refund` DISABLE KEYS */;
INSERT INTO `sales_refund` VALUES (1,2,1,8,1,'Measles Vaccine (Repacked by 25 ml )','1',4.00,'2018-09-05 11:48:08'),(2,2,1,8,1,'Measles Vaccine (Repacked by 25 ml )','1',4.00,'2018-09-05 11:59:45'),(3,4,3,7,1,'Parainfluenza Vaccine','9',27000.00,'2018-09-05 12:05:39'),(4,4,3,7,1,'Parainfluenza Vaccine','1',3000.00,'2018-09-05 12:05:46'),(5,10,12,2,1,'Parainfluenza Vaccine (Repacked by 500 ml )','1',150.00,'2018-09-05 12:21:35'),(6,10,12,2,1,'Parainfluenza Vaccine (Repacked by 500 ml )','1',150.00,'2018-09-05 12:21:45'),(7,10,13,2,1,'Measles Vaccine (Repacked by 25 ml )','1',4.00,'2018-09-05 12:22:20'),(8,10,12,2,1,'Parainfluenza Vaccine (Repacked by 500 ml )','4',600.00,'2018-09-05 12:25:44'),(9,10,13,2,1,'Measles Vaccine (Repacked by 25 ml )','2',8.00,'2018-09-05 12:26:00'),(10,10,13,2,1,'Measles Vaccine (Repacked by 25 ml )','2',4.00,'2018-09-05 12:26:06'),(11,10,13,2,1,'Measles Vaccine (Repacked by 25 ml )','1',4.00,'2018-09-05 12:29:48'),(12,10,13,2,1,'Measles Vaccine (Repacked by 25 ml )','1',4.00,'2018-09-05 12:30:40'),(13,9,8,7,1,'Collar (D)','1',90.00,'2018-09-05 12:36:45'),(14,9,8,7,1,'Collar (D)','1',90.00,'2018-09-05 12:36:49'),(15,9,9,7,1,'Parainfluenza Vaccine','1',3000.00,'2018-09-05 12:36:58'),(16,9,9,7,1,'Parainfluenza Vaccine','1',3000.00,'2018-09-05 12:37:02'),(17,9,10,7,1,'Measles Vaccine (Repacked by 25 ml )','2',8.00,'2018-09-05 12:37:06'),(18,9,11,7,1,'Parainfluenza Vaccine (Repacked by 500 ml )','3',450.00,'2018-09-05 12:37:10'),(19,10,13,2,1,'Measles Vaccine (Repacked by 25 ml )','9',36.00,'2018-09-05 12:39:38'),(20,10,13,2,1,'Measles Vaccine (Repacked by 25 ml )','1',4.00,'2018-09-10 11:26:18');
/*!40000 ALTER TABLE `sales_refund` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `service_products`
--

DROP TABLE IF EXISTS `service_products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `service_products` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `services_id` int(11) NOT NULL,
  `products_id` int(11) NOT NULL,
  `quantity` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`,`services_id`,`products_id`),
  KEY `fk_service_products_products1_idx` (`products_id`),
  KEY `fk_service_products_services1_idx` (`services_id`),
  CONSTRAINT `fk_service_products_products1` FOREIGN KEY (`products_id`) REFERENCES `products` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_service_products_services1` FOREIGN KEY (`services_id`) REFERENCES `services` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `service_products`
--

LOCK TABLES `service_products` WRITE;
/*!40000 ALTER TABLE `service_products` DISABLE KEYS */;
INSERT INTO `service_products` VALUES (2,7,40,2),(3,8,41,1),(4,9,36,1);
/*!40000 ALTER TABLE `service_products` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `service_transaction`
--

DROP TABLE IF EXISTS `service_transaction`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `service_transaction` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `services_id` int(11) NOT NULL,
  `service_price` decimal(20,2) DEFAULT NULL,
  `pets_id` int(11) NOT NULL,
  `hospitalization_id` int(11) NOT NULL,
  PRIMARY KEY (`id`,`services_id`,`pets_id`,`hospitalization_id`),
  KEY `fk_service_transaction_services1_idx` (`services_id`),
  KEY `fk_service_transaction_pets1_idx` (`pets_id`),
  CONSTRAINT `fk_service_transaction_pets1` FOREIGN KEY (`pets_id`) REFERENCES `pets` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_service_transaction_services1` FOREIGN KEY (`services_id`) REFERENCES `services` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `service_transaction`
--

LOCK TABLES `service_transaction` WRITE;
/*!40000 ALTER TABLE `service_transaction` DISABLE KEYS */;
INSERT INTO `service_transaction` VALUES (2,7,208.00,6,6),(3,7,208.00,7,7);
/*!40000 ALTER TABLE `service_transaction` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `services`
--

DROP TABLE IF EXISTS `services`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `services` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(45) DEFAULT NULL,
  `description` varchar(45) DEFAULT NULL,
  `base_price` decimal(20,2) DEFAULT NULL,
  `price` decimal(20,2) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `date_added` timestamp NULL DEFAULT NULL,
  `date_modified` timestamp NULL DEFAULT NULL,
  `archived` varchar(3) DEFAULT NULL,
  `servicescol` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=13 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `services`
--

LOCK TABLES `services` WRITE;
/*!40000 ALTER TABLE `services` DISABLE KEYS */;
INSERT INTO `services` VALUES (7,'Measle Vaccination','Vaccination against Measles',200.00,208.00,'available','2018-08-27 05:21:14','2018-08-27 05:21:14','no',NULL),(8,'Parainfluenza  Vaccination','Vaccination agaist Parainfluenza',200.00,350.00,'available','2018-08-27 05:21:31','2018-08-27 05:21:31','no',NULL),(9,' Lyme disease Vaccination','Vaccination agaist  Lyme disease',200.00,340.00,'available','2018-08-27 05:21:53','2018-08-27 05:21:53','no',NULL),(10,'Pet Grooming L','Pet Grooming for Large Breed',200.00,200.00,'available','2018-08-27 05:22:27','2018-08-27 05:22:27','no',NULL),(11,'Pet Grooming M','Pet Grooming for Medium Breed',180.00,180.00,'available','2018-08-27 05:22:45','2018-08-27 05:22:58','no',NULL),(12,'Pet Grooming S','Pet Grooming for Small Breed',120.00,120.00,'available','2018-08-27 05:23:21','2018-08-27 05:23:21','no',NULL);
/*!40000 ALTER TABLE `services` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `staff`
--

DROP TABLE IF EXISTS `staff`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `staff` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `person_id` int(11) NOT NULL,
  `position_pos_id` int(11) NOT NULL,
  `username` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `archived` varchar(3) DEFAULT NULL,
  PRIMARY KEY (`id`,`person_id`,`position_pos_id`),
  KEY `fk_staff_person1_idx` (`person_id`),
  KEY `fk_staff_position1_idx` (`position_pos_id`),
  CONSTRAINT `fk_staff_person1` FOREIGN KEY (`person_id`) REFERENCES `person` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_staff_position1` FOREIGN KEY (`position_pos_id`) REFERENCES `position` (`pos_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staff`
--

LOCK TABLES `staff` WRITE;
/*!40000 ALTER TABLE `staff` DISABLE KEYS */;
INSERT INTO `staff` VALUES (1,10,1,'admin','admin','active','no'),(2,11,2,'staff','staff','active','no');
/*!40000 ALTER TABLE `staff` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `suppliers`
--

DROP TABLE IF EXISTS `suppliers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `suppliers` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `organization_name` varchar(45) DEFAULT NULL,
  `person_id` int(11) NOT NULL,
  `archived` varchar(3) DEFAULT NULL,
  PRIMARY KEY (`id`,`person_id`),
  KEY `fk_suppliers_person1_idx` (`person_id`),
  CONSTRAINT `fk_suppliers_person1` FOREIGN KEY (`person_id`) REFERENCES `person` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suppliers`
--

LOCK TABLES `suppliers` WRITE;
/*!40000 ALTER TABLE `suppliers` DISABLE KEYS */;
INSERT INTO `suppliers` VALUES (1,'Happy Pets Inc.',14,'no'),(2,'Honey Pet Supplies',15,'no');
/*!40000 ALTER TABLE `suppliers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `transactions`
--

DROP TABLE IF EXISTS `transactions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `transactions` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `staff_id` int(11) NOT NULL,
  `customers_id` int(11) NOT NULL,
  `transaction_date` datetime DEFAULT NULL,
  `total` decimal(20,2) DEFAULT NULL,
  PRIMARY KEY (`id`,`staff_id`,`customers_id`),
  KEY `fk_transactions_staff1_idx` (`staff_id`),
  KEY `fk_transactions_customers1_idx` (`customers_id`),
  CONSTRAINT `fk_transactions_customers1` FOREIGN KEY (`customers_id`) REFERENCES `customers` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_transactions_staff1` FOREIGN KEY (`staff_id`) REFERENCES `staff` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions`
--

LOCK TABLES `transactions` WRITE;
/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
INSERT INTO `transactions` VALUES (1,1,2,'2018-08-27 14:56:07',208.00),(2,1,8,'2018-09-05 11:47:46',1508.00),(3,1,9,'2018-09-05 12:04:08',300.00),(4,1,7,'2018-09-05 12:05:07',3000.00),(5,1,8,'2018-09-05 12:13:57',18750.00),(6,1,10,'2018-09-05 12:14:45',32.00),(7,1,8,'2018-09-05 12:17:56',24270.00),(8,1,9,'2018-09-05 12:18:49',15732.00),(9,1,7,'2018-09-05 12:20:05',6638.00),(10,1,2,'2018-09-05 12:21:21',3244.00);
/*!40000 ALTER TABLE `transactions` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-09-10 11:54:47
