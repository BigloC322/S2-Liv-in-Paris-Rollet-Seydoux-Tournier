using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_S2_Vis_in_Paris
{
    internal class Lien
    {
        ///cette classe permet de créer des liens entre les sommets selon les relations données dans le fichier
        ///

        private List<int[]> relations; //un lien entre deux sommets est représenté par un tableau contenants ces deux sommets

        public Lien(List<int[]> relations)
        {
            this.relations = relations;
        }

        public List<int[]> Relations
        { 
            get { return relations; }
            set { this.relations = value; }
        }

        /// <summary>
        /// Cette méthode lis le fichier avec les liens, et met ces liens dans une liste de tableaux
        /// </summary>
        /// <param name="cheminFichierRelations"></param>
        /// <returns></returns>
        
        public List<int[]> Arête(string cheminFichierRelations)
        {
            //à partir de la ligne 2, il y a toutes les relations entre les sommets dans le fichier
            string ligneLue = "";
            List<int[]> relations = new List<int[]>();

            try
            {
                using (StreamReader lecture = new StreamReader(cheminFichierRelations))
                {
                    lecture.ReadLine(); //permet de sauter une ligne (la ligne 1 qui contient de l'info mais pas les relations)

                    while ((ligneLue = lecture.ReadLine()) != null)
                    {
                        string[] séparation = ligneLue.Split(' '); //on casse en deux la ligne qui a les deux sommets reliés
                        int membre1 = Convert.ToInt32(séparation[0]);
                        int membre2 = Convert.ToInt32(séparation[1]);
                        int[] lienEntreMembres = new int[2];
                        lienEntreMembres[0] = membre1;
                        lienEntreMembres[1] = membre2;
                        relations.Add(lienEntreMembres); //on ajoute donc un tableau qui relie deux sommets 
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Le fichier n'a pas été trouvé.");
            }
            return relations;
        }

        public void relationsToString(List<int[]> relations)
        {
            for (int i = 0; i < relations.Count; i++)
            {
                for (int j = 0; j < relations[i].Length; j++)
                {
                    Console.Write(relations[i][j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}