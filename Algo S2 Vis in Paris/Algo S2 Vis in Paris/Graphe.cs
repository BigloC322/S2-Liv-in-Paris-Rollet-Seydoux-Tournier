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
        private int[,] grapheAsso;
        private Dictionary<int, List<int>> listeAdj;
        private List<List<int>> listeDesChemins;

        public Graphe(int[,] grapheAsso, Dictionary<int, List<int>> listeAdj, List<List<int>> listeDesChemins)
        {
            this.grapheAsso = grapheAsso;
            this.listeAdj = listeAdj;
            this.listeDesChemins = listeDesChemins;
        }

        public int[,] GrapheAsso
        {
            get { return this.grapheAsso; }
            set { this.grapheAsso = value; }
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

        public bool ContientCircuits(int[,] matriceAdj)
        {
            bool contientCircuits = false;



            return contientCircuits;
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
    }
}