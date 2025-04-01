using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace Algo_S2_Vis_in_Paris
{
    internal class Avis
    {
        private string idAvis;
        private int note;
        private string commentaire;
        private string idCommande;
        private string idParticulier;

        public Avis(string idAvis, int note, string commentaire, string idCommande, string idParticulier)
        {
            this.idAvis = idAvis;
            this.note = note;
            this.commentaire = commentaire;
            this.idCommande = idCommande;
            this.idParticulier = idParticulier;
        }

        public void AjouterAvis(Avis test)
        {
            ConnexionSQL a = new ConnexionSQL();
            string requetetable = $"INSERT INTO AVIS VALUES ('{test.IdAvis}','{test.Note}','{test.Commentaire}','{test.IdCommande}','{test.IdParticulier}');";
            try
            {
                MySqlCommand command = a.MaConnexion.CreateCommand();
                command.CommandText = requetetable;
                command.ExecuteNonQuery();
            }
            catch (MySqlException e)
            {
                Console.WriteLine("Erreur lors de la création de l'avis : " + e.Message);
            }
            finally
            {
                a.MaConnexion.Close();
                Console.WriteLine("Connexion fermée.");
            }
        }

        public string IdAvis
        {
            get { return idAvis; }
            set { idAvis = value; }
        }

        public int Note
        {
            get { return note; }
            set { note = value; }
        }

        public string Commentaire
        {
            get { return commentaire; }
            set { commentaire = value; }
        }

        public string IdCommande
        {
            get { return idCommande; }
            set { idCommande = value; }
        }

        public string IdParticulier
        {
            get { return idParticulier; }
            set { idParticulier = value; }
        }
    }
}