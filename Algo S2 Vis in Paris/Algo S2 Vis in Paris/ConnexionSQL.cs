using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Algo_S2_Vis_in_Paris
{
    internal class ConnexionSQL
    {
        private MySqlConnection maConnexion;

        public ConnexionSQL()
        {
            string connexionString = "SERVER=localhost;PORT=3307;" +
                                     "DATABASE=LIVIP;" +
                                     "UID=root;PASSWORD=root";
            try
            {
                maConnexion = new MySqlConnection(connexionString);
                maConnexion.Open();
                Console.WriteLine("Connexion réussie !");
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur de connexion : " + e.Message);
            }
        }
        //avoir
        //inserer
        //
        public void AfficherCommande()
        {
            if (maConnexion == null || maConnexion.State != System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Connexion non disponible.");
                return;
            }

            string query = "SELECT * FROM Commande";
            try
            {
                using (MySqlCommand command = new MySqlCommand(query, maConnexion))
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("\nListe des commandes :\n");
                    Console.WriteLine("---------------------------------------------------------");
                    Console.WriteLine("ID  | Date Cmd  | Date Livr | Dép. | Montant | Dest. | Statut | Client | Produit");
                    Console.WriteLine("---------------------------------------------------------");

                    while (reader.Read())
                    {
                        Console.WriteLine($"{reader["ID_Commande"]} | {reader["Date_Commande"]} | {reader["Date_Livraison"]} | {reader["Adresse_de_livraison"]}");
                    }
                }
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur lors de l'exécution de la requête : " + e.Message);
            }
            finally
            {
                maConnexion.Close();
                Console.WriteLine("Connexion fermée.");
            }
        }
    }
}
