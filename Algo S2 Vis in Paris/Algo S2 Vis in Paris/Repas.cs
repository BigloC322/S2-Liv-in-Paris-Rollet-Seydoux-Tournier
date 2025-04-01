using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Algo_S2_Vis_in_Paris
{
    internal class Repas
    {
        private string idPlat;
        private string nomDuPlat;
        private string type;
        private string nombreDePortion;
        private string dateDeFabrication;
        private string dateDePeremption;
        private string prixUnitaire;
        private string nationalité;
        private string photo;
        private string idCommande;

        public Repas(string idPlat, string nomDuPlat, string type, string nombreDePortion, string dateDeFabrication, string dateDePeremption, string prixUnitaire, string nationalité, string photo, string idCommande)
        {
            this.idPlat = idPlat;
            this.nomDuPlat = nomDuPlat;
            this.type = type;
            this.nombreDePortion = nombreDePortion;
            this.dateDeFabrication = dateDeFabrication;
            this.dateDePeremption = dateDePeremption;
            this.prixUnitaire = prixUnitaire;
            this.nationalité = nationalité;
            this.photo = photo;
            this.idCommande = idCommande;
        }
        public void AjouterRepas(Repas test)
        {
            ConnexionSQL a = new ConnexionSQL();
            string requetetable = $"INSERT INTO REPAS VALUES ('{test.IdPlat}','{test.NomDuPlat}','{test.Type}','{test.NombreDePortion},{test.DateDeFabrication}','{test.DateDePeremption}','{test.PrixUnitaire}','{test.Nationalité}','{test.Photo}','{test.IdCommande}');";
            try
            {
                MySqlCommand command = a.MaConnexion.CreateCommand();
                command.CommandText = requetetable;
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur lors de la création du repas : " + e.Message);
            }
            finally
            {
                a.MaConnexion.Close();
                Console.WriteLine("Connexion fermée.");
            }
        }
        public string IdPlat
        {
            get { return idPlat; }
            set { idPlat = value; }
        }

        public string NomDuPlat
        {
            get { return nomDuPlat; }
            set { nomDuPlat = value; }
        }

        public string Type
        {
            get { return type; }
            set { type = value; }
        }

        public string NombreDePortion
        {
            get { return nombreDePortion; }
            set { nombreDePortion = value; }
        }

        public string DateDeFabrication
        {
            get { return dateDeFabrication; }
            set { dateDeFabrication = value; }
        }

        public string DateDePeremption
        {
            get { return dateDePeremption; }
            set { dateDePeremption = value; }
        }

        public string PrixUnitaire
        {
            get { return prixUnitaire; }
            set { prixUnitaire = value; }
        }

        public string Nationalité
        {
            get { return nationalité; }
            set { nationalité = value; }
        }

        public string Photo
        {
            get { return photo; }
            set { photo = value; }
        }

        public string IdCommande
        {
            get { return idCommande; }
            set { idCommande = value; }
        }
    }
}