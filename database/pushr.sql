-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Gegenereerd op: 01 mrt 2023 om 10:03
-- Serverversie: 10.4.27-MariaDB
-- PHP-versie: 8.2.0

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pushr`
--

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `messages`
--

CREATE TABLE `messages` (
  `id` int(255) NOT NULL,
  `from_id` int(255) NOT NULL,
  `message` varchar(1000) NOT NULL,
  `to_id` int(255) NOT NULL,
  `datum` datetime DEFAULT current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Gegevens worden geëxporteerd voor tabel `messages`
--

INSERT INTO `messages` (`id`, `from_id`, `message`, `to_id`, `datum`) VALUES
(1, 38, 'leuk he', 1, NULL),
(2, 1, 'ja echt leuk', 38, NULL),
(3, 38, 'goeiemorgen', 1, NULL),
(4, 1, 'goeiemiddag', 38, NULL),
(6, 1, 'asdfjklksjdklcnslajdfsadf', 38, NULL),
(7, 38, 'hallo', 1, '2023-02-28 13:15:48'),
(13, 38, 'jdjdjd', 1, '2023-02-28 14:15:41'),
(14, 38, 'fbfbfb', 1, '2023-02-28 14:17:01');

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `requests`
--

CREATE TABLE `requests` (
  `id` int(255) NOT NULL,
  `sender_id` int(255) NOT NULL,
  `receiver_id` int(255) NOT NULL,
  `accepted` tinyint(1) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `users`
--

CREATE TABLE `users` (
  `id` int(255) NOT NULL,
  `name` varchar(55) NOT NULL,
  `password` varchar(255) NOT NULL,
  `nickname` varchar(55) NOT NULL,
  `token` varchar(255) DEFAULT NULL,
  `archive` tinyint(1) NOT NULL DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Gegevens worden geëxporteerd voor tabel `users`
--

INSERT INTO `users` (`id`, `name`, `password`, `nickname`, `token`, `archive`) VALUES
(1, 'Robin', 'D8578EDF8458CE06FBC5BB76A58C5CA4', 'Robin', NULL, 0),
(25, 'Paul', '6C63212AB48E8401EAF6B59B95D816A9', 'Paul', NULL, 0),
(36, 'Tim', 'B15D47E99831EE63E3F47CF3D4478E9A', 'Tim', NULL, 0),
(38, 'Jan', 'FA27EF3EF6570E32A79E74DECA7C1BC3', 'Jan', NULL, 0),
(39, 'Test', '098F6BCD4621D373CADE4E832627B4F6', 'Test', NULL, 0),
(40, 'Robin', '8EE60A2E00C90D7E00D5069188DC115B', 'Robin1', 'fs10VNYwTUWIF6aDdDcP4K:APA91bE0OfObfADf3IzqGMDrlcUF3w610kYnDnbj3xm-TPA01Y-A9yZ6Y0CtCMqw3sVyDguwDMkR-G4GolbpGDGtqdR48IdyWdhSc_nmbp-Von_me-QBCGpb8gy65DgkIjR4AWwTZi_4', 0);

--
-- Indexen voor geëxporteerde tabellen
--

--
-- Indexen voor tabel `messages`
--
ALTER TABLE `messages`
  ADD PRIMARY KEY (`id`),
  ADD KEY `senduser_id` (`from_id`),
  ADD KEY `receiveuser_id` (`to_id`);

--
-- Indexen voor tabel `requests`
--
ALTER TABLE `requests`
  ADD PRIMARY KEY (`id`),
  ADD KEY `requestinguser_id` (`sender_id`),
  ADD KEY `user_id` (`receiver_id`),
  ADD KEY `id` (`id`);

--
-- Indexen voor tabel `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`id`),
  ADD KEY `id` (`id`);

--
-- AUTO_INCREMENT voor geëxporteerde tabellen
--

--
-- AUTO_INCREMENT voor een tabel `messages`
--
ALTER TABLE `messages`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=15;

--
-- AUTO_INCREMENT voor een tabel `requests`
--
ALTER TABLE `requests`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT voor een tabel `users`
--
ALTER TABLE `users`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=41;

--
-- Beperkingen voor geëxporteerde tabellen
--

--
-- Beperkingen voor tabel `requests`
--
ALTER TABLE `requests`
  ADD CONSTRAINT `requests_ibfk_1` FOREIGN KEY (`sender_id`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `requests_ibfk_2` FOREIGN KEY (`receiver_id`) REFERENCES `users` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
