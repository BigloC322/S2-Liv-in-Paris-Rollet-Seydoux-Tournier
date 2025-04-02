using System;
using System.Collections;
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

        private List<int[]> liensStations; //un lien entre deux sommets est représenté par un tableau contenants ces deux sommets
        private List<decimal> pondération;

        public Lien(List<int[]> liensStations, List<decimal> pondération)
        {
            this.liensStations = liensStations;
            this.pondération = pondération;
        }

        public List<int[]> LiensStations
        { 
            get { return liensStations; }
            set { this.liensStations = value; }
        }

        public List<decimal> Pondération
        {
            get { return pondération; }
            set { this.pondération = value; }
        }

        /// <summary>
        /// Cette méthode lis le fichier avec les liens, et met ces liens dans une liste de tableaux
        /// </summary>
        /// <param name="cheminFichierMetro"></param>
        /// <returns></returns>
        
        public List<int[]> CréerLiens(string cheminFichierMetro)
        {
            string ligneLue = "";
            List<int[]> relationsEntreStations = new List<int[]>();

            try
            {
                using (StreamReader lecture = new StreamReader(cheminFichierMetro))
                {
                    lecture.ReadLine();
                    while ((ligneLue = lecture.ReadLine()) != null)
                    {
                        string[] valeursColonnes = ligneLue.Split(',');

                        if (valeursColonnes.Length >= 4)
                        {
                            try
                            {
                                int[] lien = new int[2];
                                lien[0] = Convert.ToInt32(valeursColonnes[0]);
                                lien[1] = Convert.ToInt32(valeursColonnes[3]);

                                relationsEntreStations.Add(lien);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Une erreur s'est produite lors de la lecture de fichiers. {ex.Message}");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Une erreur s'est produite.");
            }

            List<int[]> relationsEntreStationsReel = new List<int[]>();

            foreach (var relation in relationsEntreStations)
            {
                if (!relation.Contains(0))
                {
                    relationsEntreStationsReel.Add(relation);
                }
            }

            relationsEntreStations = relationsEntreStationsReel;

            return relationsEntreStations;
        }

        /// <summary>
        /// Cette méthode permet de traiter les multiples de stations et de faire le lien entre les lignes
        /// </summary>
        /// <param name="idStations"></param>
        /// <param name="nomsStations"></param>
        /// <param name="relationsEntreStations"></param>
        /// <param name="cheminFichierMetro"></param>
        /// <returns></returns>

        public List<int[]> GestionStationsDoubles(List<int> idStations, List<string> nomsStations, List<int[]> relationsEntreStations, string cheminFichierMetro)
        {
            HashSet<string> doubleStations = new HashSet<string>();
            HashSet<string> stationsParcourues = new HashSet<string>();

            foreach (var station in nomsStations)
            {
                string trimmedStation = station.Trim();

                if (stationsParcourues.Contains(trimmedStation))
                {
                    doubleStations.Add(trimmedStation);
                }
                else
                {
                    stationsParcourues.Add(trimmedStation);
                }
            }

            List<string> doubleStationsTotal = new List<string>();
            foreach (var station in doubleStations)
            {
                doubleStationsTotal.Add(station);
            }

            foreach (var station in nomsStations)
            {
                if (doubleStationsTotal.Contains(station))
                {
                    doubleStationsTotal.Add(station);
                }
            }

            foreach (var station in doubleStations)
            {
                doubleStationsTotal.Remove(station);
            }

            List<int> idDesDoubles = new List<int>();
            for (int i = 0; i < nomsStations.Count; i++)
            {
                string trimmedStation = nomsStations[i].Trim();
                if (doubleStationsTotal.Contains(trimmedStation))
                {
                    idDesDoubles.Add(idStations[i]);
                }
            }

            Dictionary<string, int> stationEtId = new Dictionary<string, int>();
            for (int i = 0; i < nomsStations.Count; i++)
            {
                string station = nomsStations[i].Trim();
                if (stationEtId.ContainsKey(station))
                {
                    stationEtId[station]++;
                }
                else
                {
                    stationEtId[station] = 1;
                }
            }

            Dictionary<string, List<int>> doubleStationEtId = new Dictionary<string, List<int>>();
            for (int i = 0; i < nomsStations.Count; i++)
            {
                string station = nomsStations[i].Trim();
                int number = idStations[i];

                if (stationEtId[station] > 1)
                {
                    if (!doubleStationEtId.ContainsKey(station))
                    {
                        doubleStationEtId[station] = new List<int>();
                    }
                    doubleStationEtId[station].Add(number);
                }
            }

            List<int[]> LiensEntreLignes = new List<int[]>();

            foreach (var stationList in doubleStationEtId.Values)
            {
                for (int i = 0; i < stationList.Count; i++)
                {
                    for (int j = i + 1; j < stationList.Count; j++)
                    {
                        LiensEntreLignes.Add(new int[] { stationList[i], stationList[j] });
                    }
                }
            }

            for (int i = 0; i < LiensEntreLignes.Count; i++)
            {
                relationsEntreStations.Add(LiensEntreLignes[i]);
            }
            
            return relationsEntreStations;
        }

        public List<decimal> PondérerArcs(List<int[]> liensStations, string cheminPonderation)

        {
            if (!File.Exists(cheminPonderation))
            {
                throw new FileNotFoundException("Le fichier de pondération n'a pas été trouvé.", cheminPonderation);
            }
            List<decimal> poidsArcs = new List<decimal>();

            try
            {
                string[] lignes = File.ReadAllLines(cheminPonderation);
                foreach (string ligne in lignes)
                {
                    if (decimal.TryParse(ligne, out decimal poids))
                    {
                        if (poids > 0)
                        {
                            poidsArcs.Add(poids);
                        }
                    }
                    else
                    {
                        throw new FormatException("Le format du poids dans le fichier est incorrect.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la lecture du fichier de pondération.", ex);
            }
            if (poidsArcs.Count > liensStations.Count)
            {
                throw new InvalidOperationException("Le nombre de poids dépasse le nombre d'arcs.");
            }
            while (poidsArcs.Count < liensStations.Count)
            {
                poidsArcs.Add(2); // Ajoute un poids par défaut de 2 pour les arcs sans poids
            }
            
            return poidsArcs;
        }

        public void liensStationsToString(List<int[]> relations)
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