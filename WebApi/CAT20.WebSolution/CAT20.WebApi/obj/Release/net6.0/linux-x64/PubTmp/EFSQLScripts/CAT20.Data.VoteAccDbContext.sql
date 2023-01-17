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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230074851_First') THEN

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230074851_First') THEN

    CREATE TABLE `account_details` (
        `acc_d_id` int NOT NULL AUTO_INCREMENT,
        `acc_d_acc_no` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `acc_d_name_sinhala` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `acc_d_name_english` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `acc_d_name_tamil` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `acc_d_bank_id` int NULL COMMENT 'control db fk',
        `acc_d_status` int NULL,
        `acc_d_office_id` int NULL,
        CONSTRAINT `PRIMARY` PRIMARY KEY (`acc_d_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230074851_First') THEN

    CREATE TABLE `vt_balancesheet_balance` (
        `vt_balancesheet_bal_id` int NOT NULL AUTO_INCREMENT,
        `vt_balancesheet_bal_vote_id` int NOT NULL,
        `vt_balancesheet_bal_year` int NULL,
        `vt_balancesheet_bal_balance` double NOT NULL,
        `vt_balancesheet_bal_comment` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_balancesheet_bal_enter_date` datetime(6) NULL,
        `vt_balancesheet_bal_sabha_id` int NOT NULL,
        `vt_balancesheet_bal_status` int NULL,
        CONSTRAINT `PRIMARY` PRIMARY KEY (`vt_balancesheet_bal_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230074851_First') THEN

    CREATE TABLE `vt_balsheet_title` (
        `vt_balsheet_title_id` int NOT NULL AUTO_INCREMENT,
        `vt_balsheet_title_name_sinhala` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_balsheet_title_name_english` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_balsheet_title_name_tamil` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_balsheet_title_code` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_balsheet_title_balpath` int NULL,
        `vt_balsheet_title_status` int NULL,
        `vt_balsheet_title_sabha_id` int NULL,
        CONSTRAINT `PK_vt_balsheet_title` PRIMARY KEY (`vt_balsheet_title_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230074851_First') THEN

    CREATE TABLE `vt_inc_vote_allocation` (
        `vt_inc_vote_allocation_id` int NOT NULL AUTO_INCREMENT,
        `vt_inc_vote_allocation_vote_id` int NULL,
        `vt_inc_vote_allocation_allocation_amount` double NULL,
        `vt_inc_vote_allocation_inc_amount` double NULL,
        `vt_inc_vote_allocation_create_date` datetime(6) NULL,
        `vt_inc_vote_allocation_year` int NULL,
        `vt_inc_vote_allocation_status` int NULL,
        `vt_inc_vote_allocation_sabha_id` int NULL,
        CONSTRAINT `PK_vt_inc_vote_allocation` PRIMARY KEY (`vt_inc_vote_allocation_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230074851_First') THEN

    CREATE TABLE `vt_programme` (
        `vt_programme_id` int NOT NULL AUTO_INCREMENT,
        `vt_programme_name_sinhala` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_programme_name_english` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `vt_programme_name_tamil` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `vt_programme_code` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `vt_programme_status` int NULL,
        `vt_programme_sabha_id` int NULL,
        CONSTRAINT `PK_vt_programme` PRIMARY KEY (`vt_programme_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230074851_First') THEN

    CREATE TABLE `vt_vote_details` (
        `vt_d_id` int NOT NULL,
        `vt_d_vote_code` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_vote_name_sinhala` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_vote_name_english` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_vote_name_tamil` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_vote_order` int NULL,
        `vt_d_programme_id` int NULL,
        `vt_d_programme_name_sinhala` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_programme_name_english` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_programme_name_tamil` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `ProgrammeCode` longtext CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_project_id` int NULL,
        `vt_d_project_name_sinhala` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_project_name_english` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_project_name_tamil` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_project_code` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_subproject_id` int NULL,
        `vt_d_subproject_name_sinhala` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_subproject_name_english` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_subproject_name_tamil` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_subproject_code` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_title_id` int NULL,
        `vt_d_title_name_sinhala` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_title_name_english` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_title_name_tamil` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_title_code` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_subtitle_id` int NOT NULL,
        `vt_d_subtitle_name_sinhala` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_subtitle_name_english` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_subtitle_name_tamil` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_subtitle_code` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_income_or_expense` int NULL,
        `vt_d_vote_or_bal` int NULL,
        `vt_d_sabha_id` int NULL,
        `vt_d_sabha_code` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_d_status` int NULL,
        `vt_d_balancesheet_title_id` int NULL,
        `vt_d_balancesheet_subtitle_id` int NULL,
        CONSTRAINT `PRIMARY` PRIMARY KEY (`vt_d_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230074851_First') THEN

    CREATE TABLE `account_bal_details` (
        `acc_bd_id` int NOT NULL AUTO_INCREMENT,
        `acc_bd_acc_d_id` int NOT NULL,
        `acc_bd_year` int NULL,
        `acc_bd_bal_amount` double NOT NULL,
        `acc_bd_enter_date` datetime(6) NULL,
        `acc_bd_status` int NOT NULL,
        `acc_sabha_id` int NOT NULL,
        CONSTRAINT `PRIMARY` PRIMARY KEY (`acc_bd_id`),
        CONSTRAINT `fk_acc_bd_acc_d_id` FOREIGN KEY (`acc_bd_acc_d_id`) REFERENCES `account_details` (`acc_d_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230074851_First') THEN

    CREATE TABLE `vt_balsheet_subtitle` (
        `vt_balsheet_subtitle_id` int NOT NULL AUTO_INCREMENT,
        `vt_balsheet_subtitle_name_sinhala` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_balsheet_subtitle_name_english` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_balsheet_subtitle_name_tamil` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_balsheet_subtitle_code` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_balsheet_subtitle_title_id` int NULL,
        `vt_balsheet_subtitle_status` int NULL,
        `vt_balsheet_subtitle_sabha_id` int NULL,
        CONSTRAINT `PK_vt_balsheet_subtitle` PRIMARY KEY (`vt_balsheet_subtitle_id`),
        CONSTRAINT `fk_vt_balsheet_subtitle_title_id` FOREIGN KEY (`vt_balsheet_subtitle_title_id`) REFERENCES `vt_balsheet_title` (`vt_balsheet_title_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230074851_First') THEN

    CREATE TABLE `vt_inc_project` (
        `vt_inc_project_id` int NOT NULL AUTO_INCREMENT,
        `vt_inc_project_sinhala` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `vt_inc_project_english` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `vt_inc_project_tamil` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `vt_inc_project_code` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `vt_inc_project_status` int NULL,
        `vt_inc_project_programme_id` int NULL,
        `vt_inc_project_sabha_id` int NULL,
        CONSTRAINT `PK_vt_inc_project` PRIMARY KEY (`vt_inc_project_id`),
        CONSTRAINT `fk_vt_inc_project_programme_id` FOREIGN KEY (`vt_inc_project_programme_id`) REFERENCES `vt_programme` (`vt_programme_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230074851_First') THEN

    CREATE TABLE `vt_inc_title` (
        `vt_inc_title_id` int NOT NULL AUTO_INCREMENT,
        `vt_inc_title_name_sinhala` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `vt_inc_title_name_english` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `vt_inc_title_name_tamil` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `vt_inc_title_name_code` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL,
        `vt_inc_title_status` int NULL,
        `vt_inc_title_programme_id` int NULL,
        `vt_inc_title_sabha_id` int NULL,
        CONSTRAINT `PK_vt_inc_title` PRIMARY KEY (`vt_inc_title_id`),
        CONSTRAINT `fk_vt_inc_title_name_programme_id` FOREIGN KEY (`vt_inc_title_programme_id`) REFERENCES `vt_programme` (`vt_programme_id`)
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230074851_First') THEN

    CREATE TABLE `vt_inc_sub_project` (
        `vt_inc_sub_project_id` int NOT NULL AUTO_INCREMENT,
        `vt_inc_sub_project_name_sinhala` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_inc_sub_project_name_english` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_inc_sub_project_name_tamil` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_inc_sub_project_name_code` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_inc_sub_project_status` int NULL,
        `vt_inc_sub_project_project_id` int NOT NULL,
        `vt_inc_sub_project_sabha_id` int NULL,
        `vt_inc_sub_project_programme_id` int NULL,
        CONSTRAINT `PK_vt_inc_sub_project` PRIMARY KEY (`vt_inc_sub_project_id`),
        CONSTRAINT `fk_vt_inc_sub_project_project_id` FOREIGN KEY (`vt_inc_sub_project_project_id`) REFERENCES `vt_inc_project` (`vt_inc_project_id`) ON DELETE CASCADE
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230074851_First') THEN

    CREATE TABLE `vt_inc_subtitle` (
        `vt_inc_subtitle_id` int NOT NULL AUTO_INCREMENT,
        `vt_inc_subtitle_name_sinhala` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_inc_subtitle_name_english` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_inc_subtitle_name_tamil` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_inc_subtitle_name_code` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
        `vt_inc_subtitle_title_id` int NOT NULL,
        `vt_inc_subtitle_status` int NULL,
        `vt_inc_subtitle_sabha_id` int NULL,
        `vt_inc_subtitle_programme_id` int NULL,
        CONSTRAINT `PK_vt_inc_subtitle` PRIMARY KEY (`vt_inc_subtitle_id`),
        CONSTRAINT `fk_vt_inc_subtitle_title_id` FOREIGN KEY (`vt_inc_subtitle_title_id`) REFERENCES `vt_inc_title` (`vt_inc_title_id`) ON DELETE CASCADE
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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230074851_First') THEN

    CREATE INDEX `fk_acc_bd_acc_d_id` ON `account_bal_details` (`acc_bd_acc_d_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230074851_First') THEN

    CREATE INDEX `fk_vt_balsheet_subtitle_title_id` ON `vt_balsheet_subtitle` (`vt_balsheet_subtitle_title_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230074851_First') THEN

    CREATE INDEX `fk_vt_inc_project_programme_id` ON `vt_inc_project` (`vt_inc_project_programme_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230074851_First') THEN

    CREATE INDEX `fk_vt_inc_sub_project_project_id` ON `vt_inc_sub_project` (`vt_inc_sub_project_project_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230074851_First') THEN

    CREATE INDEX `fk_vt_inc_subtitle_title_id` ON `vt_inc_subtitle` (`vt_inc_subtitle_title_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230074851_First') THEN

    CREATE INDEX `fk_vt_inc_title_name_programme_id` ON `vt_inc_title` (`vt_inc_title_programme_id`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230074851_First') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20221230074851_First', '6.0.10');

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
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20221230131051_FirstMig') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20221230131051_FirstMig', '6.0.10');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

