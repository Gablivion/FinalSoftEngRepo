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
INSERT INTO `cage` VALUES (6,'Cage 1','first cage on top left','available',150.00),(7,'Cage 2','first cage on top middle','available',200.00),(8,'Deluxe','first cage on top right','available',400.00),(9,'VIP','middle cage on the corner','available',500.00);
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
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` VALUES (1,12,'no'),(2,13,'no'),(7,14,'no'),(8,16,'no'),(9,17,'no'),(10,18,'no'),(11,19,'no'),(12,20,'no'),(13,21,'no'),(14,22,'no'),(15,23,'no'),(16,24,'no');
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
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hospitalization`
--

LOCK TABLES `hospitalization` WRITE;
/*!40000 ALTER TABLE `hospitalization` DISABLE KEYS */;
INSERT INTO `hospitalization` VALUES (6,6,6,'2018-08-27 13:18:49',NULL,0.00,'discharged','no'),(7,7,7,'2018-08-27 14:55:48',NULL,0.00,'discharged','no');
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
) ENGINE=InnoDB AUTO_INCREMENT=35 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory_log`
--

LOCK TABLES `inventory_log` WRITE;
/*!40000 ALTER TABLE `inventory_log` DISABLE KEYS */;
INSERT INTO `inventory_log` VALUES (13,'Stock In (Purchased)','2018-08-27 13:07:38','Collar (D)','50','Purchased Item from Gabriel Suazo Pil',1,NULL),(14,'Stock In (Purchased)','2018-08-27 13:07:38','Parainfluenza Vaccine','30','Purchased Item from Gabriel Suazo Pil',1,NULL),(15,'Stock In (Purchased)','2018-08-27 13:07:38','Measles Vaccine','25','Purchased Item from Gabriel Suazo Pil',1,NULL),(16,'Stock Out (Repack)','2018-08-27 13:08:06','Measles Vaccine','25','For Shelf',1,NULL),(17,'Stock Out (Repack)','2018-08-27 13:11:05','Parainfluenza Vaccine','10','For Shelf',1,NULL),(18,'Stock Out (Service Usage)','2018-08-27 13:24:31','Measles Vaccine (Repacked by 25 ml )','2','Stocked out to usage by Gabriel Suazo Pil',1,NULL),(19,'Stock Out (Hospitalization Product)','2018-08-27 13:24:45','Collar (D)','1','Used in hospitalization',1,NULL),(20,'Stock Out (Service Usage)','2018-08-27 14:55:53','Measles Vaccine (Repacked by 25 ml )','2','Stocked out to usage by Gabriel Suazo Pil',1,NULL),(21,'Stock In (Purchased)','2018-09-10 13:15:04','Pedigree Dog Food','15','Purchased Item from Gabriel Suazo Pil',1,NULL),(22,'Stock In (Purchased)','2018-09-10 13:15:04','Whiskas Tuna Dry Cat Food','20','Purchased Item from Gabriel Suazo Pil',1,NULL),(23,'Stock In (Purchased)','2018-09-10 13:16:25','Food Bowl','5','Purchased Item from Gabriel Suazo Pil',1,NULL),(24,'Stock In (Purchased)','2018-09-10 13:16:25','Dog Brush','5','Purchased Item from Gabriel Suazo Pil',1,NULL),(25,'Stock In (Purchased)','2018-09-10 13:17:33','Rabies Vaccine','20','Purchased Item from Gabriel Suazo Pil',1,NULL),(26,'Stock In (Purchased)','2018-09-10 13:22:11','Saint Roche Premium Organic Dog Shampoo','20','Purchased Item from Alexandra Adriano Ybanez',3,NULL),(27,'Stock In (Purchased)','2018-09-10 13:22:11','Bearing Tick and Flea Shampoo','20','Purchased Item from Alexandra Adriano Ybanez',3,NULL),(28,'Stock In (Purchased)','2018-09-10 13:22:11','Saint Gertie Cat Shampoo','20','Purchased Item from Alexandra Adriano Ybanez',3,NULL),(29,'Stock In (Purchased)','2018-09-10 13:23:35','Parainfluenza Vaccine','10','Purchased Item from Alexandra Adriano Ybanez',3,NULL),(30,'Stock In (Purchased)','2018-09-10 13:24:34','Whiskas Tuna Dry Cat Food','10','Purchased Item from Alexandra Adriano Ybanez',3,NULL),(31,'Stock In (Purchased)','2018-09-10 13:28:05','Leptospirosis Vaccine','5','Purchased Item from Alexandra Adriano Ybanez',3,NULL),(32,'Stock In (Purchased)','2018-09-10 13:30:27','Leptospirosis Vaccine','5','Purchased Item from Alexandra Adriano Ybanez',3,NULL),(33,'Stock In (Purchased)','2018-09-10 13:31:48','Dog Brush','5','Purchased Item from Alexandra Adriano Ybanez',3,NULL),(34,'Stock In (Purchased)','2018-09-10 13:31:48','Collar (D)','5','Purchased Item from Alexandra Adriano Ybanez',3,NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=42 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `person`
--

LOCK TABLES `person` WRITE;
/*!40000 ALTER TABLE `person` DISABLE KEYS */;
INSERT INTO `person` VALUES (10,'Gabriel','Suazo','Pil','male','1998-04-18','Buhangin, Davao City','09989099365','gablivion@gmail.com',NULL,NULL),(11,'Cherub ','Suazo','Pil','female','2001-03-21','Buhangin, Davao City','09989099342','cherubie@gmai.com',NULL,NULL),(12,'Gerard','Susalo','Pil','male','1972-11-15','Sasa, Davao City','09989443422','gsp@yahoo.com',NULL,NULL),(13,'Yvonne','Salinas','Suazo','female','1964-11-27','Buhangin, Davao City','09983356377','yvonnesal1998@yahoo.com',NULL,NULL),(14,'Ely','Santos','Suplayan','female','1989-04-18','Puan, Davao City','09989883422','Elysup@gmail.com',NULL,NULL),(15,'Honey','Gallegos','Lirasan','female','1989-09-07','Bajada, Davao City','09987743422','honeygal@yahoo.com',NULL,NULL),(16,'Barry','Sagun','Salinas','male','1998-03-23','Buhangin, Davao City','09989099365','barsag1998@gmail.com','2018-09-10 03:56:24','2018-09-10 03:56:24'),(17,'Austin','Gallegos','Pil','female','1998-03-24','Buhangin, Davao City','09907655342','austgal23@gmail.com','2018-09-10 03:57:23','2018-09-10 03:57:23'),(18,'Charlotte','Denise','Doble','female','1997-01-11','Buhangin, Davao City','09970772428','csdoble@addu.edu.ph','2018-09-10 03:58:03','2018-09-10 03:58:03'),(19,'Ian','Regin','Pioquinto','male','1999-08-30','Mintal, Davao City','09771881599','piox14@gmail.com','2018-09-10 03:59:11','2018-09-10 03:59:11'),(20,'Krystal','Reyes','Reroma','female','1998-03-26','Matina, Davao City','09989022132','krystalreroma@yahoo.com','2018-09-10 03:59:49','2018-09-10 03:59:49'),(21,'Joeferson','Sun','Go','male','1999-03-30','Agdao, Davao City','09088687175','jsgo@addu.edu.ph','2018-09-10 04:01:20','2018-09-10 04:01:20'),(22,'John Carlo','Mila','Ebreo','male','1999-09-21','Matina, Davao City','09338505621','jcebreo@gmail.com','2018-09-10 04:03:21','2018-09-10 04:03:21'),(23,'Camille','Dayon','Descalsota','female','1997-07-30','Matina, Davao City','09950321149','cddescalsota@addu.edu.ph','2018-09-10 04:05:00','2018-09-10 04:05:00'),(24,'Lee Christian','Neffe','Logan','male','1998-12-12','Digos City','09489912053','leelogan123@yahoo.com','2018-09-10 04:06:16','2018-09-10 04:06:16'),(25,'Bryan','Al','Anap','male','1998-10-13','Mandug, Davao City','09194208025','bryananap@gmail.com','2018-09-10 04:36:55','2018-09-10 04:36:55'),(26,'Junrick','Gazo','Bation','male','1999-03-12','Catalunan Pequeno, Davao City','09423082381','jgbation@addu.edu.ph','2018-09-10 04:38:31','2018-09-10 04:38:31'),(27,'Kiara','Yu','Huertas','female','1999-11-07','Mintal, Davao City','09489242048','khuertas@gmail.com','2018-09-10 04:39:54','2018-09-10 04:39:54'),(28,'Dwight','Barlis','De Jesus','male','2000-03-20','Obrero, Davao City','09229426920','djdwight08@yahoo.com','2018-09-10 04:42:49','2018-09-10 04:42:49'),(29,'Emmalyn','Taghoy','Maxey','female','1998-05-11','Talomo, Davao City','09152966198','adetaghoy@gmail.com','2018-09-10 04:44:00','2018-09-10 04:44:00'),(30,'Kristine','Adriano','Ybanez','female','1976-12-02','Sasa, Davao City','09198869136','kaybanez@yahoo.com','2018-09-10 04:45:02','2018-09-10 04:45:02'),(31,'Rica','Orillo','Reroma','female','1997-01-10','Bajada, Davao City','09176324185','riczreroma@yahoo.com','2018-09-10 04:46:41','2018-09-10 04:46:41'),(32,'Dianne','Piramide','Nery','female','1997-10-12','Matina, Davao City','09085183130','diannericka12@gmail.com','2018-09-10 04:48:04','2018-09-10 04:48:04'),(33,'Alexandra','Adriano','Ybanez','female','1999-06-05','Poblacion, Davao City','0997772428','akaybanez@addu.edu.ph','2018-09-10 04:49:18','2018-09-10 04:49:18'),(34,'Ian','Cruz','Batiquin','male','1998-10-05','Calinan, Davao City','09288770609','iccbatiquin@addu.edu.ph','2018-09-10 04:50:33','2018-09-10 04:50:33'),(35,'Lorenzo','Revelo','Quianzon','male','1999-05-11','Bangkal, Davao City','09776558736','renzoquianzon@gmail.com','2018-09-10 04:51:47','2018-09-10 04:51:47'),(36,'Elton','John','Castaño','male','1998-06-26','Buhangin, Davao City','099572442719','castanoelton@yahoo.com','2018-09-10 04:53:01','2018-09-10 04:53:01'),(37,'Frederic','Ferraros','Llanos','male','1998-06-21','Poblacion, Davao City','09989083996','dericllanos@yahoo.com','2018-09-10 04:57:41','2018-09-10 04:57:41'),(38,'Julius','Fe','Morandante','male','1999-05-25','Mintal, Davao City','0933648765','jmorandante@yahoo.com','2018-09-10 05:08:50','2018-09-10 05:08:50'),(39,'Jusane','Salutan','Bellezas','female','1998-07-07','Buhangin, Davao City','09435437869','jtsbellezas@addu.edu.ph','2018-09-10 05:09:39','2018-09-10 05:09:39'),(40,'Darrel','Zabala','Domalaon','male','1998-08-08','Ecoland Subdivision, Davao City','0915484394','dzdomalaon@addu.edu.ph','2018-09-10 05:11:25','2018-09-10 05:11:25'),(41,'Ken','Keleme','Gabisan','male','1998-09-23','Sasa, Davao City','09472852077','kengabisan@gmail.com','2018-09-10 05:12:34','2018-09-10 05:12:34');
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
) ENGINE=InnoDB AUTO_INCREMENT=18 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pets`
--

