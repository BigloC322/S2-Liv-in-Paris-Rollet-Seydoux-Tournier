using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Algo_S2_Vis_in_Paris
{
    internal class Ingredient
    {
        private string iD_Ingrédient;
        private string régime_alimentaire;
        private string ingrédient;

        public Ingredient(string iD_Ingrédient, string régime_alimentaire, string ingrédient)
        {
            this.iD_Ingrédient = iD_Ingrédient;
            this.régime_alimentaire = régime_alimentaire;
            this.ingrédient = ingrédient;
        }

        public void AjouterIngredient(Ingredient test)
        {
            ConnexionSQL a = new ConnexionSQL();
            string requetetable = $"INSERT INTO INGREDIENT VALUES ('{test.ID_Ingrédient}','{test.Régime_alimentaire}','{test.Ingrédient}');";
            try
            {
                MySqlCommand command = a.MaConnexion.CreateCommand();
                command.CommandText = requetetable;
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur lors de la création des ingredients : " + e.Message);
            }
            finally
            {
                a.MaConnexion.Close();
                Console.WriteLine("Connexion fermée.");
            }
        }

        public string ID_Ingrédient
        {
            get { return this.iD_Ingrédient; }
            set { this.iD_Ingrédient = value; }
        }

        public string Régime_alimentaire
        {
            get { return this.régime_alimentaire; }
            set { this.régime_alimentaire = value; }
        }
        public string Ingrédient
        {
            get { return this.ingrédient; }
            set { this.ingrédient = value;
        }
    }
}