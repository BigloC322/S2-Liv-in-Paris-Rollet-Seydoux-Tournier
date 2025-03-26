using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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