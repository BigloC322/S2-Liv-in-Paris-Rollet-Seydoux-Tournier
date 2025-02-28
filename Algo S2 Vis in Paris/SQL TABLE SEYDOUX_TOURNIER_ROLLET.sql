DROP DATABASE IF EXISTS LIVIP;
CREATE DATABASE IF NOT EXISTS LIVIP;
USE LIVIP;

CREATE TABLE Utilisateur(
   ID_Utilisatieur VARCHAR(50),
   Nom_ VARCHAR(50),
   Prénom VARCHAR(50),
   Adresse VARCHAR(50),
   Téléphone VARCHAR(50),
   Adresse_email VARCHAR(50),
   Pseudo VARCHAR(50),
   Mot_de_passe_ VARCHAR(50),
   Préférence_alimentaire VARCHAR(50),
   Station_de_métro VARCHAR(50),
   PRIMARY KEY(ID_Utilisatieur)
);

CREATE TABLE Cusinier(
   ID_Cuisinier VARCHAR(50),
   ID_Utilisatieur VARCHAR(50) NOT NULL,
   PRIMARY KEY(ID_Cuisinier),
   UNIQUE(ID_Utilisatieur),
   FOREIGN KEY(ID_Utilisatieur) REFERENCES Utilisateur(ID_Utilisatieur)
);

CREATE TABLE Entreprise(
   ID_Entreprise VARCHAR(50),
   Nom VARCHAR(50),
   Nom_Référent VARCHAR(50),
   PRIMARY KEY(ID_Entreprise)
);

CREATE TABLE Ingrédient(
   ID_Ingredient VARCHAR(50),
   Régime_alimentaire_ VARCHAR(50),
   Ingrédients_ VARCHAR(50),
   PRIMARY KEY(ID_Ingredient)
);

CREATE TABLE Client(
   ID_Particulier VARCHAR(50),
   ID_Entreprise VARCHAR(50),
   ID_Utilisatieur VARCHAR(50) NOT NULL,
   PRIMARY KEY(ID_Particulier),
   UNIQUE(ID_Utilisatieur),
   FOREIGN KEY(ID_Entreprise) REFERENCES Entreprise(ID_Entreprise),
   FOREIGN KEY(ID_Utilisatieur) REFERENCES Utilisateur(ID_Utilisatieur)
);

CREATE TABLE Commande(
   ID_Commande VARCHAR(50),
   Date_Commande VARCHAR(50),
   Date_Livraison VARCHAR(50),
   Adresse_de_la_cuisine VARCHAR(50),
   Prix_Total VARCHAR(50),
   Adresse_de_livraison VARCHAR(50),
   Statut VARCHAR(50),
   ID_Cuisinier VARCHAR(50) NOT NULL,
   ID_Particulier VARCHAR(50) NOT NULL,
   PRIMARY KEY(ID_Commande),
   FOREIGN KEY(ID_Cuisinier) REFERENCES Cusinier(ID_Cuisinier),
   FOREIGN KEY(ID_Particulier) REFERENCES Client(ID_Particulier)
);

CREATE TABLE Avis(
   ID_Avis VARCHAR(50),
   Note INT,
   Commentaire VARCHAR(200),
   ID_Commande VARCHAR(50) NOT NULL,
   ID_Particulier VARCHAR(50) NOT NULL,
   PRIMARY KEY(ID_Avis),
   FOREIGN KEY(ID_Commande) REFERENCES Commande(ID_Commande),
   FOREIGN KEY(ID_Particulier) REFERENCES Client(ID_Particulier)
);

CREATE TABLE Plat(
   ID_Plat VARCHAR(50),
   Nom_du_plat_ VARCHAR(50),
   Type_ VARCHAR(50),
   Nombre_de_portion VARCHAR(50),
   Date_de_fabrication VARCHAR(50),
   Date_de_péremption VARCHAR(50),
   Prix_Unitaire VARCHAR(50),
   Nationalité VARCHAR(50),
   Photo VARCHAR(50),
   ID_Commande VARCHAR(50) NOT NULL,
   PRIMARY KEY(ID_Plat),
   FOREIGN KEY(ID_Commande) REFERENCES Commande(ID_Commande)
);

CREATE TABLE Contient(
   ID_Plat VARCHAR(50),
   ID_Ingredient VARCHAR(50),
   PRIMARY KEY(ID_Plat, ID_Ingredient),
   FOREIGN KEY(ID_Plat) REFERENCES Plat(ID_Plat),
   FOREIGN KEY(ID_Ingredient) REFERENCES Ingrédient(ID_Ingredient)
);
