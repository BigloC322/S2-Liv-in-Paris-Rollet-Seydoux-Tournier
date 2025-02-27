using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

namespace Algo_S2_Vis_in_Paris
{
    [TestClass]
    public class UnitTest1
    {
        /// <ExplicationTests>
        /// La première méthode teste si une case de la matrice d'ajdacence contient bien un 1 (qui indique une relation) selon une relation déjà définie dans une liste de relations
        /// On vérifie donc que la relation est bien représentée dans la matrice d'adjacence
        /// 
        /// Pour le test de liste adjacence, on remplit une listeVoulue qui devrait correspondre à ce qui a été défini au-dessus, et on regarde si ce sont les mêmes
        /// 
        /// Pour le test de noeuds, on vérifie que la classe Noeud définit bien qu'il y a 34 sommets comme dans le fichier
        /// <>

        [TestMethod]
        public void TestCréationMatriceAdjacence()
        {
            int membres = 10;
            List<int[]> relations = new List<int[]>();
            int[] rel1 = new int[] { 1, 3 }; 
            int[] rel2 = new int[] { 2, 3 };

            int[,] mat = new int[membres,membres];

            int[,] matAdj = CréationMatriceAdjacence(mat, relations);

            Assert.AreEqual(matAdj[2,3], 1);
        }

        [TestMethod]
        public void TestCréationListeAdj()
        {
            Dictionary<int, List<int>> listeAdjacence = new Dictionary<int, List<int>>();
            List<int[]> relations = new List<int[]>
            {
                new int[] { 1, 2 },
                new int[] { 2, 3 }
            };
            Graphe graphe = new Graphe(new int[3, 3], listeAdjacence, new List<List<int>>());
            var resultat = graphe.CréationListeAdj(relations, listeAdjacence);

            var listeVoulue = new Dictionary<int, List<int>>
            {
                { 1, new List<int> { 2 } },
                { 2, new List<int> { 1, 3 } },
                { 3, new List<int> { 2 } }
            };

            CollectionAssert.AreEqual(listeVoulue[1], resultat[1]);
            CollectionAssert.AreEqual(listeVoulue[2], resultat[2]);
            CollectionAssert.AreEqual(listeVoulue[3], resultat[3]);
        }

        [TestMethod]
        public void NombreSommets()
        {
            List<int> listeSommets = new List<int>;
            Noeud n = new Noeud(listeSommets);
            int nbSommets = listeSommets.Count;

            Assert.AreEqual(nbSommets, 34);
        }
    }
}