using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Algo_S2_Vis_in_Paris
{
    internal class MétrosGoogleMaps
    {
        public void AfficherMetrosGoogleMaps(List<string> nomsStations, List<decimal[]> coord, int[,] GrapheMetro)
        {
            string apiKey = "AIzaSyA5c_dadBOvCPSoziJsC11SObDlNSqoUJ8";
            string centre = "48.861486,2.334151";
            string zoom = "12";
            string dimension = "640x640";

            string url = $"https://maps.googleapis.com/maps/api/staticmap?center={centre}&zoom={zoom}&size={dimension}&maptype=roadmap&key={apiKey}";

            using (WebClient clientWeb = new WebClient())
            {
                clientWeb.DownloadFile(url, "Carte du métro de Paris.png");
            }

            using (Bitmap bitmapGoogle = new Bitmap("Carte du métro de Paris.png"))
            {
                Bitmap bitmapRedimensioné = new Bitmap(bitmapGoogle, new Size(5000, 5000));

                using (Graphics g = Graphics.FromImage(bitmapRedimensioné))
                {
                    Pen stylo = new Pen(Color.Blue, 6);

                    for (int i = 0; i < GrapheMetro.GetLength(0); i++)
                    {
                        for (int j = 0; j < GrapheMetro.GetLength(1); j++)
                        {
                            if (GrapheMetro[i, j] == 1)
                            {
                                PointF debut = ConvertToPixels(coord[i][0], coord[i][1]);
                                PointF fin = ConvertToPixels(coord[j][0], coord[j][1]);

                                g.DrawLine(stylo, debut.X, debut.Y, fin.X, fin.Y);
                            }
                        }
                    }

                    foreach (var station in nomsStations.Select((nom, indice) => new { nom, indice }))
                    {
                        PointF stationPoint = ConvertToPixels(coord[station.indice][0], coord[station.indice][1]);
                        g.FillEllipse(Brushes.Red, stationPoint.X - 5, stationPoint.Y - 5, 30, 30);

                        Brush pinceau = Brushes.Cyan;
                        int étiquette = 1;
                        SizeF tailleTexte = g.MeasureString(station.nom, new Font("Arial", 20));
                        g.FillRectangle(pinceau, stationPoint.X + 10 - étiquette, stationPoint.Y - 5 - étiquette, tailleTexte.Width + étiquette * 2, tailleTexte.Height + étiquette * 2);
                        g.DrawString(station.nom, new Font("Arial", 17), Brushes.Black, stationPoint.X + 10, stationPoint.Y - 5);
                    }
                }

                bitmapRedimensioné.Save("CARTE METRO PARIS.png");
                Console.WriteLine("L'image de la carte des métros de Paris a été sauvegardée sous le nom 'CARTE METRO PARIS.png'.");
            }
        }

        private PointF ConvertToPixels(decimal latitude, decimal longitude)
        {
            int imageWidth = 5000;
            int imageHeight = 5000;

            decimal minLatitude = 48.815573m;
            decimal maxLatitude = 48.902144m;
            decimal minLongitude = 2.224199m;
            decimal maxLongitude = 2.469920m;

            float x = (float)((double)(longitude - minLongitude) / (double)(maxLongitude - minLongitude) * imageWidth);
            float y = (float)((double)(maxLatitude - latitude) / (double)(maxLatitude - minLatitude) * imageHeight);

            float verticalScaleFactor = 0.6f;
            y *= verticalScaleFactor;

            float horizontalScaleFactor = 1.1f;
            x *= horizontalScaleFactor;

            float translationX = 50;
            float translationY = 1100;

            x += translationX;
            y += translationY;

            Console.WriteLine($"Latitude: {latitude}, Longitude: {longitude} => X: {x}, Y: {y}");

            return new PointF(x, y);
        }
    }
}