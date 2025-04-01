using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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
        public void AjouterEntreprise(Entreprise test)
        {
            ConnexionSQL a = new ConnexionSQL();
            string requetetable = $"INSERT INTO ENTREPRISE VALUES ('{test.ID_Entreprise}','{test.Nom}','{test.Nom_référent}');";
            try
            {
                MySqlCommand command = a.MaConnexion.CreateCommand();
                command.CommandText = requetetable;
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur lors de la création de l'entreprise : " + e.Message);
            }
            finally
            {
                a.MaConnexion.Close();
                Console.WriteLine("Connexion fermée.");
            }
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