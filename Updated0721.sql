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
  PRIMARY KEY (`id`,`pets_id`),
  KEY `fk_allergies_pets1_idx` (`pets_id`),
  CONSTRAINT `fk_allergies_pets1` FOREIGN KEY (`pets_id`) REFERENCES `pets` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `allergies`
--

LOCK TABLES `allergies` WRITE;
/*!40000 ALTER TABLE `allergies` DISABLE KEYS */;
INSERT INTO `allergies` VALUES (1,3,'Allergy in the nose'),(2,3,'Allergy in the nose');
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
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `cage`
--

LOCK TABLES `cage` WRITE;
/*!40000 ALTER TABLE `cage` DISABLE KEYS */;
INSERT INTO `cage` VALUES (3,'Kulungan','Para sa Dog ni Siya','unavailable');
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
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `customers`
--

LOCK TABLES `customers` WRITE;
/*!40000 ALTER TABLE `customers` DISABLE KEYS */;
INSERT INTO `customers` VALUES (4,5,'no');
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
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
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
  `name` varchar(45) DEFAULT NULL,
  `expiration_date` datetime DEFAULT NULL,
  `hospitalization_id` int(11) NOT NULL,
  `quantity` int(11) DEFAULT NULL,
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
  `name` varchar(45) DEFAULT NULL,
  `price` varchar(45) DEFAULT NULL,
  `subtotal` varchar(45) DEFAULT NULL,
  `quantity` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`,`hospitalization_id`),
  KEY `fk_hosp_prods_hospitalization1_idx` (`hospitalization_id`),
  CONSTRAINT `fk_hosp_prods_hospitalization1` FOREIGN KEY (`hospitalization_id`) REFERENCES `hospitalization` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hosp_prods`
--

LOCK TABLES `hosp_prods` WRITE;
/*!40000 ALTER TABLE `hosp_prods` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `hospitalization`
--

LOCK TABLES `hospitalization` WRITE;
/*!40000 ALTER TABLE `hospitalization` DISABLE KEYS */;
INSERT INTO `hospitalization` VALUES (3,3,3,'2018-07-20 00:24:28',NULL,0.00,'active','no');
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
) ENGINE=InnoDB AUTO_INCREMENT=125 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory_log`
--

LOCK TABLES `inventory_log` WRITE;
/*!40000 ALTER TABLE `inventory_log` DISABLE KEYS */;
INSERT INTO `inventory_log` VALUES (122,'Stock In (Purchased)','2018-07-19 23:59:52','Doggies','4','Purchased Item from Gabriel  Suazo Pil',3,NULL),(123,'Stock In (Purchased)','2018-07-20 00:07:56','Doggies','46','Purchased Item from Gabriel  Suazo Pil',3,NULL),(124,'Stock Out (Sales Order)','2018-07-20 00:08:25','Doggies','6','Purchased by KJ Lyn Pil',3,NULL);
/*!40000 ALTER TABLE `inventory_log` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `inventory_repack`
--

DROP TABLE IF EXISTS `inventory_repack`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `inventory_repack` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `product_inventory_id` int(11) NOT NULL,
  `product_inventory_products_id` int(11) NOT NULL,
  `quantity` varchar(45) DEFAULT NULL,
  `expiration_date` date DEFAULT NULL,
  `status` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id`,`product_inventory_id`,`product_inventory_products_id`),
  KEY `fk_product_inventory_copy1_product_inventory1_idx` (`product_inventory_id`,`product_inventory_products_id`),
  CONSTRAINT `fk_product_inventory_copy1_product_inventory1` FOREIGN KEY (`product_inventory_id`, `product_inventory_products_id`) REFERENCES `product_inventory` (`id`, `products_id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `inventory_repack`
--

LOCK TABLES `inventory_repack` WRITE;
/*!40000 ALTER TABLE `inventory_repack` DISABLE KEYS */;
/*!40000 ALTER TABLE `inventory_repack` ENABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `person`
--

LOCK TABLES `person` WRITE;
/*!40000 ALTER TABLE `person` DISABLE KEYS */;
INSERT INTO `person` VALUES (4,'Gabriel',' Suazo','Pil','male','1998-04-18','Buhangin, D.C.','09989099365','gablivion@gmail.com',NULL,NULL),(5,'KJ','Lyn','Pil','female','1998-07-19','Tags','099890997463','kjl@gmail.com','2018-07-19 15:59:23','2018-07-19 15:59:23');
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `pets`
--

LOCK TABLES `pets` WRITE;
/*!40000 ALTER TABLE `pets` DISABLE KEYS */;
INSERT INTO `pets` VALUES (3,4,'Gaef','white and grey','Dog','Husky','male','2018-07-20','N/A','yes','2018-07-19 16:24:18','2018-07-19 16:24:18','no');
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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
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
) ENGINE=InnoDB AUTO_INCREMENT=27 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `product_inventory`
--

LOCK TABLES `product_inventory` WRITE;
/*!40000 ALTER TABLE `product_inventory` DISABLE KEYS */;
INSERT INTO `product_inventory` VALUES (25,20,'4','2018-07-19','available',NULL),(26,20,'40','2018-07-21','available',NULL);
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
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `products`
--

LOCK TABLES `products` WRITE;
/*!40000 ALTER TABLE `products` DISABLE KEYS */;
INSERT INTO `products` VALUES (20,'Doggies','Dog Treates',200.00,'600','mg','yes','2018-07-19 15:57:59','2018-07-19 15:57:59','no',16);
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
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_order`
--

LOCK TABLES `purchase_order` WRITE;
/*!40000 ALTER TABLE `purchase_order` DISABLE KEYS */;
INSERT INTO `purchase_order` VALUES (21,2,3,600.00,'2018-07-19 15:59:41','delivered'),(22,2,3,7314.00,'2018-07-19 16:07:42','delivered');
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
) ENGINE=InnoDB AUTO_INCREMENT=43 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `purchase_order_line`
--

