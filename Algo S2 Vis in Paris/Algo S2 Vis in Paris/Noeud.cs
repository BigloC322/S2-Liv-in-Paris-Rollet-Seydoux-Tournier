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
        private List<decimal[]> coord;

        public Noeud(List<int> idStations, List<string> nomsStations, List<decimal[]> coord)
        {
            this.idStations = idStations;
            this.nomsStations = nomsStations;
            this.coord = coord;
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

        public List<decimal[]> Coord
        {
            get { return this.coord; }
            set { this.coord = value; }
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

        public List<decimal[]> CoordStations(string cheminFichierMetroCoord, List<string> nomsStations, List<decimal[]> coord)
        {
            string ligneLue = "";

            try
            {
                using (StreamReader lecture = new StreamReader(cheminFichierMetroCoord))
                {
                    lecture.ReadLine();
                    while ((ligneLue = lecture.ReadLine()) != null)
                    {
                        string[] valeursColonnes = ligneLue.Split(',');

                        if (valeursColonnes.Length >= 4)
                        {
                            try
                            {
                                decimal[] noeudCoord = new decimal[2];
                                noeudCoord[0] = Convert.ToDecimal(valeursColonnes[4]);
                                noeudCoord[1] = Convert.ToDecimal(valeursColonnes[3]);

                                coord.Add(noeudCoord);
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

            return coord;
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

        public void AfficherCoordTest(List<decimal[]> relations)
        {
            for (int i = 0; i < relations.Count; i++)
            {
                for (int j = 0; j < relations[i].Length; j++)
                {
                    Console.Write(relations[i][j] + "  ");
                }
                Console.WriteLine();
            }
        }
    }
}