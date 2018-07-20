CREATE DATABASE  IF NOT EXISTS `fabpets` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `fabpets`;
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
-- Table structure for table `cage`
--

DROP TABLE IF EXISTS `cage`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `cage` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `cage_description` varchar(255) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `hospitalization_id` int(11) NOT NULL,
  PRIMARY KEY (`id`,`hospitalization_id`),
  KEY `fk_cage_hospitalization1_idx` (`hospitalization_id`),
  CONSTRAINT `fk_cage_hospitalization1` FOREIGN KEY (`hospitalization_id`) REFERENCES `hospitalization` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cage`
--

LOCK TABLES `cage` WRITE;
/*!40000 ALTER TABLE `cage` DISABLE KEYS */;
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
  PRIMARY KEY (`id`,`person_id`),
  KEY `fk_customers_person1_idx` (`person_id`),
  CONSTRAINT `fk_customers_person1` FOREIGN KEY (`person_id`) REFERENCES `person` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` VALUES (13,36);
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
  `uraniation_status` varchar(45) DEFAULT NULL,
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
-- Table structure for table `hospitalization`
--

DROP TABLE IF EXISTS `hospitalization`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `hospitalization` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `transactions_id` int(11) NOT NULL,
  `pets_id` int(11) NOT NULL,
  `date_in` datetime DEFAULT NULL,
  `date_out` datetime DEFAULT NULL,
  `subtotal` decimal(20,2) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`,`transactions_id`,`pets_id`),
  KEY `fk_hospitalization_transactions1_idx` (`transactions_id`),
  KEY `fk_hospitalization_pets1_idx` (`pets_id`),
  CONSTRAINT `fk_hospitalization_pets1` FOREIGN KEY (`pets_id`) REFERENCES `pets` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_hospitalization_transactions1` FOREIGN KEY (`transactions_id`) REFERENCES `transactions` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hospitalization`
--

LOCK TABLES `hospitalization` WRITE;
/*!40000 ALTER TABLE `hospitalization` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=93 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory_log`
--

