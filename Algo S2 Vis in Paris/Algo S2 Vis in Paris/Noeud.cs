using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_S2_Vis_in_Paris
{
    internal class Noeud
    {
        private List<int> ensembleSommets;

        public Noeud(List<int> ensembleSommets)
        {
            this.ensembleSommets = ensembleSommets;
        }

        public List<int> EnsembleSommets
        {
            get { return this.ensembleSommets; }
            set { this.ensembleSommets = value; }
        }

        /// <summary>
        /// Cette méthode crée une liste qui contient tous les sommets
        /// </summary>
        /// <param name="cheminFichierRelations"></param>
        /// <param name="ensembleSommets"></param>
        /// <returns></returns>
        
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

            string[] séparationLigne = ligneLue.Split(' '); //vu que la ligne 1 a plusieurs nombres
            string nbMembresString = séparationLigne[0]; //on veut seulement le premier qui contient le nb de membres
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
            Console.WriteLine();
        }
    }
}