using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;
using TriangleDemo.Properties;
using TriangleNet;
using TriangleNet.Geometry;
using TriangleNet.IO;
using TriangleNet.Meshing;
using TriangleNet.Rendering;
using TriangleNet.Topology;

namespace TriangleDemo
{
    class Graph
    {
        public IPolygon input;
        private IMesh mesh;
        private IRenderControl control;
        private RenderManager renderManager;
        private MainWindow myGui;
        public ConstraintOptions Options { get; set; }
        public CsvReader csvReader;

        public Graph(MainWindow window)
        {
            //csvReader = new CsvReader();
            myGui = window;
            renderManager = new RenderManager();
            control = new TriangleNet.Rendering.GDI.RenderControl();
            Options = new ConstraintOptions();
            Options.ConformingDelaunay = false;
            Options.SegmentSplitting = 0;


            if (control != null)
            {
                InitializeRenderControl((Control)control);
                renderManager.Initialize(control);
                control.Refresh();
            }
            else
            {
                MessageBox.Show("Error", "Failed to initialize renderer.");
            }
        }

        //nacitam vstup zo suboru
        public void LoadInputFile(string inputFile)
        {
            csvReader = new CsvReader();
            csvReader.OpenFile(inputFile);
            input = csvReader.Read();            
        }

        //nastavim vstup kniznici a zobrazim
        public void RenderFloorPlan()
        {
            renderManager.Set(input);
            control.Refresh();
        }

        public List<TriangleNet.Geometry.Point> CalculateCoGs()
        {
            if (input == null)
            {
                return null;
            }
            List<TriangleNet.Geometry.Point> CoGs = new List<TriangleNet.Geometry.Point>();
            mesh = input.Triangulate(new ConstraintOptions { ConformingDelaunay = true });
            CoGs.Add(CalculateCenterOfGravity());
            renderManager.SetConformingCoG(CoGs[0]);
            mesh = input.Triangulate(new ConstraintOptions { ConformingDelaunay = false });
            CoGs.Add(CalculateCenterOfGravity());
            renderManager.SetConstrianedCoG(CoGs[1]);
            return CoGs;
        }

        public void RenderTriangles(bool visible)
        {
            if (input == null)
            {
                return;
            }
            mesh = input.Triangulate(Options);
            renderManager.Set(mesh, false);
            renderManager.Enable(1, visible);
            control.Refresh();
        }

        public void RenderConformingCoG(bool visible)
        {
            renderManager.Enable(7, visible);
            control.Refresh();
        }

        public void RenderConstrainedCoG(bool visible)
        {
            renderManager.Enable(8, visible);
            control.Refresh();
        }

        public void Resize()
        {
            control.HandleResize();
            control.Refresh();
        }

