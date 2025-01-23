namespace Algo_S2_Vis_in_Paris
{
    class Program
    {
        static void Main(string[] args)
        {
            string cheminFichierRelations = @"relations_association_karaté.txt";

            int sommet = 0;
            List<int> ensembleSommets = new List<int>();
            Noeud membresAsso = new Noeud(sommet, ensembleSommets);

            ensembleSommets = membresAsso.DéfinirSommets(cheminFichierRelations, ensembleSommets);

            membresAsso.sommetsToString(ensembleSommets);
        }
    }
}