namespace Algo_S2_Vis_in_Paris
{
    class Program
    {
        static void Main(string[] args)
        {
            string cheminFichierRelations = @"relations_association_karaté.txt";

            List<int> ensembleSommets = new List<int>();
            Noeud membresAsso = new Noeud(ensembleSommets);
            membresAsso.EnsembleSommets = membresAsso.DéfinirSommets(cheminFichierRelations, ensembleSommets);
            membresAsso.sommetsToString(membresAsso.EnsembleSommets);

            Console.WriteLine();

            List<int[]> relations = new List<int[]>();
            Lien arêtes = new Lien(relations);
            arêtes.Relations = arêtes.Arête(cheminFichierRelations);
            arêtes.relationsToString(arêtes.Relations);

            Console.WriteLine();

            int[,] matriceAdj = new int[ensembleSommets.Count,ensembleSommets.Count]; //forcément la matrice d'adjacence est de la dimension du nombre de sommets
            Dictionary<int, List<int>> listeAdj = new Dictionary<int, List<int>>();
            List<List<int>> listeDesChemins = new List<List<int>>();
            Graphe g = new Graphe(matriceAdj, listeAdj, listeDesChemins);

            g.GrapheAsso = g.CréationMatriceAdjacence(matriceAdj, arêtes.Relations); //avec matrice adj
            g.ListeAdj = g.CréationListeAdj(arêtes.Relations, listeAdj); //avec liste adj

            g.MatriceAdjacenceToString(g.GrapheAsso);
            Console.WriteLine();
            g.ListeAdjacenceToString(g.ListeAdj);

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
                Console.WriteLine("\nLe graphe du réseau des membres de l'association est connexe.");
            }
            else
            {
                Console.WriteLine("\nLe graphe du réseau des membres de l'association n'est pas connexe.");
            }

            VisualisationGraphe graphismes = new VisualisationGraphe();
            graphismes.ReprésenterGraphe(g.GrapheAsso);
        }
    }
}