LOCK TABLES `inventory_log` WRITE;
/*!40000 ALTER TABLE `inventory_log` DISABLE KEYS */;
INSERT INTO `inventory_log` VALUES (91,'Stock In (Purchased)','2018-02-19 14:40:07','Vaccine','2','Purchased Item from Gabriel John Pil',17,NULL),(92,'Stock Out (Sales Order)','2018-02-19 14:40:42','Vaccine','1','Purchased by Nadir Shat Sagun',17,NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=37 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `person`
--

LOCK TABLES `person` WRITE;
/*!40000 ALTER TABLE `person` DISABLE KEYS */;
INSERT INTO `person` VALUES (34,'Gabriel','John','Pil','male','1998-04-18','Buhangin','09098472342','gablivion@gmail.com',NULL,NULL),(35,'Rex','Aguda','Collado','female','1999-03-20','Qatar','5463782904','rex@yahoo.com','2018-02-19 06:36:50','2018-02-19 06:36:50'),(36,'Nadir','Shat','Sagun','male','1999-06-06','Buhangin','57483297548392','nadir@yahoo.com','2018-02-19 06:37:48','2018-02-19 06:37:48');
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
  PRIMARY KEY (`id`,`customer_id`),
  KEY `fk_pets_customers1_idx` (`customer_id`),
  CONSTRAINT `fk_pets_customers1` FOREIGN KEY (`customer_id`) REFERENCES `customers` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pets`
--

LOCK TABLES `pets` WRITE;
/*!40000 ALTER TABLE `pets` DISABLE KEYS */;
INSERT INTO `pets` VALUES (3,13,'Predator Jr.','Brown','Dog','Chihuahua','male','2017-02-19','N/A','yes','2018-02-19 06:41:53','2018-02-19 06:41:53');
/*!40000 ALTER TABLE `pets` ENABLE KEYS */;
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
  PRIMARY KEY (`id`,`products_id`),
  KEY `fk_product_inventory_products1_idx` (`products_id`),
  CONSTRAINT `fk_product_inventory_products1` FOREIGN KEY (`products_id`) REFERENCES `products` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=39 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_inventory`
--

LOCK TABLES `product_inventory` WRITE;
/*!40000 ALTER TABLE `product_inventory` DISABLE KEYS */;
INSERT INTO `product_inventory` VALUES (38,28,'1','2018-02-19','available');
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
  `volume` int(11) DEFAULT NULL,
  `expirable` varchar(5) DEFAULT NULL,
  `date_added` timestamp NULL DEFAULT NULL,
  `date_modified` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=30 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (28,'Vaccine','Drugs',250.00,30,'yes','2018-02-19 06:39:18','2018-02-19 06:39:18'),(29,'Kettle Korn','Food',55.00,0,'no','2018-02-19 06:39:37','2018-02-19 06:39:37');
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
  PRIMARY KEY (`id`,`staff_id`,`suppliers_id`),
  KEY `fk_products_has_suppliers_suppliers1_idx` (`suppliers_id`),
  KEY `fk_purchase_order_staff1_idx` (`staff_id`),
  CONSTRAINT `fk_products_has_suppliers_suppliers1` FOREIGN KEY (`suppliers_id`) REFERENCES `suppliers` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_purchase_order_staff1` FOREIGN KEY (`staff_id`) REFERENCES `staff` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=48 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_order`
--

LOCK TABLES `purchase_order` WRITE;
/*!40000 ALTER TABLE `purchase_order` DISABLE KEYS */;
INSERT INTO `purchase_order` VALUES (47,5,17,500.00,'2018-02-19 06:39:53');
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
  `expiration` date DEFAULT NULL,
  `stocked_in` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`id`,`products_id`,`purchase_order_id`),
  KEY `fk_purchase_order_line_products1_idx` (`products_id`),
  KEY `fk_purchase_order_line_purchase_order1_idx` (`purchase_order_id`),
  CONSTRAINT `fk_purchase_order_line_products1` FOREIGN KEY (`products_id`) REFERENCES `products` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_purchase_order_line_purchase_order1` FOREIGN KEY (`purchase_order_id`) REFERENCES `purchase_order` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=51 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_order_line`
--

LOCK TABLES `purchase_order_line` WRITE;
/*!40000 ALTER TABLE `purchase_order_line` DISABLE KEYS */;
INSERT INTO `purchase_order_line` VALUES (50,28,47,'2',250.00,500.00,'2018-02-19','yes');
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
  PRIMARY KEY (`id`,`transactions_id`),
  KEY `fk_order_transactions1_idx` (`transactions_id`),
  CONSTRAINT `fk_order_transactions1` FOREIGN KEY (`transactions_id`) REFERENCES `transactions` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=16 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_order`
--

LOCK TABLES `sales_order` WRITE;
/*!40000 ALTER TABLE `sales_order` DISABLE KEYS */;
INSERT INTO `sales_order` VALUES (15,26,250.00);
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
  PRIMARY KEY (`id`,`order_id`,`products_id`),
  KEY `fk_order_line_order1_idx` (`order_id`),
  KEY `fk_order_line_products1_idx` (`products_id`),
  CONSTRAINT `fk_order_line_order1` FOREIGN KEY (`order_id`) REFERENCES `sales_order` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_order_line_products1` FOREIGN KEY (`products_id`) REFERENCES `products` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_order_line`
--

LOCK TABLES `sales_order_line` WRITE;
/*!40000 ALTER TABLE `sales_order_line` DISABLE KEYS */;
INSERT INTO `sales_order_line` VALUES (16,15,28,'1',250.00,250.00);
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
  `product` varchar(45) DEFAULT NULL,
  `quantity` varchar(45) DEFAULT NULL,
  `amount` decimal(20,2) DEFAULT NULL,
  `date` datetime DEFAULT NULL,
  `notes` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`,`sales_order_id`),
  KEY `fk_sales_refund_sales_order1_idx` (`sales_order_id`),
  CONSTRAINT `fk_sales_refund_sales_order1` FOREIGN KEY (`sales_order_id`) REFERENCES `sales_order` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
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
  `transactions_id` int(11) NOT NULL,
  `service_price` decimal(20,2) DEFAULT NULL,
  `subtotal` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`,`services_id`,`transactions_id`),
  KEY `fk_services_transactions1_idx` (`transactions_id`),
  KEY `fk_service_transaction_services1_idx` (`services_id`),
  CONSTRAINT `fk_service_transaction_services1` FOREIGN KEY (`services_id`) REFERENCES `services` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_services_transactions1` FOREIGN KEY (`transactions_id`) REFERENCES `transactions` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
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
  `price` decimal(20,2) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  `date_added` timestamp NULL DEFAULT NULL,
  `date_modified` timestamp NULL DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `services`
