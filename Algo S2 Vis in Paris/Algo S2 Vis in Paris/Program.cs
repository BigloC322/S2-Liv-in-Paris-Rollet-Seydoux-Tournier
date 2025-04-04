using System;
using System.Globalization;
using MySql.Data.MySqlClient;
using Mysqlx.Session;
using MySqlX.XDevAPI.Common;
using static System.Net.Mime.MediaTypeNames;

namespace Algo_S2_Vis_in_Paris
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Partie Code
            /*
           string cheminFichierMetro = @"metros.csv";
           string cheminFichierMetroCoord = @"MetroCoord.csv";
           string cheminPonderation = @"TempsEntreStation.txt";

           List<int> idStations = new List<int>();
           List<string> nomsStations = new List<string>();
           List<decimal[]> coord = new List<decimal[]>();
           Noeud stations = new Noeud(idStations, nomsStations, coord);
           stations.IdStations = stations.DéfinirIdSommets(cheminFichierMetro, idStations);
           stations.NomsStations = stations.DéfinirNomsStations(cheminFichierMetro, nomsStations);
           stations.Coord = stations.CoordStations(cheminFichierMetroCoord, stations.NomsStations, coord);

           List<int[]> liensStations = new List<int[]>();
           List<decimal> pondération = new List<decimal>();
           Lien Arcs = new Lien(liensStations, pondération);
           Arcs.LiensStations = Arcs.CréerLiens(cheminFichierMetro);
           List<int[]> liens = new List<int[]>();
           liens = Arcs.GestionStationsDoubles(stations.IdStations, stations.NomsStations, Arcs.LiensStations, cheminFichierMetro);
           Arcs.Pondération = Arcs.PondérerArcs(Arcs.LiensStations, cheminPonderation);
           Arcs.LiensStations = liens;

           int[,] matriceAdj = new int[stations.IdStations.Count, stations.IdStations.Count]; //forcément la matrice d'adjacence est de la dimension du nombre de sommets
           Dictionary<int, List<int>> listeAdj = new Dictionary<int, List<int>>();
           List<List<int>> listeDesChemins = new List<List<int>>();
           Graphe g = new Graphe(matriceAdj, listeAdj, listeDesChemins);

           g.GrapheMetro = g.CréationMatriceAdjacence(matriceAdj, Arcs.LiensStations); //avec matrice adj

           g.ListeAdj = g.CréationListeAdj(Arcs.LiensStations, listeAdj); //avec liste adj


               Console.WriteLine("\n");
               bool[] sommetmarqué = new bool[34];
               for (int i = 0; i < sommetmarqué.Length; i++)
               {
                   sommetmarqué[i] = false;
               }
               Random r = new Random();
               int s = r.Next(34);
               g.ParcoursEnLargueur(s, sommetmarqué, g.GrapheAsso);
               Console.WriteLine("\n");

               sommetmarqué = new bool[34];
               for (int i = 0; i < sommetmarqué.Length; i++)
               {
                   sommetmarqué[i] = false;
               }
               s = r.Next(34);
               g.ParcoursEnProfondeur(s, sommetmarqué, g.GrapheAsso);
               Console.WriteLine("\n");


               bool connexe = g.EstConnexe(g.GrapheAsso);
               if (connexe == true)
               {
                   Console.WriteLine("\nLe graphe est connexe.");
               }
               else
               {
                   Console.WriteLine("\nLe graphe n'est pas connexe.");
               }

               //g.Haversine(stations.Coord, stations.NomsStations);

               VisualisationGraphe graphismes = new VisualisationGraphe();
               graphismes.ReprésenterGraphe(g.GrapheMetro);

               MétrosGoogleMaps m = new MétrosGoogleMaps();
               m.AfficherMetrosGoogleMaps(stations.NomsStations, stations.Coord, g.GrapheMetro);

           */
            #endregion
            Console.WriteLine("================================================== ");
            Console.WriteLine("Bienvue sur l'interface Liv in Paris ");
            Console.WriteLine("================================================== ");
            Console.WriteLine("Avez vous déjà un compte ? \nTapez : \n1 : oui\n2 : non ");
            int n = Convert.ToInt32(Console.ReadLine());
            switch (n)
            {
                case 1:
                    Console.WriteLine("Connectez vous à votre compte, rentrez votre pseudo et votre mdp : ");
                    string pseudo = Console.ReadLine();
                    string mdp = Console.ReadLine();
                    Utilisateur.RechercherUtilisateur(pseudo, mdp);
                    
                    break;
                case 2:
                    Console.WriteLine("Rentrez les informations suivantes : nom, prénom, adresse, téléphone, email, pseudo, mot de passe, pref_alimentaire, station de métro ");
                    string nom = Console.ReadLine();
                    string prénom = Console.ReadLine();
                    string adresse = Console.ReadLine();
                    string téléphone = Console.ReadLine();
                    string adresse_email = Console.ReadLine();
                    string pseudoo = Console.ReadLine();
                    string mdpp = Console.ReadLine();
                    string pref_alimentaire = Console.ReadLine();
                    string station_de_métro = Console.ReadLine();
                    Utilisateur a = new Utilisateur(nom, prénom, adresse, téléphone, adresse_email, pseudoo, mdpp, pref_alimentaire, station_de_métro);
                    Utilisateur.AjouterUtilisateur(a);
                    Console.Clear();
                    Console.WriteLine("Bienvenue Mr" + nom);
                    break;
            }
            Console.WriteLine("Que voulez-vous faire : \n" + "1 - Module Client de l’interface\n" +"2 - Module Commande de l’interface\n" +"3 - Module Statistiques\n" +"4 - Module Autre");
            int m = Convert.ToInt32(Console.ReadLine());
            switch(m)
            {
                case 1:
                    Console.Clear();
                    Console.WriteLine("Bienvenuedans les fourneaux  vous êtes vous déjà connecté ? ");
                    Console.WriteLine("Nouvelle version de l'app dispo ! Allez voir la V2 ");
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("Bienvenue Gros Gourmand vous êtes vous déjà connecté ? ");
                    Console.WriteLine("Nouvelle version de l'app dispo ! Allez voir la V2 ");
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("Bienvenue dans le module de statistiques");
                    Console.WriteLine("Que voulez voir : \n0 : Afficher par cuisinier le nombre de livraisons effectuées\n1 : Afficher les commandes selon une période de temps\n2 : Afficher la moyenne des prix des commandes\n3 : Afficher la moyenne des comptes clients\n4 : Afficher la liste des commandes pour un client selon la nationalité des plats, la période ");
                    int o = Convert.ToInt32(Console.ReadLine());
                    switch (o)
                    {
                        case 0:
                            string cmd0 = $"SELECT C.ID_Cuisinier, COUNT(C.ID_Commande) AS Nombre_de_livraisons FROM Commande C GROUP BY C.ID_Cuisinier;";
                            ConnexionSQL a = new ConnexionSQL();
                            try
                            {
                                MySqlCommand command = a.MaConnexion.CreateCommand();
                                command.CommandText = cmd0;
                                command.ExecuteNonQuery();
                                using(MySqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        while (reader.Read())
                                        {
                                            string idCuisinier = reader["ID_Cuisinier"].ToString();
                                            int nombreLivraisons = Convert.ToInt32(reader["Nombre_de_livraisons"]);
                                            Console.WriteLine($"Cuisinier ID: {idCuisinier}, Nombre de livraisons: {nombreLivraisons}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Aucune donnée trouvée.");
                                    }
                                }
                            }
                            catch (MySqlException e)
                            {
                                Console.WriteLine("Erreur lors de la lecture : " + e.Message);
                            }
                            finally
                            {
                                a.MaConnexion.Close();
                                Console.WriteLine("Connexion fermée.");
                            }
                            break;
                        case 1:
                            Console.WriteLine("Rentrez la date de début et de fin sur lesquelles vous voulez étudier (pour rappel du format : AAAA-MM-DD)");
                            string datedébut = Console.ReadLine();
                            string datefin = Console.ReadLine();
                            string cmd1 = $"SELECT * FROM Commande WHERE Date_Commande BETWEEN '{datedébut}' AND '{datefin}';";
                            ConnexionSQL b = new ConnexionSQL();
                            try
                            {
                                MySqlCommand command = b.MaConnexion.CreateCommand();
                                command.CommandText = cmd1;
                                command.ExecuteNonQuery();
                                using (MySqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        while (reader.Read())
                                        {
                                            string idCommande = reader["ID_Commande"].ToString();
                                            string dateCommande = reader["Date_Commande"].ToString();
                                            string adresseLivraison = reader["Adresse_de_livraison"].ToString();
                                            Console.WriteLine($"Commande ID: {idCommande}, Date: {dateCommande}, Adresse de livraison: {adresseLivraison}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Aucune donnée trouvée.");
                                    }
                                }
                            }
                            catch (MySqlException e)
                            {
                                Console.WriteLine("Erreur lors de la lecture : " + e.Message);
                            }
                            finally
                            {
                                b.MaConnexion.Close();
                                Console.WriteLine("Connexion fermée.");
                            }
                            break;
                        case 2:
                            string cmd2 = $"SELECT AVG(CAST(Prix_Total AS DECIMAL(10, 2))) AS Moyenne_Prix_Commandes FROM Commande;";
                            ConnexionSQL c = new ConnexionSQL();
                            try
                            {
                                MySqlCommand command = c.MaConnexion.CreateCommand();
                                command.CommandText = cmd2;
                                object result = command.ExecuteScalar();
                                using (MySqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        while (reader.Read())
                                        {
                                            Console.WriteLine($"Moyenne des prix des commandes : {result}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Aucune donnée trouvée.");
                                    }
                                }
                            }
                            catch (MySqlException e)
                            {
                                Console.WriteLine("Erreur lors de la lecture : " + e.Message);
                            }
                            finally
                            {
                                c.MaConnexion.Close();
                                Console.WriteLine("Connexion fermée.");
                            }

                            break;
                        case 3:
                            string cmd3 = "$SELECT AVG(Nombre_Commandes) AS Moyenne_Commandes_Par_Client FROM (SELECT COUNT(ID_Commande) AS Nombre_Commandes FROM Commande GROUP BY ID_Particulier ) AS Client_Commandes;";
                            ConnexionSQL d = new ConnexionSQL();
                            try
                            {
                                MySqlCommand command = d.MaConnexion.CreateCommand();
                                command.CommandText = cmd3;
                                command.ExecuteNonQuery();
                                object result = command.ExecuteScalar();
                                using (MySqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        while (reader.Read())
                                        {
                                            Console.WriteLine($"Moyenne des commandes par client : {result}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Aucune donnée trouvée.");
                                    }
                                }
                            }
                            catch (MySqlException e)
                            {
                                Console.WriteLine("Erreur lors de la lecture : " + e.Message);
                            }
                            finally
                            {
                                d.MaConnexion.Close();
                                Console.WriteLine("Connexion fermée.");
                            }
                            break;
                        case 4:
                            Console.WriteLine("Rentrez l'idclient recherché (pour rappel de la forme U+un chiffre)");
                            string idclient = Console.ReadLine();
                            string cmd4 = $"SELECT Co.ID_Commande, R.Nom_du_plat_, R.Nationalité, Co.Date_Commande FROM Commande Co JOIN REPAS R ON Co.ID_Commande = R.ID_Commande JOIN Client C ON Co.ID_Particulier = C.ID_Particulier WHERE C.ID_Particulier = '{idclient}';";
                            ConnexionSQL u = new ConnexionSQL();
                            try
                            {
                                MySqlCommand command = u.MaConnexion.CreateCommand();
                                command.CommandText = cmd4;
                                command.ExecuteNonQuery();
                                using (MySqlDataReader reader = command.ExecuteReader())
                                {
                                    if (reader.HasRows)
                                    {
                                        while (reader.Read())
                                        {
                                            string idCommande = reader["ID_Commande"].ToString();
                                            string nomPlat = reader["Nom_du_plat_"].ToString();
                                            string nationalite = reader["Nationalité"].ToString();
                                            string dateCommande = reader["Date_Commande"].ToString();
                                            Console.WriteLine($"Commande ID: {idCommande}, Plat: {nomPlat}, Nationalité: {nationalite}, Date: {dateCommande}");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Aucune commande trouvée.");
                                    }
                                }
                            }
                            catch (MySqlException z)
                            {
                                Console.WriteLine("Erreur lors de la lecture : " + z.Message);
                            }
                            finally
                            {
                                u.MaConnexion.Close();
                                Console.WriteLine("Connexion fermée.");
                            }
                            break;
                    }
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Bienvenue dans les plus de l'appli");
                    Console.WriteLine("RDV dans la V2 de notre appli !  ");
                    break;
            }
        }
    }
}