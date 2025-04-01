using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Algo_S2_Vis_in_Paris
{
    internal class Cuisinier
    {
        private string iD_Cuisinier;
        private string iD_Utilisateur;

        public Cuisinier(string iD_Cuisinier, string iD_Utilisateur)
        {
            this.iD_Cuisinier = iD_Cuisinier;
            this.iD_Utilisateur = iD_Utilisateur;
        }

        public void AjouterCuisiner(Cuisinier test)
        {
            ConnexionSQL a = new ConnexionSQL();
            string requetetable = $"INSERT INTO CUISINIER VALUES ('{test.ID_Cuisinier}','{test.ID_Utilisateur}');";
            try
            {
                MySqlCommand command = a.MaConnexion.CreateCommand();
                command.CommandText = requetetable;
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur lors de la création du cuisinier : " + e.Message);
            }
            finally
            {
                a.MaConnexion.Close();
                Console.WriteLine("Connexion fermée.");
            }
        }



        public string ID_Cuisinier
        {
            get { return this.iD_Cuisinier; }
            set { this.iD_Cuisinier = value; }
        }

        public string ID_Utilisateur
        {
            get { return this.iD_Utilisateur; }
            set { this.iD_Utilisateur = value; }
        }
    }
}