namespace Algo_S2_Vis_in_Paris
{
    class Program
    {
        static void Main(string[] args)
        {
            string cheminFichierMetro = @"metros.csv";
            string cheminFichierMetroCoord = @"MetroCoord.csv";

            List<int> idStations = new List<int>();
            List<string> nomsStations = new List<string>();
            List<decimal[]> coord = new List<decimal[]>();
            Noeud stations = new Noeud(idStations, nomsStations, coord);
            stations.IdStations = stations.DéfinirIdSommets(cheminFichierMetro, idStations);
            stations.NomsStations = stations.DéfinirNomsStations(cheminFichierMetro, nomsStations);
            stations.Coord = stations.CoordStations(cheminFichierMetroCoord, stations.NomsStations, coord);
            
            List<int[]> liensStations = new List<int[]>();
            List<int> pondération = new List<int>();
            Lien Arcs = new Lien(liensStations, pondération);
            Arcs.LiensStations = Arcs.CréerLiens(cheminFichierMetro);
            List<int[]> liens = new List<int[]>();
            liens = Arcs.GestionStationsDoubles(stations.IdStations, stations.NomsStations, Arcs.LiensStations, cheminFichierMetro);
            Arcs.Pondération = Arcs.PondérerArcs(Arcs.LiensStations);
            Arcs.LiensStations = liens;

            int[,] matriceAdj = new int[stations.IdStations.Count, stations.IdStations.Count]; //forcément la matrice d'adjacence est de la dimension du nombre de sommets
            Dictionary<int, List<int>> listeAdj = new Dictionary<int, List<int>>();
            List<List<int>> listeDesChemins = new List<List<int>>();
            Graphe g = new Graphe(matriceAdj, listeAdj, listeDesChemins);

            g.GrapheMetro = g.CréationMatriceAdjacence(matriceAdj, Arcs.LiensStations); //avec matrice adj

            g.ListeAdj = g.CréationListeAdj(Arcs.LiensStations, listeAdj); //avec liste adj

            /*
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
            }*/

            //g.Haversine(stations.Coord, stations.NomsStations);

            VisualisationGraphe graphismes = new VisualisationGraphe();
            graphismes.ReprésenterGraphe(g.GrapheMetro);

            MétrosGoogleMaps m = new MétrosGoogleMaps();
            m.AfficherMetrosGoogleMaps(stations.NomsStations, stations.Coord, g.GrapheMetro);
        }
    }
}