<<<<<<< Updated upstream
﻿Console.WriteLine("Paul");
Console.WriteLine("Alex");
Console.WriteLine("Florent");
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
Console.WriteLine("Florent");
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
=======
=======
<<<<<<< Updated upstream
﻿namespace Algo_S2_Vis_in_Paris
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
=======
﻿//En route les putes  
//lesgo
Console.WriteLine("Paul");
Console.WriteLine("Alex");
//test
>>>>>>> Stashed changes
>>>>>>> Stashed changes
