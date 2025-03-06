namespace Algo_S2_Vis_in_Paris
{
    class Program
    {
        static void Main(string[] args)
        {
            string cheminFichierMetro = @"metrotest.csv";

            List<int> idStations = new List<int>();
            List<string> nomsStations = new List<string>();
            Noeud stations = new Noeud(idStations, nomsStations);
            stations.IdStations = stations.DéfinirIdSommets(cheminFichierMetro, idStations);
            stations.NomsStations = stations.DéfinirNomsStations(cheminFichierMetro, nomsStations);

            //stations.idStationsToString(stations.IdStations);
            //stations.nomsStationsToString(stations.NomsStations);

            Console.WriteLine();
            
            List<int[]> liensStations = new List<int[]>();
            Lien Arcs = new Lien(liensStations);
            Arcs.LiensStations = Arcs.CréerLiens(cheminFichierMetro);
            List<int[]> liens = new List<int[]>();
            liens = Arcs.GestionStationsDoubles(stations.IdStations, stations.NomsStations, Arcs.LiensStations, cheminFichierMetro);
            Arcs.LiensStations = liens;
            //Arcs.liensStationsToString(Arcs.LiensStations);

            Console.WriteLine();

            int[,] matriceAdj = new int[stations.IdStations.Count, stations.IdStations.Count]; //forcément la matrice d'adjacence est de la dimension du nombre de sommets
            Dictionary<int, List<int>> listeAdj = new Dictionary<int, List<int>>();
            List<List<int>> listeDesChemins = new List<List<int>>();
            Graphe g = new Graphe(matriceAdj, listeAdj, listeDesChemins);

            g.GrapheMetro = g.CréationMatriceAdjacence(matriceAdj, Arcs.LiensStations); //avec matrice adj
            Console.WriteLine();
            //g.MatriceAdjacenceToString(g.GrapheMetro);

            Console.WriteLine();
            g.ListeAdj = g.CréationListeAdj(Arcs.LiensStations, listeAdj); //avec liste adj
            
            Console.WriteLine();
            //g.ListeAdjacenceToString(g.ListeAdj);

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

            VisualisationGraphe graphismes = new VisualisationGraphe();
            graphismes.ReprésenterGraphe(g.GrapheMetro);
        }
    }
}