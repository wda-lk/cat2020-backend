CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230080548_First') THEN

    ALTER DATABASE CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230080548_First') THEN

    CREATE TABLE `u_previledges` (
        `up_id` int NOT NULL AUTO_INCREMENT,
        `up_name_sinhala` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `up_name_english` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `up_name_tamil` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `up_status` int NULL,
        `up_office_id` int NULL,
        `up_sabha_id` int NULL,
        `up_description` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        CONSTRAINT `PRIMARY` PRIMARY KEY (`up_id`)
    ) CHARACTER SET=utf8mb3 COLLATE=utf8mb3_general_ci;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230080548_First') THEN

    CREATE TABLE `user_details` (
        `ud_id` int NOT NULL AUTO_INCREMENT,
        `ud_name_in_full` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `ud_name_with_initials` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `ud_username` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `ud_password` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `ud_nic` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `ud_contact_no` int NULL,
        `ud_birthday` datetime(6) NULL,
        `ud_sabha_id` int NULL,
        `ud_office_id` int NULL,
        `ud_active_status` int NULL,
        `ud_gender_id` int NULL COMMENT 'control db fk',
        `ud_profile_pic_path` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `ud_q1_id` int NULL,
        `ud_answer1` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `ud_q2_id` int NULL,
        `ud_answer2` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        CONSTRAINT `PRIMARY` PRIMARY KEY (`ud_id`)
    ) CHARACTER SET=utf8mb3 COLLATE=utf8mb3_general_ci;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230080548_First') THEN

    CREATE TABLE `user_recover_questions` (
        `user_recover_questions_id` int NOT NULL,
        `user_recover_questions` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        CONSTRAINT `PK_user_recover_questions` PRIMARY KEY (`user_recover_questions_id`)
    ) CHARACTER SET=utf8mb3 COLLATE=utf8mb3_general_ci;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230080548_First') THEN

    CREATE TABLE `user_has_previledges` (
        `uhp_id` int NOT NULL AUTO_INCREMENT,
        `uhp_user_det_id` int NOT NULL,
        `uhp_user_priv_id` int NOT NULL,
        `uhp_status` int NULL,
        `uhp_sabha_id` int NULL,
        CONSTRAINT `PRIMARY` PRIMARY KEY (`uhp_id`),
        CONSTRAINT `fk_uhp_user_det_id` FOREIGN KEY (`uhp_user_det_id`) REFERENCES `user_details` (`ud_id`) ON DELETE CASCADE,
        CONSTRAINT `fk_uhp_user_priv_id` FOREIGN KEY (`uhp_user_priv_id`) REFERENCES `u_previledges` (`up_id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb3 COLLATE=utf8mb3_general_ci;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230080548_First') THEN

    CREATE INDEX `fk_uhp_user_det_id` ON `user_has_previledges` (`uhp_user_det_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230080548_First') THEN

    CREATE INDEX `fk_uhp_user_priv_id` ON `user_has_previledges` (`uhp_user_priv_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230080548_First') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20221230080548_First', '6.0.10');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

START TRANSACTION;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230131341_FirstMig') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20221230131341_FirstMig', '6.0.10');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

