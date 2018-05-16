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
        public IPolygon InputPolygon { get; set; }
        public double ToleranceFactor { get; set; }
        private double TOLERANCE;
        private string[] lines;

        public CsvReader()
        {
            Vertexes = new List<Vertex>();
            InputPolygon = new Polygon();
            ToleranceFactor = 0.005;
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
            //indexy pre ciary
            int startXColumnIndex = Array.IndexOf(header, "Start X");
            int startYColumnIndex = Array.IndexOf(header, "Start Y");
            int endXColumnIndex = Array.IndexOf(header, "End X");
            int endYColumnIndex = Array.IndexOf(header, "End Y");
            //indexy pre obluky
            int centerXColumnIndex = Array.IndexOf(header, "Center X");
            int centerYColumnIndex = Array.IndexOf(header, "Center Y");
            int radiusColumnIndex = Array.IndexOf(header, "Radius");
            int startAngleColumnIndex = Array.IndexOf(header, "Start Angle");
            int totalAngleColumnIndex = Array.IndexOf(header, "Total Angle");
            //indexy pre diery
            int positionXColumnIndex = Array.IndexOf(header, "Position X");
            int positionYColumnIndex = Array.IndexOf(header, "Position Y");
                       

            // nacitam ciary
            IEnumerable<string[]> linesList = csv.Where(o => o[nameColumnIndex] == "Line");
                        
            foreach (string[] line in linesList)
            {
                double startX = double.Parse(line[startXColumnIndex], CultureInfo.InvariantCulture);
                double startY = double.Parse(line[startYColumnIndex], CultureInfo.InvariantCulture);
                double endX = double.Parse(line[endXColumnIndex], CultureInfo.InvariantCulture);
                double endY = double.Parse(line[endYColumnIndex], CultureInfo.InvariantCulture);

                var segment = new Segment(GetVertex(startX, startY), GetVertex(endX, endY));
                InputPolygon.Add(segment);
            }
            
            //vyratam TOLERANCE
            CalculateTolerance(startXColumnIndex, startYColumnIndex, endXColumnIndex, endYColumnIndex, linesList);

            //nacitam obluky
            foreach (string[] line in csv.Where(o => o[nameColumnIndex] == "Arc"))
            {
                
                double X = double.Parse(line[centerXColumnIndex], CultureInfo.InvariantCulture);
                double Y = double.Parse(line[centerYColumnIndex], CultureInfo.InvariantCulture);
                double radius = double.Parse(line[radiusColumnIndex], CultureInfo.InvariantCulture);
                double startAngle = double.Parse(line[startAngleColumnIndex], CultureInfo.InvariantCulture);
                double totalAngle = double.Parse(line[totalAngleColumnIndex], CultureInfo.InvariantCulture);
                //double endAngle = (startAngle + totalAngle) % 360;
                double step = 10 / radius;

                Vertex vertex = GetVertex(X + radius * Math.Cos(D2Rad(startAngle)), Y + radius * Math.Sin(D2Rad(startAngle)));
                Vertex endVertex;
                for (double angle = startAngle + step; angle < (startAngle + totalAngle); angle += step)
                {
                    endVertex = GetVertex(X + radius * Math.Cos(D2Rad(angle)), Y + radius * Math.Sin(D2Rad(angle)));
                    Segment segment = new Segment(vertex, endVertex);
                    InputPolygon.Add(segment);
                    vertex = endVertex;
                }
                endVertex = GetVertex(X + radius * Math.Cos(D2Rad(startAngle + totalAngle)), Y + radius * Math.Sin(D2Rad(startAngle + totalAngle)));
                InputPolygon.Add(new Segment(vertex, endVertex));

            }

            //nacitam diery
            foreach (string[] line in csv.Where(o => o[nameColumnIndex] == "Hole"))
            {
                double X = double.Parse(line[positionXColumnIndex], CultureInfo.InvariantCulture);
                double Y = double.Parse(line[positionYColumnIndex], CultureInfo.InvariantCulture);
                InputPolygon.Holes.Add(new Point(X, Y));
            }

            return InputPolygon;    //mam hotovy polygon
        }

        private double D2Rad(double degrees)
        {
            return (Math.PI / 180) * degrees;
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
