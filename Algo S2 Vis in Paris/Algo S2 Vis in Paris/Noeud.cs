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
        private int[] ensembleSommets;

        public Noeud(int sommet, int[] ensembleSommets)
        {
            this.sommet = sommet;
            this.ensembleSommets = ensembleSommets;
        }

        public int Sommet
        {
            get { return this.sommet; }
            set { this.sommet = value; }
        }

        public int[] EnsembleSommets
        {
            get { return this.ensembleSommets; }
            set { this.ensembleSommets = value; }
        }

        public int[] DéfinirSommets()
        {
            return this.ensembleSommets;
        }
    }
}
