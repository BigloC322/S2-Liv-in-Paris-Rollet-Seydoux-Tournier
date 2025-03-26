using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_S2_Vis_in_Paris
{
    internal class Graphe
    {
        private int[,] grapheMetro;
        private Dictionary<int, List<int>> listeAdj;
        private List<List<int>> listeDesChemins;

        public Graphe(int[,] grapheMetro, Dictionary<int, List<int>> listeAdj, List<List<int>> listeDesChemins)
        {
            this.grapheMetro = grapheMetro;
            this.listeAdj = listeAdj;
            this.listeDesChemins = listeDesChemins;
        }

        public int[,] GrapheMetro
        {
            get { return this.grapheMetro; }
            set { this.grapheMetro = value; }
        }

        public Dictionary<int, List<int>> ListeAdj
        {
            get { return this.listeAdj; }
            set { this.listeAdj = value; }
        }

        public List<List<int>> ListeDesChemins
        {
            get { return this.listeDesChemins; }
            set { this.listeDesChemins = value; }
        }

        /// <summary>
        /// Cette méthode créé la matrice à partir des liens définis dans la classe Liens
        /// </summary>
        /// <param name="matriceAdj"></param>
        /// <param name="relations"></param>
        /// <returns></returns>
        
        public int[,] CréationMatriceAdjacence(int[,] matriceAdj, List<int[]> relations)
        {
            for (int i = 0; i < matriceAdj.GetLength(0); i++)
            {
                for (int j = 0; j < matriceAdj.GetLength(1); j++)
                {
                    for (int k = 0; k < relations.Count; k++)
                    {
                        for (int l = 0; l < relations[k].Length; l++)
                        {
                            if (relations[k].Contains(i + 1) && relations[k].Contains(j + 1)) //si le lien existe entre les deux sommets (équivalent aux deux indices de la case) alors il y a une arête
                            {
                                if (i != j)
                                {
                                    matriceAdj[i, j] = 1;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            return matriceAdj;
        }

        /// <summary>
        /// Cette méthode créé une liste d'adjacence à partir des liens définis dans la classe Liens
        /// </summary>
        /// <param name="relations"></param>
        /// <param name="listeAdjacence"></param>
        /// <returns></returns>
        
        public Dictionary<int, List<int>> CréationListeAdj(List<int[]> relations, Dictionary<int, List<int>> listeAdjacence)
        {
            foreach (var rel in relations)
            {
                int h = rel[0];
                int g = rel[1];

                if (!listeAdjacence.ContainsKey(h))
                {
                    listeAdjacence[h] = new List<int>();
                }
                listeAdjacence[h].Add(g);

                if (!listeAdjacence.ContainsKey(g)) //car graphe non-orienté, on ajoute la relation dans les deux sens
                {
                    listeAdjacence[g] = new List<int>();
                }
                listeAdjacence[g].Add(h);
            }

            return listeAdjacence;
        }

        /// <summary>
        /// Cette méthode vérifie si le graphe (défini par la matrice) est connexe, en utilisant les puissances de matrices
        /// </summary>
        /// <param name="matriceAdj"></param>
        /// <returns></returns>
        
        public bool EstConnexe(int[,] matriceAdj)
        {
            int dimension = matriceAdj.GetLength(0);
            int puissance = dimension;

            int[,] matriceAdjPuissanceK = new int[matriceAdj.GetLength(0), matriceAdj.GetLength(1)]; //matrice qui contient les produits A^k

            matriceAdjPuissanceK = PuissanceMatrice(puissance, matriceAdj);

            bool valPositives = true;
            for (int i = 0; i < matriceAdjPuissanceK.GetLength(0); i++) //le graphe est connexe ssi sa matrice d'adjacence puissance (nomre de sommets - 1) n'a aucune valeurs nulles
            {
                for (int j = 0; j < matriceAdjPuissanceK.GetLength(1); j++)
                {
                    if (matriceAdjPuissanceK[i,j] == 0)
                    {
                        valPositives = false;
                        break;
                    }
                }
            }
            Console.WriteLine();
            MatriceAdjacenceToString(matriceAdjPuissanceK);
            Console.WriteLine();

            return valPositives;
        }

        public int[,] PuissanceMatrice(int puissance, int[,] matrice)
        {
            int[,] matriceP = new int[matrice.GetLength(0), matrice.GetLength(1)];
            for (int i = 0; i < matriceP.GetLength(0); i++)
            {
                for (int j = 0; j < matriceP.GetLength(1); j++)
                {
                    matriceP[i, j] = 0; //initialisation des valeurs à 0
                }
            }

            for (int i = 1; i < puissance; i++) //s'arrête à puissance - 1: le chemin le plus long possible (puissance = dimension d'où ce nombre)
            {
                for (int a = 0; a < matrice.GetLength(0); a++)
                {
                    for (int b = 0; b < a; b++)
                    {
                        for (int k = 0; k < matrice.GetLength(0); k++)
                        {
                            matriceP[a, b] += matrice[a, k] * matrice[k, b];
                        }
                    }
                }
            }
            return matriceP;
        }

        /// <summary>
        /// Cette méthode parcourt le graphe en largeur en utilisant une File
        /// </summary>
        /// <param name="s"></param>
        /// <param name="SommetMarqué"></param>
        /// <param name="matriceAdj"></param>
        
        public void ParcoursEnLargueur(int s, bool[] SommetMarqué, int[,] matriceAdj)
        {
            Queue<int> file = new Queue<int>();
            file.Enqueue(s);
            SommetMarqué[s] = true;

            while(file.Count > 0)
            {
                s = file.Dequeue();
                Console.Write(s + 1 + " "); //on met + 1 car le tableau va de 0 à 33 mais les membres/sommets sont de 1 à 34

                for (int i = 0; i < matriceAdj.GetLength(0); i++)
                {
                    if (matriceAdj[s, i] == 1)
                    {
                        if (SommetMarqué[i] == false)
                        {
                            file.Enqueue(i);
                            SommetMarqué[i] = true;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Cette méthode parcourt le graphe en profondeur en utilisant une méthode Explorer qui marque si un sommet a été exploré
        /// </summary>
        /// <param name="s"></param>
        /// <param name="SommetMarqué"></param>
        /// <param name="matriceAdj"></param>
        
        public void ParcoursEnProfondeur(int s, bool[] SommetMarqué, int[,] matriceAdj) //dans cette méthode, on vérifie pendant le parcours s'il y a un cycle et on l'affiche en même temps
        {
            bool direSiCircuitExiste = false;

            for (int i = s; i < matriceAdj.GetLength(0); i++)
            {
                if (SommetMarqué[i] == false)
                {
                    direSiCircuitExiste = Explorer(i, SommetMarqué, matriceAdj, direSiCircuitExiste);
                }
            }

            for (int i = 0; i < s; i++)
            {
                if (SommetMarqué[i] == false)
                {
                    direSiCircuitExiste = Explorer(i, SommetMarqué, matriceAdj, direSiCircuitExiste);
                }
            }

            if (direSiCircuitExiste == true)
            {
                Console.WriteLine("\nExistence d'un cycle");
            }
            else
            {
                Console.WriteLine("\nPas de cycle depuis le sommet choisi");
            }
        }

        public bool Explorer(int s, bool[] SommetMarqué, int[,] matriceAdj, bool direSiCircuitExiste)
        {
            SommetMarqué[s] = true;
            Console.Write(s + 1 + " ");

            for (int i = 0; i < matriceAdj.GetLength(0); i++)
            {
                if (SommetMarqué[i] == true)
                {
                    direSiCircuitExiste = true;
                }
                
                if (matriceAdj[s,i] == 1)
                {
                    if (SommetMarqué[i] == false)
                    {
                        Explorer(i, SommetMarqué, matriceAdj, direSiCircuitExiste);
                    }
                }
            }
            return direSiCircuitExiste;
        }

        public void MatriceAdjacenceToString(int[,] matriceAdj)
        {
            for (int i = 0; i < matriceAdj.GetLength(0); i++)
            {
                for (int j = 0; j < matriceAdj.GetLength(1); j++)
                {
                    Console.Write($"{matriceAdj[i, j],3}" + " ");
                }
                Console.WriteLine();
            }
        }

        public void ListeAdjacenceToString(Dictionary<int, List<int>> listeAdjacence)
        {
            foreach (var sommet in listeAdjacence)
            {
                Console.Write("Sommet " + sommet.Key + ": ");
                Console.WriteLine(string.Join(", ", sommet.Value));
            }
        }

        public double Haversine(List<decimal[]> coord, List<string> nomsStations)
        {
            Console.WriteLine("Test Haversine:\n");
            Console.WriteLine("Choisir une station de départ.");
            string stationDep = Convert.ToString(Console.ReadLine());
            do
            {
                Console.WriteLine("\nNom de station pas valide, réessayez.");
                stationDep = Convert.ToString(Console.ReadLine());
            }
            while (!nomsStations.Contains(stationDep));
            Console.WriteLine("Choisir une station d'arrivée.");
            string stationArr = Convert.ToString(Console.ReadLine());
            do
            {
                Console.WriteLine("\nNom de station pas valide, réessayez.");
                stationArr = Convert.ToString(Console.ReadLine());
            }
            while (!nomsStations.Contains(stationArr));

            int indiceStationDep = 0;
            int indiceStationArr = 0;
            for (int i = 0; i < nomsStations.Count; i++)
            {
                if (nomsStations[i] == stationDep)
                {
                    indiceStationDep = i;
                }
                if (nomsStations[i] == stationArr)
                {
                    indiceStationArr = i;
                }
            }

            decimal latitudeDépart = coord[indiceStationDep][0];
            decimal longitudeDépart = coord[indiceStationDep][1];
            decimal latitudeArrivée = coord[indiceStationArr][0];
            decimal longitudeArrivée = coord[indiceStationArr][1];

            double latitudeDépartRadians = Convert.ToDouble(latitudeDépart) * (Math.PI / 180);
            double longitudeDépartRadians = Convert.ToDouble(longitudeDépart) * (Math.PI / 180);
            double latitudeArrivéeRadians = Convert.ToDouble(latitudeArrivée) * (Math.PI / 180);
            double longitudeArrivéeRadians = Convert.ToDouble(longitudeArrivée) * (Math.PI / 180);

            double deltaPhi = latitudeArrivéeRadians - latitudeDépartRadians;
            double deltaLambda = longitudeArrivéeRadians - longitudeDépartRadians;

            double moitiéDeltaPhi = (double) deltaPhi / 2;
            double moitiéDeltaLambda = (double) deltaLambda / 2;
            double racine = Math.Sqrt( (Math.Sin(moitiéDeltaPhi) * Math.Sin(moitiéDeltaPhi)) + Math.Cos(Convert.ToDouble(latitudeDépart)) * Math.Cos(Convert.ToDouble(latitudeArrivée)) * Math.Sin(moitiéDeltaLambda) * Math.Sin(moitiéDeltaLambda) );
            double arcsin = Math.Asin(racine);
            double distance = 2 * 6371 * arcsin;

            Console.WriteLine("\nLa distance entre " + stationDep + " et " + stationArr + " est de " + distance + " kilomètres");

            return distance;
        }
    }
}