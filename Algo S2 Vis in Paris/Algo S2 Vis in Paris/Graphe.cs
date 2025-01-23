using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_S2_Vis_in_Paris
{
    internal class Graphe
    {
        private int[,] grapheAsso;

        public Graphe(int[,] grapheAsso)
        {
            this.grapheAsso = grapheAsso;
        }

        public int[,] GrapheAsso
        {
            get { return this.grapheAsso; }
            set { this.grapheAsso = value; }
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

        public void MatriceAdjacenceToString(int[,] matriceAdj)
        {
            for (int i = 0; i < matriceAdj.GetLength(0); i++)
            {
                for (int j = 0; j < matriceAdj.GetLength(1); j++)
                {
                    Console.Write(matriceAdj[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}