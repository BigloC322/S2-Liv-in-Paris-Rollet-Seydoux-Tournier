namespace Algo_S2_Vis_in_Paris
{
    class Program
    {
        static void Main(string[] args)
        {
            string cheminFichierRelations = @"relations_association_karaté.txt";

            List<int> ensembleSommets = new List<int>();
            Noeud membresAsso = new Noeud(ensembleSommets);
            ensembleSommets = membresAsso.DéfinirSommets(cheminFichierRelations, ensembleSommets);
            membresAsso.sommetsToString(ensembleSommets);

            List<int[]> relations = new List<int[]>();
            Lien arêtes = new Lien(relations);
            //int nbRelations = arêtes.DéterminerNbRelations(cheminFichierRelations);
            relations = arêtes.Arête(cheminFichierRelations);
            arêtes.relationsToString(relations);
        }
    }
}