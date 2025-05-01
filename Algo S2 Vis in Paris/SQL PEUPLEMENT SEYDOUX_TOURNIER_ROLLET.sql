-- Peuplement de la table Utilisateur
INSERT INTO Utilisateur VALUES
('U1', 'Dupont', 'Jean', '12 Rue A', '0601010101', 'jean.dupont@email.com', 'JeanDup', 'root', 'Végétarien', 'Bastille'),
('U2', 'Martin', 'Sophie', '34 Rue B', '0602020202', 'sophie.martin@email.com', 'SophieM', 'root', 'Sans gluten', 'Châtelet'),
('U3', 'Durand', 'Paul', '56 Rue C', '0603030303', 'paul.durand@email.com', 'PaulD', 'root', 'Halal', 'République'),
('U4', 'Bernard', 'Emma', '78 Rue D', '0604040404', 'emma.bernard@email.com', 'EmmaB', 'root', 'Casher', 'Mabillon'),
('U5', 'Thomas', 'Lucas', '90 Rue E', '0605050505', 'lucas.thomas@email.com', 'LucasT', 'root', 'Végan', 'Nation');

-- Peuplement de la table Cusinier
INSERT INTO Cuisinier VALUES
('C1', 'U1'),
('C2', 'U2');

-- Peuplement de la table Entreprise
INSERT INTO Entreprise VALUES
('E1', 'TechCorp', 'Alice Dupont', 20),
('E2', 'Foodies', 'Bernard Martin', 15),
('E3', 'GreenEat', 'Claire Thomas', 80),
('E4', 'BioMarket', 'David Lambert', 40),
('E5', 'VitaLife', 'Eve Moreau', 25);

-- Peuplement de la table Ingrédient
INSERT INTO Ingrédient VALUES
('I1', 'Végétarien', 'Tomate'),
('I2', 'Sans gluten', 'Riz'),
('I3', 'Halal', 'Poulet'),
('I4', 'Casher', 'Saumon'),
('I5', 'Végan', 'Tofu');

-- Peuplement de la table Client
INSERT INTO Client VALUES
('P3', 'E3', 'U3'),
('P4', 'E4', 'U4'),
('P5', 'E5', 'U5');

-- Peuplement de la table Commande
INSERT INTO Commande VALUES
('CO1', '2025-02-01', '2025-02-02', 'Bastille', '20.50', 'Châtelet', 'Livrée', 'C1', 'P3'),
('CO2', '2025-02-03', '2025-02-04', 'Châtelet', '30.00', 'République', 'En cours', 'C2', 'P4');