LOCK TABLES `pets` WRITE;
/*!40000 ALTER TABLE `pets` DISABLE KEYS */;
INSERT INTO `pets` VALUES (6,7,'George','White','Cat','Siamese','male','2018-07-24','552015556','yes','2018-08-27 05:16:07','2018-08-27 05:16:07','no'),(7,2,'Connor','Brownish Gold','Dog','Golden Retriever','male','2018-07-09','552015556','yes','2018-08-27 05:16:38','2018-08-27 05:16:38','no'),(8,1,'White','Dirty White','Dog','Labrador Retriever','male','2018-08-27','552035556','yes','2018-08-27 05:17:20','2018-08-27 05:17:20','no'),(9,11,'Solar','White','Cat','Persian','female','2017-04-10','552015556','yes','2018-09-10 04:08:27','2018-09-10 04:08:27','no'),(10,10,'Mina','Black','Dog','Shih Tzu','female','2018-02-22','5520155556','no','2018-09-10 04:09:59','2018-09-10 04:09:59','no'),(11,12,'Connor','Brown','Dog','Golden Retriever','male','2015-11-03','552015556','no','2018-09-10 04:10:58','2018-09-10 04:10:58','no'),(12,13,'Ling','White','Dog','Maltese','female','2017-12-28','552015556','yes','2018-09-10 04:12:14','2018-09-10 04:12:14','no'),(13,14,'Iris','Gray','Cat','Exotic Shorthair','female','2018-05-06','552015556','yes','2018-09-10 04:13:34','2018-09-10 04:13:34','no'),(14,15,'Blacky','Black','Dog','Poodle','male','2016-10-30','552015556','no','2018-09-10 04:14:46','2018-09-10 04:14:46','no'),(15,16,'Cheddar','Tan','Dog','Corgi','male','2015-11-01','552015556','no','2018-09-10 04:16:17','2018-09-10 04:16:17','no'),(16,8,'Panda','Black','Dog','Siberian Husky','male','2017-01-14','55201556','yes','2018-09-10 04:17:45','2018-09-10 04:17:45','no'),(17,10,'Peanut','White','Cat','Ragdoll','female','2018-04-25','55201556','yes','2018-09-10 04:19:24','2018-09-10 04:19:24','no');
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
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_inventory`
--

LOCK TABLES `product_inventory` WRITE;
/*!40000 ALTER TABLE `product_inventory` DISABLE KEYS */;
INSERT INTO `product_inventory` VALUES (3,37,'54','0000-00-00','available',NULL),(4,39,'20','2019-04-01','available',NULL),(5,38,'0','2019-04-01','unavailable',NULL),(6,40,'21','2019-04-01','available',NULL),(7,41,'10','2019-04-01','available',NULL),(8,45,'15','2020-09-10','available',NULL),(9,46,'30','2020-09-10','available',NULL),(10,36,'5','0000-00-00','available',NULL),(11,42,'10','0000-00-00','available',NULL),(12,44,'20','2021-09-10','available',NULL),(13,47,'20','2021-09-10','available',NULL),(14,48,'20','0000-00-00','available',NULL),(15,49,'20','0000-00-00','available',NULL),(16,39,'10','2020-09-10','available',NULL),(17,50,'5','2020-10-10','available',NULL),(18,50,'5','2020-11-10','available',NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (36,'Food Bowl','Bowl for your Dogs',140.00,'0','N/A','no','2018-08-27 05:01:30','2018-08-27 05:01:30','no',10,0),(37,'Collar (D)','Dog collar',90.00,'0','N/A','no','2018-08-27 05:03:05','2018-08-27 05:03:05','no',10,0),(38,'Measles Vaccine','Vaccine Vial for Measles',200.00,'50','ml','yes','2018-08-27 05:05:17','2018-08-27 05:05:17','no',15,1),(39,'Parainfluenza Vaccine','Vaccine Bottle for Parainfluenza',3000.00,'1000','ml','yes','2018-08-27 05:05:56','2018-08-27 05:05:56','no',5,1),(40,'Measles Vaccine (Repacked by 25 ml )','Vaccine Vial for Measles',4.00,'25','ml','yes','2018-08-27 05:08:06','2018-08-27 05:08:06','no',15,1),(41,'Parainfluenza Vaccine (Repacked by 500 ml )','Vaccine Bottle for Parainfluenza',150.00,'500','ml','yes','2018-08-27 05:11:05','2018-08-27 05:11:05','no',5,1),(42,'Dog Brush','Brush',80.00,'0','N/A','no','2018-09-10 04:21:55','2018-09-10 04:21:55','no',10,0),(43,'Litter Box','Litter box',350.00,'0','N/A','no','2018-09-10 04:22:21','2018-09-10 04:22:21','no',10,0),(44,'Rabies Vaccine','Vaccine',400.00,'80','ml','yes','2018-09-10 04:23:26','2018-09-10 04:23:26','no',5,1),(45,'Pedigree Dog Food','Dog Food',180.00,'1','kg','yes','2018-09-10 04:24:28','2018-09-10 04:25:47','no',15,0),(46,'Whiskas Tuna Dry Cat Food','Cat Food',145.00,'1','kg','yes','2018-09-10 04:26:34','2018-09-10 04:26:34','no',15,0),(47,'Saint Roche Premium Organic Dog Shampoo','Dog Shampoo',150.00,'250','ml','yes','2018-09-10 04:30:27','2018-09-10 04:30:27','no',15,0),(48,'Bearing Tick and Flea Shampoo','Flea Shampoo',280.00,'300','ml','no','2018-09-10 04:31:54','2018-09-10 04:31:54','no',10,0),(49,'Saint Gertie Cat Shampoo','Cat Shampoo',200.00,'250','ml','no','2018-09-10 04:32:48','2018-09-10 04:32:48','no',15,0),(50,'Leptospirosis Vaccine','Vaccine',680.00,'100','ml','yes','2018-09-10 05:27:04','2018-09-10 05:27:04','no',15,1);
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
) ENGINE=InnoDB AUTO_INCREMENT=40 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_order`
--

