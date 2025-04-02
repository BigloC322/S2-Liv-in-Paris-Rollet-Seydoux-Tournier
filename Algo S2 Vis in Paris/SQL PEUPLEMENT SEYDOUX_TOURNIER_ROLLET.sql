-- Peuplement de la table Utilisateur
INSERT INTO Utilisateur VALUES
('U1', 'Dupont', 'Jean', '12 Rue A', '0601010101', 'jean.dupont@email.com', 'jeandup', 'mdp123', 'Végétarien', 'Bastille'),
('U2', 'Martin', 'Sophie', '34 Rue B', '0602020202', 'sophie.martin@email.com', 'sophiem', 'mdp234', 'Sans gluten', 'Châtelet'),
('U3', 'Durand', 'Paul', '56 Rue C', '0603030303', 'paul.durand@email.com', 'pauld', 'mdp345', 'Halal', 'République'),
('U4', 'Bernard', 'Emma', '78 Rue D', '0604040404', 'emma.bernard@email.com', 'emmab', 'mdp456', 'Casher', 'Montparnasse'),
('U5', 'Thomas', 'Lucas', '90 Rue E', '0605050505', 'lucas.thomas@email.com', 'lucast', 'mdp567', 'Végan', 'Nation');

-- Peuplement de la table Cusinier
INSERT INTO Cuisinier VALUES
('C1', 'U1'),
('C2', 'U2'),
('C3', 'U3'),
('C4', 'U4'),
('C5', 'U5');

-- Peuplement de la table Entreprise
INSERT INTO Entreprise VALUES
('E1', 'TechCorp', 'Alice Dupont'),
('E2', 'Foodies', 'Bernard Martin'),
('E3', 'GreenEat', 'Claire Thomas'),
('E4', 'BioMarket', 'David Lambert'),
('E5', 'VitaLife', 'Eve Moreau');

-- Peuplement de la table Ingrédient
INSERT INTO Ingrédient VALUES
('I1', 'Végétarien', 'Tomate'),
('I2', 'Sans gluten', 'Riz'),
('I3', 'Halal', 'Poulet'),
('I4', 'Casher', 'Saumon'),
('I5', 'Végan', 'Tofu');

-- Peuplement de la table Client
INSERT INTO Client VALUES
('P1', 'E1', 'U1'),
('P2', 'E2', 'U2'),
('P3', 'E3', 'U3'),
('P4', 'E4', 'U4'),
('P5', 'E5', 'U5');

-- Peuplement de la table Commande
INSERT INTO Commande VALUES
('CO1', '2025-02-01', '2025-02-02', 'Bastille', '20.50', 'Châtelet', 'Livrée', 'C1', 'P1'),
('CO2', '2025-02-03', '2025-02-04', 'Châtelet', '30.00', 'République', 'En cours', 'C2', 'P2'),
('CO3', '2025-02-05', '2025-02-06', 'République', '25.75', 'Montparnasse', 'Préparée', 'C3', 'P3'),
('CO4', '2025-02-07', '2025-02-08', 'Montparnasse', '18.90', 'Nation', 'Annulée', 'C4', 'P4'),
('CO5', '2025-02-09', '2025-02-10', 'Nation', '22.30', 'Bastille', 'Livrée', 'C5', 'P5');

-- Peuplement de la table Avis
INSERT INTO Avis VALUES
('A1', 5, 'Excellent service', 'CO1', 'P1'),
('A2', 4, 'Très bon plat', 'CO2', 'P2'),
('A3', 3, 'Correct mais pourrait être amélioré', 'CO3', 'P3'),
('A4', 2, 'Moyen, manque de saveur', 'CO4', 'P4'),
('A5', 1, 'Mauvaise expérience', 'CO5', 'P5');

-- Peuplement de la table Plat
INSERT INTO REPAS VALUES
('PL1', 'Salade César', 'Entrée', '2', '2025-02-01', '2025-02-05', '10.50', 'Française', 'salade.jpg', 'CO1'),
('PL2', 'Poulet Tikka', 'Plat', '3', '2025-02-02', '2025-02-06', '12.00', 'Indienne', 'tikka.jpg', 'CO2'),
('PL3', 'Sushi', 'Plat', '4', '2025-02-03', '2025-02-07', '15.00', 'Japonaise', 'sushi.jpg', 'CO3'),
('PL4', 'Lasagnes', 'Plat', '2', '2025-02-04', '2025-02-08', '13.50', 'Italienne', 'lasagnes.jpg', 'CO4'),
('PL5', 'Falafel', 'Entrée', '5', '2025-02-05', '2025-02-09', '9.00', 'Moyen-Orient', 'falafel.jpg', 'CO5');

-- Peuplement de la table Contient
INSERT INTO Contient VALUES
('PL1', 'I1'),
('PL2', 'I3'),
('PL3', 'I4'),
('PL4', 'I2'),
('PL5', 'I5');