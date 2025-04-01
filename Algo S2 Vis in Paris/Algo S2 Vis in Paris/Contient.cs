using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Algo_S2_Vis_in_Paris
{
    internal class Contient
    {
        private string idPlat;
        private List<string> idIngredient;

        public Contient(string idPlat, List<string> idIngredient)
        {
            this.idPlat = idPlat;
            this.idIngredient = idIngredient;
        }

        public void AjouterContient(Contient test)
        {
            ConnexionSQL a = new ConnexionSQL();
            string requetetable = $"INSERT INTO CONTIENT VALUES ('{test.IdPlat}','{test.IdIngredient}');";
            try
            {
                MySqlCommand command = a.MaConnexion.CreateCommand();
                command.CommandText = requetetable;
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur lors de la création du lien de contenance : " + e.Message);
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

        public List<string> IdIngredient
        {
            get { return idIngredient; }
            set { idIngredient = value; }
        }
    }
}