using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_S2_Vis_in_Paris
{
    internal class Commande
    {
        private string idCommande;
        private string dateCommande;
        private string dateLivraison;
        private string adresseDeLaCuisine;
        private string prixTotal;
        private string adresseDeLivraison;
        private string statut;
        private string idCuisinier;
        private string idParticulier;

        public Commande(string idCommande, string dateCommande, string dateLivraison, string adresseDeLaCuisine, string prixTotal, string adresseDeLivraison, string statut, string idCuisinier, string idParticulier)
        {
            this.idCommande = idCommande;
            this.dateCommande = dateCommande;
            this.dateLivraison = dateLivraison;
            this.adresseDeLaCuisine = adresseDeLaCuisine;
            this.prixTotal = prixTotal;
            this.adresseDeLivraison = adresseDeLivraison;
            this.statut = statut;
            this.idCuisinier = idCuisinier;
            this.idParticulier = idParticulier;
        }
        public string IdCommande
        {
            get { return idCommande; }
            set { idCommande = value; }
        }

        public string DateCommande
        {
            get { return dateCommande; }
            set { dateCommande = value; }
        }

        public string DateLivraison
        {
            get { return dateLivraison; }
            set { dateLivraison = value; }
        }

        public string AdresseDeLaCuisine
        {
            get { return adresseDeLaCuisine; }
            set { adresseDeLaCuisine = value; }
        }

        public string PrixTotal
        {
            get { return prixTotal; }
            set { prixTotal = value; }
        }

        public string AdresseDeLivraison
        {
            get { return adresseDeLivraison; }
            set { adresseDeLivraison = value; }
        }

        public string Statut
        {
            get { return statut; }
            set { statut = value; }
        }

        public string IdCuisinier
        {
            get { return idCuisinier; }
            set { idCuisinier = value; }
        }

        public string IdParticulier
        {
            get { return idParticulier; }
            set { idParticulier = value; }
        }
    }
}