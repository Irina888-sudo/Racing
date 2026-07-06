CREATE DATABASE IF NOT EXISTS racing_db;
USE racing_db;

CREATE TABLE voitures (
    id INT AUTO_INCREMENT PRIMARY KEY,
    nom VARCHAR(50) NOT NULL UNIQUE,
    vitesse_max INT NOT NULL,
    acceleration DECIMAL(5,2) NOT NULL
);

CREATE TABLE resultats (
    id INT AUTO_INCREMENT PRIMARY KEY,
    voiture_id INT NOT NULL,
    temps_course TIME NOT NULL,
    vitesse_finale INT NOT NULL,
    temps_1ere_accel TIME,
    date_course DATETIME DEFAULT CURRENT_TIMESTAMP,
    FOREIGN KEY (voiture_id) REFERENCES voitures(id)
);

DELIMITER //                                                                                                                                                                                                                                                                                                            


CREATE PROCEDURE sp_InsertResultat(
    IN p_nom_voiture VARCHAR(50),
    IN p_temps_course TIME,
    IN p_vitesse_finale INT,
    IN p_temps_1ere_accel TIME
)
BEGIN
    -- ⭐ À CODER PAR MOI — sp_InsertResultat
    -- Durée estimée : 20-30 min
    -- TODO :
    -- 1. Récupérer l'id de la voiture à partir de p_nom_voiture
    -- 2. Insérer une ligne dans `resultats` avec cet id + les paramètres
END //

DELIMITER $$