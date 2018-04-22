using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
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
        private StringBuilder filePath = new StringBuilder(@"C:\Users\Eva\Desktop\Triangle.NET\triangle.poly"); //  C:\Users\Eva\Desktop\Triangle.NET\triangle.poly   @"C:\Users\Michal\Desktop\triangle.poly"
        private IPolygon input;
        private RenderManager renderManager;
        private MainWindow myGui;

        private System.Drawing.Point[] TVert = new System.Drawing.Point[3];
        private double[] TSide = new double[4];
        private List<double> TContent = new List<double>();
        private double[] Sum_TCenterXS_TCenterYS_S = new double[3];
        private System.Drawing.Point ObjCenter;
        private double[] AverageCenter = new double[2];
        private int TNumber = 0;

        public Graph(MainWindow window)
        {
            myGui = window;
            input = FileProcessor.Read(filePath.ToString());
            IMesh mesh = input.Triangulate();

           // TriangleCentres = new List<System.Drawing.Point>();            
            foreach (Triangle triangle in mesh.Triangles)
            {
                Console.WriteLine("--- Triangle ---");
                Console.WriteLine("Id:" + triangle.ID);
                Console.WriteLine("Area:" + triangle.Area);
                Console.WriteLine("Label:" + triangle.Label);
                Console.WriteLine("Vertex 0: [" + triangle.GetVertex(0).X.ToString() + "; " + triangle.GetVertex(0).Y.ToString() + "]");
                Console.WriteLine("Vertex 1: [" + triangle.GetVertex(1).X.ToString() + "; " + triangle.GetVertex(1).Y.ToString() + "]");
                Console.WriteLine("Vertex 2: [" + triangle.GetVertex(2).X.ToString() + "; " + triangle.GetVertex(2).Y.ToString() + "]");


                //ulozim vrcholy trojuholnika do pola
                for (int i = 0; i < 3; i++)
                {
                    TVert[i].X = Convert.ToInt32(triangle.GetVertex(i).X);
                    TVert[i].Y = Convert.ToInt32(triangle.GetVertex(i).Y);
                }
                //dlzka stran do pola + polovicny obsah (pre heronov vzorec)
                TSide[3] = 0;
                for (int i = 0; i < 3; i++)
                {
                    TSide[i] = Math.Sqrt(Math.Pow((TVert[i].X - TVert[(i + 1) % 3].X), 2) + Math.Pow((TVert[i].Y - TVert[(i + 1) % 3].Y), 2));
                    TSide[3] += TSide[i];
                }
                //ratame obsah - heronov vzorec 
                double TS = 0;
                TS = Math.Sqrt(TSide[3] * (TSide[3] - TSide[0]) * (TSide[3] - TSide[1]) * (TSide[3] - TSide[2]));
                TContent.Add(TS);
                Console.WriteLine("Triangle Content: " + TS.ToString());
                Console.WriteLine("obvod trojuholnika/2: " + TSide[3].ToString());
                Console.WriteLine("Side 0: " + TSide[0].ToString());
                Console.WriteLine("Side 1: " + TSide[1].ToString());
                Console.WriteLine("Side 2: " + TSide[2].ToString());

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
                TNumber++;
                AverageCenter[0] += TC[0];
                AverageCenter[1] += TC[1];
            }
            //suradnice taziska objektu
            double[] ObjCen = new double[2];
            ObjCenter.X = Convert.ToInt32(Sum_TCenterXS_TCenterYS_S[0] / Sum_TCenterXS_TCenterYS_S[2]);
            ObjCenter.Y = Convert.ToInt32(Sum_TCenterXS_TCenterYS_S[1] / Sum_TCenterXS_TCenterYS_S[2]);
            ObjCen[0] = (Sum_TCenterXS_TCenterYS_S[0] / Sum_TCenterXS_TCenterYS_S[2]);
            ObjCen[1] = (Sum_TCenterXS_TCenterYS_S[1] / Sum_TCenterXS_TCenterYS_S[2]);

            AverageCenter[0] = AverageCenter[0] / TNumber;
            AverageCenter[1] = AverageCenter[1] / TNumber;

            Console.WriteLine("--- Object Center ---");
            Console.WriteLine("Object Center Int (weighted average): [" + ObjCenter.X.ToString() + "; " + ObjCenter.Y.ToString() + "]");
            Console.WriteLine("Object Center (weighted average): [" + ObjCen[0].ToString() + "; " + ObjCen[1].ToString() + "]");
            Console.WriteLine("Object Center (average): [" + AverageCenter[0].ToString() + "; " + AverageCenter[1].ToString() + "]");


            renderManager = new RenderManager();

            IRenderControl control = new TriangleNet.Rendering.GDI.RenderControl();

            if (control != null)
            {
                InitializeRenderControl((Control)control);
                renderManager.Initialize(control);
                renderManager.Set(input);
                renderManager.Set(mesh, true);
                control.Refresh();

            }
            else
            {
                MessageBox.Show("Ooops ...", "Failed to initialize renderer.");
            }
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