LOCK TABLES `purchase_order_line` WRITE;
/*!40000 ALTER TABLE `purchase_order_line` DISABLE KEYS */;
INSERT INTO `purchase_order_line` VALUES (41,20,21,'4',150.00,600.00,'yes','delivered'),(42,20,22,'46',159.00,7314.00,'yes','delivered');
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
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_order`
--

LOCK TABLES `sales_order` WRITE;
/*!40000 ALTER TABLE `sales_order` DISABLE KEYS */;
INSERT INTO `sales_order` VALUES (35,35,1200.00,NULL);
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
) ENGINE=InnoDB AUTO_INCREMENT=34 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sales_order_line`
--

LOCK TABLES `sales_order_line` WRITE;
/*!40000 ALTER TABLE `sales_order_line` DISABLE KEYS */;
INSERT INTO `sales_order_line` VALUES (33,35,20,'6',200.00,1200.00,'2018-07-21 00:00:00','no');
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
) ENGINE=InnoDB AUTO_INCREMENT=17 DEFAULT CHARSET=utf8;
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
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;
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
  `pets_id` int(11) NOT NULL,
  PRIMARY KEY (`id`,`services_id`,`transactions_id`,`pets_id`),
  KEY `fk_services_transactions1_idx` (`transactions_id`),
  KEY `fk_service_transaction_services1_idx` (`services_id`),
  KEY `fk_service_transaction_pets1_idx` (`pets_id`),
  CONSTRAINT `fk_service_transaction_pets1` FOREIGN KEY (`pets_id`) REFERENCES `pets` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_service_transaction_services1` FOREIGN KEY (`services_id`) REFERENCES `services` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_services_transactions1` FOREIGN KEY (`transactions_id`) REFERENCES `transactions` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=utf8;
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
  `archived` varchar(3) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `services`
--

LOCK TABLES `services` WRITE;
/*!40000 ALTER TABLE `services` DISABLE KEYS */;
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
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `staff`
--

LOCK TABLES `staff` WRITE;
/*!40000 ALTER TABLE `staff` DISABLE KEYS */;
INSERT INTO `staff` VALUES (3,4,1,'admin','admin','active',NULL);
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
INSERT INTO `suppliers` VALUES (2,'The Supplies',5,'no');
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
) ENGINE=InnoDB AUTO_INCREMENT=36 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `transactions`
--

LOCK TABLES `transactions` WRITE;
/*!40000 ALTER TABLE `transactions` DISABLE KEYS */;
INSERT INTO `transactions` VALUES (35,3,4,'2018-07-20 00:08:25',1200.00);
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

-- Dump completed on 2018-07-20 11:21:42