        private TriangleNet.Geometry.Point CalculateCenterOfGravity()
        {
            TriangleNet.Geometry.Point[] TVert = new TriangleNet.Geometry.Point[3];
            double[] TSide = new double[4];
            ////List<double> TContent = new List<double>();
            double[] Sum_TCenterXS_TCenterYS_S = new double[3];
            TriangleNet.Geometry.Point ObjCenter = new TriangleNet.Geometry.Point();
            ////double[] AverageCenter = new double[2];
            ////int TNumber = 0;
                                    
            foreach (Triangle triangle in mesh.Triangles)
            {
                //ulozim vrcholy trojuholnika do pola
                for (int i = 0; i < 3; i++)
                {
                    TVert[i] = new TriangleNet.Geometry.Point();
                    TVert[i].X = triangle.GetVertex(i).X;
                    TVert[i].Y = triangle.GetVertex(i).Y;
                }
                //dlzka stran do pola + polovicny obvod (pre heronov vzorec)
                TSide[3] = 0;
                for (int i = 0; i < 3; i++)
                {
                    TSide[i] = Math.Sqrt(Math.Pow((TVert[i].X - TVert[(i + 1) % 3].X), 2) + Math.Pow((TVert[i].Y - TVert[(i + 1) % 3].Y), 2));
                    TSide[3] += TSide[i];
                }
                TSide[3] = TSide[3] / 2;
                //ratame obsah - heronov vzorec 
                double TS = 0;
                TS = Math.Sqrt(TSide[3] * (TSide[3] - TSide[0]) * (TSide[3] - TSide[1]) * (TSide[3] - TSide[2]));
                ////TContent.Add(TS);
                //Console.WriteLine("Triangle Content: " + TS.ToString());
                //Console.WriteLine("obvod trojuholnika/2: " + TSide[3].ToString());
                //Console.WriteLine("Side 0: " + TSide[0].ToString());
                //Console.WriteLine("Side 1: " + TSide[1].ToString());
                //Console.WriteLine("Side 2: " + TSide[2].ToString());

                //ratame tazisko trojuholnika                
                double[] TC = new double[2];
                TC[0] = TVert[0].X + 2 * ((TVert[1].X + (double)(TVert[2].X - TVert[1].X) / 2) - TVert[0].X) / 3;
                TC[1] = TVert[0].Y + 2 * ((TVert[1].Y + (double)(TVert[2].Y - TVert[1].Y) / 2) - TVert[0].Y) / 3;
                Console.WriteLine("Triangle Center: [" + TC[0].ToString() + "; " + TC[1].ToString() + "]");

                //pomocne sumy pre vyratanie celkoveho taziska (weighted average)
                Sum_TCenterXS_TCenterYS_S[0] += TC[0] * TS;
                Sum_TCenterXS_TCenterYS_S[1] += TC[1] * TS;
                Sum_TCenterXS_TCenterYS_S[2] += TS;
                //pomocne vypocty pre vyratanie priemerneho taziska
                ////TNumber++;
                ////AverageCenter[0] += TC[0];
                ////AverageCenter[1] += TC[1];
            }
            //suradnice taziska objektu
            //double[] ObjCen = new double[2];
            ObjCenter.X = Sum_TCenterXS_TCenterYS_S[0] / Sum_TCenterXS_TCenterYS_S[2];
            ObjCenter.Y = Sum_TCenterXS_TCenterYS_S[1] / Sum_TCenterXS_TCenterYS_S[2];
            //ObjCen[0] = (Sum_TCenterXS_TCenterYS_S[0] / Sum_TCenterXS_TCenterYS_S[2]);
            //ObjCen[1] = (Sum_TCenterXS_TCenterYS_S[1] / Sum_TCenterXS_TCenterYS_S[2]);

            ////AverageCenter[0] = AverageCenter[0] / TNumber;
            ////AverageCenter[1] = AverageCenter[1] / TNumber;

            //Console.WriteLine("--- Object Center ---");
            //Console.WriteLine("Object Center Int (weighted average): [" + ObjCenter.X.ToString() + "; " + ObjCenter.Y.ToString() + "]");
            //Console.WriteLine("Object Center (weighted average): [" + ObjCen[0].ToString() + "; " + ObjCen[1].ToString() + "]");
            //Console.WriteLine("Object Center (average): [" + AverageCenter[0].ToString() + "; " + AverageCenter[1].ToString() + "]");

            return new TriangleNet.Geometry.Point(ObjCenter.X, ObjCenter.Y);
        }

        private void InitializeRenderControl(Control control)
        {
            myGui.panel1.Controls.Add(control);

            var size = myGui.panel1.ClientRectangle;

            // Initialize control
            control.BackColor = Color.WhiteSmoke;
            control.Dock = DockStyle.Fill;
            control.Font = new Font("Consolas", 8.25F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            control.Location = new System.Drawing.Point(0, 0);
            control.Name = "renderControl1";
            control.Size = new Size(size.Width, size.Height);
            control.TabIndex = 0;
            control.Text = "renderControl1";
        }
    }
}
