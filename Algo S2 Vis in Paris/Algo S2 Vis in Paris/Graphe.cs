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

        public int[,] CréationMatriceAdjacence()
        {
            return grapheAsso;
        }
    }
}