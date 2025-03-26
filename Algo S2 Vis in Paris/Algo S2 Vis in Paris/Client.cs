using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_S2_Vis_in_Paris
{
    internal class Client
    {
        private string iD_Particulier;
        private string iD_Entreprise;
        private string iD_Utilisateur;

        public Client(string iD_Particulier, string iD_Entreprise, string iD_Utilisateur)
        {
            this.iD_Particulier = iD_Particulier;
            this.iD_Entreprise = iD_Entreprise;
            this.iD_Utilisateur = iD_Utilisateur;
        }

        public string ID_Particulier
        {
            get { return this.iD_Particulier; }
            set { this.iD_Particulier = value; }
        }

        public string ID_Entreprise
        {
            get { return this.iD_Entreprise; }
            set { this.iD_Entreprise = value; }
        }

        public string ID_Utilisateur
        {
            get { return this.iD_Utilisateur; }
            set { this.iD_Utilisateur = value; }
        }
    }
}