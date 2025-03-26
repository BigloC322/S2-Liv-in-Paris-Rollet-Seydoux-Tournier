using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_S2_Vis_in_Paris
{
    internal class Entreprise
    {
        private string iD_Entreprise;
        private string nom;
        private string nom_référent;

        public Entreprise(string iD_Entreprise, string nom, string nom_référent)
        {
            this.iD_Entreprise = iD_Entreprise;
            this.nom = nom;
            this.nom_référent = nom_référent;
        }

        public string ID_Entreprise
        {
            get { return this.iD_Entreprise; }
            set { this.iD_Entreprise = value; }
        }

        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }

        public string Nom_référent
        {
            get { return this.nom_référent; }
            set { this.nom_référent = value; }
        }
    }
}