-- Peuplement de la table Plat
INSERT INTO REPAS VALUES
('PL1', 'Butter Chicken', 'Plat', '1', CURDATE(), CURDATE() + INTERVAL 2 DAY, '15.90', 'Indienne', 'Butter Chicken.jpg', 'CO1'),
('PL2', 'Burger', 'Plat', '2', CURDATE(), CURDATE() + INTERVAL 2 DAY, '11.20', 'Américaine', 'Burger.jpg', 'CO2'),
('PL3', 'Club Sandwich', 'Plat', '3', CURDATE(), CURDATE() + INTERVAL 4 DAY, '12.70', 'Classique', 'Club Sandwich.jpg', 'CO2'),
('PL4', 'Curry vert', 'Plat', '1', CURDATE(), CURDATE() + INTERVAL 2 DAY, '13.50', 'Thaï', 'Curry vert.jpg', 'CO1'),
('PL5', 'Pâtes au pesto', 'Plat', '2', CURDATE(), CURDATE() + INTERVAL 3 DAY, '12.00', 'Italienne', 'Pâtes au pesto.jpg', 'CO1'),
('PL6', 'Pâtes aux truffes', 'Plat', '1', CURDATE(), CURDATE() + INTERVAL 3 DAY, '18.00', 'Italienne', 'Pâtes aux truffes.jpg', 'CO1'),
('PL7', 'Pavé de saumon', 'Plat', '1', CURDATE(), CURDATE(), '21.50', 'Française', 'Pavé de saumon.jpg', 'CO2'),
('PL8', 'Pizza Pepperoni', 'Plat', '4', CURDATE(), CURDATE() + INTERVAL 7 DAY, '10.50', 'Italienne', 'Pizza Pepperoni.jpg', 'CO1'),
('PL9', 'Salade César', 'Entrée', '2', CURDATE(), CURDATE() + INTERVAL 1 DAY, '10.50', 'Classique', 'Salade César.jpg', 'CO1'),
('PL10', 'Soupe oignons', 'Plat', '1', CURDATE(), CURDATE() + INTERVAL 1 DAY, '9.30', 'Française', 'Soupe aux oignons.jpg', 'CO2'),
('PL11', 'Steak Tartare', 'Plat', '2', CURDATE(), CURDATE(), '17.20', 'Française', 'Steak Tartare Frites.jpg', 'CO1'),
('PL12', 'Sushis', 'Plat', '3', CURDATE(), CURDATE() + INTERVAL 1 DAY, '17.50', 'Japonaise', 'Sushis.jpg', 'CO2'),
('PL13', 'Tacos', 'Plat', '2', CURDATE(), CURDATE() + INTERVAL 4 DAY, '11.50', 'Mexicaine', 'Tacos.jpg', 'CO2'),
('PL14', 'Kebab', 'Plat', '2', CURDATE(), CURDATE() + INTERVAL 4 DAY, '8.50', 'Turque', 'Kebab.jpg', 'CO2'),
('PL15', 'Moelleux', 'Dessert', '1', CURDATE(), CURDATE() + INTERVAL 1 DAY, '7.00', 'Classique', 'Moelleux.jpg', 'CO1'),
('PL16', 'Caviar 30g', 'Entrée', '1', CURDATE(), CURDATE(), '64.00', 'Russe', 'Caviar.jpg', 'CO1'),
('PL17', 'Homard', 'Plat', '1', CURDATE(), CURDATE(), '55.00', 'Américaine', 'Homard.jpg', 'CO2'),
('PL18', 'Crêpes', 'Dessert', '1', CURDATE(), CURDATE() + INTERVAL 2 DAY, '9.50', 'Américaine', 'Crêpes.jpg', 'CO1'),
('PL19', 'Makis thon rouge', 'Entrée', '1', CURDATE(), CURDATE(), '14.00', 'Japonaise', 'Makis thon rouge.jpg', 'CO1'),
('PL20', 'Cabillaud beurre blanc', 'Plat', '1', CURDATE(), CURDATE() + INTERVAL 1 DAY, '22.00', 'Française', 'Cabillaud.jpg', 'CO1'),
('PL21', 'Côte de boeuf', 'Plat', '1', CURDATE(), CURDATE() + INTERVAL 1 DAY, '23.00', 'Française', 'Côte de boeuf.jpg', 'CO1'),
('PL22', 'Tataki de thon', 'Plat', '1', CURDATE(), CURDATE() + INTERVAL 1 DAY, '17.00', 'Japonaise', 'Tataki de thon.jpg', 'CO1'),
('PL23', 'Chili con carne', 'Plat', '1', CURDATE(), CURDATE() + INTERVAL 3 DAY, '12.00', 'Mexicaine', 'Chili con carne.jpg', 'CO1'),
('PL24', 'Poulet coréen', 'Plat', '1', CURDATE(), CURDATE() + INTERVAL 1 DAY, '16.00', 'Coréenne', 'Poulet Corée.jpg', 'CO1'),
('PL25', 'Pizza Regina', 'Plat', '1', CURDATE(), CURDATE() + INTERVAL 4 DAY, '13.50', 'Italienne', 'Regina.jpg', 'CO1'),
('PL26', 'Boeuf Wagyu', 'Plat', '1', CURDATE(), CURDATE() + INTERVAL 1 DAY, '140.00', 'Japonaise', 'Boeuf Wagyu.jpg', 'CO1'),
('PL27', 'Profiteroles', 'Dessert', '1', CURDATE(), CURDATE() + INTERVAL 1 DAY, '13.00', 'Française', 'Profiteroles.jpg', 'CO1'),
('PL28', 'Boeuf bourguignon', 'Plat', '1', CURDATE(), CURDATE() + INTERVAL 2 DAY, '19.00', 'Française', 'Boeuf bourguignon.jpg', 'CO1'),
('PL29', 'Tikka Masala', 'Plat', '1', CURDATE(), CURDATE() + INTERVAL 2 DAY, '17.50', 'Indienne', 'Tikka Masala.jpg', 'CO1'),
('PL30', 'Mozzarella et pesto', 'Entrée', '1', CURDATE(), CURDATE() + INTERVAL 1 DAY, '11.00', 'Italienne', 'Mozzarella et pesto.jpg', 'CO1'),
('PL31', 'Antipasti', 'Plat', '1', CURDATE(), CURDATE(), '14.00', 'Italienne', 'Antipasti.jpg', 'CO1'),
('PL32', 'Cookies', 'Dessert', '1', CURDATE(), CURDATE() + INTERVAL 2 DAY, '4.00', 'Américaine', 'Cookies.jpg', 'CO1'),
('PL33', 'Canard laqué', 'Plat', '1', CURDATE(), CURDATE() + INTERVAL 1 DAY, '17.50', 'Chinoise', 'Canard laqué.jpg', 'CO1');