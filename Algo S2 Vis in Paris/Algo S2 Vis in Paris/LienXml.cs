using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace Algo_S2_Vis_in_Paris
{
    internal class LienXml
    {
        //type = le nom de ta table 
        public static void ExportToXml(string type)
        {
            ConnexionSQL a = new ConnexionSQL();
            try
            {
                string query = $"SELECT * FROM {type};";
                MySqlCommand command = new MySqlCommand(query, a.MaConnexion);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataSet ds = new DataSet();
                adapter.Fill(ds, type);

                ds.WriteXml($"{type}.xml"); 
                Console.WriteLine("Export XML réussi !");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur XML : " + ex.Message);
            }
            finally
            {
                a.MaConnexion.Close();
            }
        }
        public static void ExportToJson(string type)
        {
            ConnexionSQL a = new ConnexionSQL();
            try
            {
                string query = $"SELECT * FROM {type};";
                MySqlCommand command = new MySqlCommand(query, a.MaConnexion);
                MySqlDataAdapter adapter = new MySqlDataAdapter(command);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                string json = JsonConvert.SerializeObject(dt, Formatting.Indented);
                File.WriteAllText($"{type}.json", json);
                Console.WriteLine("Export JSON réussi !");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erreur JSON : " + ex.Message);
            }
            finally
            {
                a.MaConnexion.Close();
            }
        }


    }
}
