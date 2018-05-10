using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using TriangleNet.Geometry;

namespace TriangleDemo
{
    class CsvReader
    {
        private List<Vertex> Vertexes;
        //private List<ISegment> Segments;
        public IPolygon InputPolygon { get; set; }
        public double ToleranceFactor { get; set; }
        private double TOLERANCE;
        private string[] lines;

        public CsvReader()
        {
            Vertexes = new List<Vertex>();
            //Segments = new List<ISegment>();
            InputPolygon = new Polygon();            
        }

        public void OpenFile(string filePath)
        {
            lines = File.ReadAllLines(filePath);
        }

        public IPolygon Read()
        {
            Vertexes = new List<Vertex>();
            InputPolygon = new Polygon();
            var header = lines[0].Split(',').ToArray();
            var csv = from line in lines.Skip(1)
                      select (line.Split(',').ToArray());

            int nameColumnIndex = Array.IndexOf(header, "Name");
            int startXColumnIndex = Array.IndexOf(header, "Start X");
            int startYColumnIndex = Array.IndexOf(header, "Start Y");
            int endXColumnIndex = Array.IndexOf(header, "End X");
            int endYColumnIndex = Array.IndexOf(header, "End Y");
            int positionXColumnIndex = Array.IndexOf(header, "Position X");
            int positionYColumnIndex = Array.IndexOf(header, "Position Y");

            // nacitam ciary
            IEnumerable<string[]> linesList = csv.Where(o => o[nameColumnIndex] == "Line");
            //vyratam TOLERANCE
            CalculateTolerance(startXColumnIndex, startYColumnIndex, endXColumnIndex, endYColumnIndex, linesList);
            //pridam segmenty polygonu
            foreach (string[] line in linesList)
            {
                double startX = double.Parse(line[startXColumnIndex], CultureInfo.InvariantCulture);
                double startY = double.Parse(line[startYColumnIndex], CultureInfo.InvariantCulture);
                double endX = double.Parse(line[endXColumnIndex], CultureInfo.InvariantCulture);
                double endY = double.Parse(line[endYColumnIndex], CultureInfo.InvariantCulture);

                var segment = new Segment(GetVertex(startX, startY), GetVertex(endX, endY));
                //Segments.Add(segment);
                InputPolygon.Add(segment);
            }
            //pridam diery
            foreach (string[] line in csv.Where(o => o[nameColumnIndex] == "Hole"))
            {
                double X = double.Parse(line[positionXColumnIndex], CultureInfo.InvariantCulture);
                double Y = double.Parse(line[positionYColumnIndex], CultureInfo.InvariantCulture);
                InputPolygon.Holes.Add(new Point(X, Y));
            }
            return InputPolygon;    //mam hotovy polygon
        }

        //metoda na ratanie TOLERANCE - tolerancia bude uzivatelom zadane percento diametra mnoziny bodov
        private void CalculateTolerance(int startXColumnIndex, int startYColumnIndex,
                                                 int endXColumnIndex, int endYColumnIndex, 
                                                 IEnumerable<string[]> linesList)
        {
            List<double> pointsListX = new List<double>();
            pointsListX.AddRange(linesList.Select(o => double.Parse(o[startXColumnIndex], CultureInfo.InvariantCulture)));
            pointsListX.AddRange(linesList.Select(o => double.Parse(o[endXColumnIndex], CultureInfo.InvariantCulture)));
            List<double> pointsListY = new List<double>();
            pointsListY.AddRange(linesList.Select(o => double.Parse(o[startYColumnIndex], CultureInfo.InvariantCulture)));
            pointsListY.AddRange(linesList.Select(o => double.Parse(o[endYColumnIndex], CultureInfo.InvariantCulture)));

            var minX = pointsListX.Min();
            var minY = pointsListY.Min();
            var maxX = pointsListX.Max();
            var maxY = pointsListY.Max();
            double diameter = Math.Sqrt(Math.Pow(maxX - minX, 2) + Math.Pow(maxY - minY, 2));
            TOLERANCE = diameter * ToleranceFactor;
        }

        private Vertex GetVertex(double x, double y)
        {
            //hladanie zhody so zadanym bodom (vramci tolerancie) - predchadza dieram v polygone
            Vertex vertex = Vertexes.FirstOrDefault(o => Math.Abs(o.X - x) < TOLERANCE &&
                                                         Math.Abs(o.Y - y) < TOLERANCE);
            if (vertex == null)
            {
                vertex = new Vertex(x, y);
                Vertexes.Add(vertex);
                InputPolygon.Add(vertex);
            }
            return vertex;
        }
    }
}
