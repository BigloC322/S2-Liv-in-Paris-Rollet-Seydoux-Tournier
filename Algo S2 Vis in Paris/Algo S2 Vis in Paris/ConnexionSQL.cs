using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Crypto.Digests;

namespace Algo_S2_Vis_in_Paris
{
    internal class ConnexionSQL
    {
        private MySqlConnection maConnexion;
        private string connexionString = "SERVER=localhost;PORT=3307;" +
                                     "DATABASE=LIVIP;" +
                                     "UID=root;PASSWORD=root";
        public ConnexionSQL()
        {
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
        public MySqlConnection MaConnexion
        {
            get { return this.maConnexion; }
            set { this.maConnexion = value; }
        }
        public void AfficherCommande(string nomtable) // Test pour une base random 
        {
            if (maConnexion == null || maConnexion.State != System.Data.ConnectionState.Open)
            {
                Console.WriteLine("Connexion non disponible.");
                return;
            }

            string requetetable = $"SELECT * FROM {nomtable}";
            string requeteinfos = $"SELECT COLUMN_NAME FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME = '{nomtable}' AND TABLE_SCHEMA = 'LIVIP';";
            List<string> listeinfos = new List<string>();
            try
            {
                using (MySqlCommand infos = new MySqlCommand(requeteinfos, maConnexion))
                using (MySqlDataReader reader1 = infos.ExecuteReader())
                {                    
                    while (reader1.Read())
                    {
                        listeinfos.Add(reader1["COLUMN_NAME"].ToString());
                    }
                }
                using (MySqlCommand command = new MySqlCommand(requetetable, maConnexion))
                using (MySqlDataReader reader2 = command.ExecuteReader())
                {
                    Console.WriteLine($"\nListe des {nomtable} :\n");
                    while (reader2.Read())
                    {
                        Console.Write($"{reader2[listeinfos[0]]} ");
                        for (int i=1; i<listeinfos.Count;i++)
                        {
                            Console.Write($"| {reader2[listeinfos[i]]} ");
                        }
                        Console.WriteLine();
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
