-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Gegenereerd op: 21 feb 2023 om 13:11
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
-- Tabelstructuur voor tabel `chats`
--

CREATE TABLE `chats` (
  `id` int(255) NOT NULL,
  `user1_id` int(255) NOT NULL,
  `user2_id` int(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `messages`
--

CREATE TABLE `messages` (
  `id` int(255) NOT NULL,
  `chatid` int(255) NOT NULL,
  `senduser_id` int(255) NOT NULL,
  `message` varchar(1000) NOT NULL,
  `receiveuser_id` int(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Tabelstructuur voor tabel `requests`
--

CREATE TABLE `requests` (
  `id` int(255) NOT NULL,
  `requestinguser_id` int(255) NOT NULL,
  `user_id` int(255) NOT NULL,
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
(1, 'Robin', 'qwerty', 'robin2', NULL, 1),
(2, 'test1', '1', 'test123', NULL, 1),
(3, 'test2', '2', 'test123456\r\n                                           ', NULL, 1),
(4, 'Robin2', 'adsfasdfsadf', 'asdgdas', NULL, 1),
(5, 'Test', 'password', 'kerstman', NULL, 1),
(16, 'Piet', '734442E33D8EFF4B48B62D603966BDB5', 'Piet', NULL, 1),
(18, 'Egnwfn', 'D25AEE4702BC86C9EBDE8C220D5E25B9', 'Megnegnsfn', NULL, 1),
(19, 'Sh d', '0246C0F814B8113F42299CF2F804DFB7', 'Rhmrhn.t', NULL, 1);

--
-- Indexen voor geëxporteerde tabellen
--

--
-- Indexen voor tabel `chats`
--
ALTER TABLE `chats`
  ADD PRIMARY KEY (`id`),
  ADD KEY `user1_id` (`user1_id`),
  ADD KEY `user2_id` (`user2_id`);

--
-- Indexen voor tabel `messages`
--
ALTER TABLE `messages`
  ADD PRIMARY KEY (`id`),
  ADD KEY `senduser_id` (`senduser_id`),
  ADD KEY `receiveuser_id` (`receiveuser_id`),
  ADD KEY `chatid` (`chatid`);

--
-- Indexen voor tabel `requests`
--
ALTER TABLE `requests`
  ADD PRIMARY KEY (`id`),
  ADD KEY `requestinguser_id` (`requestinguser_id`),
  ADD KEY `user_id` (`user_id`);

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
-- AUTO_INCREMENT voor een tabel `chats`
--
ALTER TABLE `chats`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT voor een tabel `messages`
--
ALTER TABLE `messages`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT voor een tabel `requests`
--
ALTER TABLE `requests`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT voor een tabel `users`
--
ALTER TABLE `users`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=20;

--
-- Beperkingen voor geëxporteerde tabellen
--

--
-- Beperkingen voor tabel `chats`
--
ALTER TABLE `chats`
  ADD CONSTRAINT `chats_ibfk_1` FOREIGN KEY (`user1_id`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `chats_ibfk_2` FOREIGN KEY (`user2_id`) REFERENCES `users` (`id`);

--
-- Beperkingen voor tabel `messages`
--
ALTER TABLE `messages`
  ADD CONSTRAINT `messages_ibfk_1` FOREIGN KEY (`chatid`) REFERENCES `chats` (`id`),
  ADD CONSTRAINT `messages_ibfk_2` FOREIGN KEY (`senduser_id`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `messages_ibfk_3` FOREIGN KEY (`receiveuser_id`) REFERENCES `users` (`id`);

--
-- Beperkingen voor tabel `requests`
--
ALTER TABLE `requests`
  ADD CONSTRAINT `requests_ibfk_1` FOREIGN KEY (`requestinguser_id`) REFERENCES `users` (`id`),
  ADD CONSTRAINT `requests_ibfk_2` FOREIGN KEY (`user_id`) REFERENCES `users` (`id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
