using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_S2_Vis_in_Paris
{
    internal class Noeud
    {
        private List<int> idStations;
        private List<string> nomsStations;

        public Noeud(List<int> idStations, List<string> nomsStations)
        {
            this.idStations = idStations;
        }

        public List<int> IdStations
        {
            get { return this.idStations; }
            set { this.idStations = value; }
        }

        public List<string> NomsStations
        {
            get { return this.nomsStations; }
            set { this.nomsStations = value; }
        }

        /// <summary>
        /// Cette méthode créé une liste qui contient tous les sommets
        /// </summary>
        /// <param name="cheminFichier"></param>
        /// <param name="idStations"></param>
        /// <returns></returns>
        
        public List<int> DéfinirIdSommets(string cheminFichier, List<int> idStations)
        {
            string ligneLue = "";
            int colonneId = 0;

            try
            {
                using (StreamReader lecture = new StreamReader(cheminFichier))
                {
                    lecture.ReadLine();
                    while ((ligneLue = lecture.ReadLine()) != null)
                    {
                        string[] valeurs = ligneLue.Split(',');
                        int[] valeursInt = new int[valeurs.Length];
                        if (colonneId < valeurs.Length)
                        {
                            int idStation = Convert.ToInt16(valeurs[colonneId]);
                            idStations.Add(idStation);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Le fichier n'a pas été trouvé. {ex.Message}");
            }

            return idStations;
        }

        public List<string> DéfinirNomsStations(string cheminFichier, List<string> nomsStations)
        {
            string ligneLue = "";
            int colonneId = 1;

            try
            {
                using (StreamReader lecture = new StreamReader(cheminFichier))
                {
                    lecture.ReadLine();
                    while ((ligneLue = lecture.ReadLine()) != null)
                    {
                        string[] valeurs = ligneLue.Split(',');
                        if (colonneId < valeurs.Length)
                        {
                            nomsStations.Add(valeurs[colonneId]);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Le fichier n'a pas été trouvé.");
            }

            return nomsStations;
        }

        public void idStationsToString(List<int> ensembleSommets)
        {
            for (int i = 0; i < ensembleSommets.Count; i++)
            {
                Console.WriteLine(ensembleSommets[i]);
            }
        }

        public void nomsStationsToString(List<string> ensembleSommets)
        {
            for (int i = 0; i < ensembleSommets.Count; i++)
            {
                Console.WriteLine(ensembleSommets[i]);
            }
        }
    }
}