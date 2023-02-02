-- phpMyAdmin SQL Dump
-- version 4.9.7
-- https://www.phpmyadmin.net/
--
-- Хост: localhost:3306
-- Време на генериране:  2 фев 2023 в 04:36
-- Версия на сървъра: 10.3.36-MariaDB-log-cll-lve
-- Версия на PHP: 7.4.33

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данни: `vdevsonl_demoHTTPLogin`
--

-- --------------------------------------------------------

--
-- Структура на таблица `example_products`
--

CREATE TABLE `example_products` (
  `id` int(200) NOT NULL,
  `product_Name` varchar(256) COLLATE utf8_unicode_ci NOT NULL,
  `product_Weight` int(200) NOT NULL,
  `product_Category` varchar(256) COLLATE utf8_unicode_ci NOT NULL,
  `product_Image` varchar(256) COLLATE utf8_unicode_ci NOT NULL,
  `product_added_by` varchar(256) COLLATE utf8_unicode_ci NOT NULL,
  `product_price` double NOT NULL,
  `product_has_inventory` tinyint(1) NOT NULL,
  `product_Color` varchar(256) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Схема на данните от таблица `example_products`
--

INSERT INTO `example_products` (`id`, `product_Name`, `product_Weight`, `product_Category`, `product_Image`, `product_added_by`, `product_price`, `product_has_inventory`, `product_Color`) VALUES
(1, 'Example Product', 140, 'No Category', 'public_html/images/image0.png/', 'root', 47, 1, 'BLUE'),
(2, 'Gaming PC', 492, 'Electronics', 'public_html/images/pc0.png/', 'admin', 1450, 1, 'null');

-- --------------------------------------------------------

--
-- Структура на таблица `example_sessions`
--

CREATE TABLE `example_sessions` (
  `sessionHash` varchar(256) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Структура на таблица `example_users`
--

CREATE TABLE `example_users` (
  `id` int(11) NOT NULL,
  `username` varchar(256) COLLATE utf8_unicode_ci NOT NULL,
  `password` varchar(256) COLLATE utf8_unicode_ci NOT NULL,
  `token` varchar(256) COLLATE utf8_unicode_ci NOT NULL,
  `email` varchar(256) COLLATE utf8_unicode_ci NOT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Indexes for dumped tables
--

--
-- Индекси за таблица `example_products`
--
ALTER TABLE `example_products`
  ADD PRIMARY KEY (`id`);

--
-- Индекси за таблица `example_sessions`
--
ALTER TABLE `example_sessions`
  ADD PRIMARY KEY (`sessionHash`);

--
-- Индекси за таблица `example_users`
--
ALTER TABLE `example_users`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `example_products`
--
ALTER TABLE `example_products`
  MODIFY `id` int(200) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `example_users`
--
ALTER TABLE `example_users`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
