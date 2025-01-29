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
            int longueur = 1000;
            int largeur = 1000;
            Bitmap visuel = new Bitmap(longueur, largeur);
            Graphics graphisme = Graphics.FromImage(visuel);

            // Define node positions (in a circular layout)
            int nodeCount = matriceAdj.GetLength(0);
            PointF[] positions = new PointF[nodeCount];
            float centerX = largeur / 2;
            float centerY = longueur / 2;
            float radius = 200; // Distance from center
            float angleStep = 360f / nodeCount;

            for (int i = 0; i < nodeCount; i++)
            {
                float angle = i * angleStep * (float)Math.PI / 180f;
                positions[i] = new PointF(
                    centerX + radius * (float)Math.Cos(angle),
                    centerY + radius * (float)Math.Sin(angle)
                );
            }

            // Draw connections (edges)
            Pen linePen = new Pen(Color.Black, 2);
            for (int i = 0; i < nodeCount; i++)
            {
                for (int j = 0; j < nodeCount; j++)
                {
                    if (matriceAdj[i, j] == 1) // Check for connection
                    {
                        graphisme.DrawLine(linePen, positions[i], positions[j]);
                    }
                }
            }

            // Draw nodes and labels
            Brush nodeBrush = Brushes.Blue;
            Brush textBrush = Brushes.Black;
            Font font = new Font("Arial", 12);
            float nodeRadius = 10;

            for (int i = 0; i < nodeCount; i++)
            {
                // Draw node as a circle
                graphisme.FillEllipse(nodeBrush, positions[i].X - nodeRadius, positions[i].Y - nodeRadius, nodeRadius * 2, nodeRadius * 2);

                // Draw node label
                string label = (i + 1).ToString(); // Node number (1-based index)
                SizeF labelSize = graphisme.MeasureString(label, font);
                graphisme.DrawString(label, font, textBrush, positions[i].X - labelSize.Width / 2, positions[i].Y - labelSize.Height / 2);
            }

            // Save the bitmap to a file
            string filePath = "graph_with_labels.png";
            visuel.Save(filePath);
            Console.WriteLine($"Graph saved to {filePath}");
        }
    }
}