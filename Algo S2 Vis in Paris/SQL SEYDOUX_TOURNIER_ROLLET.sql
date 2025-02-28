SELECT U.Nom_, U.Prénom, C.ID_Cuisinier 
FROM Utilisateur U 
JOIN Cusinier C ON U.ID_Utilisatieur = C.ID_Utilisatieur;

SELECT Cl.ID_Particulier, E.Nom 
FROM Client Cl 
JOIN Entreprise E ON Cl.ID_Entreprise = E.ID_Entreprise;

SELECT Co.ID_Commande, P.Nom_du_plat_ 
FROM Commande Co 
JOIN Plat P ON Co.ID_Commande = P.ID_Commande;

SELECT A.ID_Avis, A.Note, U.Nom_ 
FROM Avis A 
JOIN Client Cl ON A.ID_Particulier = Cl.ID_Particulier 
JOIN Utilisateur U ON Cl.ID_Utilisatieur = U.ID_Utilisatieur;

