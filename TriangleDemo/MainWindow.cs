using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TriangleDemo
{
    public partial class MainWindow : Form
    {
        Graph graph;
        public MainWindow()
        {
            InitializeComponent();
            graph = new Graph(this);
        }
        
        public void RefreshGraph()
        {
            graph.csvReader.Read();
            graph.RenderFloorPlan();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {   
            //vyberem subor
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                //nacitam a zobrazim subor
    //            SetToleranceFactor();
                graph.LoadInputFile(openFileDialog.FileName);
                graph.RenderFloorPlan();
                //ratam tazisko
                List<TriangleNet.Geometry.Point> points = graph.CalculateCoGs();
                //zapisem do textboxov
                if (points != null)
                {
                    tbConformingCoGX.Text = points[0].X.ToString();
                    tbConformingCoGY.Text = points[0].Y.ToString();
                    tbConstrainedCoGX.Text = points[1].X.ToString();
                    tbConstrainedCoGY.Text = points[1].Y.ToString();
                }
                //napisem do labelu nazov fileu
                labelFileName.Text = openFileDialog.FileName;
                //trianguluj ak je zakliknute
                ConstrainedTriangulate(chbConstrainedTriangulate.Checked);
                ConformingTriangulate(chbConformingTriangulate.Checked);
            }
        }


        private void MainWindow_Resize(object sender, EventArgs e)
        {
            graph.Resize();
        }

        //trianguluj constrained Delaunay
        private void ConstrainedTriangulate(bool visible)
        {
            graph.Options.ConformingDelaunay = false;
            graph.RenderTriangles(visible);
        }

        private void chbConstrainedTriangulate_Clicked(object sender, EventArgs e)
        {
            //klik na checkbox trianguluj constrained Delaunay
            CheckBox checkbox = (CheckBox)sender;
            ConstrainedTriangulate(checkbox.Checked);
            if (checkbox.Checked)
                chbConformingTriangulate.Checked = false;
        }

        private void chbConstrainedCoG_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            graph.RenderConstrainedCoG(checkbox.Checked);
        }

        private void ConformingTriangulate(bool visible)
        {
            graph.Options.ConformingDelaunay = true;
            graph.RenderTriangles(visible);
        }

        private void chbConformingTriangulate_Clicked(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            ConformingTriangulate(checkbox.Checked);
            if (checkbox.Checked)
                chbConstrainedTriangulate.Checked = false;
        }

        private void chbConformingCoG_CheckedChanged(object sender, EventArgs e)
        {
            CheckBox checkbox = (CheckBox)sender;
            graph.RenderConformingCoG(checkbox.Checked);
        }

        private void SetToleranceFactor()
        {
            if (Convert.ToDouble(tbToleranceFactor.Text) >= 0 && Convert.ToDouble(tbToleranceFactor.Text) <= 100)
            {
                graph.csvReader.ToleranceFactor = Convert.ToDouble(tbToleranceFactor.Text) * 0.01;
            }
            else
            {
                graph.csvReader.ToleranceFactor = 0.005;
                tbToleranceFactor.Text = "0.5";
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (graph.csvReader != null)
            {
                SetToleranceFactor();
                graph.input = graph.csvReader.Read();
                graph.RenderFloorPlan();

                ConstrainedTriangulate(chbConstrainedTriangulate.Checked);
                ConformingTriangulate(chbConformingTriangulate.Checked);
            }
        }
                
    }
}
