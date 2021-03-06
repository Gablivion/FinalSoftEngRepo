-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: fabpets
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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `allergies`
--

LOCK TABLES `allergies` WRITE;
/*!40000 ALTER TABLE `allergies` DISABLE KEYS */;
INSERT INTO `allergies` VALUES (2,6,'Dust','2018-08-27 05:19:01'),(3,6,'Water','2018-08-27 05:19:05'),(4,8,'Dust','2018-09-17 15:27:19');
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
INSERT INTO `cage` VALUES (6,'Cage 1','first cage on top left','unavailable',150.00),(7,'Cage 2','first cage on top middle','available',200.00),(8,'Deluxe','first cage on top right','available',400.00),(9,'VIP','middle cage on the corner','available',500.00);
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
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hosp_prods`
--

LOCK TABLES `hosp_prods` WRITE;
/*!40000 ALTER TABLE `hosp_prods` DISABLE KEYS */;
INSERT INTO `hosp_prods` VALUES (9,6,37,'90.00',1),(10,8,38,'200.00',1);
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
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hospitalization`
--

LOCK TABLES `hospitalization` WRITE;
/*!40000 ALTER TABLE `hospitalization` DISABLE KEYS */;
INSERT INTO `hospitalization` VALUES (6,6,6,'2018-08-27 13:18:49',NULL,90.00,'discharged','no'),(7,7,7,'2018-08-27 14:55:48',NULL,0.00,'discharged','no'),(8,8,9,'2018-09-05 11:33:42',NULL,200.00,'discharged','no'),(9,8,6,'2018-09-17 23:26:38',NULL,0.00,'active','no');
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
) ENGINE=InnoDB AUTO_INCREMENT=85 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory_log`
--

LOCK TABLES `inventory_log` WRITE;
/*!40000 ALTER TABLE `inventory_log` DISABLE KEYS */;
INSERT INTO `inventory_log` VALUES (56,'Stock In (Purchased)','2018-09-17 14:20:46','Food Bowl','20','Purchased Item from Gabriel Suazo Pil',1,NULL),(57,'Stock In (Purchased)','2018-09-17 14:20:46','Measles Vaccine','25','Purchased Item from Gabriel Suazo Pil',1,NULL),(58,'Stock Out (Repack)','2018-09-17 14:21:22','Measles Vaccine','5','For Shelf',1,NULL),(59,'Stock Out (Repack)','2018-09-17 14:21:51','Measles Vaccine','5','For Shelf',1,NULL),(60,'Stock Out (Repack)','2018-09-17 14:44:54','Measles Vaccine','2','For Shelf',0,NULL),(61,'Stock Out (Repack)','2018-09-17 14:46:19','Measles Vaccine','1','For Shelf',0,NULL),(62,'Stock Out (Repack)','2018-09-17 14:46:34','Measles Vaccine','3','For Shelf',0,NULL),(63,'Stock Out (Manual)','2018-09-17 14:47:12','Parainfluenza Vaccine (Repacked by 500 ml )','1','None',0,NULL),(64,'Stock Out (Manual)','2018-09-17 14:47:24','Parainfluenza Vaccine (Repacked by 500 ml )','2','None',0,NULL),(65,'Stock Out (Manual)','2018-09-17 14:48:27','Measles Vaccine (Repacked by 1 ml )','1','None',0,NULL),(66,'Stock Out (Manual)','2018-09-17 14:48:40','Measles Vaccine (Repacked by 1 ml )','3','None',0,NULL),(67,'Stock Out (Manual)','2018-09-17 14:50:02','Measles Vaccine','1','None',1,NULL),(68,'Stock Out (Manual)','2018-09-17 14:50:05','Measles Vaccine','1','None',1,NULL),(69,'Stock Out (Hospitalization Product)','2018-09-17 14:50:47','Measles Vaccine','1','Used in hospitalization',1,NULL),(70,'Stock Out (Sales Order)','2018-09-17 15:24:21','Measles Vaccine','200.00','Purchased by Cherub  Suazo Pil',1,NULL),(71,'Stock Out (Sales Order)','2018-09-17 15:24:31','Measles Vaccine','400.00','Purchased by Honey Gallegos Lirasan',1,NULL),(72,'Stock In (Refund)','2018-09-17 15:24:39','Measles Vaccine','1','Purchased Item from Gabriel Suazo Pil',1,NULL),(73,'Stock In (Refund)','2018-09-17 22:24:29','Measles Vaccine','1','Purchased Item from Gabriel Suazo Pil',1,NULL),(74,'Stock In (Purchased)','2018-09-17 23:22:24','Food Bowl','2','Purchased Item from Gabriel Suazo Pil',1,NULL),(75,'Stock Out (Repack)','2018-09-17 23:22:56','Measles Vaccine','2','For Shelf',1,NULL),(76,'Stock Out (Manual)','2018-09-17 23:23:37','Measles Vaccine (Repacked by 1 ml )','2','Bad Repacking',1,NULL),(77,'Stock In (Purchased)','2018-09-17 23:33:26','Shamme Dog Shampoo','6','Purchased Item from Gabriel Suazo Pil',1,NULL),(78,'Stock Out (Repack)','2018-09-17 23:34:33','Shamme Dog Shampoo','1','For Shelf',1,NULL),(79,'Stock Out (Repack)','2018-09-17 23:34:53','Shamme Dog Shampoo','1','For Shelf',1,NULL),(80,'Stock Out (Repack)','2018-09-17 23:35:10','Shamme Dog Shampoo','1','For Shelf',1,NULL),(81,'Stock Out (Repack)','2018-09-17 23:35:18','Shamme Dog Shampoo','1','For Shelf',1,NULL),(82,'Stock Out (Manual)','2018-09-17 23:35:33','Shamme Dog Shampoo (Repacked by 5 ml )','1','BAD REPACKING',1,NULL),(83,'Stock Out (Manual)','2018-09-17 23:35:41','Shamme Dog Shampoo (Repacked by 4 ml )','1','BAD REPACKING',1,NULL),(84,'Stock Out (Repack)','2018-09-17 23:35:55','Shamme Dog Shampoo','1','For Shelf',1,NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `medicines_given`
--

LOCK TABLES `medicines_given` WRITE;
/*!40000 ALTER TABLE `medicines_given` DISABLE KEYS */;
INSERT INTO `medicines_given` VALUES (1,8,8,'Measles Vaccine','Inventory','2018-09-17 06:50:47');
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
INSERT INTO `person` VALUES (10,'Gabriel','Suazo','Pil','male','1998-04-18','Buhangin, Davao City','09989099365','gablivion@gmail.com',NULL,NULL),(11,'Cherub ','Suazo','Pil','female','2001-03-21','Buhangin, Davao City','09989099342','cherubie@gmai.com',NULL,NULL),(12,'Gerard','Susalo','Pil','male','1972-11-15','Sasa, Davao City','09989443422','gsp@yahoo.com',NULL,NULL),(13,'Yvonne','Salinas','Suazo','female','1964-11-27','Buhangin, Davao City','09983356377','yvonnesal1998@yahoo.com',NULL,NULL),(14,'Ely','Santos','Suplayan','female','1989-04-18','Puan, Davao City','09989883422','Elysup@gmail.com',NULL,NULL),(15,'Honey','Gallegos','Lirasan','female','1989-09-07','Bajada, Davao City','09987743422','honeygal@yahoo.com',NULL,'2018-09-17 15:21:29');
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
) ENGINE=InnoDB AUTO_INCREMENT=22 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_inventory`
--

