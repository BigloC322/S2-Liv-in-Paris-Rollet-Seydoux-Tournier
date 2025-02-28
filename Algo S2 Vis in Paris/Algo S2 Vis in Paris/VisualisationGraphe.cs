using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algo_S2_Vis_in_Paris
{
    internal class VisualisationGraphe
    {
        public void ReprésenterGraphe(int[,] matriceAdj)
        {
            int longueur = 3000;
            int largeur = 3000;
            Bitmap visuel = new Bitmap(longueur, largeur);
            Graphics graphisme = Graphics.FromImage(visuel);

            int sommetCount = matriceAdj.GetLength(0);
            PointF[] positions = new PointF[sommetCount];
            float centerX = largeur / 2;
            float centerY = longueur / 2;
            float radius = 1200;
            float angleStep = 360f / sommetCount;

            for (int i = 0; i < sommetCount; i++)
            {
                float angle = i * angleStep * (float)Math.PI / 180f;
                positions[i] = new PointF(
                    centerX + radius * (float)Math.Cos(angle),
                    centerY + radius * (float)Math.Sin(angle)
                );
            }

            Pen linePen = new Pen(Color.White, 2);
            for (int i = 0; i < sommetCount; i++)
            {
                for (int j = 0; j < sommetCount; j++)
                {
                    if (matriceAdj[i, j] == 1)
                    {
                        graphisme.DrawLine(linePen, positions[i], positions[j]);
                    }
                }
            }

            Brush couleurSommet = Brushes.MediumBlue;
            Brush couleurNombreSommet = Brushes.Black;
            Font font = new Font("Arial", 18);
            float rayonSommet = 30;

            for (int i = 0; i < sommetCount; i++)
            {
                graphisme.FillEllipse(couleurSommet, positions[i].X - rayonSommet, positions[i].Y - rayonSommet, rayonSommet * 2, rayonSommet * 2);

                string label = (i + 1).ToString();
                SizeF labelSize = graphisme.MeasureString(label, font);
                graphisme.DrawString(label, font, couleurNombreSommet, positions[i].X - labelSize.Width / 2, positions[i].Y - labelSize.Height / 2);
            }

            string filePath = "graphe_visuel.png";
            visuel.Save(filePath);
            Console.WriteLine($"\nLe graphe a été enregistré dans le fichier {filePath}");
        }
    }
}