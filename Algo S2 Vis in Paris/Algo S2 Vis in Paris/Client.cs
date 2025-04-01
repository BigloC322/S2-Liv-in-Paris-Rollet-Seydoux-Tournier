using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Xml;

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

        public void AjouterClient(Client test)
        {
            ConnexionSQL a = new ConnexionSQL();
            string requetetable = $"INSERT INTO CLIENT VALUES ('{test.ID_Particulier}','{test.ID_Entreprise}','{test.ID_Utilisateur}');";
            try
            {
                MySqlCommand command = a.MaConnexion.CreateCommand();
                command.CommandText = requetetable;
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur lors de la création du client : " + e.Message);
            }
            finally
            {
                a.MaConnexion.Close();
                Console.WriteLine("Connexion fermée.");
            }
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