LOCK TABLES `purchase_order` WRITE;
/*!40000 ALTER TABLE `purchase_order` DISABLE KEYS */;
INSERT INTO `purchase_order` VALUES (30,1,1,90750.00,'2018-08-27 05:06:45','delivered'),(31,6,1,5000.00,'2018-09-10 05:13:59','delivered'),(32,9,1,1000.00,'2018-09-10 05:16:03','delivered'),(33,10,1,7000.00,'2018-09-10 05:17:18','delivered'),(34,7,3,11600.00,'2018-09-10 05:21:43','delivered'),(35,3,3,28000.00,'2018-09-10 05:23:15','delivered'),(36,8,3,1300.00,'2018-09-10 05:24:16','delivered'),(37,4,3,3250.00,'2018-09-10 05:27:34','delivered'),(38,5,3,3350.00,'2018-09-10 05:30:05','delivered'),(39,2,3,750.00,'2018-09-10 05:31:29','delivered');
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
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_order_line`
--

LOCK TABLES `purchase_order_line` WRITE;
/*!40000 ALTER TABLE `purchase_order_line` DISABLE KEYS */;
INSERT INTO `purchase_order_line` VALUES (3,39,30,'30',2800.00,84000.00,'yes','delivered'),(4,38,30,'25',150.00,3750.00,'yes','delivered'),(5,37,30,'50',60.00,3000.00,'yes','delivered'),(6,36,30,'20',90.00,1800.00,'no','cancelled'),(7,45,31,'15',160.00,2400.00,'yes','delivered'),(8,46,31,'20',130.00,2600.00,'yes','delivered'),(9,36,32,'5',130.00,650.00,'yes','delivered'),(10,42,32,'5',70.00,350.00,'yes','delivered'),(11,44,33,'20',350.00,7000.00,'yes','delivered'),(12,47,34,'20',140.00,2800.00,'yes','delivered'),(13,48,34,'20',260.00,5200.00,'yes','delivered'),(14,49,34,'20',180.00,3600.00,'yes','delivered'),(15,39,35,'10',2800.00,28000.00,'yes','delivered'),(16,46,36,'10',130.00,1300.00,'yes','delivered'),(17,50,37,'5',650.00,3250.00,'yes','delivered'),(18,50,38,'5',670.00,3350.00,'yes','delivered'),(19,42,39,'5',70.00,350.00,'yes','delivered'),(20,37,39,'5',80.00,400.00,'yes','delivered');
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_order`
--

