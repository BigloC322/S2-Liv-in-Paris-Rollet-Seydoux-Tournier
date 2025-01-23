using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_S2_Vis_in_Paris
{
    internal class Noeud
    {
        private int sommet;
        private List<int> ensembleSommets;

        public Noeud(int sommet, List<int> ensembleSommets)
        {
            this.sommet = sommet;
            this.ensembleSommets = ensembleSommets;
        }

        public int Sommet
        {
            get { return this.sommet; }
            set { this.sommet = value; }
        }

        public List<int> EnsembleSommets
        {
            get { return this.ensembleSommets; }
            set { this.ensembleSommets = value; }
        }

        public List<int> DéfinirSommets(string cheminFichierRelations, List<int> ensembleSommets)
        {
            int ligneInit = 1; //la première ligne du fichier contient les infos sur le nombre de membres et relations
            string ligneLue = "";
            int indiceLigne = 1;

            try
            {
                using (StreamReader lecture = new StreamReader(cheminFichierRelations))
                {
                    while ((ligneLue = lecture.ReadLine()) != null)
                    {
                        if (indiceLigne == ligneInit)
                        {
                            Console.WriteLine(ligneLue);
                            break;
                        }
                        indiceLigne++;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Le fichier n'a pas été trouvé.");
            }

            string[] séparationLigne = ligneLue.Split(' ');
            string nbMembresString = séparationLigne[0];
            int nbMembres = Convert.ToInt32(nbMembresString);

            for (int i = 1; i <= nbMembres; i++)
            {
                ensembleSommets.Add(i); //ajout dans la liste du nb de membres, allant de 1 au nb de membres lu dans le fichier
            }

            return ensembleSommets;
        }

        public void sommetsToString(List<int> ensembleSommets)
        {
            for (int i = 0; i < ensembleSommets.Count; i++)
            {
                Console.Write(ensembleSommets[i] + " ");
            }
        }
    }
}