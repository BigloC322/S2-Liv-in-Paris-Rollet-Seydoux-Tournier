using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_S2_Vis_in_Paris
{
    internal class Ingredient
    {
        private string iD_Ingrédient;
        private string régime_alimentaire;

        public Ingredient(string iD_Ingrédient, string régime_alimentaire)
        {
            this.iD_Ingrédient = iD_Ingrédient;
            this.régime_alimentaire = régime_alimentaire;
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
    }
}