LOCK TABLES `sales_order` WRITE;
/*!40000 ALTER TABLE `sales_order` DISABLE KEYS */;
INSERT INTO `sales_order` VALUES (1,1,208.00,NULL);
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_order_line`
--

LOCK TABLES `sales_order_line` WRITE;
/*!40000 ALTER TABLE `sales_order_line` DISABLE KEYS */;
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
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_refund`
--

LOCK TABLES `sales_refund` WRITE;
/*!40000 ALTER TABLE `sales_refund` DISABLE KEYS */;
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
INSERT INTO `service_products` VALUES (2,7,40,2),(3,8,41,1),(4,12,48,1),(5,11,48,1),(6,10,48,2),(7,13,44,1);
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
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `services`
--

LOCK TABLES `services` WRITE;
/*!40000 ALTER TABLE `services` DISABLE KEYS */;
INSERT INTO `services` VALUES (7,'Measle Vaccination','Vaccination against Measles',200.00,208.00,'available','2018-08-27 05:21:14','2018-08-27 05:21:14','no',NULL),(8,'Parainfluenza  Vaccination','Vaccination agaist Parainfluenza',200.00,350.00,'available','2018-08-27 05:21:31','2018-08-27 05:21:31','no',NULL),(9,' Lyme disease Vaccination','Vaccination agaist  Lyme disease',200.00,200.00,'available','2018-08-27 05:21:53','2018-08-27 05:21:53','no',NULL),(10,'Pet Grooming L','Pet Grooming for Large Breed',200.00,760.00,'available','2018-08-27 05:22:27','2018-08-27 05:22:27','no',NULL),(11,'Pet Grooming M','Pet Grooming for Medium Breed',180.00,460.00,'available','2018-08-27 05:22:45','2018-08-27 05:22:58','no',NULL),(12,'Pet Grooming S','Pet Grooming for Small Breed',120.00,400.00,'available','2018-08-27 05:23:21','2018-08-27 05:23:21','no',NULL),(13,'Rabies Vaccination','Vaccination',300.00,700.00,'available','2018-09-10 04:34:59','2018-09-10 04:34:59','no',NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staff`
--

LOCK TABLES `staff` WRITE;
/*!40000 ALTER TABLE `staff` DISABLE KEYS */;
INSERT INTO `staff` VALUES (1,10,1,'admin','admin','active','no'),(2,11,2,'staff','staff','active','no'),(3,33,2,'akay','akay','active','no'),(4,34,2,'ian','ian','active','no'),(5,35,2,'renzo','renzo','inactive','no'),(6,36,2,'elton','elton','inactive','no'),(7,37,2,'deric','deric','active','no'),(8,38,2,'julius','julius','active','no'),(9,39,2,'jusane','jusane','active','no'),(10,40,2,'dadz','dadz','active','no'),(11,41,2,'ken','ken','active','no');
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
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suppliers`
--

LOCK TABLES `suppliers` WRITE;
/*!40000 ALTER TABLE `suppliers` DISABLE KEYS */;
INSERT INTO `suppliers` VALUES (1,'Happy Pets Inc.',14,'no'),(2,'Honey Pet Supplies',15,'no'),(3,'Black PAWnther',25,'no'),(4,'Jun Marketing',26,'no'),(5,'Huertas Merchandise',27,'no'),(6,'SC Supplies',28,'no'),(7,'Maxey Marketing',29,'no'),(8,'3K Store',30,'no'),(9,'R&R General Merchandise',31,'no'),(10,'Eia Supplies',32,'no');
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
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions`
--

LOCK TABLES `transactions` WRITE;
/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
INSERT INTO `transactions` VALUES (1,1,2,'2018-08-27 14:56:07',208.00);
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

-- Dump completed on 2018-09-10 13:34:41
