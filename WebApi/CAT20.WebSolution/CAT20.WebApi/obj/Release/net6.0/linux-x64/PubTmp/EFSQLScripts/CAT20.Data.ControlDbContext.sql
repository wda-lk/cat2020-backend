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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230075025_First') THEN

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230075025_First') THEN

    CREATE TABLE `cd_app_category` (
        `cd_app_cat_id` int NOT NULL AUTO_INCREMENT,
        `cd_app_cat_name` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cd_app_cat_status` int NULL,
        CONSTRAINT `PRIMARY` PRIMARY KEY (`cd_app_cat_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230075025_First') THEN

    CREATE TABLE `cd_bank_details` (
        `cd_bd_id` int NOT NULL AUTO_INCREMENT,
        `cd_bd_name` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cd_bd_status` int NULL,
        CONSTRAINT `PRIMARY` PRIMARY KEY (`cd_bd_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230075025_First') THEN

    CREATE TABLE `cd_gender` (
        `cd_gender_id` int NOT NULL AUTO_INCREMENT,
        `cd_gender` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cd_status` int NULL,
        CONSTRAINT `PK_cd_gender` PRIMARY KEY (`cd_gender_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230075025_First') THEN

    CREATE TABLE `cd_languages` (
        `cd_languages_id` int NOT NULL,
        `cd_languages_name` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cd_language_status` int NULL,
        CONSTRAINT `PK_cd_languages` PRIMARY KEY (`cd_languages_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230075025_First') THEN

    CREATE TABLE `cd_month` (
        `cd_month_id` int NOT NULL,
        `cd_month` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        CONSTRAINT `PK_cd_month` PRIMARY KEY (`cd_month_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230075025_First') THEN

    CREATE TABLE `cd_office_type` (
        `cd_ot_id` int NOT NULL AUTO_INCREMENT,
        `cd_ot_name` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cd_ot_status` int NULL,
        CONSTRAINT `PRIMARY` PRIMARY KEY (`cd_ot_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230075025_First') THEN

    CREATE TABLE `cd_province` (
        `cd_p_id` int NOT NULL AUTO_INCREMENT,
        `cd_p_name_sinhala` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cd_p_name_english` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cd_p_name_tamil` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cd_p_status` int NULL,
        CONSTRAINT `PRIMARY` PRIMARY KEY (`cd_p_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230075025_First') THEN

    CREATE TABLE `cd_selected_languages` (
        `cd_selected_languages_id` int NOT NULL AUTO_INCREMENT,
        `cd_selected_languages_lang_id` int NULL,
        `cd_selected_languages_sabha_id` int NULL,
        `cd_selected_languages_status` int NULL,
        CONSTRAINT `PK_cd_selected_languages` PRIMARY KEY (`cd_selected_languages_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230075025_First') THEN

    CREATE TABLE `cd_year` (
        `cd_year_id` int NOT NULL,
        `cd_year` int NOT NULL,
        CONSTRAINT `PK_cd_year` PRIMARY KEY (`cd_year_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230075025_First') THEN

    CREATE TABLE `cdb_customer_types` (
        `cdb_cus_type_id` int NOT NULL AUTO_INCREMENT,
        `cdb_cus_type_name_in_sinhala` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cdb_cus_type_name_in_english` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cdb_cus_type_name_in_tamil` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cdb_cus_type_status` int NULL,
        CONSTRAINT `PRIMARY` PRIMARY KEY (`cdb_cus_type_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230075025_First') THEN

    CREATE TABLE `cd_district` (
        `cd_d_id` int NOT NULL AUTO_INCREMENT,
        `cd_d_cd_p_id` int NOT NULL,
        `cd_d_name_sinhala` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cd_d_name_english` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cd_d_name_tamil` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cd_d_status` int NULL,
        CONSTRAINT `PRIMARY` PRIMARY KEY (`cd_d_id`),
        CONSTRAINT `fk_cd_d_cd_p_id` FOREIGN KEY (`cd_d_cd_p_id`) REFERENCES `cd_province` (`cd_p_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230075025_First') THEN

    CREATE TABLE `cd_sabha` (
        `cd_s_id` int NOT NULL AUTO_INCREMENT,
        `cd_s_cd_d_id` int NULL,
        `cd_s_name_sinhala` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cd_s_name_english` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cd_s_name_tamil` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cd_s_code` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cd_s_logo_path` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cd_s_status` int NULL,
        `cd_s_create_date` datetime(6) NULL,
        `cd_s_tp_no1` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cd_s_tp_no2` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cd_s_address_sinhala` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cd_s_address_english` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cd_s_address_tamil` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        CONSTRAINT `PRIMARY` PRIMARY KEY (`cd_s_id`),
        CONSTRAINT `fk_cd_s_cd_d_id` FOREIGN KEY (`cd_s_cd_d_id`) REFERENCES `cd_district` (`cd_d_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230075025_First') THEN

    CREATE TABLE `cd_office` (
        `cd_o_id` int NOT NULL AUTO_INCREMENT,
        `cd_o_cd_s_id` int NULL,
        `cd_o_name_sinhala` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cd_o_name_english` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cd_o_name_tamil` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `cd_o_office_type_id` int NULL,
        `cd_o_status` int NULL,
        `cd_o_create_date` datetime(6) NULL,
        CONSTRAINT `PRIMARY` PRIMARY KEY (`cd_o_id`),
        CONSTRAINT `fk_cd_o_cd_s_id` FOREIGN KEY (`cd_o_cd_s_id`) REFERENCES `cd_sabha` (`cd_s_id`),
        CONSTRAINT `fk_cd_o_office_type_id` FOREIGN KEY (`cd_o_office_type_id`) REFERENCES `cd_office_type` (`cd_ot_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230075025_First') THEN

    CREATE INDEX `fk_cd_d_cd_p_id` ON `cd_district` (`cd_d_cd_p_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230075025_First') THEN

    CREATE INDEX `fk_cd_o_cd_s_id` ON `cd_office` (`cd_o_cd_s_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230075025_First') THEN

    CREATE INDEX `fk_cd_o_office_type_id` ON `cd_office` (`cd_o_office_type_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230075025_First') THEN

    CREATE INDEX `fk_cd_s_cd_d_id` ON `cd_sabha` (`cd_s_cd_d_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230075025_First') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20221230075025_First', '6.0.10');

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230131207_FirstMig') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20221230131207_FirstMig', '6.0.10');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