LOCK TABLES `product_inventory` WRITE;
/*!40000 ALTER TABLE `product_inventory` DISABLE KEYS */;
INSERT INTO `product_inventory` VALUES (8,36,'22','0000-00-00','available',NULL),(9,38,'3','2019-09-17','available',NULL),(13,42,'0','2019-09-17','unavailable',NULL),(14,42,'0','2019-09-17','unavailable',NULL),(15,42,'0','2019-09-17','unavailable',NULL),(16,43,'1','0000-00-00','available',NULL),(17,44,'0','0000-00-00','unavailable',NULL),(18,45,'0','0000-00-00','unavailable',NULL),(19,46,'1','0000-00-00','available',NULL),(20,47,'1','0000-00-00','available',NULL),(21,48,'1','0000-00-00','available',NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=49 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (36,'Food Bowl','Bowl for your Dogs',140.00,'0','N/A','no','2018-08-27 05:01:30','2018-08-27 05:01:30','no',10,0),(37,'Collar (D)','Dog collar',90.00,'0','N/A','no','2018-08-27 05:03:05','2018-08-27 05:03:05','no',10,0),(38,'Measles Vaccine','Vaccine Vial for Measles',200.00,'50','ml','yes','2018-08-27 05:05:17','2018-08-27 05:05:17','no',15,1),(39,'Parainfluenza Vaccine','Vaccine Bottle for Parainfluenza',3000.00,'1000','ml','yes','2018-08-27 05:05:56','2018-08-27 05:05:56','no',5,1),(40,'Measles Vaccine (Repacked by 25 ml )','Vaccine Vial for Measles',4.00,'25','ml','yes','2018-08-27 05:08:06','2018-08-27 05:08:06','no',15,1),(41,'Parainfluenza Vaccine (Repacked by 500 ml )','Vaccine Bottle for Parainfluenza',150.00,'500','ml','yes','2018-08-27 05:11:05','2018-08-27 05:11:05','no',5,1),(42,'Measles Vaccine (Repacked by 1 ml )','Vaccine Vial for Measles',200.00,'1','ml','yes','2018-09-17 06:46:19','2018-09-17 06:46:19','no',15,1),(43,'Shamme Dog Shampoo','Dog Shampoo',500.00,'1000','ml','no','2018-09-17 15:32:52','2018-09-17 15:32:52','no',5,0),(44,'Shamme Dog Shampoo (Repacked by 5 ml )','Dog Shampoo',2.50,'5','ml','no','2018-09-17 15:34:33','2018-09-17 15:34:33','no',5,0),(45,'Shamme Dog Shampoo (Repacked by 4 ml )','Dog Shampoo',2.00,'4','ml','no','2018-09-17 15:34:53','2018-09-17 15:34:53','no',5,0),(46,'Shamme Dog Shampoo (Repacked by 250 ml )','Dog Shampoo',125.00,'250','ml','no','2018-09-17 15:35:10','2018-09-17 15:35:10','no',5,0),(47,'Shamme Dog Shampoo (Repacked by 200 ml )','Dog Shampoo',100.00,'200','ml','no','2018-09-17 15:35:18','2018-09-17 15:35:18','no',5,0),(48,'Shamme Dog Shampoo (Repacked by 300 ml )','Dog Shampoo',166.67,'300','ml','no','2018-09-17 15:35:55','2018-09-17 15:35:55','no',5,0);
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
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_order`
--

LOCK TABLES `purchase_order` WRITE;
/*!40000 ALTER TABLE `purchase_order` DISABLE KEYS */;
INSERT INTO `purchase_order` VALUES (31,2,1,6900.00,'2018-09-17 06:20:28','delivered'),(32,1,1,0.00,'2018-09-17 15:21:51','cancelled'),(33,1,1,240.00,'2018-09-17 15:22:07','delivered'),(34,2,1,2880.00,'2018-09-17 15:33:18','delivered');
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
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_order_line`
--

LOCK TABLES `purchase_order_line` WRITE;
/*!40000 ALTER TABLE `purchase_order_line` DISABLE KEYS */;
INSERT INTO `purchase_order_line` VALUES (7,36,31,'20',120.00,2400.00,'yes','delivered'),(8,38,31,'25',180.00,4500.00,'yes','delivered'),(9,36,32,'5',130.00,650.00,'no','cancelled'),(10,36,33,'2',120.00,240.00,'yes','delivered'),(11,43,34,'6',480.00,2880.00,'yes','delivered');
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
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_order`
--

LOCK TABLES `sales_order` WRITE;
/*!40000 ALTER TABLE `sales_order` DISABLE KEYS */;
INSERT INTO `sales_order` VALUES (12,12,200.00,NULL),(13,13,400.00,'yes');
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
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_order_line`
--

LOCK TABLES `sales_order_line` WRITE;
/*!40000 ALTER TABLE `sales_order_line` DISABLE KEYS */;
INSERT INTO `sales_order_line` VALUES (16,12,38,'1',200.00,200.00,'2019-09-17 00:00:00','no'),(17,13,38,'0',200.00,400.00,'2019-09-17 00:00:00','yes');
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
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_refund`
--

LOCK TABLES `sales_refund` WRITE;
/*!40000 ALTER TABLE `sales_refund` DISABLE KEYS */;
INSERT INTO `sales_refund` VALUES (21,13,17,10,1,'Measles Vaccine','1',200.00,'2018-09-17 15:24:39'),(22,13,17,10,1,'Measles Vaccine','1',200.00,'2018-09-17 22:24:29');
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
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `service_products`
--

LOCK TABLES `service_products` WRITE;
/*!40000 ALTER TABLE `service_products` DISABLE KEYS */;
INSERT INTO `service_products` VALUES (2,7,40,2),(3,8,41,1),(4,9,36,1),(5,12,47,1),(6,11,46,1),(7,10,48,1);
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
INSERT INTO `services` VALUES (7,'Measle Vaccination','Vaccination against Measles',200.00,208.00,'available','2018-08-27 05:21:14','2018-08-27 05:21:14','no',NULL),(8,'Parainfluenza  Vaccination','Vaccination agaist Parainfluenza',200.00,350.00,'available','2018-08-27 05:21:31','2018-08-27 05:21:31','no',NULL),(9,' Lyme disease Vaccination','Vaccination agaist  Lyme disease',200.00,340.00,'available','2018-08-27 05:21:53','2018-08-27 05:21:53','no',NULL),(10,'Pet Grooming L','Pet Grooming for Large Breed',200.00,366.67,'available','2018-08-27 05:22:27','2018-08-27 05:22:27','no',NULL),(11,'Pet Grooming M','Pet Grooming for Medium Breed',180.00,305.00,'available','2018-08-27 05:22:45','2018-08-27 05:22:58','no',NULL),(12,'Pet Grooming S','Pet Grooming for Small Breed',120.00,220.00,'available','2018-08-27 05:23:21','2018-08-27 05:23:21','no',NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions`
--

LOCK TABLES `transactions` WRITE;
/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
INSERT INTO `transactions` VALUES (11,1,1,'2018-09-17 14:51:02',6200.00),(12,1,9,'2018-09-17 15:24:21',200.00),(13,1,10,'2018-09-17 15:24:31',400.00);
/*!40000 ALTER TABLE `transactions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'fabpets'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-09-18  9:28:40
