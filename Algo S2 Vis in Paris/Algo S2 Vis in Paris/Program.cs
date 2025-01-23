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
            //int nbRelations = arêtes.DéterminerNbRelations(cheminFichierRelations);
            arêtes.Relations = arêtes.Arête(cheminFichierRelations);
            arêtes.relationsToString(arêtes.Relations);

            Console.WriteLine();

            int[,] matriceAdj = new int[ensembleSommets.Count,ensembleSommets.Count]; //forcément la matrice d'adjacence est de la dimension du nombre de sommets
            Graphe g = new Graphe(matriceAdj);
            g.GrapheAsso = g.CréationMatriceAdjacence(matriceAdj, arêtes.Relations);
            g.MatriceAdjacenceToString(g.GrapheAsso);
        }
    }
}