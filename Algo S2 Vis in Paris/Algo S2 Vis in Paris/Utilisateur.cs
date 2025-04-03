using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509.SigI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Algo_S2_Vis_in_Paris
{
    internal class Utilisateur
    {
        private string iD_Utilisateur;
        private string nom;
        private string prénom;
        private string adresse;
        private string téléphone;
        private string adresse_email;
        private string pseudo;
        private string mot_de_passe;
        private string pref_alimentaire;
        private string station_de_métro;
        private int cpt = 5;

        public Utilisateur(string nom, string prénom, string adresse, string téléphone, string adresse_email, string pseudo, string mot_de_passe, string pref_alimentaire, string station_de_métro)
        {
            cpt++;
            this.iD_Utilisateur = "U"+Convert.ToString(cpt);
            this.nom = nom;
            this.prénom = prénom;
            this.adresse = adresse;
            this.téléphone = téléphone;
            this.adresse_email = adresse_email;
            this.pseudo = pseudo;
            this.mot_de_passe = mot_de_passe;
            this.pref_alimentaire = pref_alimentaire;
            this.station_de_métro = station_de_métro;
        }
        public static void AjouterUtilisateur(Utilisateur test)
        {
            ConnexionSQL a = new ConnexionSQL();
            string requetetable = $"INSERT INTO UTILISATEUR VALUES ('{test.ID_Utilisateur}','{test.Nom}','{test.Prénom}','{test.Adresse}','{test.Téléphone}','{test.Adresse_email}','{test.Pseudo}','{test.Mot_de_passe}','{test.Pref_alimentaire}','{test.Station_de_métro}');";
            try
            {
                MySqlCommand command = a.MaConnexion.CreateCommand();
                command.CommandText = requetetable;
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur lors de la création de l'utilisateur : " + e.Message);
            }
            finally
            {
                a.MaConnexion.Close();
                Console.WriteLine("Connexion fermée.");
            }
        }
        public static void RechercherUtilisateur(string pseudo, string mdp)
        {
            ConnexionSQL a = new ConnexionSQL();
            string requetetable = $"SELECT * FROM Utilisateur WHERE Pseudo = '{pseudo}' AND Mot_de_passe_ = '{mdp}';";
            try
            {
                MySqlCommand command = a.MaConnexion.CreateCommand();
                command.CommandText = requetetable;
                command.ExecuteNonQuery();
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows) // Vérifie si un résultat est trouvé
                    {
                        while (reader.Read()) // Lire ligne par ligne
                        {
                            Console.Clear();
                            Console.WriteLine($" Vous êtes l'utilisateur {reader["ID_Utilisateur"]},Bienvenue {reader["Nom_"]}, Email: {reader["Adresse_email"]}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Aucun utilisateur trouvé.");
                    }
                }

            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur lors de la recherche de l'utilisateur : " + e.Message);
            }
            finally
            {
                a.MaConnexion.Close();
            }
        }
        public void SupprimerUtilisateur(Utilisateur test)
        {
            ConnexionSQL a = new ConnexionSQL();
            string requetetable = $"DELETE FROM UTILISATEUR WHERE ID_UTILISATEUR='{test.ID_Utilisateur}';";
            try
            {
                MySqlCommand command = a.MaConnexion.CreateCommand();
                command.CommandText = requetetable;
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur lors de la suppression de l'utilisateur : " + e.Message);
            }
            finally
            {
                a.MaConnexion.Close();
                Console.WriteLine("Connexion fermée.");
            }
        }

        public string ID_Utilisateur
        {
            get { return this.iD_Utilisateur ;}
            set { this.iD_Utilisateur = value; }
        }

        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }

        public string Prénom
        {
            get { return this.prénom; }
            set { this.prénom = value; }
        }

        public string Adresse
        {
            get { return this.adresse; }
            set { this.adresse = value; }
        }

        public string Téléphone
        {
            get { return this.téléphone; }
            set { this.téléphone = value; }
        }

        public string Adresse_email
        {
            get { return this.adresse_email; }
            set { this.adresse_email = value; }
        }

        public string Pseudo
        {
            get { return this.pseudo; }
            set { this.pseudo = value; }
        }

        public string Mot_de_passe
        {
            get { return this.mot_de_passe; }
            set { this.mot_de_passe = value; }
        }

        public string Pref_alimentaire
        {
            get { return this.pref_alimentaire; }
            set { this.pref_alimentaire = value; }
        }

        public string Station_de_métro
        {
            get { return this.station_de_métro; }
            set { this.station_de_métro = value; }
        }
    }
}