--

LOCK TABLES `services` WRITE;
/*!40000 ALTER TABLE `services` DISABLE KEYS */;
INSERT INTO `services` VALUES (5,'Grooming','To make beautiful',300.00,'available','2018-02-19 06:38:24','2018-02-19 06:38:24');
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
  `position` varchar(45) DEFAULT NULL,
  `username` varchar(45) DEFAULT NULL,
  `password` varchar(45) DEFAULT NULL,
  `status` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`,`person_id`),
  KEY `fk_staff_person1_idx` (`person_id`),
  CONSTRAINT `fk_staff_person1` FOREIGN KEY (`person_id`) REFERENCES `person` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=19 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staff`
--

LOCK TABLES `staff` WRITE;
/*!40000 ALTER TABLE `staff` DISABLE KEYS */;
INSERT INTO `staff` VALUES (17,34,'owner','a','a','active'),(18,35,'staff','rex','rex','active');
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
  PRIMARY KEY (`id`,`person_id`),
  KEY `fk_suppliers_person1_idx` (`person_id`),
  CONSTRAINT `fk_suppliers_person1` FOREIGN KEY (`person_id`) REFERENCES `person` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `suppliers`
--

LOCK TABLES `suppliers` WRITE;
/*!40000 ALTER TABLE `suppliers` DISABLE KEYS */;
INSERT INTO `suppliers` VALUES (5,'Predator',36);
/*!40000 ALTER TABLE `suppliers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `temporary_inventory`
--

DROP TABLE IF EXISTS `temporary_inventory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `temporary_inventory` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `temporary_products_id` int(11) NOT NULL,
  `transactions_id` int(11) NOT NULL,
  `temp_product_quantity` int(11) DEFAULT NULL,
  `temp_product_expiration_date` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`,`temporary_products_id`,`transactions_id`),
  KEY `fk_temporary_inventory_temporary_products_idx` (`temporary_products_id`),
  KEY `fk_temporary_inventory_transactions1_idx` (`transactions_id`),
  CONSTRAINT `fk_temporary_inventory_temporary_products` FOREIGN KEY (`temporary_products_id`) REFERENCES `temporary_products` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_temporary_inventory_transactions1` FOREIGN KEY (`transactions_id`) REFERENCES `transactions` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `temporary_inventory`
--

LOCK TABLES `temporary_inventory` WRITE;
/*!40000 ALTER TABLE `temporary_inventory` DISABLE KEYS */;
/*!40000 ALTER TABLE `temporary_inventory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `temporary_products`
--

DROP TABLE IF EXISTS `temporary_products`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `temporary_products` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `temp_product_name` varchar(45) DEFAULT NULL,
  `temp_product_description` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `temporary_products`
--

LOCK TABLES `temporary_products` WRITE;
/*!40000 ALTER TABLE `temporary_products` DISABLE KEYS */;
/*!40000 ALTER TABLE `temporary_products` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions`
--

LOCK TABLES `transactions` WRITE;
/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
INSERT INTO `transactions` VALUES (26,17,13,'2018-02-19 14:40:42',250.00);
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

-- Dump completed on 2018-02-19 15:01:24
