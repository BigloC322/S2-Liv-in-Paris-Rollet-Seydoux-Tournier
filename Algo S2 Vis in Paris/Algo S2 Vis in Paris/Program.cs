using System;

namespace Algo_S2_Vis_in_Paris
{
    class Program
    {
        static void Main(string[] args)
        {
            #region truc de merde d'alex
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

           //Utilisateur test = new Utilisateur("123456", "Schaeffer", "Noémie","Toulouse rue de merde","06787878","nomeri@pute","scheffpute","dddd","halal","Sablons");
           //test.AjouterUtilisateur(test);
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

                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("Bienvenue dans les plus de l'appli");
                    break;
            }
        }
    }
}